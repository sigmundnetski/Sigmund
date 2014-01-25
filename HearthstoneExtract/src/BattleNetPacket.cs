using bnet.protocol;
using Google.ProtocolBuffers;
using System;

public class BattleNetPacket : PacketFormat
{
    private object body;
    private int bodySize;
    private bnet.protocol.Header header;
    private int headerSize;

    public BattleNetPacket()
    {
        this.headerSize = -1;
        this.bodySize = -1;
        this.header = null;
        this.body = null;
    }

    public BattleNetPacket(bnet.protocol.Header h, IMessageLite b)
    {
        this.headerSize = -1;
        this.bodySize = -1;
        this.header = h;
        this.body = b;
    }

    public override int Decode(byte[] bytes, int offset, int available)
    {
        int num = 0;
        if (this.headerSize < 0)
        {
            if (available < 2)
            {
                return num;
            }
            this.headerSize = (bytes[offset] << 8) + bytes[offset + 1];
            available -= 2;
            num += 2;
            offset += 2;
        }
        if (this.header == null)
        {
            if (available < this.headerSize)
            {
                return num;
            }
            CodedInputStream input = CodedInputStream.CreateInstance(bytes, offset, this.headerSize);
            this.header = bnet.protocol.Header.CreateBuilder().MergeFrom(input).BuildPartial();
            this.bodySize = !this.header.HasSize ? 0 : ((int) this.header.Size);
            if (this.header == null)
            {
                throw new Exception("failed to parse BattleNet packet header");
            }
            available -= this.headerSize;
            num += this.headerSize;
            offset += this.headerSize;
        }
        if (this.body != null)
        {
            return num;
        }
        if (available < this.bodySize)
        {
            return num;
        }
        byte[] destinationArray = new byte[this.bodySize];
        Array.Copy(bytes, offset, destinationArray, 0, this.bodySize);
        this.body = destinationArray;
        return (num + this.bodySize);
    }

    public override byte[] Encode()
    {
        if (!(this.body is IMessageLite))
        {
            return null;
        }
        IMessageLite body = (IMessageLite) this.body;
        int serializedSize = this.header.SerializedSize;
        int length = body.SerializedSize;
        byte[] flatArray = new byte[(2 + serializedSize) + length];
        flatArray[0] = (byte) ((serializedSize >> 8) & 0xff);
        flatArray[1] = (byte) (serializedSize & 0xff);
        this.header.WriteTo(CodedOutputStream.CreateInstance(flatArray, 2, serializedSize));
        body.WriteTo(CodedOutputStream.CreateInstance(flatArray, 2 + serializedSize, length));
        return flatArray;
    }

    public object GetBody()
    {
        return this.body;
    }

    public bnet.protocol.Header GetHeader()
    {
        return this.header;
    }

    public override bool IsLoaded()
    {
        return ((this.header != null) && (this.body != null));
    }
}

