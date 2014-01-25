namespace RPCServices
{
    using System;

    public class ConnectionService : ServiceDescriptor
    {
        public const uint BIND_METHOD_ID = 2;
        public const uint CONNECT_METHOD_ID = 1;
        public const uint CONNECTION_SERVICE_ID = 0;
        public const uint ECHO_METHOD_ID = 3;
        public const uint ENCRYPT_METHOD_ID = 6;
        public const uint FORCE_DISCONNECT_METHOD_ID = 4;
        public const uint KEEP_ALIVE_METHOD_ID = 5;
        public const uint REQUEST_DISCONNECT_METHOD_ID = 7;

        public ConnectionService() : base("bnet.protocol.connection.ConnectionService")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.connection.ConnectionService.Connect", 1, true), new MethodDescriptor("bnet.protocol.connection.ConnectionService.Bind", 2, true), new MethodDescriptor("bnet.protocol.connection.ConnectionService.Echo", 3, true), new MethodDescriptor("bnet.protocol.connection.ConnectionService.ForceDisconnect", 4, false), new MethodDescriptor("bnet.protocol.connection.ConnectionService.KeepAlive", 5, false), new MethodDescriptor("bnet.protocol.connection.ConnectionService.Encrypt", 6, true), new MethodDescriptor("bnet.protocol.connection.ConnectionService.RequestDisconnect", 7, false) };
        }
    }
}

