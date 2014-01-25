using System;

public class MethodDescriptor
{
    private bool hasReturnData;
    private uint id;
    private RPCContextDelegate listener;
    private string name;

    public MethodDescriptor(string n, uint i, bool b)
    {
        this.name = n;
        this.id = i;
        this.hasReturnData = b;
    }

    public bool HasListener()
    {
        return (this.listener != null);
    }

    public void NotifyListener(RPCContext context)
    {
        if (this.listener != null)
        {
            this.listener(context);
        }
    }

    public void RegisterListener(RPCContextDelegate d)
    {
        this.listener = d;
    }

    public bool HasReturnData
    {
        get
        {
            return this.hasReturnData;
        }
    }

    public uint Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }
}

