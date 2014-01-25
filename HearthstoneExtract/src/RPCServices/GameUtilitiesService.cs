namespace RPCServices
{
    using System;

    public class GameUtilitiesService : ServiceDescriptor
    {
        public const uint GAME_UTILITY_SERVICE_ID = 9;
        public const uint GET_LOAD_ID = 5;
        public const uint GET_PLAYER_VARIABLES_ID = 3;
        public const uint NOTIFY_GAME_ACCT_OFFLINE_ID = 8;
        public const uint NOTIFY_GAME_ACCT_ONLINE_ID = 7;
        public const uint PRESENCE_CHANNEL_CREATED_ID = 2;
        public const uint PROCESS_CLIENT_REQUEST_ID = 1;
        public const uint PROCESS_SERVER_REQUEST_ID = 6;

        public GameUtilitiesService() : base("bnet.protocol.game_utilities.GameUtilities")
        {
            base.Methods = new MethodDescriptor[8];
            base.Methods[0] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.ProcessClientRequest", 1, true);
            base.Methods[1] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.PresenceChannelCreated", 2, true);
            base.Methods[2] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.GetPlayerVariables", 3, true);
            base.Methods[4] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.GetLoad", 5, true);
            base.Methods[5] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.ProcessServerRequest", 6, true);
            base.Methods[6] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.NotifyGameAccountOnline", 7, false);
            base.Methods[7] = new MethodDescriptor("bnet.protocol.game_utilities.GameUtilities.NotifyGameAccountOffline", 8, false);
        }
    }
}

