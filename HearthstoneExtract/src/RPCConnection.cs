using bnet.protocol;
using Google.ProtocolBuffers;
using RPCServices;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class RPCConnection : IConnectionListener<BattleNetPacket>
{
    private ClientConnection<BattleNetPacket> Connection;
    private string host = string.Empty;
    private Queue<BattleNetPacket> incomingPackets = new Queue<BattleNetPacket>();
    private static uint nextToken;
    private Queue<BattleNetPacket> outBoundPackets = new Queue<BattleNetPacket>();
    private int port;
    private ServiceCollectionHelper serviceHelper = new ServiceCollectionHelper();
    private object tokenLock = new object();
    private string userName = string.Empty;
    private Dictionary<uint, RPCContext> waitingForResponse = new Dictionary<uint, RPCContext>();

    public RPCConnection(string u, string h, int p)
    {
        this.userName = u;
        this.host = h;
        this.port = p;
    }

    public void Connect()
    {
        this.Connection = new ClientConnection<BattleNetPacket>();
        this.Connection.AddListener(this, null);
        this.Connection.Connect(this.host, this.port);
    }

    protected bnet.protocol.Header CreateHeader(uint serviceId, uint methodId, uint token, uint size)
    {
        bnet.protocol.Header.Builder builder = bnet.protocol.Header.CreateBuilder();
        builder.SetServiceId(serviceId);
        builder.SetMethodId(methodId);
        builder.SetToken(token);
        builder.SetSize(size);
        return builder.BuildPartial();
    }

    public void Disconnect()
    {
        this.Connection.Disconnect();
    }

    private ServiceDescriptor GetListenerServiceDescriptor(uint serviceId)
    {
        return this.serviceHelper.GetListenerServiceById(serviceId);
    }

    public uint GetListenerServiceNameHash(uint serviceId)
    {
        ServiceDescriptor listenerServiceDescriptor = this.GetListenerServiceDescriptor(serviceId);
        if (listenerServiceDescriptor != null)
        {
            return listenerServiceDescriptor.Hash;
        }
        return uint.MaxValue;
    }

    private ServiceDescriptor GetServiceDescriptor(uint serviceId)
    {
        return this.serviceHelper.GetServiceById(serviceId);
    }

    public uint GetServiceNameHash(uint serviceId)
    {
        ServiceDescriptor serviceDescriptor = this.GetServiceDescriptor(serviceId);
        if (serviceDescriptor != null)
        {
            return serviceDescriptor.Hash;
        }
        return uint.MaxValue;
    }

    public void PacketReceived(BattleNetPacket p, object state)
    {
        Queue<BattleNetPacket> incomingPackets = this.incomingPackets;
        lock (incomingPackets)
        {
            this.incomingPackets.Enqueue(p);
        }
    }

    private void PrintHeader(bnet.protocol.Header h)
    {
    }

    protected void QueuePacket(BattleNetPacket packet)
    {
        Queue<BattleNetPacket> outBoundPackets = this.outBoundPackets;
        lock (outBoundPackets)
        {
            this.outBoundPackets.Enqueue(packet);
        }
    }

    public RPCContext QueueRequest(uint serviceId, uint methodId, IMessageLite message, RPCContextDelegate callback = new RPCContextDelegate())
    {
        uint nextToken;
        if (message == null)
        {
            return null;
        }
        object tokenLock = this.tokenLock;
        lock (tokenLock)
        {
            nextToken = RPCConnection.nextToken;
            RPCConnection.nextToken++;
        }
        RPCContext context = new RPCContext {
            Callback = callback
        };
        ServiceDescriptor serviceDescriptor = this.GetServiceDescriptor(serviceId);
        if ((serviceDescriptor != null) && serviceDescriptor.MethodHasReturnData(methodId))
        {
            this.waitingForResponse.Add(nextToken, context);
        }
        bnet.protocol.Header h = this.CreateHeader(serviceId, methodId, nextToken, (uint) message.SerializedSize);
        BattleNetPacket packet = new BattleNetPacket(h, message);
        context.Header = h;
        this.QueuePacket(packet);
        return context;
    }

    public void QueueResponse(RPCContext context, IMessageLite message)
    {
        if (message != null)
        {
            bnet.protocol.Header.Builder builder = bnet.protocol.Header.CreateBuilder().MergeFrom(context.Header);
            builder.SetServiceId(0xfe);
            builder.SetMethodId(0);
            builder.SetSize((uint) message.SerializedSize);
            context.Header = builder.BuildPartial();
            BattleNetPacket packet = new BattleNetPacket(context.Header, message);
            this.QueuePacket(packet);
        }
    }

    public void RegisterServiceMethodListener(uint serviceId, uint methodId, RPCContextDelegate callback)
    {
        ServiceDescriptor listenerServiceDescriptor = this.GetListenerServiceDescriptor(serviceId);
        if (listenerServiceDescriptor != null)
        {
            listenerServiceDescriptor.RegisterMethodListener(methodId, callback);
        }
    }

    public void Update()
    {
        if (this.Connection != null)
        {
            this.Connection.Update();
        }
        if (this.incomingPackets.Count > 0)
        {
            Queue<BattleNetPacket> queue;
            Queue<BattleNetPacket> incomingPackets = this.incomingPackets;
            lock (incomingPackets)
            {
                queue = new Queue<BattleNetPacket>(this.incomingPackets.ToArray());
                this.incomingPackets.Clear();
            }
            while (queue.Count > 0)
            {
                BattleNetPacket packet = queue.Dequeue();
                bnet.protocol.Header h = packet.GetHeader();
                this.PrintHeader(h);
                byte[] body = (byte[]) packet.GetBody();
                if (h.ServiceId == 0xfe)
                {
                    RPCContext context;
                    if (h.HasToken && this.waitingForResponse.TryGetValue(h.Token, out context))
                    {
                        context.Header = h;
                        context.Payload = body;
                        context.ResponseReceived = true;
                        if (context.Callback != null)
                        {
                            context.Callback(context);
                        }
                        this.waitingForResponse.Remove(h.Token);
                    }
                }
                else
                {
                    ServiceDescriptor listenerServiceDescriptor = this.GetListenerServiceDescriptor(h.ServiceId);
                    if (listenerServiceDescriptor != null)
                    {
                        if (listenerServiceDescriptor.HasMethodListener(h.MethodId))
                        {
                            RPCContext context2 = new RPCContext {
                                Header = h,
                                Payload = body,
                                ResponseReceived = true
                            };
                            listenerServiceDescriptor.NotifyMethodListener(context2);
                        }
                        else
                        {
                            Debug.LogError(string.Concat(new object[] { "[!]Unhandled Server Request Received (Service id:", h.ServiceId, " Method id:", h.MethodId, ")" }));
                        }
                        continue;
                    }
                    Debug.LogError(string.Concat(new object[] { "[!]Server Requested an Unsupported (Service id:", h.ServiceId, " Method id:", h.MethodId, ")" }));
                }
            }
        }
        if (this.outBoundPackets.Count > 0)
        {
            Queue<BattleNetPacket> queue3;
            Queue<BattleNetPacket> outBoundPackets = this.outBoundPackets;
            lock (outBoundPackets)
            {
                queue3 = new Queue<BattleNetPacket>(this.outBoundPackets.ToArray());
                this.outBoundPackets.Clear();
            }
            while (queue3.Count > 0)
            {
                BattleNetPacket packet2 = queue3.Dequeue();
                if (this.Connection != null)
                {
                    this.Connection.QueuePacket(packet2);
                    this.PrintHeader(packet2.GetHeader());
                }
                else
                {
                    Debug.LogError("##Client Connection object does not exists!##");
                    this.PrintHeader(packet2.GetHeader());
                }
            }
        }
    }

    public string Host
    {
        get
        {
            return this.host;
        }
    }

    public int Port
    {
        get
        {
            return this.port;
        }
    }

    public string UserName
    {
        get
        {
            return this.userName;
        }
    }
}

