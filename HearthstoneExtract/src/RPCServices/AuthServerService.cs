namespace RPCServices
{
    using System;

    public class AuthServerService : ServiceDescriptor
    {
        public const uint AUTH_SERVER_SERVICE_ID = 1;
        public const uint GEN_TEMP_COOKIE_METHOD_ID = 5;
        public const uint LOGON_METHOD_ID = 1;
        public const uint MODULE_MESSAGE_METHOD_ID = 3;
        public const uint MODULE_NOTIFY_METHOD_ID = 2;
        public const uint SELECT_GAME_ACCT_METHOD_ID = 4;

        public AuthServerService() : base("bnet.protocol.authentication.AuthenticationServer")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.authentication.AuthenticationServer.Logon", 1, true), new MethodDescriptor("bnet.protocol.authentication.AuthenticationServer.ModuleNotify", 2, true), new MethodDescriptor("bnet.protocol.authentication.AuthenticationServer.ModuleMessage", 3, true), new MethodDescriptor("bnet.protocol.authentication.AuthenticationServer.SelectGameAccount", 4, true), new MethodDescriptor("bnet.protocol.authentication.AuthenticationServer.GenerateTempCookie", 5, true) };
        }
    }
}

