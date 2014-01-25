using System;

public class ServiceDescriptor
{
    private uint hash;
    private int id;
    protected MethodDescriptor[] Methods;
    private string name;

    public ServiceDescriptor(string n)
    {
        this.name = n;
        this.id = -1;
        this.hash = Compute32.Hash(this.name);
        Console.WriteLine(string.Concat(new object[] { "service: ", n, ", hash: ", this.hash }));
    }

    public bool HasMethodListener(uint method_id)
    {
        return ((((this.Methods != null) && (method_id > 0)) && (method_id <= this.Methods.Length)) && this.Methods[(int) ((IntPtr) (method_id - 1))].HasListener());
    }

    public bool MethodHasReturnData(uint method_id)
    {
        return ((((this.Methods != null) && (method_id > 0)) && (method_id <= this.Methods.Length)) && this.Methods[(int) ((IntPtr) (method_id - 1))].HasReturnData);
    }

    public void NotifyMethodListener(RPCContext context)
    {
        if (((this.Methods != null) && (context.Header.MethodId > 0)) && (context.Header.MethodId <= this.Methods.Length))
        {
            this.Methods[(int) ((IntPtr) (context.Header.MethodId - 1))].NotifyListener(context);
        }
    }

    public void RegisterMethodListener(uint method_id, RPCContextDelegate callback)
    {
        if (((this.Methods != null) && (method_id > 0)) && (method_id <= this.Methods.Length))
        {
            this.Methods[(int) ((IntPtr) (method_id - 1))].RegisterListener(callback);
        }
    }

    public uint Hash
    {
        get
        {
            return this.hash;
        }
    }

    public int Id
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

