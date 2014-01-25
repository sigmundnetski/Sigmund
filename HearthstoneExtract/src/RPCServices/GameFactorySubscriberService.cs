namespace RPCServices
{
    using System;

    public class GameFactorySubscriberService : ServiceDescriptor
    {
        public const uint GAME_FACTORY_SUB_SERVICE_ID = 7;
        public const uint NOTIFY_GAME_FOUND_ID = 1;

        public GameFactorySubscriberService() : base("bnet.protocol.game_master.GameFactorySubscriber")
        {
            base.Methods = new MethodDescriptor[] { new MethodDescriptor("bnet.protocol.game_master.GameFactorySubscriber.NotifyGameFound", 1, false) };
        }
    }
}

