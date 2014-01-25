using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Pool<T>
{
    public const int DEFAULT_EXTENSION_COUNT = 5;
    public const int DEFAULT_MAX_RELEASED_ITEM_COUNT = 5;
    private List<T> m_activeList;
    private CreateItemCallback<T> m_createItemCallback;
    private DestroyItemCallback<T> m_destroyItemCallback;
    private int m_extensionCount;
    private List<T> m_freeList;
    private int m_maxReleasedItemCount;

    public Pool()
    {
        this.m_freeList = new List<T>();
        this.m_activeList = new List<T>();
        this.m_extensionCount = 5;
        this.m_maxReleasedItemCount = 5;
    }

    public T Acquire()
    {
        if (this.m_freeList.Count == 0)
        {
            if (this.m_extensionCount == 0)
            {
                return default(T);
            }
            if (!this.AddFreeItems(this.m_extensionCount))
            {
                return default(T);
            }
        }
        int index = this.m_freeList.Count - 1;
        T item = this.m_freeList[index];
        this.m_freeList.RemoveAt(index);
        this.m_activeList.Add(item);
        return item;
    }

    public List<T> AcquireBatch(int count)
    {
        List<T> list = new List<T>();
        for (int i = 0; i < count; i++)
        {
            T item = this.Acquire();
            list.Add(item);
        }
        return list;
    }

    public bool AddFreeItems(int count)
    {
        if (this.m_createItemCallback == null)
        {
            return false;
        }
        for (int i = 0; i < count; i++)
        {
            int freeListIndex = (this.m_activeList.Count + this.m_freeList.Count) + 1;
            T item = this.m_createItemCallback(freeListIndex);
            this.m_freeList.Add(item);
        }
        return true;
    }

    public void Clear()
    {
        if (this.m_destroyItemCallback == null)
        {
            this.m_activeList.Clear();
            this.m_freeList.Clear();
        }
        else
        {
            for (int i = 0; i < this.m_activeList.Count; i++)
            {
                this.m_destroyItemCallback(this.m_activeList[i]);
            }
            this.m_activeList.Clear();
            for (int j = 0; j < this.m_freeList.Count; j++)
            {
                this.m_destroyItemCallback(this.m_freeList[j]);
            }
            this.m_freeList.Clear();
        }
    }

    public List<T> GetActiveList()
    {
        return this.m_activeList;
    }

    public CreateItemCallback<T> GetCreateItemCallback()
    {
        return this.m_createItemCallback;
    }

    public DestroyItemCallback<T> GetDestroyItemCallback()
    {
        return this.m_destroyItemCallback;
    }

    public int GetExtensionCount()
    {
        return this.m_extensionCount;
    }

    public List<T> GetFreeList()
    {
        return this.m_freeList;
    }

    public int GetMaxReleasedItemCount()
    {
        return this.m_maxReleasedItemCount;
    }

    public bool Release(T item)
    {
        if (!this.m_activeList.Remove(item))
        {
            return false;
        }
        if (this.m_freeList.Count < this.m_maxReleasedItemCount)
        {
            this.m_freeList.Add(item);
            return true;
        }
        if (this.m_destroyItemCallback != null)
        {
            return false;
        }
        this.m_destroyItemCallback(item);
        return true;
    }

    public bool ReleaseAll()
    {
        return this.ReleaseBatch(0, this.m_activeList.Count);
    }

    public bool ReleaseBatch(int activeListStart, int count)
    {
        if (count > 0)
        {
            if (activeListStart >= this.m_activeList.Count)
            {
                return false;
            }
            int num = this.m_activeList.Count - activeListStart;
            if (count > num)
            {
                count = num;
            }
            int num2 = count;
            int num3 = this.m_maxReleasedItemCount - this.m_freeList.Count;
            if (num2 > num3)
            {
                num2 = num3;
            }
            if (num2 > 0)
            {
                List<T> range = this.m_activeList.GetRange(activeListStart, num2);
                this.m_activeList.RemoveRange(activeListStart, num2);
                this.m_freeList.AddRange(range);
            }
            int num4 = count - num2;
            if (num4 > 0)
            {
                if (this.m_destroyItemCallback == null)
                {
                    return false;
                }
                for (int i = 0; i < num4; i++)
                {
                    T item = this.m_activeList[activeListStart];
                    this.m_activeList.RemoveAt(activeListStart);
                    this.m_destroyItemCallback(item);
                }
            }
        }
        return true;
    }

    public void SetCreateItemCallback(CreateItemCallback<T> callback)
    {
        this.m_createItemCallback = callback;
    }

    public void SetDestroyItemCallback(DestroyItemCallback<T> callback)
    {
        this.m_destroyItemCallback = callback;
    }

    public void SetExtensionCount(int count)
    {
        this.m_extensionCount = count;
    }

    public void SetMaxReleasedItemCount(int count)
    {
        this.m_maxReleasedItemCount = count;
    }

    public delegate T CreateItemCallback(int freeListIndex);

    public delegate void DestroyItemCallback(T item);
}

