namespace RPCServices
{
    using System;
    using System.Collections.Generic;

    public sealed class ServiceCollectionHelper
    {
        private Dictionary<uint, ServiceDescriptor> allListeners = new Dictionary<uint, ServiceDescriptor>();
        private Dictionary<uint, ServiceDescriptor> allServices = new Dictionary<uint, ServiceDescriptor>();

        public ServiceCollectionHelper()
        {
            ConnectionService service = new ConnectionService();
            this.allServices.Add(0, service);
            this.allServices.Add(1, new AuthServerService());
            this.allServices.Add(9, new GameUtilitiesService());
            this.allServices.Add(8, new GameMasterService());
            this.allServices.Add(10, new NotificationService());
            this.allServices.Add(4, new PresenceService());
            this.allServices.Add(3, new ChannelService());
            this.allListeners.Add(0, service);
            this.allListeners.Add(2, new AuthClientService());
            this.allListeners.Add(4, new GameMasterSubscriberService());
            this.allListeners.Add(7, new GameFactorySubscriberService());
            this.allListeners.Add(5, new NotificationListenerService());
            this.allListeners.Add(6, new ChannelSubscriberService());
        }

        public ServiceDescriptor GetListenerServiceById(uint service_id)
        {
            ServiceDescriptor descriptor;
            this.allListeners.TryGetValue(service_id, out descriptor);
            return descriptor;
        }

        public ServiceDescriptor GetServiceById(uint service_id)
        {
            ServiceDescriptor descriptor;
            this.allServices.TryGetValue(service_id, out descriptor);
            return descriptor;
        }
    }
}

