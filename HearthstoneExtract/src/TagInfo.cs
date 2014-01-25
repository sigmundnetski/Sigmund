using System;

public class TagInfo
{
    private string m_name;
    private int m_tag = 0;
    private TAG_TYPE m_type;

    public string GetName()
    {
        return this.m_name;
    }

    public int GetTag()
    {
        return this.m_tag;
    }

    public TAG_TYPE GetTagType()
    {
        return this.m_type;
    }

    public bool IsDictionaryString()
    {
        return ((this.m_type == TAG_TYPE.ENTITY_DEFINITION) || (this.m_type == TAG_TYPE.STRING));
    }

    public void SetName(string name)
    {
        this.m_name = name;
    }

    public void SetTag(int tag)
    {
        this.m_tag = tag;
    }

    public void SetTagType(TAG_TYPE type)
    {
        this.m_type = type;
    }

    public override string ToString()
    {
        return string.Format("[name={2} tag={0} type={1}]", this.m_tag, this.m_type, this.m_name);
    }
}

