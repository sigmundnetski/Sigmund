using System;
using UnityEngine;

public class PowerTask
{
    private bool m_completed;
    private Network.PowerHistory m_power;

    private void ApplyPower()
    {
        GameState state = GameState.Get();
        switch (this.m_power.Type)
        {
            case Network.PowerHistory.PowType.FULL_ENTITY:
            {
                Network.HistFullEntity power = this.m_power as Network.HistFullEntity;
                state.OnFullEntity(power);
                return;
            }
            case Network.PowerHistory.PowType.SHOW_ENTITY:
            {
                Network.HistShowEntity showEntity = this.m_power as Network.HistShowEntity;
                state.OnShowEntity(showEntity);
                return;
            }
            case Network.PowerHistory.PowType.HIDE_ENTITY:
            {
                Network.HistHideEntity hideEntity = this.m_power as Network.HistHideEntity;
                state.OnHideEntity(hideEntity);
                return;
            }
            case Network.PowerHistory.PowType.TAG_CHANGE:
            {
                Network.HistTagChange tagChange = this.m_power as Network.HistTagChange;
                state.OnTagChange(tagChange);
                return;
            }
            case Network.PowerHistory.PowType.CREATE_GAME:
            {
                Network.HistCreateGame createGame = this.m_power as Network.HistCreateGame;
                state.OnCreateGame(createGame);
                return;
            }
            case Network.PowerHistory.PowType.META_DATA:
                return;
        }
        Debug.LogWarning(string.Format("PowerTask.ApplyPower() - unknown power type {0}", this.m_power.Type));
    }

    public void DoTask()
    {
        if (!this.m_completed)
        {
            this.ApplyPower();
            this.m_completed = true;
        }
    }

    public Network.PowerHistory GetPower()
    {
        return this.m_power;
    }

    public bool IsCompleted()
    {
        return this.m_completed;
    }

    public void SetCompleted(bool complete)
    {
        this.m_completed = complete;
    }

    public void SetPower(Network.PowerHistory power)
    {
        this.m_power = power;
    }
}

