using System;

public class ZoneChange
{
    private int m_destinationControllerId;
    private int m_destinationPos;
    private Zone m_destinationZone;
    private TAG_ZONE m_destinationZoneTag;
    private Entity m_entity;
    private ZoneChangeList m_parentList;
    private PowerTask m_powerTask;
    private int m_sourcePos;
    private Zone m_sourceZone;
    private TAG_ZONE m_sourceZoneTag;

    public int GetDestinationControllerId()
    {
        return this.m_destinationControllerId;
    }

    public int GetDestinationPosition()
    {
        return this.m_destinationPos;
    }

    public Zone GetDestinationZone()
    {
        return this.m_destinationZone;
    }

    public TAG_ZONE GetDestinationZoneTag()
    {
        return this.m_destinationZoneTag;
    }

    public Entity GetEntity()
    {
        return this.m_entity;
    }

    public ZoneChangeList GetParentList()
    {
        return this.m_parentList;
    }

    public PowerTask GetPowerTask()
    {
        return this.m_powerTask;
    }

    public int GetSourcePosition()
    {
        return this.m_sourcePos;
    }

    public Zone GetSourceZone()
    {
        return this.m_sourceZone;
    }

    public TAG_ZONE GetSourceZoneTag()
    {
        return this.m_sourceZoneTag;
    }

    public void SetDestinationControllerId(int controllerId)
    {
        this.m_destinationControllerId = controllerId;
    }

    public void SetDestinationPosition(int pos)
    {
        this.m_destinationPos = pos;
    }

    public void SetDestinationZone(Zone zone)
    {
        this.m_destinationZone = zone;
    }

    public void SetDestinationZoneTag(TAG_ZONE tag)
    {
        this.m_destinationZoneTag = tag;
    }

    public void SetEntity(Entity entity)
    {
        this.m_entity = entity;
    }

    public void SetParentList(ZoneChangeList parentList)
    {
        this.m_parentList = parentList;
    }

    public void SetPowerTask(PowerTask powerTask)
    {
        this.m_powerTask = powerTask;
    }

    public void SetSourcePosition(int pos)
    {
        this.m_sourcePos = pos;
    }

    public void SetSourceZone(Zone zone)
    {
        this.m_sourceZone = zone;
    }

    public void SetSourceZoneTag(TAG_ZONE tag)
    {
        this.m_sourceZoneTag = tag;
    }

    public override string ToString()
    {
        object[] args = new object[] { (this.m_powerTask != null) ? this.m_powerTask.GetPower().Type.ToString() : "(null)", this.m_entity, this.m_sourceZoneTag, this.m_sourcePos, this.m_destinationZoneTag, this.m_destinationPos };
        return string.Format("[power={0} entity={1} srcZoneTag={2} srcPos={3} dstZoneTag={4} dstPos={5}]", args);
    }
}

