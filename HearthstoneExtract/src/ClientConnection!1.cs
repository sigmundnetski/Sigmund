using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ClientConnection<PacketType> where PacketType: PacketFormat, new()
{
    private static int BACKING_BUFFER_SIZE;
    private byte[] m_backingBuffer;
    private int m_backingBufferBytes;
    private ConnectionState<PacketType> m_connectionState;
    private PacketType m_currentPacket;
    private string m_hostAddress;
    private int m_hostPort;
    private List<IConnectionListener<PacketType>> m_listeners;
    private List<object> m_listenerStates;
    private Queue<PacketType> m_outQueue;
    private byte[] m_receiveBuffer;
    private AsyncCallback m_receiveCallback;
    private AsyncCallback m_sendCallback;
    private Socket m_socket;
    private bool m_stolenSocket;
    private static int RECEIVE_BUFFER_SIZE;

    static ClientConnection()
    {
        ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE = 0x10000;
        ClientConnection<PacketType>.BACKING_BUFFER_SIZE = 0x40000;
    }

    public ClientConnection()
    {
        this.m_outQueue = new Queue<PacketType>();
        this.m_listeners = new List<IConnectionListener<PacketType>>();
        this.m_listenerStates = new List<object>();
        this.m_receiveCallback = new AsyncCallback(ClientConnection<PacketType>.ReceiveCallback);
        this.m_sendCallback = new AsyncCallback(ClientConnection<PacketType>.SendCallback);
        this.m_connectionState = ConnectionState<PacketType>.Disconnected;
        this.m_receiveBuffer = new byte[ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE];
        this.m_backingBuffer = new byte[ClientConnection<PacketType>.BACKING_BUFFER_SIZE];
        this.m_stolenSocket = false;
    }

    public ClientConnection(Socket socket)
    {
        this.m_outQueue = new Queue<PacketType>();
        this.m_listeners = new List<IConnectionListener<PacketType>>();
        this.m_listenerStates = new List<object>();
        this.m_receiveCallback = new AsyncCallback(ClientConnection<PacketType>.ReceiveCallback);
        this.m_sendCallback = new AsyncCallback(ClientConnection<PacketType>.SendCallback);
        this.m_socket = socket;
        this.m_connectionState = ConnectionState<PacketType>.Connected;
        this.m_receiveBuffer = new byte[ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE];
        this.m_stolenSocket = true;
        this.m_hostAddress = "local";
        this.m_hostPort = 0;
    }

    public void AddListener(IConnectionListener<PacketType> listener, object state)
    {
        this.m_listeners.Add(listener);
        this.m_listenerStates.Add(state);
    }

    private void BytesReceived(int nBytes)
    {
        if (this.m_backingBufferBytes > 0)
        {
            if ((nBytes + this.m_backingBufferBytes) > ClientConnection<PacketType>.BACKING_BUFFER_SIZE)
            {
                Debug.LogError("backing buffer out of room");
            }
            else
            {
                int num = this.m_backingBufferBytes + nBytes;
                Array.Copy(this.m_receiveBuffer, 0, this.m_backingBuffer, this.m_backingBufferBytes, nBytes);
                this.m_backingBufferBytes = 0;
                this.BytesReceived(this.m_backingBuffer, num, 0);
            }
        }
        else
        {
            this.BytesReceived(this.m_receiveBuffer, nBytes, 0);
        }
    }

    private void BytesReceived(byte[] bytes, int nBytes, int offset)
    {
        while (nBytes > 0)
        {
            if (this.m_currentPacket == null)
            {
                this.m_currentPacket = Activator.CreateInstance<PacketType>();
            }
            int num = this.m_currentPacket.Decode(bytes, offset, nBytes);
            nBytes -= num;
            offset += num;
            if (this.m_currentPacket.IsLoaded())
            {
                for (int i = 0; i < this.m_listeners.Count; i++)
                {
                    IConnectionListener<PacketType> listener = this.m_listeners[i];
                    object state = this.m_listenerStates[i];
                    listener.PacketReceived(this.m_currentPacket, state);
                }
                this.m_currentPacket = null;
            }
            else
            {
                Array.Copy(bytes, offset, this.m_backingBuffer, 0, nBytes);
                this.m_backingBufferBytes = nBytes;
                return;
            }
        }
        this.m_backingBufferBytes = 0;
    }

    public void Connect(string host, int port)
    {
        this.m_hostAddress = host;
        this.m_hostPort = port;
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(host), port);
        if (this.m_socket != null)
        {
            this.Disconnect();
        }
        this.m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.m_connectionState = ConnectionState<PacketType>.Connecting;
        try
        {
            this.m_socket.BeginConnect(remoteEP, new AsyncCallback(ClientConnection<PacketType>.ConnectCallback), this);
        }
        catch (Exception exception)
        {
            Debug.LogWarning("Could not connect to " + this.HostAddress + " -- " + exception.Message);
            this.m_connectionState = ConnectionState<PacketType>.ConnectionFailed;
        }
    }

    private static void ConnectCallback(IAsyncResult ar)
    {
        ClientConnection<PacketType> asyncState = (ClientConnection<PacketType>) ar.AsyncState;
        Socket socket = asyncState.m_socket;
        byte[] receiveBuffer = asyncState.m_receiveBuffer;
        try
        {
            socket.EndConnect(ar);
            socket.BeginReceive(receiveBuffer, 0, ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE, SocketFlags.None, asyncState.m_receiveCallback, asyncState);
        }
        catch (Exception exception)
        {
            asyncState.m_connectionState = ConnectionState<PacketType>.ConnectionFailed;
            socket.Close();
            Debug.LogWarning("Failed to connect to " + asyncState.HostAddress + " -- " + exception.Message);
            return;
        }
        asyncState.m_connectionState = !socket.Connected ? ConnectionState<PacketType>.ConnectionFailed : ConnectionState<PacketType>.Connected;
    }

    public void Disconnect()
    {
        if (this.m_socket != null)
        {
            this.m_socket.Close();
        }
        this.m_connectionState = ConnectionState<PacketType>.Disconnected;
    }

    ~ClientConnection()
    {
        if (this.m_socket != null)
        {
            this.Disconnect();
        }
    }

    public void QueuePacket(PacketType packet)
    {
        this.m_outQueue.Enqueue(packet);
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        ClientConnection<PacketType> asyncState = (ClientConnection<PacketType>) ar.AsyncState;
        Socket socket = asyncState.m_socket;
        if (asyncState.Active)
        {
            try
            {
                int nBytes = socket.EndReceive(ar);
                if (nBytes == 0)
                {
                    asyncState.Disconnect();
                }
                else
                {
                    byte[] receiveBuffer = asyncState.m_receiveBuffer;
                    asyncState.BytesReceived(nBytes);
                    socket.BeginReceive(receiveBuffer, 0, ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE, SocketFlags.None, asyncState.m_receiveCallback, asyncState);
                }
            }
            catch (Exception exception)
            {
                Debug.LogError("error receiving from " + asyncState.HostAddress + " -- " + exception.Message);
                asyncState.Disconnect();
            }
        }
    }

    public void RemoveListener(IConnectionListener<PacketType> listener)
    {
        while (this.m_listeners.Remove(listener))
        {
        }
    }

    public void SendBytes(byte[] bytes)
    {
        if (bytes.Length > 0)
        {
            this.m_socket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, this.m_sendCallback, this);
        }
    }

    private static void SendCallback(IAsyncResult ar)
    {
        ClientConnection<PacketType> asyncState = (ClientConnection<PacketType>) ar.AsyncState;
        Socket socket = asyncState.m_socket;
        try
        {
            socket.EndSend(ar);
        }
        catch (Exception exception)
        {
            asyncState.Disconnect();
            Debug.LogError("error sending to " + asyncState.HostAddress + " -- " + exception.Message);
        }
    }

    public void SendPacket(PacketType packet)
    {
        byte[] bytes = packet.Encode();
        this.SendBytes(bytes);
    }

    public void SendString(string str)
    {
        byte[] bytes = new ASCIIEncoding().GetBytes(str);
        this.SendBytes(bytes);
    }

    public void StartReceiving()
    {
        if (!this.m_stolenSocket)
        {
            Debug.LogError("StartReceiving should only be called on sockets created with ClientConnection(Socket)");
        }
        else
        {
            try
            {
                this.m_socket.BeginReceive(this.m_receiveBuffer, 0, ClientConnection<PacketType>.RECEIVE_BUFFER_SIZE, SocketFlags.None, this.m_receiveCallback, this);
            }
            catch (Exception exception)
            {
                Debug.LogError("error receiving from local connection: " + exception.Message);
            }
        }
    }

    public void Update()
    {
        if ((this.m_socket != null) && (this.m_connectionState == ConnectionState<PacketType>.Connected))
        {
            while (this.m_outQueue.Count > 0)
            {
                PacketType packet = this.m_outQueue.Dequeue();
                this.SendPacket(packet);
            }
        }
    }

    public bool Active
    {
        get
        {
            return this.m_socket.Connected;
        }
    }

    public string HostAddress
    {
        get
        {
            return (this.m_hostAddress + ":" + this.m_hostPort);
        }
    }

    public ConnectionState<PacketType> State
    {
        get
        {
            return this.m_connectionState;
        }
    }

    public enum ConnectionState
    {
        public const ClientConnection<PacketType>.ConnectionState Connected = ClientConnection<PacketType>.ConnectionState.Connected;,
        public const ClientConnection<PacketType>.ConnectionState Connecting = ClientConnection<PacketType>.ConnectionState.Connecting;,
        public const ClientConnection<PacketType>.ConnectionState ConnectionFailed = ClientConnection<PacketType>.ConnectionState.ConnectionFailed;,
        public const ClientConnection<PacketType>.ConnectionState Disconnected = ClientConnection<PacketType>.ConnectionState.Disconnected;
    }
}

