using System;
using System.Collections.Generic;
using System.Reflection;

public class QueueList<T>
{
    private List<T> m_list;

    public QueueList()
    {
        this.m_list = new List<T>();
    }

    public void Clear()
    {
        this.m_list.Clear();
    }

    public bool Contains(T item)
    {
        return this.m_list.Contains(item);
    }

    public T Dequeue()
    {
        T local = this.m_list[0];
        this.m_list.RemoveAt(0);
        return local;
    }

    public int Enqueue(T item)
    {
        int count = this.m_list.Count;
        this.m_list.Add(item);
        return count;
    }

    public int GetCount()
    {
        return this.m_list.Count;
    }

    public T GetItem(int index)
    {
        return this.m_list[index];
    }

    public List<T> GetList()
    {
        return this.m_list;
    }

    public T Peek()
    {
        return this.m_list[0];
    }

    public T RemoveAt(int position)
    {
        if (this.m_list.Count <= position)
        {
            return default(T);
        }
        T local = this.m_list[position];
        this.m_list.RemoveAt(position);
        return local;
    }

    public int Count
    {
        get
        {
            return this.m_list.Count;
        }
    }

    public T this[int index]
    {
        get
        {
            return this.m_list[index];
        }
        set
        {
            this.m_list[index] = value;
        }
    }
}

