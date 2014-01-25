using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

public class RadioButtonGroup : MonoBehaviour
{
    public GameObject m_buttonContainer;
    private DelButtonSelected m_buttonSelectedCB;
    public FramedRadioButton m_framedRadioButtonPrefab;
    private List<FramedRadioButton> m_framedRadioButtons = new List<FramedRadioButton>();

    private FramedRadioButton CreateNewFramedRadioButton()
    {
        FramedRadioButton button = (FramedRadioButton) UnityEngine.Object.Instantiate(this.m_framedRadioButtonPrefab);
        button.transform.parent = this.m_buttonContainer.transform;
        button.transform.localPosition = Vector3.zero;
        button.transform.localScale = Vector3.one;
        button.transform.localRotation = Quaternion.identity;
        button.m_radioButton.AddEventListener(UIEventType.RELEASE, new UIEvent.Handler(this.OnRadioButtonReleased));
        return button;
    }

    public void Hide()
    {
        this.m_buttonContainer.SetActive(false);
    }

    private void OnRadioButtonReleased(UIEvent e)
    {
        RadioButton element = e.GetElement() as RadioButton;
        if (element == null)
        {
            Debug.LogWarning(string.Format("RadioButtonGroup.OnRadioButtonReleased(): UIEvent {0} source is not a RadioButton!", e));
        }
        else
        {
            foreach (FramedRadioButton button2 in this.m_framedRadioButtons)
            {
                RadioButton radioButton = button2.m_radioButton;
                bool selected = element == radioButton;
                radioButton.SetSelected(selected);
            }
            if (this.m_buttonSelectedCB != null)
            {
                this.m_buttonSelectedCB(element.GetButtonID(), element.GetUserData());
            }
        }
    }

    public void ShowButtons(List<ButtonData> buttonData, DelButtonSelected buttonSelectedCallback)
    {
        this.m_buttonContainer.SetActive(true);
        int count = buttonData.Count;
        while (this.m_framedRadioButtons.Count > count)
        {
            FramedRadioButton button = this.m_framedRadioButtons[0];
            this.m_framedRadioButtons.RemoveAt(0);
            UnityEngine.Object.DestroyImmediate(button);
        }
        bool flag = 1 == count;
        this.m_buttonContainer.transform.localPosition = Vector3.zero;
        Vector3 position = this.m_buttonContainer.transform.position;
        Vector3 vector2 = position;
        float num2 = 0f;
        RadioButton radioButton = null;
        for (int i = 0; i < count; i++)
        {
            FramedRadioButton button3;
            FramedRadioButton.FrameType sINGLE;
            if (this.m_framedRadioButtons.Count > i)
            {
                button3 = this.m_framedRadioButtons[i];
            }
            else
            {
                button3 = this.CreateNewFramedRadioButton();
                this.m_framedRadioButtons.Add(button3);
            }
            if (flag)
            {
                sINGLE = FramedRadioButton.FrameType.SINGLE;
            }
            else if (i == 0)
            {
                sINGLE = FramedRadioButton.FrameType.MULTI_LEFT_END;
            }
            else if ((count - 1) == i)
            {
                sINGLE = FramedRadioButton.FrameType.MULTI_RIGHT_END;
            }
            else
            {
                sINGLE = FramedRadioButton.FrameType.MULTI_MIDDLE;
            }
            ButtonData data = buttonData[i];
            button3.Show();
            button3.Init(sINGLE, data.m_text, data.m_id, data.m_userData);
            if (data.m_selected)
            {
                if (radioButton != null)
                {
                    Debug.LogWarning("RadioButtonGroup.WaitThenShowButtons(): more than one button was set as selected. Selecting the FIRST provided option.");
                    button3.m_radioButton.SetSelected(false);
                }
                else
                {
                    radioButton = button3.m_radioButton;
                    radioButton.SetSelected(true);
                }
            }
            else
            {
                button3.m_radioButton.SetSelected(false);
            }
            Bounds bounds = button3.GetBounds();
            Vector3 vector3 = vector2;
            vector3.x -= button3.GetLeftEdgeOffset();
            button3.transform.position = vector3;
            vector2.x += bounds.size.x;
            num2 += bounds.size.x;
        }
        position.x -= num2 / 2f;
        this.m_buttonContainer.transform.position = position;
        this.m_buttonSelectedCB = buttonSelectedCallback;
        if ((radioButton != null) && (this.m_buttonSelectedCB != null))
        {
            this.m_buttonSelectedCB(radioButton.GetButtonID(), radioButton.GetUserData());
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ButtonData
    {
        public int m_id;
        public string m_text;
        public bool m_selected;
        public object m_userData;
        public ButtonData(int id, string text, object userData, bool selected)
        {
            this.m_id = id;
            this.m_text = text;
            this.m_userData = userData;
            this.m_selected = selected;
        }
    }

    public delegate void DelButtonSelected(int buttonID, object userData);
}

