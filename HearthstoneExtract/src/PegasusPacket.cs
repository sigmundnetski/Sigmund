using Google.ProtocolBuffers;
using System;

public class PegasusPacket : PacketFormat
{
    public object Body;
    public int Size;
    private const int SIZE_BYTES = 4;
    private bool sizeRead;
    public int Type;
    private const int TYPE_BYTES = 4;
    private bool typeRead;

    public PegasusPacket()
    {
    }

    public PegasusPacket(int type, object body)
    {
        this.Type = type;
        this.Size = -1;
        this.Body = body;
    }

    public PegasusPacket(int type, int size, object body)
    {
        this.Type = type;
        this.Size = size;
        this.Body = body;
    }

    public override int Decode(byte[] bytes, int offset, int available)
    {
        string str = string.Empty;
        for (int i = 0; (i < 8) && (i < available); i++)
        {
            str = str + bytes[offset + i] + " ";
        }
        int num2 = 0;
        if (!this.typeRead)
        {
            if (available < 4)
            {
                return num2;
            }
            this.Type = BitConverter.ToInt32(bytes, offset);
            this.typeRead = true;
            available -= 4;
            num2 += 4;
            offset += 4;
        }
        if (!this.sizeRead)
        {
            if (available < 4)
            {
                return num2;
            }
            this.Size = BitConverter.ToInt32(bytes, offset);
            this.sizeRead = true;
            available -= 4;
            num2 += 4;
            offset += 4;
        }
        if (this.Body != null)
        {
            return num2;
        }
        if (available < this.Size)
        {
            return num2;
        }
        byte[] destinationArray = new byte[this.Size];
        Array.Copy(bytes, offset, destinationArray, 0, this.Size);
        this.Body = destinationArray;
        return (num2 + this.Size);
    }

    public override byte[] Encode()
    {
        if (!(this.Body is IMessageLite))
        {
            return null;
        }
        IMessageLite body = (IMessageLite) this.Body;
        this.Size = body.SerializedSize;
        byte[] destinationArray = new byte[8 + this.Size];
        Array.Copy(BitConverter.GetBytes(this.Type), 0, destinationArray, 0, 4);
        Array.Copy(BitConverter.GetBytes(this.Size), 0, destinationArray, 4, 4);
        body.WriteTo(CodedOutputStream.CreateInstance(destinationArray, 8, this.Size));
        return destinationArray;
    }

    public object GetBody()
    {
        return this.Body;
    }

    public override bool IsLoaded()
    {
        return (this.Body != null);
    }
}

