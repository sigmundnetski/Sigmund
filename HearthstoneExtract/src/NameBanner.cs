using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NameBanner : MonoBehaviour
{
    public GameObject m_alphaBanner;
    public Transform m_classBone;
    public UberText m_className;
    private bool m_isPlayer;
    public Transform m_nameBone;
    public UberText m_playerName;
    private const float UNKNOWN_NAME_WAIT = 5f;

    private void Awake()
    {
        SceneUtils.SetLayer(base.gameObject, GameLayer.GeneralUI);
        base.transform.parent = BaseUI.Get().transform;
        BaseUI.Get().m_BnetCamera.GetComponent<ScreenResizeDetector>().AddSizeChangedListener(new ScreenResizeDetector.SizeChangedCallback(this.OnSizeChanged));
        this.m_playerName.transform.position = this.m_nameBone.position;
        this.m_className.gameObject.SetActive(false);
        this.m_playerName.Text = string.Empty;
    }

    public void FadeClass()
    {
        iTween.FadeTo(this.m_className.gameObject, 0f, 1f);
        iTween.MoveTo(this.m_playerName.gameObject, this.m_nameBone.position, 5f);
    }

    private void OnSizeChanged(object userData)
    {
        this.UpdateAnchor(this.m_isPlayer);
    }

    public void SetClass(string className)
    {
        this.m_className.gameObject.SetActive(true);
        this.m_className.Text = className;
        this.m_playerName.transform.position = this.m_classBone.position;
    }

    public void SetName(string name)
    {
        this.m_playerName.Text = name;
    }

    public void SetPlayer(bool isPlayer)
    {
        this.m_isPlayer = isPlayer;
        this.UpdateAnchor(this.m_isPlayer);
    }

    private void Start()
    {
        base.StartCoroutine(this.UpdateName());
        base.StartCoroutine(this.UpdateUnknownName());
    }

    private void UpdateAnchor(bool isPlayer)
    {
        Vector3 vector;
        Bounds farClipBounds = CameraUtils.GetFarClipBounds(PegUI.Get().orthographicUICam);
        if (isPlayer)
        {
            vector = new Vector3(farClipBounds.min.x - base.transform.parent.localPosition.x, farClipBounds.min.y + 75f, 0f);
        }
        else
        {
            vector = new Vector3(farClipBounds.min.x - base.transform.parent.localPosition.x, farClipBounds.max.y - 50f, 0f);
        }
        base.transform.localPosition = vector;
    }

    [DebuggerHidden]
    private IEnumerator UpdateName()
    {
        return new <UpdateName>c__Iterator5D { <>f__this = this };
    }

    [DebuggerHidden]
    private IEnumerator UpdateUnknownName()
    {
        return new <UpdateUnknownName>c__Iterator5E { <>f__this = this };
    }

    [CompilerGenerated]
    private sealed class <UpdateName>c__Iterator5D : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal Dictionary<int, Player>.ValueCollection.Enumerator <$s_279>__2;
        internal NameBanner <>f__this;
        internal string <name>__4;
        internal Player <p>__1;
        internal Player <player>__3;
        internal Dictionary<int, Player> <playerMap>__0;

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
                    if (GameState.Get().GetPlayerMap().Count == 0)
                    {
                        this.$current = null;
                        this.$PC = 1;
                        goto Label_01A4;
                    }
                    this.<playerMap>__0 = GameState.Get().GetPlayerMap();
                    this.<p>__1 = null;
                    break;

                case 2:
                    break;

                case 3:
                    goto Label_0161;

                default:
                    goto Label_01A2;
            }
            while (this.<p>__1 == null)
            {
                this.<$s_279>__2 = this.<playerMap>__0.Values.GetEnumerator();
                try
                {
                    while (this.<$s_279>__2.MoveNext())
                    {
                        this.<player>__3 = this.<$s_279>__2.Current;
                        if (this.<player>__3.IsLocal() == this.<>f__this.m_isPlayer)
                        {
                            this.<p>__1 = this.<player>__3;
                        }
                    }
                }
                finally
                {
                    this.<$s_279>__2.Dispose();
                }
                this.$current = null;
                this.$PC = 2;
                goto Label_01A4;
            }
            this.<name>__4 = this.<p>__1.GetName();
            if (this.<name>__4 != null)
            {
                this.<>f__this.SetName(this.<name>__4);
            }
            if (MissionMgr.Get().IsTutorial())
            {
                goto Label_01A2;
            }
        Label_0161:
            while (this.<p>__1.GetHero().GetClass() == TAG_CLASS.NONE)
            {
                this.$current = null;
                this.$PC = 3;
                goto Label_01A4;
            }
            this.<>f__this.SetClass(GameStrings.GetClassName(this.<p>__1.GetHero().GetClass()).ToUpper());
            this.$PC = -1;
        Label_01A2:
            return false;
        Label_01A4:
            return true;
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

    [CompilerGenerated]
    private sealed class <UpdateUnknownName>c__Iterator5E : IDisposable, IEnumerator, IEnumerator<object>
    {
        internal object $current;
        internal int $PC;
        internal NameBanner <>f__this;

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
                    this.$current = new WaitForSeconds(5f);
                    this.$PC = 1;
                    return true;

                case 1:
                    if (!(this.<>f__this.m_playerName.Text != string.Empty))
                    {
                        this.<>f__this.SetName(GameStrings.Get("GAMEPLAY_UNKNOWN_OPPONENT_NAME"));
                        this.$PC = -1;
                        break;
                    }
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

