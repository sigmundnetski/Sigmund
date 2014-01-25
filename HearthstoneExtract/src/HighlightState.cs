using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using UnityEngine;

public class HighlightState : MonoBehaviour
{
    private const string FSM_BIRTH_STATE = "Birth";
    private const string FSM_BIRTHTRANSITION_STATE = "BirthTransition";
    private const string FSM_DEATH_STATE = "Death";
    private const string FSM_DEATHTRANSITION_STATE = "DeathTransition";
    private const string FSM_IDLE_STATE = "Idle";
    private const string FSM_IDLETRANSITION_STATE = "IdleTransition";
    private readonly string HIGHLIGHT_SHADER_NAME = "Custom/Selection/Highlight";
    private string m_BirthTransition = "None";
    protected ActorStateType m_CurrentState;
    private string m_DeathTransition = "None";
    protected PlayMakerFSM m_FSM;
    public List<HighlightRenderState> m_HighlightStates;
    public HighlightStateType m_highlightType;
    public Vector3 m_HistoryTranslation = new Vector3(0f, -0.1f, 0f);
    private string m_IdleTransition = "None";
    private bool m_isDirty;
    private Material m_Material;
    protected ActorStateType m_PreviousState;
    public GameObject m_RenderPlane;
    public int m_RenderQueue;
    private string m_SecondBirthTransition = "None";
    private float m_seed;
    private string m_sendEvent;
    public Texture2D m_StaticSilouetteTexture;

    private void Awake()
    {
        if (this.m_RenderPlane == null)
        {
            Debug.LogError("m_RenderPlane is null!");
            base.enabled = false;
        }
        this.m_RenderPlane.renderer.enabled = false;
        this.m_FSM = this.m_RenderPlane.GetComponent<PlayMakerFSM>();
        if (this.m_FSM != null)
        {
            this.m_FSM.enabled = true;
        }
    }

    public bool ChangeState(ActorStateType stateType)
    {
        if (stateType == this.m_CurrentState)
        {
            return true;
        }
        this.m_PreviousState = this.m_CurrentState;
        this.m_CurrentState = stateType;
        if (stateType == ActorStateType.NONE)
        {
            this.m_RenderPlane.renderer.enabled = false;
            return true;
        }
        if ((stateType == ActorStateType.CARD_IDLE) || (stateType == ActorStateType.HIGHLIGHT_OFF))
        {
            if (this.m_FSM == null)
            {
                this.m_RenderPlane.renderer.enabled = false;
                return true;
            }
            this.m_DeathTransition = this.m_PreviousState.ToString();
            this.SendDataToPlaymaker();
            this.SendPlaymakerDeathEvent();
            return true;
        }
        foreach (HighlightRenderState state in this.m_HighlightStates)
        {
            if (state.m_StateType != stateType)
            {
                continue;
            }
            if (state.m_Material != null)
            {
                this.m_Material.CopyPropertiesFromMaterial(state.m_Material);
                this.m_RenderPlane.renderer.sharedMaterial = this.m_Material;
                this.m_RenderPlane.renderer.sharedMaterial.SetFloat("_Seed", this.m_seed);
                bool flag = this.RenderSilouette();
                if (stateType == ActorStateType.CARD_HISTORY)
                {
                    base.transform.localPosition = this.m_HistoryTranslation;
                }
                else
                {
                    base.transform.localPosition = Vector3.zero;
                }
                if (this.m_FSM == null)
                {
                    this.m_RenderPlane.renderer.enabled = true;
                    return flag;
                }
                this.m_BirthTransition = stateType.ToString();
                this.m_SecondBirthTransition = this.m_PreviousState.ToString();
                this.m_IdleTransition = this.m_BirthTransition;
                this.SendDataToPlaymaker();
                this.SendPlaymakerBirthEvent();
                return flag;
            }
            this.m_RenderPlane.renderer.enabled = false;
            return true;
        }
        if (this.m_highlightType == HighlightStateType.CARD)
        {
            this.m_CurrentState = ActorStateType.CARD_IDLE;
        }
        else if (this.m_highlightType == HighlightStateType.HIGHLIGHT)
        {
            this.m_CurrentState = ActorStateType.HIGHLIGHT_OFF;
        }
        this.m_DeathTransition = this.m_PreviousState.ToString();
        this.SendDataToPlaymaker();
        this.SendPlaymakerDeathEvent();
        this.m_RenderPlane.renderer.enabled = false;
        return false;
    }

    private void LateUpdate()
    {
    }

    public void OnActionFinished()
    {
    }

    protected void OnApplicationFocus(bool state)
    {
        this.m_isDirty = true;
    }

    protected void OnDestroy()
    {
        if (this.m_Material != null)
        {
            UnityEngine.Object.Destroy(this.m_Material);
        }
    }

    private bool RenderSilouette()
    {
        if (this.m_StaticSilouetteTexture != null)
        {
            this.m_RenderPlane.renderer.sharedMaterial.mainTexture = this.m_StaticSilouetteTexture;
            this.m_RenderPlane.renderer.sharedMaterial.renderQueue = 0xbb8 + this.m_RenderQueue;
            return true;
        }
        HighlightRender component = this.m_RenderPlane.GetComponent<HighlightRender>();
        if (component == null)
        {
            Debug.LogError("Unable to find HighlightRender component on m_RenderPlane");
            return false;
        }
        if (component.enabled)
        {
            component.CreateSilhouetteTexture();
            this.m_RenderPlane.renderer.sharedMaterial.mainTexture = component.SilhouetteTexture;
            this.m_RenderPlane.renderer.sharedMaterial.renderQueue = 0xbb8 + this.m_RenderQueue;
        }
        return true;
    }

    private void SendDataToPlaymaker()
    {
        if (this.m_FSM != null)
        {
            FsmMaterial fsmMaterial = this.m_FSM.FsmVariables.GetFsmMaterial("HighlightMaterial");
            if (fsmMaterial != null)
            {
                fsmMaterial.Value = this.m_RenderPlane.renderer.sharedMaterial;
            }
            FsmString fsmString = this.m_FSM.FsmVariables.GetFsmString("CurrentState");
            if (fsmString != null)
            {
                fsmString.Value = this.m_CurrentState.ToString();
            }
            FsmString str2 = this.m_FSM.FsmVariables.GetFsmString("PreviousState");
            if (str2 != null)
            {
                str2.Value = this.m_PreviousState.ToString();
            }
        }
    }

    private void SendPlaymakerBirthEvent()
    {
        if (this.m_FSM != null)
        {
            FsmString fsmString = this.m_FSM.FsmVariables.GetFsmString("BirthTransition");
            if (fsmString != null)
            {
                fsmString.Value = this.m_BirthTransition;
            }
            FsmString str2 = this.m_FSM.FsmVariables.GetFsmString("SecondBirthTransition");
            if (str2 != null)
            {
                str2.Value = this.m_SecondBirthTransition;
            }
            FsmString str3 = this.m_FSM.FsmVariables.GetFsmString("IdleTransition");
            if (str3 != null)
            {
                str3.Value = this.m_IdleTransition;
            }
            this.m_FSM.SendEvent("Birth");
        }
    }

    private void SendPlaymakerDeathEvent()
    {
        if (this.m_FSM != null)
        {
            FsmString fsmString = this.m_FSM.FsmVariables.GetFsmString("DeathTransition");
            if (fsmString != null)
            {
                fsmString.Value = this.m_DeathTransition;
            }
            this.m_FSM.SendEvent("Death");
        }
    }

    public void SetDirty()
    {
        this.m_isDirty = true;
    }

    private void Setup()
    {
        this.m_seed = UnityEngine.Random.value;
        this.m_CurrentState = ActorStateType.CARD_IDLE;
        this.m_RenderPlane.renderer.enabled = false;
        if (this.m_Material == null)
        {
            Shader shader = Shader.Find(this.HIGHLIGHT_SHADER_NAME);
            if (shader == null)
            {
                Debug.LogError("Failed to load Highlight Shader: " + this.HIGHLIGHT_SHADER_NAME);
                base.enabled = false;
            }
            this.m_Material = new Material(shader);
            this.m_RenderPlane.renderer.sharedMaterial = this.m_Material;
        }
        this.m_RenderPlane.renderer.sharedMaterial = this.m_Material;
    }

    private void Start()
    {
        if (this.m_highlightType == HighlightStateType.NONE)
        {
            Transform parent = base.transform.parent;
            if (parent != null)
            {
                if (parent.GetComponent<ActorStateMgr>() != null)
                {
                    this.m_highlightType = HighlightStateType.CARD;
                }
                else
                {
                    this.m_highlightType = HighlightStateType.HIGHLIGHT;
                }
            }
        }
        if (this.m_highlightType == HighlightStateType.NONE)
        {
            Debug.LogError("m_highlightType is not set!");
            base.enabled = false;
        }
        this.Setup();
    }

    private void Update()
    {
        if ((this.m_isDirty && (this.m_RenderPlane != null)) && this.m_RenderPlane.renderer.enabled)
        {
            this.UpdateSilouette();
            this.m_isDirty = false;
        }
    }

    protected void UpdateSilouette()
    {
        this.RenderSilouette();
    }
}

