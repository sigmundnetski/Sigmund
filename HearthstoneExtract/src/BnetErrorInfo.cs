using System;

public class BnetErrorInfo
{
    private BnetError m_error;
    private BnetFeature m_feature;
    private BnetFeatureEvent m_featureEvent;
    private string m_name;

    public static BnetErrorInfo CreateFromDll(BattleNet.DllErrorInfo src)
    {
        return new BnetErrorInfo { m_feature = (BnetFeature) src.feature, m_featureEvent = (BnetFeatureEvent) src.featureEvent, m_error = (BnetError) src.code, m_name = DLLUtils.StringFromNativeUtf8(src.name) };
    }

    public uint GetCode()
    {
        return (uint) this.m_error;
    }

    public BnetError GetError()
    {
        return this.m_error;
    }

    public BnetFeature GetFeature()
    {
        return this.m_feature;
    }

    public BnetFeatureEvent GetFeatureEvent()
    {
        return this.m_featureEvent;
    }

    public string GetName()
    {
        return this.m_name;
    }

    public void SetCode(uint code)
    {
        this.m_error = (BnetError) code;
    }

    public void SetError(BnetError error)
    {
        this.m_error = error;
    }

    public void SetFeature(BnetFeature feature)
    {
        this.m_feature = feature;
    }

    public void SetFeatureEvent(BnetFeatureEvent featureEvent)
    {
        this.m_featureEvent = featureEvent;
    }

    public void SetName(string name)
    {
        this.m_name = name;
    }

    public override string ToString()
    {
        if (Enum.IsDefined(typeof(BnetError), this.m_error))
        {
            return string.Format("[event={0} error={1}]", this.m_featureEvent, this.m_error);
        }
        return string.Format("[event={0} code={1} name={2}]", this.m_featureEvent, this.m_error, this.m_name);
    }
}

