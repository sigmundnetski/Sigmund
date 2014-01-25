using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class DebugConsoleBroadcaster
{
    private byte[] m_buffer = new byte[0x400];
    private byte[] m_responseBytes;
    private Socket m_socket;

    public void BeginListening(int port, string broadCastResponse)
    {
        this.m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        this.m_responseBytes = new ASCIIEncoding().GetBytes(broadCastResponse);
        IPEndPoint localEP = new IPEndPoint(IPAddress.Any, port);
        try
        {
            this.m_socket.Bind(localEP);
        }
        catch (SocketException exception)
        {
            Debug.LogWarning("SocketException (" + exception + "), creating DebugConsoleBroadcaster.  Client Remote will not be available (this likely occurred because you had multiple game instances running on your computer).");
        }
        EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
        this.m_socket.BeginReceiveFrom(this.m_buffer, 0, this.m_buffer.Length, SocketFlags.None, ref remoteEP, new AsyncCallback(DebugConsoleBroadcaster.OnBroadcast), this);
    }

    private static void OnBroadcast(IAsyncResult ar)
    {
        DebugConsoleBroadcaster asyncState = (DebugConsoleBroadcaster) ar.AsyncState;
        Socket socket = asyncState.m_socket;
        byte[] buffer = asyncState.m_buffer;
        byte[] responseBytes = asyncState.m_responseBytes;
        if ((socket != null) && socket.Connected)
        {
            try
            {
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
                socket.EndReceiveFrom(ar, ref endPoint);
                Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket2.Connect(endPoint);
                socket2.Send(responseBytes, 0, responseBytes.Length, SocketFlags.None);
                EndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref remoteEP, new AsyncCallback(DebugConsoleBroadcaster.OnBroadcast), asyncState);
            }
            catch (Exception exception)
            {
                Debug.LogError("error receiving debug broadcast: " + exception.Message);
            }
        }
    }

    private static void OnBroadcastSent(IAsyncResult ar)
    {
        Socket asyncState = (Socket) ar.AsyncState;
        try
        {
            asyncState.EndSendTo(ar);
            asyncState.Close(1);
        }
        catch (SocketException exception)
        {
            Debug.LogError(string.Concat(new object[] { "socket exception sending broadcast: ", exception.SocketErrorCode, " ", exception.Message }));
        }
        catch (Exception exception2)
        {
            Debug.LogError(string.Concat(new object[] { "error sending debug broadcast: ", exception2.GetType(), " ", exception2.Message }));
        }
    }

    public void StopListening()
    {
        if (this.m_socket != null)
        {
            this.m_socket.Close();
        }
    }
}

