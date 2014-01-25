using bnet.protocol;
using System;

public class RPCContext
{
    private RPCContextDelegate callback;
    private bnet.protocol.Header header;
    private byte[] payload;
    private bool responseReceived;

    public RPCContextDelegate Callback
    {
        get
        {
            return this.callback;
        }
        set
        {
            this.callback = value;
        }
    }

    public bnet.protocol.Header Header
    {
        get
        {
            return this.header;
        }
        set
        {
            this.header = value;
        }
    }

    public byte[] Payload
    {
        get
        {
            return this.payload;
        }
        set
        {
            this.payload = value;
        }
    }

    public bool ResponseReceived
    {
        get
        {
            return this.responseReceived;
        }
        set
        {
            this.responseReceived = value;
        }
    }
}

