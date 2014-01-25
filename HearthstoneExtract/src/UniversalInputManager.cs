using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class UniversalInputManager : MonoBehaviour
{
    public static readonly PlatformDependentValue<bool> IsTouchDevice;
    private Font m_defaultInputFont;
    private InputFinishReason m_finishedInputReason;
    private bool m_gameDialogActive;
    public GUISkin m_GuiSkin;
    private bool m_handleInputFinished;
    private bool m_initiallyFocusedInput;
    private bool m_inputActive;
    private InputCanceledCallback m_inputCanceledCallback;
    private InputCompletedCallback m_inputCompletedCallback;
    private bool m_inputFocused;
    private Font m_inputFont;
    private int m_inputMaxCharacters;
    private GameObject m_inputOwner;
    private InputUpdatedCallback m_inputUpdatedCallback;
    private Dictionary<GameLayer, int> m_layerPriorityMap;
    private List<MouseOnOrOffScreenCallback> m_mouseOnOrOffScreenListeners = new List<MouseOnOrOffScreenCallback>();
    private bool m_mouseOnScreen;
    private int m_offCameraRaycastMask;
    private bool m_systemDialogActive;
    private string m_text;
    private Vector2 m_textInitialScreenSize;
    private Rect m_textNormalizedRect;
    private static UniversalInputManager s_instance;
    private static readonly List<GameLayer> s_layerPriorityOrder = new List<GameLayer> { 13, 0x10, 0x13, 0x12, 0x18, 0x19, 0x1a, 0x11 };
    private const TextAnchor TEXT_ALIGNMENT = TextAnchor.MiddleLeft;
    private const string TEXT_CONTROL_NAME = "UniversalInputManagerTextInput";
    private const int TEXT_MAX_FONT_SIZE = 0x20;
    private const int TEXT_PADDING = 1;

    static UniversalInputManager()
    {
        PlatformDependentValue<bool> value2 = new PlatformDependentValue<bool>(PlatformCategory.Input) {
            Mouse = false,
            Touch = true
        };
        IsTouchDevice = value2;
    }

    private void Awake()
    {
        s_instance = this;
        if (this.m_GuiSkin != null)
        {
            this.m_defaultInputFont = this.m_GuiSkin.textField.font;
        }
        this.m_mouseOnScreen = InputUtil.IsMouseOnScreen();
        this.CreateLayerPriorityMap();
    }

    private void CancelTextInput()
    {
        InputCanceledCallback inputCanceledCallback = this.m_inputCanceledCallback;
        this.ClearTextInputVars();
        if (inputCanceledCallback != null)
        {
            inputCanceledCallback();
        }
    }

    public void CancelTextInputBox(GameObject owningGameObj)
    {
        if (this.m_inputOwner == owningGameObj)
        {
            this.CancelTextInput();
        }
    }

    public bool CanRaycastOffCamera(GameLayer layer)
    {
        return this.CanRaycastOffCamera(layer.LayerBit());
    }

    public bool CanRaycastOffCamera(LayerMask layerMask)
    {
        return ((this.m_offCameraRaycastMask & layerMask) != 0);
    }

    private void ClearTextInputVars()
    {
        this.m_inputActive = false;
        this.m_inputFocused = false;
        this.m_inputOwner = null;
        this.m_inputMaxCharacters = 0;
        this.m_inputUpdatedCallback = null;
        this.m_inputCompletedCallback = null;
        this.m_inputCanceledCallback = null;
        this.m_inputFont = null;
        this.m_handleInputFinished = false;
    }

    private void CompleteTextInput()
    {
        InputCompletedCallback inputCompletedCallback = this.m_inputCompletedCallback;
        this.ClearTextInputVars();
        if (inputCompletedCallback != null)
        {
            inputCompletedCallback(this.m_text);
        }
    }

    private int ComputeTextInputFontSize(Vector2 screenSize, float rectHeight)
    {
        if (rectHeight >= 32f)
        {
            return 0x20;
        }
        if (rectHeight <= 1f)
        {
            return 1;
        }
        return (0x20 / Mathf.CeilToInt(32f / rectHeight));
    }

    private Rect ComputeTextInputRect(Vector2 screenSize)
    {
        float num = screenSize.x / screenSize.y;
        float num2 = this.m_textInitialScreenSize.x / this.m_textInitialScreenSize.y;
        float num3 = num2 / num;
        float num4 = screenSize.y / this.m_textInitialScreenSize.y;
        float num5 = (0.5f - this.m_textNormalizedRect.x) * this.m_textInitialScreenSize.x;
        float num6 = num5 * num4;
        return new Rect((screenSize.x * 0.5f) - num6, this.m_textNormalizedRect.y * screenSize.y, (this.m_textNormalizedRect.width * screenSize.x) * num3, this.m_textNormalizedRect.height * screenSize.y);
    }

    private void CreateLayerPriorityMap()
    {
        this.m_layerPriorityMap = new Dictionary<GameLayer, int>();
        int num = 1;
        for (int i = 0; i < s_layerPriorityOrder.Count; i++)
        {
            GameLayer layer = s_layerPriorityOrder[i];
            this.m_layerPriorityMap[layer] = num++;
        }
        IEnumerator enumerator = Enum.GetValues(typeof(GameLayer)).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                GameLayer current = (GameLayer) ((int) enumerator.Current);
                if (!s_layerPriorityOrder.Contains(current))
                {
                    this.m_layerPriorityMap.Add(current, 0);
                }
            }
        }
        finally
        {
            IDisposable disposable = enumerator as IDisposable;
            if (disposable == null)
            {
            }
            disposable.Dispose();
        }
    }

    public void EnableRaycastOffCamera(GameLayer layer, bool enable)
    {
        this.EnableRaycastOffCamera(layer.LayerBit(), enable);
    }

    public void EnableRaycastOffCamera(LayerMask mask, bool enable)
    {
        if (enable)
        {
            this.m_offCameraRaycastMask |= mask;
        }
        else
        {
            this.m_offCameraRaycastMask &= ~mask;
        }
    }

    private bool FilteredRaycast(Camera camera, Vector3 screenPoint, LayerMask mask, out RaycastHit hitInfo)
    {
        if (this.CanRaycastOffCamera(mask))
        {
            if (!Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hitInfo, camera.farClipPlane, (int) mask))
            {
                return false;
            }
        }
        else if (!CameraUtils.Raycast(camera, Input.mousePosition, mask, out hitInfo))
        {
            return false;
        }
        return true;
    }

    private Camera FindBestCameraForRaycast(Camera requestedCamera, ref LayerMask mask)
    {
        Camera camera = this.FindUIOverlayCameraForRaycast(requestedCamera, mask);
        if (camera != null)
        {
            return camera;
        }
        Camera camera2 = CameraUtils.FindFullScreenEffectsCamera(true);
        if (camera2 != null)
        {
            mask = GameLayer.IgnoreFullScreenEffects.LayerBit();
            return camera2;
        }
        if (requestedCamera != null)
        {
            return requestedCamera;
        }
        return Camera.main;
    }

    private Camera FindUIOverlayCameraForRaycast(Camera requestedCamera, LayerMask mask)
    {
        if ((mask & PegUI.UI_OVERLAY_BIT_MASK) != 0)
        {
            Camera camera = CameraUtils.FindFirstByLayerMask(mask);
            if (camera != null)
            {
                return camera;
            }
        }
        return null;
    }

    public static UniversalInputManager Get()
    {
        return s_instance;
    }

    private LayerMask GetHigherPriorityLayerMask(GameLayer layer)
    {
        int num = this.m_layerPriorityMap[layer];
        LayerMask mask = 0;
        foreach (KeyValuePair<GameLayer, int> pair in this.m_layerPriorityMap)
        {
            GameLayer key = pair.Key;
            if (pair.Value > num)
            {
                mask |= key.LayerBit();
            }
        }
        return mask;
    }

    public bool GetInputHitInfo(out RaycastHit hitInfo)
    {
        return this.GetInputHitInfo(GameLayer.Default.LayerBit(), out hitInfo);
    }

    public bool GetInputHitInfo(LayerMask layerMask, out RaycastHit hitInfo)
    {
        return this.GetInputHitInfo(null, layerMask, out hitInfo);
    }

    public bool GetInputHitInfo(Camera requestedCamera, LayerMask layerMask, out RaycastHit hitInfo)
    {
        return this.Raycast(requestedCamera, layerMask, out hitInfo);
    }

    public bool GetInputPointOnPlane(Vector3 origin, out Vector3 point)
    {
        return this.GetInputPointOnPlane(GameLayer.Default, origin, out point);
    }

    public bool GetInputPointOnPlane(GameLayer layer, Vector3 origin, out Vector3 point)
    {
        float num;
        point = Vector3.zero;
        LayerMask mask = layer.LayerBit();
        Camera camera = this.FindBestCameraForRaycast(null, ref mask);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        Vector3 inNormal = -camera.transform.forward;
        Plane plane = new Plane(inNormal, origin);
        if (!plane.Raycast(ray, out num))
        {
            return false;
        }
        if (this.HigherPriorityCollisionExists(layer))
        {
            return false;
        }
        point = ray.GetPoint(num);
        return true;
    }

    public string GetKeyboardInput(string originalString, out bool terminatedViaEnter)
    {
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            terminatedViaEnter = true;
            return originalString;
        }
        terminatedViaEnter = false;
        string inputString = Input.inputString;
        string str2 = !string.IsNullOrEmpty(originalString) ? originalString : string.Empty;
        foreach (char ch in inputString)
        {
            switch (ch)
            {
                case '\b':
                    if (str2.Length != 0)
                    {
                        str2 = str2.Substring(0, str2.Length - 1);
                    }
                    break;

                case '\n':
                case '\r':
                    break;

                default:
                    str2 = str2 + ch;
                    break;
            }
        }
        return str2;
    }

    public string GetText()
    {
        return this.m_text;
    }

    private bool HigherPriorityCollisionExists(GameLayer layer)
    {
        if (this.m_systemDialogActive && (this.m_layerPriorityMap[layer] < this.m_layerPriorityMap[GameLayer.SystemDialog]))
        {
            return true;
        }
        if (this.m_gameDialogActive && (this.m_layerPriorityMap[layer] < this.m_layerPriorityMap[GameLayer.GameDialog]))
        {
            return true;
        }
        LayerMask higherPriorityLayerMask = this.GetHigherPriorityLayerMask(layer);
        foreach (Camera camera in Camera.allCameras)
        {
            RaycastHit hit;
            if (((camera.cullingMask & higherPriorityLayerMask) != 0) && this.FilteredRaycast(camera, Input.mousePosition, higherPriorityLayerMask, out hit))
            {
                GameLayer gameLayer = (GameLayer) hit.collider.gameObject.layer;
                if ((camera.cullingMask & gameLayer.LayerBit()) != 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool InputHitAnyObject(LayerMask layerMask)
    {
        RaycastHit hit;
        return this.GetInputHitInfo(layerMask, out hit);
    }

    public bool InputIsOver(GameObject gameObj)
    {
        RaycastHit hit;
        return this.InputIsOver(gameObj, out hit);
    }

    public bool InputIsOver(GameObject gameObj, out RaycastHit hitInfo)
    {
        LayerMask layerMask = ((GameLayer) gameObj.layer).LayerBit();
        if (!this.Raycast(null, layerMask, out hitInfo))
        {
            return false;
        }
        return (hitInfo.collider.gameObject == gameObj);
    }

    public bool IsMouseOnScreen()
    {
        return this.m_mouseOnScreen;
    }

    public bool IsTextInputBoxActive()
    {
        return this.m_inputActive;
    }

    private void OnGUI()
    {
        if (this.m_inputActive)
        {
            this.UpdateTextInput();
        }
    }

    private void ProcessKeyboardInput()
    {
        if (!this.ProcessTextKeyboardInput())
        {
            InputManager manager = InputManager.Get();
            if ((manager == null) || !manager.HandleKeyboardInput())
            {
                CheatMgr mgr = CheatMgr.Get();
                if ((mgr == null) || !mgr.HandleKeyboardInput())
                {
                    StoreManager manager2 = StoreManager.Get();
                    if ((manager2 == null) || !manager2.HandleKeyboardInput())
                    {
                        CollectionInputMgr mgr2 = CollectionInputMgr.Get();
                        if ((mgr2 == null) || !mgr2.HandleKeyboardInput())
                        {
                            BaseUI eui = BaseUI.Get();
                            if ((eui != null) && eui.HandleKeyboardInput())
                            {
                            }
                        }
                    }
                }
            }
        }
    }

    private bool ProcessTextKeyboardInput()
    {
        if (this.m_inputActive)
        {
            return this.m_inputFocused;
        }
        if (!this.m_handleInputFinished)
        {
            return false;
        }
        if (this.m_finishedInputReason == InputFinishReason.CANCEL)
        {
            this.CancelTextInput();
        }
        else
        {
            this.CompleteTextInput();
        }
        return true;
    }

    private bool Raycast(Camera requestedCamera, LayerMask layerMask, out RaycastHit hitInfo)
    {
        hitInfo = new RaycastHit();
        Camera camera = this.FindBestCameraForRaycast(requestedCamera, ref layerMask);
        if (camera == null)
        {
            return false;
        }
        if (!this.FilteredRaycast(camera, Input.mousePosition, layerMask, out hitInfo))
        {
            return false;
        }
        GameLayer layer = (GameLayer) hitInfo.collider.gameObject.layer;
        if (this.HigherPriorityCollisionExists(layer))
        {
            return false;
        }
        return true;
    }

    public bool RegisterMouseOnOrOffScreenListener(MouseOnOrOffScreenCallback listener)
    {
        if (this.m_mouseOnOrOffScreenListeners.Contains(listener))
        {
            return false;
        }
        this.m_mouseOnOrOffScreenListeners.Add(listener);
        return true;
    }

    public void SetGameDialogActive(bool active)
    {
        this.m_gameDialogActive = active;
    }

    public void SetSystemDialogActive(bool active)
    {
        this.m_systemDialogActive = active;
    }

    public void SetText(string text)
    {
        this.m_text = text;
    }

    private void SetupTextInput(Vector2 screenSize, Rect inputScreenRect)
    {
        GUI.skin = this.m_GuiSkin;
        if (this.m_inputFont == null)
        {
            GUI.skin.textField.font = this.m_defaultInputFont;
        }
        else
        {
            GUI.skin.textField.font = this.m_inputFont;
        }
        int num = this.ComputeTextInputFontSize(screenSize, inputScreenRect.height);
        GUI.skin.textField.fontSize = num;
        GUI.SetNextControlName("UniversalInputManagerTextInput");
    }

    public bool UnregisterMouseOnOrOffScreenListener(MouseOnOrOffScreenCallback listener)
    {
        return this.m_mouseOnOrOffScreenListeners.Remove(listener);
    }

    private void Update()
    {
        this.UpdateMouseOnOrOffScreen();
        this.ProcessKeyboardInput();
    }

    private void UpdateMouseOnOrOffScreen()
    {
        bool onScreen = InputUtil.IsMouseOnScreen();
        if (onScreen != this.m_mouseOnScreen)
        {
            this.m_mouseOnScreen = onScreen;
            foreach (MouseOnOrOffScreenCallback callback in this.m_mouseOnOrOffScreenListeners.ToArray())
            {
                callback(onScreen);
            }
        }
    }

    private void UpdateTextInput()
    {
        string str;
        if (Event.current.type == EventType.KeyDown)
        {
            switch (Event.current.keyCode)
            {
                case KeyCode.KeypadEnter:
                case KeyCode.Return:
                    this.m_inputActive = false;
                    this.m_handleInputFinished = true;
                    this.m_finishedInputReason = InputFinishReason.COMPLETE;
                    return;

                case KeyCode.Escape:
                    this.m_inputActive = false;
                    this.m_handleInputFinished = true;
                    this.m_finishedInputReason = InputFinishReason.CANCEL;
                    return;
            }
        }
        Vector2 screenSize = new Vector2((float) Screen.width, (float) Screen.height);
        Rect inputScreenRect = this.ComputeTextInputRect(screenSize);
        this.SetupTextInput(screenSize, inputScreenRect);
        if (this.m_inputMaxCharacters <= 0)
        {
            str = GUI.TextField(inputScreenRect, this.m_text);
        }
        else
        {
            str = GUI.TextField(inputScreenRect, this.m_text, this.m_inputMaxCharacters);
        }
        if (this.m_initiallyFocusedInput)
        {
            this.m_inputFocused = GUI.GetNameOfFocusedControl() == "UniversalInputManagerTextInput";
            if (!this.m_inputFocused)
            {
                return;
            }
        }
        else
        {
            GUI.FocusControl("UniversalInputManagerTextInput");
            this.m_initiallyFocusedInput = true;
        }
        if (this.m_text != str)
        {
            this.m_text = str;
            if (this.m_inputUpdatedCallback != null)
            {
                this.m_inputUpdatedCallback(str);
            }
        }
    }

    public void UpdateTextInputBoxRect(GameObject owner, Rect rect)
    {
        if (owner == this.m_inputOwner)
        {
            this.m_textNormalizedRect = rect;
            this.m_textInitialScreenSize.x = Screen.width;
            this.m_textInitialScreenSize.y = Screen.height;
        }
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputCompletedCallback completedCallback)
    {
        this.UseTextInputBox(owner, rect, null, completedCallback, null, 0);
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputCompletedCallback completedCallback, int maxCharacters)
    {
        this.UseTextInputBox(owner, rect, null, completedCallback, null, maxCharacters);
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputCompletedCallback completedCallback, int maxCharacters, Font font)
    {
        this.UseTextInputBox(owner, rect, null, completedCallback, null, maxCharacters, font);
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputUpdatedCallback updatedCallback, InputCompletedCallback completedCallback, InputCanceledCallback canceledCallback)
    {
        this.UseTextInputBox(owner, rect, updatedCallback, completedCallback, canceledCallback, 0);
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputUpdatedCallback updatedCallback, InputCompletedCallback completedCallback, InputCanceledCallback canceledCallback, int maxCharacters)
    {
        this.UseTextInputBox(owner, rect, updatedCallback, completedCallback, canceledCallback, maxCharacters, null);
    }

    public void UseTextInputBox(GameObject owner, Rect rect, InputUpdatedCallback updatedCallback, InputCompletedCallback completedCallback, InputCanceledCallback canceledCallback, int maxCharacters, Font font)
    {
        if (this.m_inputOwner != null)
        {
            this.CancelTextInput();
        }
        this.m_inputActive = true;
        this.m_inputFocused = false;
        this.m_text = string.Empty;
        this.m_textNormalizedRect = rect;
        this.m_textInitialScreenSize.x = Screen.width;
        this.m_textInitialScreenSize.y = Screen.height;
        this.m_inputMaxCharacters = maxCharacters;
        this.m_inputOwner = owner;
        this.m_inputUpdatedCallback = updatedCallback;
        this.m_inputCompletedCallback = completedCallback;
        this.m_inputCanceledCallback = canceledCallback;
        this.m_inputFont = font;
        this.m_initiallyFocusedInput = false;
        this.m_handleInputFinished = false;
        this.m_finishedInputReason = InputFinishReason.INVALID;
    }

    public delegate void InputCanceledCallback();

    public delegate void InputCompletedCallback(string input);

    private enum InputFinishReason
    {
        INVALID,
        COMPLETE,
        CANCEL
    }

    public delegate void InputUpdatedCallback(string input);

    public delegate void MouseOnOrOffScreenCallback(bool onScreen);
}

