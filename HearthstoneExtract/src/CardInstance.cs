using System;

public class CardInstance
{
    private long m_acquiredTimestamp;
    private long m_instanceId;
    private bool m_premium;
    private bool m_seenBefore;

    public long GetAcquiredTimestamp()
    {
        return this.m_acquiredTimestamp;
    }

    public long GetInstanceId()
    {
        return this.m_instanceId;
    }

    public bool HasBeenSeenBefore()
    {
        return this.m_seenBefore;
    }

    public bool HasPremium()
    {
        return this.m_premium;
    }

    public void SetAcquiredTimestamp(long timestamp)
    {
        this.m_acquiredTimestamp = timestamp;
    }

    public void SetHasBeenSeenBefore(bool seenBefore)
    {
        this.m_seenBefore = seenBefore;
    }

    public void SetInstanceId(long instanceId)
    {
        this.m_instanceId = instanceId;
    }

    public void SetPremium(bool enable)
    {
        this.m_premium = enable;
    }
}

