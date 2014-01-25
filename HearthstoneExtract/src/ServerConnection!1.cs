using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class ServerConnection<PacketType> where PacketType: PacketFormat, new()
{
    private ClientConnection<PacketType> m_currentConnection;
    private bool m_listening;
    private object m_lock;
    private int m_port;
    private Socket m_socket;

    public ServerConnection()
    {
        this.m_lock = new object();
    }

    public void Disconnect()
    {
        if ((this.m_socket != null) && this.m_socket.Connected)
        {
            this.m_socket.Shutdown(SocketShutdown.Both);
            this.m_socket.Close();
        }
    }

    ~ServerConnection()
    {
        this.Disconnect();
    }

    public ClientConnection<PacketType> GetNextAcceptedConnection()
    {
        if (this.m_currentConnection != null)
        {
            ClientConnection<PacketType> currentConnection = this.m_currentConnection;
            this.m_currentConnection = null;
            return currentConnection;
        }
        this.Listen();
        return null;
    }

    public bool Listen()
    {
        object @lock = this.m_lock;
        lock (@lock)
        {
            if (this.m_listening)
            {
                return true;
            }
            this.m_listening = true;
        }
        if (this.m_socket == null)
        {
            return false;
        }
        try
        {
            this.m_socket.BeginAccept(new AsyncCallback(ServerConnection<PacketType>.OnAccept), this);
        }
        catch (Exception exception)
        {
            object obj3 = this.m_lock;
            lock (obj3)
            {
                this.m_listening = false;
            }
            Debug.LogError("error listening for incoming connections: " + exception.Message);
            this.m_socket = null;
            return false;
        }
        return true;
    }

    private static void OnAccept(IAsyncResult ar)
    {
        ServerConnection<PacketType> asyncState = (ServerConnection<PacketType>) ar.AsyncState;
        if ((asyncState != null) && (asyncState.m_socket != null))
        {
            try
            {
                Socket socket = asyncState.m_socket.EndAccept(ar);
                asyncState.m_currentConnection = new ClientConnection<PacketType>(socket);
            }
            catch (Exception exception)
            {
                Debug.LogError("error accepting connection: " + exception.Message);
            }
            asyncState.m_listening = false;
        }
    }

    public bool Open(int port)
    {
        if (this.m_socket != null)
        {
            return false;
        }
        IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
        try
        {
            this.m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.m_socket.Bind(localEP);
            this.m_socket.Listen(0x10);
        }
        catch (Exception exception)
        {
            Debug.LogWarning("SeverConnection: error opening inbound connection: " + exception.Message + " (this probably occurred because you have multiple game instances running)");
            this.m_socket = null;
            return false;
        }
        return this.Listen();
    }
}

