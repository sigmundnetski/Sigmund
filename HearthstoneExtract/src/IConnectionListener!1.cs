using System;

public interface IConnectionListener<PacketType> where PacketType: PacketFormat
{
    void PacketReceived(PacketType p, object state);
}

