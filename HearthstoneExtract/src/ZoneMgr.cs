using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class ZoneMgr : MonoBehaviour
{
    private List<ZoneChangeList> m_activeLocalChangeLists = new List<ZoneChangeList>();
    private ZoneChangeList m_activeServerChangeList;
    private QueueList<ZoneChangeList> m_localChangeListHistory = new QueueList<ZoneChangeList>();
    private int m_nextChangeListId = 1;
    private Queue<ZoneChangeList> m_pendingServerChangeLists = new Queue<ZoneChangeList>();
    private Dictionary<int, Entity> m_tempEntityMap = new Dictionary<int, Entity>();
    private List<Zone> m_zones = new List<Zone>();
    private static ZoneMgr s_instance;

    public void AddLocalZoneChange(Card triggerCard, TAG_ZONE zoneTag)
    {
        Entity entity = triggerCard.GetEntity();
        Zone destinationZone = this.FindZoneForEntityAndZoneTag(entity, zoneTag);
        this.AddLocalZoneChange(triggerCard, destinationZone, zoneTag, entity.GetZonePosition(), null, null);
    }

    public void AddLocalZoneChange(Card triggerCard, Zone destinationZone, int destinationPos)
    {
        if (destinationZone == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.AddLocalZoneChange() - illegal zone change to null zone for card {0}", triggerCard));
        }
        else
        {
            this.AddLocalZoneChange(triggerCard, destinationZone, destinationZone.m_ServerTag, destinationPos, null, null);
        }
    }

    public void AddLocalZoneChange(Card triggerCard, Zone destinationZone, int destinationPos, ChangeCompleteCallback callback, object userData)
    {
        if (destinationZone == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.AddLocalZoneChange() - illegal zone change to null zone for card {0}", triggerCard));
        }
        else
        {
            this.AddLocalZoneChange(triggerCard, destinationZone, destinationZone.m_ServerTag, destinationPos, callback, userData);
        }
    }

    public void AddLocalZoneChange(Card triggerCard, Zone destinationZone, TAG_ZONE destinationZoneTag, int destinationPos, ChangeCompleteCallback callback, object userData)
    {
        if (destinationZoneTag == TAG_ZONE.NONE)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.AddLocalZoneChange() - illegal zone change to {0} for card {1}", destinationZoneTag, triggerCard));
        }
        else
        {
            if (destinationZone != null)
            {
                List<Card> cards = destinationZone.GetCards();
                if (destinationPos <= 0)
                {
                    UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.AddLocalZoneChange() - destinationPos {0} is too small for zone {1}. Minimum is 1.", destinationPos, destinationZone));
                    return;
                }
                if (destinationPos > (cards.Count + 1))
                {
                    UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.AddLocalZoneChange() - destinationPos {0} is too large for zone {1}. Maximum is {2}.", destinationPos, destinationZone, Mathf.Max(cards.Count, 1)));
                    return;
                }
            }
            Entity triggerEntity = triggerCard.GetEntity();
            Zone sourceZone = triggerCard.GetZone();
            TAG_ZONE zone = triggerEntity.GetZone();
            int zonePosition = triggerEntity.GetZonePosition();
            if ((zone == destinationZoneTag) && (zonePosition == destinationPos))
            {
                if (callback != null)
                {
                    callback(userData);
                }
            }
            else
            {
                ZoneChangeList changeList = new ZoneChangeList();
                changeList.SetCompleteCallback(callback);
                changeList.SetCompleteCallbackUserData(userData);
                if (zone == destinationZoneTag)
                {
                    if (zonePosition != destinationPos)
                    {
                        this.CreateLocalZonePositionChanges(changeList, triggerEntity, sourceZone, zonePosition, destinationPos);
                    }
                }
                else
                {
                    this.CreateLocalZoneChanges(changeList, triggerEntity, sourceZone, zone, destinationZone, destinationZoneTag, zonePosition, destinationPos);
                }
                this.m_activeLocalChangeLists.Add(changeList);
                base.StartCoroutine(changeList.ProcessChanges());
                this.m_localChangeListHistory.Enqueue(changeList);
            }
        }
    }

    public bool AddServerZoneChanges(PowerTaskList taskList, int taskStartIndex, int taskEndIndex, ChangeCompleteCallback callback, object userData)
    {
        int nextChangeListId = this.GetNextChangeListId();
        ZoneChangeList parentList = new ZoneChangeList();
        parentList.SetId(nextChangeListId);
        parentList.SetTaskList(taskList);
        parentList.SetCompleteCallback(callback);
        parentList.SetCompleteCallbackUserData(userData);
        object[] args = new object[] { taskList.GetId(), nextChangeListId, taskStartIndex, taskEndIndex };
        Log.Zone.Print("ZoneMgr.AddServerZoneChanges() - taskListId={0} changeListId={1} taskStart={2} taskEnd={3}", args);
        List<PowerTask> list2 = taskList.GetTaskList();
        for (int i = taskStartIndex; i <= taskEndIndex; i++)
        {
            PowerTask powerTask = list2[i];
            Network.PowerHistory power = powerTask.GetPower();
            Network.PowerHistory.PowType type = power.Type;
            ZoneChange change = null;
            switch (type)
            {
                case Network.PowerHistory.PowType.FULL_ENTITY:
                    change = this.CreateZoneChangeFromFullEntity(power as Network.HistFullEntity);
                    break;

                case Network.PowerHistory.PowType.SHOW_ENTITY:
                    change = this.CreateZoneChangeFromShowEntity(power as Network.HistShowEntity);
                    break;

                case Network.PowerHistory.PowType.HIDE_ENTITY:
                    change = this.CreateZoneChangeFromHideEntity(power as Network.HistHideEntity);
                    break;

                case Network.PowerHistory.PowType.TAG_CHANGE:
                    change = this.CreateZoneChangeFromTagChange(power as Network.HistTagChange);
                    break;

                case Network.PowerHistory.PowType.META_DATA:
                {
                    continue;
                }
                default:
                    UnityEngine.Debug.LogError(string.Format("ZoneMgr.AddServerZoneChanges() - id={0} received unhandled power of type {1}", parentList.GetId(), power.Type));
                    break;
            }
            if (change != null)
            {
                change.SetParentList(parentList);
                change.SetPowerTask(powerTask);
                parentList.AddChange(change);
            }
        }
        this.m_tempEntityMap.Clear();
        if (this.PostProcessServerChangeList(parentList))
        {
            return false;
        }
        this.m_pendingServerChangeLists.Enqueue(parentList);
        return true;
    }

    private void Awake()
    {
        s_instance = this;
        foreach (Zone zone in base.gameObject.GetComponentsInChildren<Zone>())
        {
            this.m_zones.Add(zone);
        }
    }

    private int ComputeClientCardCountForZone(Zone sourceZone)
    {
        int count = sourceZone.GetCards().Count;
        foreach (ZoneChangeList list in this.m_pendingServerChangeLists)
        {
            Entity entity = null;
            foreach (ZoneChange change in list.GetChanges())
            {
                if (change.GetDestinationZone() == sourceZone)
                {
                    entity = change.GetEntity();
                }
                int destinationPosition = change.GetDestinationPosition();
                if ((entity != null) && (destinationPosition != 0))
                {
                    if (destinationPosition > count)
                    {
                        count = destinationPosition;
                    }
                    entity = null;
                }
            }
        }
        return count;
    }

    private Dictionary<Zone, int> ComputeLocalZoneCardCounts(ZoneChangeList localChangeList)
    {
        Dictionary<Zone, int> dictionary = new Dictionary<Zone, int>();
        foreach (ZoneChange change in localChangeList.GetChanges())
        {
            Zone sourceZone = change.GetSourceZone();
            if ((sourceZone != null) && !dictionary.ContainsKey(sourceZone))
            {
                dictionary[sourceZone] = this.ComputeClientCardCountForZone(sourceZone);
            }
            Zone destinationZone = change.GetDestinationZone();
            if ((destinationZone != null) && !dictionary.ContainsKey(destinationZone))
            {
                dictionary[destinationZone] = this.ComputeClientCardCountForZone(destinationZone);
            }
        }
        return dictionary;
    }

    private void CreateLocalZoneChanges(ZoneChangeList changeList, Entity triggerEntity, Zone sourceZone, TAG_ZONE sourceZoneTag, Zone destinationZone, TAG_ZONE destinationZoneTag, int sourcePos, int destinationPos)
    {
        object[] args = new object[] { triggerEntity, sourceZoneTag, sourcePos, destinationZoneTag, destinationPos };
        Log.Zone.Print(string.Format("ZoneMgr.CreateLocalZoneChanges() - triggerEntity={0} srcZone={1} srcPos={2} dstZone={3} dstPos={4}", args));
        ZoneChange change = new ZoneChange();
        change.SetParentList(changeList);
        change.SetEntity(triggerEntity);
        change.SetSourceZone(sourceZone);
        change.SetSourceZoneTag(sourceZoneTag);
        change.SetSourcePosition(sourcePos);
        change.SetDestinationZone(destinationZone);
        change.SetDestinationZoneTag(destinationZoneTag);
        if (sourcePos != destinationPos)
        {
            Log.Zone.Print(string.Format("ZoneMgr.CreateLocalZoneChanges() - srcPos={0} destPos={1}", sourcePos, destinationPos));
            change.SetDestinationPosition(destinationPos);
        }
        changeList.AddChange(change);
        if (sourceZone != null)
        {
            List<Card> cards = sourceZone.GetCards();
            for (int i = sourcePos; i < cards.Count; i++)
            {
                Card card = cards[i];
                Entity entity = card.GetEntity();
                ZoneChange change2 = new ZoneChange();
                change2.SetParentList(changeList);
                change2.SetEntity(entity);
                int pos = i;
                change2.SetSourcePosition(entity.GetZonePosition());
                change2.SetDestinationPosition(pos);
                Log.Zone.Print(string.Format("ZoneMgr.CreateLocalZoneChanges() - srcZone card {0} zonePos {1} -> {2}", card, entity.GetZonePosition(), pos));
                changeList.AddChange(change2);
            }
        }
        if (destinationZone != null)
        {
            if (destinationZone is ZoneWeapon)
            {
                List<Card> list2 = destinationZone.GetCards();
                for (int j = destinationPos - 1; j < list2.Count; j++)
                {
                    Entity entity2 = list2[j].GetEntity();
                    ZoneChange change3 = new ZoneChange();
                    change3.SetParentList(changeList);
                    change3.SetEntity(entity2);
                    change3.SetSourcePosition(entity2.GetZonePosition());
                    change3.SetDestinationZone(this.FindZoneOfType<ZoneGraveyard>(TAG_ZONE.GRAVEYARD, destinationZone.m_Side));
                    change3.SetDestinationPosition(0);
                    changeList.AddChange(change3);
                }
            }
            else if ((destinationZone is ZonePlay) || (destinationZone is ZoneHand))
            {
                List<Card> list3 = destinationZone.GetCards();
                for (int k = destinationPos - 1; k < list3.Count; k++)
                {
                    Card card3 = list3[k];
                    Entity entity3 = card3.GetEntity();
                    ZoneChange change4 = new ZoneChange();
                    change4.SetParentList(changeList);
                    change4.SetEntity(entity3);
                    int num5 = k + 2;
                    change4.SetSourcePosition(entity3.GetZonePosition());
                    change4.SetDestinationPosition(num5);
                    Log.Zone.Print(string.Format("ZoneMgr.CreateLocalZoneChanges() - dstZone card {0} zonePos {1} -> {2}", card3, entity3.GetZonePosition(), num5));
                    changeList.AddChange(change4);
                }
            }
            else
            {
                UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateLocalZoneChanges() - don't know how to predict zone position changes for zone {0}", destinationZone));
            }
        }
    }

    private void CreateLocalZonePositionChanges(ZoneChangeList changeList, Entity triggerEntity, Zone sourceZone, int sourcePos, int destinationPos)
    {
        ZoneChange change = new ZoneChange();
        change.SetParentList(changeList);
        change.SetEntity(triggerEntity);
        change.SetSourcePosition(sourcePos);
        change.SetDestinationPosition(destinationPos);
        changeList.AddChange(change);
        List<Card> cards = sourceZone.GetCards();
        if (sourcePos < destinationPos)
        {
            for (int i = sourcePos; i < destinationPos; i++)
            {
                Entity entity = cards[i].GetEntity();
                ZoneChange change2 = new ZoneChange();
                change2.SetParentList(changeList);
                change2.SetEntity(entity);
                int pos = i;
                change2.SetSourcePosition(entity.GetZonePosition());
                change2.SetDestinationPosition(pos);
                changeList.AddChange(change2);
            }
        }
        else
        {
            for (int j = destinationPos - 1; j < (sourcePos - 1); j++)
            {
                Entity entity2 = cards[j].GetEntity();
                ZoneChange change3 = new ZoneChange();
                change3.SetParentList(changeList);
                change3.SetEntity(entity2);
                int num4 = j + 2;
                change3.SetSourcePosition(entity2.GetZonePosition());
                change3.SetDestinationPosition(num4);
                changeList.AddChange(change3);
            }
        }
    }

    private ZoneChange CreateZoneChangeFromFullEntity(Network.HistFullEntity fullEntity)
    {
        Network.Entity entity = fullEntity.Entity;
        Entity entity2 = GameState.Get().GetEntity(entity.ID);
        if (entity2 == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.CreateZoneChangeFromFullEntity() - WARNING entity {0} DOES NOT EXIST!", entity.ID));
            return null;
        }
        ZoneChange change = new ZoneChange();
        change.SetEntity(entity2);
        if (entity2.GetCard() != null)
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            foreach (Network.Entity.Tag tag in entity.Tags)
            {
                if (tag.Name == 0x31)
                {
                    change.SetDestinationZoneTag((TAG_ZONE) tag.Value);
                    flag = true;
                    if (!flag2 || !flag3)
                    {
                        continue;
                    }
                    break;
                }
                if (tag.Name == 0x107)
                {
                    change.SetDestinationPosition(tag.Value);
                    flag2 = true;
                    if (!flag || !flag3)
                    {
                        continue;
                    }
                    break;
                }
                if (tag.Name == 50)
                {
                    change.SetDestinationControllerId(tag.Value);
                    flag3 = true;
                    if (flag && flag2)
                    {
                        break;
                    }
                }
            }
            if (flag || flag3)
            {
                change.SetDestinationZone(this.FindZoneForFullEntity(fullEntity));
            }
        }
        return change;
    }

    private ZoneChange CreateZoneChangeFromHideEntity(Network.HistHideEntity hideEntity)
    {
        Entity entity = GameState.Get().GetEntity(hideEntity.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.CreateZoneChangeFromHideEntity() - WARNING entity {0} DOES NOT EXIST! zone={1}", hideEntity.Entity, hideEntity.Zone));
            return null;
        }
        ZoneChange change = new ZoneChange();
        change.SetEntity(entity);
        if (!entity.IsEnchantment())
        {
            Entity entity2 = this.RegisterTempEntity(hideEntity.Entity, entity);
            entity2.SetTag(GAME_TAG.ZONE, hideEntity.Zone);
            if (entity.GetCard() == null)
            {
                UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromHideEntity() - {0} does not have a card visual", entity));
                return null;
            }
            TAG_ZONE zone = (TAG_ZONE) hideEntity.Zone;
            change.SetDestinationZoneTag(zone);
            change.SetDestinationZone(this.FindZoneForEntityAndZoneTag(entity2, zone));
        }
        return change;
    }

    private ZoneChange CreateZoneChangeFromShowEntity(Network.HistShowEntity showEntity)
    {
        Network.Entity entity = showEntity.Entity;
        Entity entity2 = GameState.Get().GetEntity(entity.ID);
        if (entity2 == null)
        {
            UnityEngine.Debug.LogWarning(string.Format("ZoneMgr.CreateZoneChangeFromShowEntity() - WARNING entity {0} DOES NOT EXIST!", entity.ID));
            return null;
        }
        ZoneChange change = new ZoneChange();
        change.SetEntity(entity2);
        if (!entity2.IsEnchantment())
        {
            if (entity2.GetCard() == null)
            {
                UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromShowEntity() - {0} does not have a card visual", entity2));
                return null;
            }
            Entity entity3 = this.RegisterTempEntity(entity.ID, entity2);
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            foreach (Network.Entity.Tag tag in entity.Tags)
            {
                entity3.SetTag(tag.Name, tag.Value);
                if (tag.Name == 0x31)
                {
                    change.SetDestinationZoneTag((TAG_ZONE) tag.Value);
                    flag = true;
                    if (!flag2 || !flag3)
                    {
                        continue;
                    }
                    break;
                }
                if (tag.Name == 0x107)
                {
                    change.SetDestinationPosition(tag.Value);
                    flag2 = true;
                    if (!flag || !flag3)
                    {
                        continue;
                    }
                    break;
                }
                if (tag.Name == 50)
                {
                    change.SetDestinationControllerId(tag.Value);
                    flag3 = true;
                    if (flag && flag2)
                    {
                        break;
                    }
                }
            }
            if (flag || flag3)
            {
                change.SetDestinationZone(this.FindZoneForShowEntity(entity3, showEntity));
            }
        }
        return change;
    }

    private ZoneChange CreateZoneChangeFromTagChange(Network.HistTagChange tagChange)
    {
        Entity entity = GameState.Get().GetEntity(tagChange.Entity);
        if (entity == null)
        {
            UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromTagChange() - Entity {0} does not exist", tagChange.Entity));
            return null;
        }
        ZoneChange change = new ZoneChange();
        change.SetEntity(entity);
        if (!entity.IsGame())
        {
            if (entity.IsPlayer())
            {
                return change;
            }
            if (entity.IsEnchantment())
            {
                return change;
            }
            Entity entity2 = this.RegisterTempEntity(tagChange.Entity, entity);
            entity2.SetTag(tagChange.Tag, tagChange.Value);
            Card card = entity.GetCard();
            if (tagChange.Tag == 0x31)
            {
                if (card == null)
                {
                    UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromTagChange() - {0} does not have a card visual", entity));
                    return null;
                }
                TAG_ZONE tag = (TAG_ZONE) tagChange.Value;
                change.SetDestinationZoneTag(tag);
                change.SetDestinationZone(this.FindZoneForEntityAndZoneTag(entity2, tag));
            }
            else if (tagChange.Tag == 0x107)
            {
                if (card == null)
                {
                    UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromTagChange() - {0} does not have a card visual", entity));
                    return null;
                }
                change.SetDestinationPosition(tagChange.Value);
            }
            else if (tagChange.Tag == 50)
            {
                if (card == null)
                {
                    UnityEngine.Debug.LogError(string.Format("ZoneMgr.CreateZoneChangeFromTagChange() - {0} does not have a card visual", entity));
                    return null;
                }
                int controllerId = tagChange.Value;
                change.SetDestinationControllerId(controllerId);
                change.SetDestinationZone(this.FindZoneForEntityAndController(entity2, controllerId));
            }
            entity2.SetTag(tagChange.Tag, tagChange.Value);
        }
        return change;
    }

    private static bool DoChangeListsMatch(ZoneChangeList serverChangeList, ZoneChangeList localChangeList)
    {
        ZoneChange change;
        ZoneChange change2;
        return FindMatchingChanges(serverChangeList, localChangeList, out change, out change2);
    }

    private void ExtractChangeMapsFromShowEntity(ZoneChangeList serverChangeList, Dictionary<Zone, int> localZoneCardCounts, out Dictionary<Entity, ZoneChange> showEntityChanges, out Dictionary<Entity, int> posChanges)
    {
        showEntityChanges = new Dictionary<Entity, ZoneChange>();
        posChanges = new Dictionary<Entity, int>();
        foreach (ZoneChange change in serverChangeList.GetChanges())
        {
            TAG_ZONE destinationZoneTag = change.GetDestinationZoneTag();
            int destinationPosition = change.GetDestinationPosition();
            int destinationControllerId = change.GetDestinationControllerId();
            if (((destinationZoneTag != TAG_ZONE.NONE) || (destinationPosition != 0)) || (destinationControllerId != 0))
            {
                Entity key = change.GetEntity();
                Network.PowerHistory.PowType type = change.GetPowerTask().GetPower().Type;
                if (((destinationZoneTag != TAG_ZONE.NONE) || (destinationControllerId != 0)) && (type == Network.PowerHistory.PowType.SHOW_ENTITY))
                {
                    Zone destinationZone = change.GetDestinationZone();
                    if ((destinationZone != null) && localZoneCardCounts.ContainsKey(destinationZone))
                    {
                        showEntityChanges.Add(key, change);
                        object[] args = new object[] { key, destinationZoneTag };
                        Log.Zone.Print("ZoneMgr.ExtractChangeMapsFromShowEntity() - found SHOW_ENTITY for {0} to ZONE {1}", args);
                    }
                }
                if (destinationPosition != 0)
                {
                    if (posChanges.ContainsKey(key))
                    {
                        Dictionary<Entity, int> dictionary;
                        Entity entity2;
                        int num3 = dictionary[entity2];
                        (dictionary = posChanges)[entity2 = key] = num3 + 1;
                        continue;
                    }
                    posChanges[key] = 0;
                }
            }
        }
    }

    private static bool FindMatchingChanges(ZoneChangeList serverChangeList, ZoneChangeList localChangeList, out ZoneChange matchingServerChange, out ZoneChange matchingLocalChange)
    {
        matchingServerChange = null;
        matchingLocalChange = null;
        foreach (ZoneChange change in serverChangeList.GetChanges())
        {
            TAG_ZONE destinationZoneTag = change.GetDestinationZoneTag();
            if (destinationZoneTag != TAG_ZONE.NONE)
            {
                Entity entity = change.GetEntity();
                foreach (ZoneChange change2 in localChangeList.GetChanges())
                {
                    if ((entity == change2.GetEntity()) && (destinationZoneTag == change2.GetDestinationZoneTag()))
                    {
                        matchingServerChange = change;
                        matchingLocalChange = change2;
                        return true;
                    }
                }
                continue;
            }
        }
        return false;
    }

    private bool FindRejectedLocalZoneChange(Entity triggerEntity, out int changeListIndex, out int changeIndex)
    {
        changeListIndex = -1;
        changeIndex = -1;
        List<ZoneChangeList> list = this.m_localChangeListHistory.GetList();
        for (int i = 0; i < list.Count; i++)
        {
            List<ZoneChange> changes = list[i].GetChanges();
            for (int j = 0; j < changes.Count; j++)
            {
                ZoneChange change = changes[j];
                if ((change.GetEntity() == triggerEntity) && (change.GetDestinationZoneTag() == TAG_ZONE.PLAY))
                {
                    changeListIndex = i;
                    changeIndex = j;
                    return true;
                }
            }
        }
        return false;
    }

    public Zone FindZoneForEntity(Entity entity)
    {
        if (entity.GetZone() != TAG_ZONE.NONE)
        {
            foreach (Zone zone in this.m_zones)
            {
                if (zone.CanAcceptTags(entity.GetControllerId(), entity.GetZone(), entity.GetCardType()))
                {
                    return zone;
                }
            }
        }
        return null;
    }

    public Zone FindZoneForEntityAndController(Entity entity, int controllerId)
    {
        foreach (Zone zone in this.m_zones)
        {
            if (zone.CanAcceptTags(controllerId, entity.GetZone(), entity.GetCardType()))
            {
                return zone;
            }
        }
        return null;
    }

    public Zone FindZoneForEntityAndZoneTag(Entity entity, TAG_ZONE zoneTag)
    {
        if (zoneTag != TAG_ZONE.NONE)
        {
            foreach (Zone zone in this.m_zones)
            {
                if (zone.CanAcceptTags(entity.GetControllerId(), zoneTag, entity.GetCardType()))
                {
                    return zone;
                }
            }
        }
        return null;
    }

    public Zone FindZoneForFullEntity(Network.HistFullEntity fullEntity)
    {
        int controllerId = 0;
        TAG_ZONE nONE = TAG_ZONE.NONE;
        TAG_CARDTYPE cardType = TAG_CARDTYPE.NONE;
        foreach (Network.Entity.Tag tag in fullEntity.Entity.Tags)
        {
            GAME_TAG name = (GAME_TAG) tag.Name;
            if (name != GAME_TAG.ZONE)
            {
                if (name == GAME_TAG.CONTROLLER)
                {
                    goto Label_0061;
                }
                if (name == GAME_TAG.CARDTYPE)
                {
                    goto Label_006E;
                }
                goto Label_007B;
            }
            nONE = (TAG_ZONE) tag.Value;
            continue;
        Label_0061:
            controllerId = tag.Value;
            continue;
        Label_006E:
            cardType = (TAG_CARDTYPE) tag.Value;
            continue;
        Label_007B:;
        }
        foreach (Zone zone in this.m_zones)
        {
            if (zone.CanAcceptTags(controllerId, nONE, cardType))
            {
                return zone;
            }
        }
        return null;
    }

    public Zone FindZoneForShowEntity(Entity entity, Network.HistShowEntity showEntity)
    {
        int controllerId = entity.GetControllerId();
        TAG_ZONE zoneTag = entity.GetZone();
        TAG_CARDTYPE cardType = entity.GetCardType();
        foreach (Network.Entity.Tag tag in showEntity.Entity.Tags)
        {
            GAME_TAG name = (GAME_TAG) tag.Name;
            if (name != GAME_TAG.ZONE)
            {
                if (name == GAME_TAG.CONTROLLER)
                {
                    goto Label_0070;
                }
                if (name == GAME_TAG.CARDTYPE)
                {
                    goto Label_007D;
                }
                goto Label_008A;
            }
            zoneTag = (TAG_ZONE) tag.Value;
            continue;
        Label_0070:
            controllerId = tag.Value;
            continue;
        Label_007D:
            cardType = (TAG_CARDTYPE) tag.Value;
            continue;
        Label_008A:;
        }
        foreach (Zone zone in this.m_zones)
        {
            if (zone.CanAcceptTags(controllerId, zoneTag, cardType))
            {
                return zone;
            }
        }
        return null;
    }

    public Zone FindZoneForTags(int controllerId, TAG_ZONE zoneTag, TAG_CARDTYPE cardType)
    {
        if (controllerId != 0)
        {
            if (zoneTag == TAG_ZONE.NONE)
            {
                return null;
            }
            foreach (Zone zone in this.m_zones)
            {
                if (zone.CanAcceptTags(controllerId, zoneTag, cardType))
                {
                    return zone;
                }
            }
        }
        return null;
    }

    public T FindZoneOfType<T>(TAG_ZONE serverTag, Player.Side side) where T: Zone
    {
        System.Type type = typeof(T);
        foreach (Zone zone in this.m_zones)
        {
            if (((zone.GetType() == type) && (zone.m_ServerTag == serverTag)) && (zone.m_Side == side))
            {
                return (T) zone;
            }
        }
        return null;
    }

    public List<Zone> FindZonesForTag(TAG_ZONE zoneTag)
    {
        List<Zone> list = new List<Zone>();
        foreach (Zone zone in this.m_zones)
        {
            if (zone.m_ServerTag == zoneTag)
            {
                list.Add(zone);
            }
        }
        return list;
    }

    public List<T> FindZonesOfType<T>() where T: Zone
    {
        List<T> list = new List<T>();
        System.Type type = typeof(T);
        foreach (Zone zone in this.m_zones)
        {
            if (zone.GetType() == type)
            {
                list.Add((T) zone);
            }
        }
        return list;
    }

    private void FixupPositionsForFullEntity(ZoneChangeList serverChangeList)
    {
        ZoneChangeList localChangeList = this.m_localChangeListHistory.Peek();
        Dictionary<Zone, int> dictionary = this.ComputeLocalZoneCardCounts(localChangeList);
        if (dictionary.Count != 0)
        {
            Dictionary<Entity, ZoneChange> dictionary2 = new Dictionary<Entity, ZoneChange>();
            List<ZoneChange> changes = serverChangeList.GetChanges();
            int count = changes.Count;
            for (int i = 0; i < count; i++)
            {
                ZoneChange change = changes[i];
                TAG_ZONE destinationZoneTag = change.GetDestinationZoneTag();
                int destinationPosition = change.GetDestinationPosition();
                int destinationControllerId = change.GetDestinationControllerId();
                if (((destinationZoneTag != TAG_ZONE.NONE) || (destinationPosition != 0)) || (destinationControllerId != 0))
                {
                    Entity key = change.GetEntity();
                    PowerTask powerTask = change.GetPowerTask();
                    Network.PowerHistory.PowType type = powerTask.GetPower().Type;
                    if (type == Network.PowerHistory.PowType.FULL_ENTITY)
                    {
                        dictionary2.Add(key, null);
                        object[] args = new object[] { key };
                        Log.Zone.Print("ZoneMgr.FixupPositionsForFullEntity() - found FULL_ENTITY for {0}", args);
                    }
                    if (destinationZoneTag != TAG_ZONE.NONE)
                    {
                        Zone destinationZone = change.GetDestinationZone();
                        if (((destinationZone != null) && dictionary.ContainsKey(destinationZone)) && dictionary2.ContainsKey(key))
                        {
                            dictionary2[key] = change;
                            object[] objArray2 = new object[] { key, destinationZoneTag };
                            Log.Zone.Print("ZoneMgr.FixupPositionsForFullEntity() - FULL_ENTITY for {0} to ZONE {1}", objArray2);
                        }
                    }
                    if (destinationPosition != 0)
                    {
                        ZoneChange change2;
                        if (dictionary2.TryGetValue(key, out change2) && (change2 != null))
                        {
                            Dictionary<Zone, int> dictionary3;
                            Zone zone3;
                            Zone zone2 = change2.GetDestinationZone();
                            List<Card> cards = zone2.GetCards();
                            int num5 = dictionary[zone2];
                            for (int j = destinationPosition - 1; j < num5; j++)
                            {
                                Entity entity = cards[j].GetEntity();
                                int pos = j + 2;
                                object[] objArray3 = new object[] { key, key.GetZonePosition(), pos };
                                Log.Zone.Print("ZoneMgr.FixupPositionsForFullEntity() - adding ZoneChange for {0}: ZONE_POSITION {1} -> {2}", objArray3);
                                ZoneChange change3 = new ZoneChange();
                                change3.SetEntity(entity);
                                change3.SetDestinationPosition(pos);
                                serverChangeList.AddChange(change3);
                            }
                            int num8 = dictionary3[zone3];
                            (dictionary3 = dictionary)[zone3 = zone2] = num8 + 1;
                        }
                        else if (type == Network.PowerHistory.PowType.TAG_CHANGE)
                        {
                            powerTask.SetCompleted(true);
                        }
                    }
                }
            }
        }
    }

    private void FixupPositionsForShowEntity(ZoneChangeList serverChangeList)
    {
        ZoneChangeList localChangeList = this.m_localChangeListHistory.Peek();
        Dictionary<Zone, int> localZoneCardCounts = this.ComputeLocalZoneCardCounts(localChangeList);
        if (localZoneCardCounts.Count != 0)
        {
            Dictionary<Entity, ZoneChange> dictionary2;
            Dictionary<Entity, int> dictionary3;
            this.ExtractChangeMapsFromShowEntity(serverChangeList, localZoneCardCounts, out dictionary2, out dictionary3);
            if (dictionary2.Count >= dictionary3.Count)
            {
                foreach (Entity entity in dictionary2.Keys)
                {
                    int num = 0;
                    if (!dictionary3.TryGetValue(entity, out num) || (num > 1))
                    {
                        return;
                    }
                }
                foreach (ZoneChange change in serverChangeList.GetChanges())
                {
                    int destinationPosition = change.GetDestinationPosition();
                    if (destinationPosition != 0)
                    {
                        Dictionary<Zone, int> dictionary4;
                        Zone zone2;
                        Entity entity2 = change.GetEntity();
                        Zone destinationZone = dictionary2[entity2].GetDestinationZone();
                        int num4 = dictionary4[zone2];
                        (dictionary4 = localZoneCardCounts)[zone2 = destinationZone] = num4 + 1;
                        int pos = localZoneCardCounts[destinationZone];
                        object[] args = new object[] { entity2, destinationPosition, pos };
                        Log.Zone.Print("ZoneMgr.FixupPositionsForShowEntity() - changing ZONE_POSITION value for {0} from {1} to {2}", args);
                        change.SetDestinationPosition(pos);
                        Network.HistTagChange power = change.GetPowerTask().GetPower() as Network.HistTagChange;
                        power.Value = pos;
                    }
                }
            }
        }
    }

    public static ZoneMgr Get()
    {
        return s_instance;
    }

    private int GetNextChangeListId()
    {
        int nextChangeListId = this.m_nextChangeListId;
        this.m_nextChangeListId = (this.m_nextChangeListId + 1) & 0x7fffffff;
        return nextChangeListId;
    }

    public List<Zone> GetZones()
    {
        return this.m_zones;
    }

    public bool HasActiveServerChange()
    {
        return (this.m_activeServerChangeList != null);
    }

    public static bool IsHandledPower(Network.PowerHistory power)
    {
        switch (power.Type)
        {
            case Network.PowerHistory.PowType.FULL_ENTITY:
            {
                Network.HistFullEntity entity2 = power as Network.HistFullEntity;
                bool flag = false;
                foreach (Network.Entity.Tag tag in entity2.Entity.Tags)
                {
                    if (tag.Name == 0xca)
                    {
                        if (tag.Value == 1)
                        {
                            return false;
                        }
                        if (tag.Value == 2)
                        {
                            return false;
                        }
                        continue;
                    }
                    if (((tag.Name == 0x31) || (tag.Name == 0x107)) || (tag.Name == 50))
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            case Network.PowerHistory.PowType.SHOW_ENTITY:
            {
                Network.HistShowEntity entity3 = power as Network.HistShowEntity;
                foreach (Network.Entity.Tag tag2 in entity3.Entity.Tags)
                {
                    if (tag2.Name == 0x31)
                    {
                        return true;
                    }
                    if (tag2.Name == 0x107)
                    {
                        return true;
                    }
                    if (tag2.Name == 50)
                    {
                        return true;
                    }
                }
                return false;
            }
            case Network.PowerHistory.PowType.HIDE_ENTITY:
                return true;

            case Network.PowerHistory.PowType.TAG_CHANGE:
            {
                Network.HistTagChange change = power as Network.HistTagChange;
                if (((change.Tag != 0x31) && (change.Tag != 0x107)) && (change.Tag != 50))
                {
                    return false;
                }
                Entity entity = GameState.Get().GetEntity(change.Entity);
                if (entity != null)
                {
                    if (entity.IsPlayer())
                    {
                        return false;
                    }
                    if (entity.IsGame())
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    public bool OnLocalZoneChangeRejected(Entity triggerEntity)
    {
        int num;
        int num2;
        if (!this.FindRejectedLocalZoneChange(triggerEntity, out num, out num2))
        {
            object[] args = new object[] { triggerEntity };
            Log.Zone.Print("ZoneMgr.OnLocalZoneChangeRejected() - did not find a zone change to reject for {0}", args);
            return false;
        }
        ZoneChangeList changeList = this.m_localChangeListHistory.RemoveAt(num);
        ZoneChange change = changeList.GetChange(num2);
        base.StartCoroutine(this.WaitThenUndoLocalZoneChange(changeList, change));
        return true;
    }

    private bool PostProcessForZoneChange(ZoneChangeList serverChangeList)
    {
        ZoneChange change;
        ZoneChange change2;
        for (ZoneChangeList list = this.m_localChangeListHistory.Peek(); !FindMatchingChanges(serverChangeList, list, out change, out change2); list = this.m_localChangeListHistory.Peek())
        {
            this.m_localChangeListHistory.Dequeue();
            if (this.m_localChangeListHistory.Count == 0)
            {
                return false;
            }
        }
        change.GetPowerTask().SetCompleted(true);
        object[] args = new object[] { change.GetEntity(), change.GetDestinationZoneTag() };
        Log.Zone.Print("ZoneMgr.PostProcessForZoneChange() - ALREADY HANDLED {0} to ZONE {1}", args);
        foreach (ZoneChange change3 in serverChangeList.GetChanges())
        {
            PowerTask powerTask = change3.GetPowerTask();
            if (powerTask.GetPower().Type == Network.PowerHistory.PowType.TAG_CHANGE)
            {
                int destinationPosition = change3.GetDestinationPosition();
                if (destinationPosition != 0)
                {
                    object[] objArray2 = new object[] { change3.GetEntity(), destinationPosition };
                    Log.Zone.Print("ZoneMgr.PostProcessForZoneChange() - DISCARDING {0} to ZONE_POSITION {1}", objArray2);
                    powerTask.SetCompleted(true);
                }
            }
        }
        return true;
    }

    private bool PostProcessServerChangeList(ZoneChangeList serverChangeList)
    {
        if (this.m_localChangeListHistory.Count == 0)
        {
            return false;
        }
        bool flag = false;
        List<ZoneChange> changes = serverChangeList.GetChanges();
        int count = changes.Count;
        for (int i = 0; i < count; i++)
        {
            ZoneChange change = changes[i];
            Network.PowerHistory.PowType type = change.GetPowerTask().GetPower().Type;
            switch (type)
            {
                case Network.PowerHistory.PowType.TAG_CHANGE:
                case Network.PowerHistory.PowType.SHOW_ENTITY:
                case Network.PowerHistory.PowType.FULL_ENTITY:
                    if (type == Network.PowerHistory.PowType.SHOW_ENTITY)
                    {
                        this.FixupPositionsForShowEntity(serverChangeList);
                        return false;
                    }
                    if (type == Network.PowerHistory.PowType.FULL_ENTITY)
                    {
                        this.FixupPositionsForFullEntity(serverChangeList);
                        return false;
                    }
                    if ((change.GetDestinationZoneTag() != TAG_ZONE.NONE) || (change.GetDestinationControllerId() != 0))
                    {
                        flag = true;
                    }
                    break;
            }
        }
        return (flag && this.PostProcessForZoneChange(serverChangeList));
    }

    private void ProcessLocalChangeLists()
    {
        int index = 0;
        while (index < this.m_activeLocalChangeLists.Count)
        {
            ZoneChangeList list = this.m_activeLocalChangeLists[index];
            if (!list.IsComplete())
            {
                index++;
            }
            else
            {
                list.FireCompleteCallback();
                this.m_activeLocalChangeLists.RemoveAt(index);
            }
        }
    }

    private void ProcessServerChangeListQueue()
    {
        if ((this.m_activeServerChangeList != null) && this.m_activeServerChangeList.IsComplete())
        {
            this.m_activeServerChangeList.FireCompleteCallback();
            this.m_activeServerChangeList = null;
        }
        if ((this.m_pendingServerChangeLists.Count > 0) && (this.m_activeServerChangeList == null))
        {
            this.m_activeServerChangeList = this.m_pendingServerChangeLists.Dequeue();
            base.StartCoroutine(this.m_activeServerChangeList.ProcessChanges());
        }
    }

    private Entity RegisterTempEntity(int id, Entity entity)
    {
        Entity entity2;
        if (!this.m_tempEntityMap.TryGetValue(id, out entity2))
        {
            entity2 = entity.CloneForZoneMgr();
            this.m_tempEntityMap.Add(id, entity2);
        }
        return entity2;
    }

    private void Start()
    {
        InputManager manager = InputManager.Get();
        if (manager != null)
        {
            manager.StartingWatchingForInput();
        }
    }

    private void Update()
    {
        this.ProcessLocalChangeLists();
        this.ProcessServerChangeListQueue();
    }

    [DebuggerHidden]
    private IEnumerator WaitThenUndoLocalZoneChange(ZoneChangeList changeList, ZoneChange change)
    {
        return new <WaitThenUndoLocalZoneChange>c__Iterator69 { changeList = changeList, change = change, <$>changeList = changeList, <$>change = change, <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <WaitThenUndoLocalZoneChange>c__Iterator69 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal ZoneChange <$>change;
        internal ZoneChangeList <$>changeList;
        internal ZoneMgr <>f__this;
        internal ZoneChange change;
        internal ZoneChangeList changeList;

        [DebuggerHidden]
        public void Dispose()
        {
            this.$PC = -1;
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 0:
                case 1:
                    if (this.<>f__this.m_activeLocalChangeLists.Contains(this.changeList))
                    {
                        this.$current = null;
                        this.$PC = 1;
                        return true;
                    }
                    this.<>f__this.AddLocalZoneChange(this.change.GetEntity().GetCard(), this.change.GetSourceZone(), this.change.GetSourcePosition());
                    this.$PC = -1;
                    break;
            }
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        object IEnumerator<object>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }

    public delegate void ChangeCompleteCallback(object userData);
}

