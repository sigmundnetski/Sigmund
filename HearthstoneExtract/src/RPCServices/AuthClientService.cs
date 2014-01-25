namespace RPCServices
{
    using System;

    public class AuthClientService : ServiceDescriptor
    {
        public const uint ACCOUNT_SETTINGS_METHOD_ID = 3;
        public const uint AUTH_CLIENT_SERVICE_ID = 2;
        public const uint LOGON_COMPLETE_METHOD_ID = 5;
        public const uint LOGON_UPDATE_METHOD_ID = 10;
        public const uint MEM_MODULE_LOAD_METHOD_ID = 6;
        public const uint MODULE_LOAD_METHOD_ID = 1;
        public const uint MODULE_MESSAGE_METHOD_ID = 2;
        public const uint SERVER_STATE_CHANGE_METHOD_ID = 4;

        public AuthClientService() : base("bnet.protocol.authentication.AuthenticationClient")
        {
            base.Methods = new MethodDescriptor[10];
            base.Methods[0] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.ModuleLoad", 1, false);
            base.Methods[1] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.ModuleMessage", 2, true);
            base.Methods[2] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.AccountSettings", 3, false);
            base.Methods[3] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.ServerStateChange", 4, false);
            base.Methods[4] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.LogonComplete", 5, false);
            base.Methods[5] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.MemModuleLoad", 6, true);
            base.Methods[9] = new MethodDescriptor("bnet.protocol.authentication.AuthenticationClient.LogonUpdate", 10, false);
        }
    }
}

