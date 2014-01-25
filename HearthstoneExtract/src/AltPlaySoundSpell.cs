using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AltPlaySoundSpell : Spell
{
    public AudioSource m_alternateSource;
    public string m_cardIDForAltSound;
    public AudioSource m_defaultSource;
    public AudioSource m_musicStinger;
    public float m_musicStingerDelay;

    public override void ChangeState(SpellStateType stateType)
    {
        base.m_activeStateType = stateType;
        if ((base.m_activeStateType == SpellStateType.BIRTH) && (GameState.Get() != null))
        {
            if (this.m_musicStinger != null)
            {
                base.StartCoroutine(this.PlayMusicStinger());
            }
            Player remotePlayer = null;
            if (base.GetSourceCard().GetEntity().IsControlledByLocalPlayer())
            {
                remotePlayer = GameState.Get().GetRemotePlayer();
            }
            else
            {
                remotePlayer = GameState.Get().GetLocalPlayer();
            }
            foreach (Card card in remotePlayer.GetBattlefieldZone().GetCards())
            {
                if (card.GetEntity().GetCardId() == this.m_cardIDForAltSound)
                {
                    SoundManager.Get().Play(this.m_alternateSource);
                    return;
                }
            }
            if (remotePlayer.GetHero().GetCardId() == this.m_cardIDForAltSound)
            {
                SoundManager.Get().Play(this.m_alternateSource);
            }
            else
            {
                SoundManager.Get().Play(this.m_defaultSource);
            }
        }
    }

    public override bool HasUsableState(SpellStateType stateType)
    {
        return true;
    }

    [DebuggerHidden]
    private IEnumerator PlayMusicStinger()
    {
        return new <PlayMusicStinger>c__IteratorC9 { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <PlayMusicStinger>c__IteratorC9 : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal AltPlaySoundSpell <>f__this;

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
                    this.$current = new WaitForSeconds(this.<>f__this.m_musicStingerDelay);
                    this.$PC = 1;
                    return true;

                case 1:
                    SoundManager.Get().Play(this.<>f__this.m_musicStinger);
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
}

