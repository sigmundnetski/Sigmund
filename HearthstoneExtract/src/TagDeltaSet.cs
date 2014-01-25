using System;
using System.Collections.Generic;
using System.Reflection;

public class TagDeltaSet
{
    private List<TagDelta> m_deltas = new List<TagDelta>();

    public void Add<TagEnum>(GAME_TAG tag, TagEnum prev, TagEnum curr)
    {
        TagDelta item = new TagDelta {
            tag = (int) tag,
            oldValue = Convert.ToInt32(prev),
            newValue = Convert.ToInt32(curr)
        };
        this.m_deltas.Add(item);
    }

    public void Add(int tag, int prev, int curr)
    {
        TagDelta item = new TagDelta {
            tag = tag,
            oldValue = prev,
            newValue = curr
        };
        this.m_deltas.Add(item);
    }

    public List<TagDelta> GetList()
    {
        return this.m_deltas;
    }

    public int NewValue(int index)
    {
        return this.m_deltas[index].newValue;
    }

    public int OldValue(int index)
    {
        return this.m_deltas[index].oldValue;
    }

    public int Size()
    {
        return this.m_deltas.Count;
    }

    public void Sort(Comparison<TagDelta> compFunc)
    {
        this.m_deltas.Sort(compFunc);
    }

    public int Tag(int index)
    {
        return this.m_deltas[index].tag;
    }

    public TagDelta this[int index]
    {
        get
        {
            return this.m_deltas[index];
        }
    }
}

