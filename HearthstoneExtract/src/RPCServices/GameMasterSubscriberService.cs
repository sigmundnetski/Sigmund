namespace RPCServices
{
    using System;

    public class GameMasterSubscriberService : ServiceDescriptor
    {
        public const uint GAME_MASTER_SUB_SERVICE_ID = 4;
        public const uint NOTIFY_FACTORY_UPDATE_ID = 1;

        public GameMasterSubscriberService() : base("bnet.protocol.game_master.GameMasterSubscriber")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.game_master.GameMasterSubscriber.NotifyFactoryUpdate", 1, false) };
        }
    }
}

