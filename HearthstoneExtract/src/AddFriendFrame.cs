using System;
using UnityEngine;

public class AddFriendFrame : MonoBehaviour
{
    public AddFriendFrameBones m_Bones;
    public FriendListUIElement m_CloseButton;
    private FriendListFrame m_friendListFrame;
    public UberText m_HeaderText;
    private PegUIElement m_inputBlocker;
    public UberText m_InstructionText;

    private void Awake()
    {
        this.InitItems();
        this.Layout();
        this.ShowTextInput();
    }

    public void Close()
    {
        UniversalInputManager.Get().CancelTextInputBox(base.gameObject);
        UnityEngine.Object.Destroy(base.gameObject);
    }

    public FriendListFrame GetFriendList()
    {
        return this.m_friendListFrame;
    }

    private void InitInputBlocker()
    {
        GameObject obj2 = CameraUtils.CreateInputBlocker(CameraUtils.FindFirstByLayer(base.gameObject.layer));
        obj2.name = "AddFriendInputBlocker";
        obj2.transform.parent = base.transform;
        obj2.transform.position = this.m_Bones.m_InputBlocker.position;
        this.m_inputBlocker = obj2.AddComponent<PegUIElement>();
        this.m_inputBlocker.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnInputBlockerReleased));
    }

    private void InitItems()
    {
        this.m_HeaderText.Text = GameStrings.Get("GLOBAL_ADDFRIEND_HEADER");
        this.m_InstructionText.Text = GameStrings.Get("GLOBAL_ADDFRIEND_INSTRUCTION");
        this.m_CloseButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnCloseButtonPressed));
        this.InitInputBlocker();
    }

    private void Layout()
    {
        base.transform.parent = BaseUI.Get().transform;
        base.transform.position = BaseUI.Get().GetAddFriendBone().position;
    }

    private void OnCloseButtonPressed(UIEvent e)
    {
        this.m_friendListFrame.OnAddFriendFrameClosed();
    }

    private void OnDestroy()
    {
        UniversalInputManager.Get().CancelTextInputBox(base.gameObject);
    }

    private void OnInputBlockerReleased(UIEvent e)
    {
        this.m_friendListFrame.OnAddFriendFrameClosed();
    }

    private void OnInputCanceled()
    {
        this.m_friendListFrame.OnAddFriendFrameClosed();
    }

    private void OnInputComplete(string input)
    {
        input = input.Trim();
        if (input.Contains("@"))
        {
            BnetFriendMgr.Get().SendInviteByEmail(input);
        }
        else if (input.Contains("#"))
        {
            BnetFriendMgr.Get().SendInviteByBattleTag(input);
        }
        else
        {
            string message = GameStrings.Get("GLOBAL_ADDFRIEND_ERROR_MALFORMED");
            UIStatus.Get().AddError(message);
        }
        this.m_friendListFrame.OnAddFriendFrameClosed();
    }

    private void OnInputUpdated(string input)
    {
        this.UpdateInstructions();
    }

    public void SetFriendList(FriendListFrame frame)
    {
        this.m_friendListFrame = frame;
    }

    private void ShowTextInput()
    {
        Rect rect = CameraUtils.CreateGUIViewportRect(BaseUI.Get().GetBnetDialogCamera(), this.m_Bones.m_InputTopLeft, this.m_Bones.m_InputBottomRight);
        UniversalInputManager.Get().UseTextInputBox(base.gameObject, rect, new UniversalInputManager.InputUpdatedCallback(this.OnInputUpdated), new UniversalInputManager.InputCompletedCallback(this.OnInputComplete), new UniversalInputManager.InputCanceledCallback(this.OnInputCanceled), -1, this.m_InstructionText.TrueTypeFont);
        this.UpdateInstructions();
    }

    private void UpdateInstructions()
    {
        bool enable = string.IsNullOrEmpty(UniversalInputManager.Get().GetText());
        SceneUtils.EnableRenderers(this.m_InstructionText, enable);
    }

    public void UpdateLayout()
    {
        this.Layout();
    }
}

