using System;
using UnityEngine;

public class DragCardSoundEffects : MonoBehaviour
{
    private const float AIR_SOUND_MAX_VOLUME = 0.5f;
    private const float AIR_SOUND_MOVEMENT_THRESHOLD = 0.92f;
    private const float AIR_SOUND_VOLUME_SPEED = 0.4f;
    private const float AIR_SOUND_VOLUME_VELOCITY_SCALE = 0.5f;
    private const string CARD_MOTION_LOOP_AIR_SOUND = "card_motion_loop_air";
    private const string CARD_MOTION_LOOP_MAGICAL_SOUND = "card_motion_loop_magical";
    private const float DISABLE_VOLUME_FADE_OUT_TIME = 0.2f;
    private AudioSource m_AirSoundLoop;
    private float m_AirVelocity;
    private float m_AirVolume;
    private bool m_Disabled;
    private AudioSource m_MagicalSoundLoop;
    private float m_MagicalVelocity;
    private float m_MagicalVolume;
    private Vector3 m_PreviousPosition;
    private const float MAGICAL_SOUND_FADE_IN_TIME = 0.5f;
    private const float MAGICAL_SOUND_VOLUME = 0.15f;

    private void Awake()
    {
        this.m_PreviousPosition = base.transform.position;
        SoundManager.LoadedCallback callback = delegate (AudioSource source, object userData) {
            if (source != null)
            {
                this.m_AirSoundLoop = source;
            }
        };
        SoundManager.Get().LoadAndPlay("card_motion_loop_air", base.gameObject, 0f, callback);
        SoundManager.LoadedCallback callback2 = delegate (AudioSource source, object userData) {
            if (source != null)
            {
                this.m_MagicalSoundLoop = source;
            }
        };
        SoundManager.Get().LoadAndPlay("card_motion_loop_magical", base.gameObject, 0f, callback2);
    }

    public void Disable()
    {
        this.m_Disabled = true;
    }

    private void DisableThis()
    {
        this.m_MagicalVolume = 0f;
        this.m_AirVolume = 0f;
        this.m_AirVelocity = 0f;
        SoundManager.Get().Stop(this.m_AirSoundLoop);
        SoundManager.Get().Stop(this.m_MagicalSoundLoop);
        base.enabled = false;
    }

    private void OnDestroy()
    {
        SoundManager.Get().Stop(this.m_AirSoundLoop);
        SoundManager.Get().Stop(this.m_MagicalSoundLoop);
    }

    public void Start()
    {
        base.enabled = true;
        this.m_Disabled = false;
    }

    private void Update()
    {
        if ((this.m_AirSoundLoop != null) && (this.m_MagicalSoundLoop != null))
        {
            this.m_MagicalSoundLoop.transform.position = base.transform.position;
            this.m_AirSoundLoop.transform.position = base.transform.position;
            if (this.m_Disabled)
            {
                if ((this.m_AirVolume <= 0f) && (this.m_MagicalVolume <= 0f))
                {
                    this.DisableThis();
                }
                this.m_AirVolume = Mathf.SmoothDamp(this.m_AirVolume, 0f, ref this.m_AirVelocity, 0.2f);
                this.m_MagicalVolume = Mathf.SmoothDamp(this.m_MagicalVolume, 0f, ref this.m_MagicalVelocity, 0.2f);
                SoundManager.Get().SetVolume(this.m_AirSoundLoop, Mathf.Clamp(this.m_AirVolume, 0f, 1f));
                SoundManager.Get().SetVolume(this.m_MagicalSoundLoop, this.m_MagicalVolume);
            }
            else
            {
                if (this.m_MagicalVolume < 0.15f)
                {
                    this.m_MagicalVolume = Mathf.SmoothDamp(this.m_MagicalVolume, 0.15f, ref this.m_MagicalVelocity, 0.5f);
                    SoundManager.Get().SetVolume(this.m_MagicalSoundLoop, this.m_MagicalVolume);
                }
                else if (this.m_MagicalVolume > 0.15f)
                {
                    this.m_MagicalVolume = 0.15f;
                    SoundManager.Get().SetVolume(this.m_MagicalSoundLoop, this.m_MagicalVolume);
                }
                Vector3 position = base.transform.position;
                Vector3 vector2 = position - this.m_PreviousPosition;
                this.m_AirVolume = Mathf.SmoothDamp(this.m_AirVolume, Mathf.Log((vector2.magnitude * 0.5f) + 0.92f), ref this.m_AirVelocity, 0.04f, 1f);
                SoundManager.Get().SetVolume(this.m_AirSoundLoop, Mathf.Clamp(this.m_AirVolume, 0f, 0.5f));
                SoundManager.Get().SetVolume(this.m_MagicalSoundLoop, this.m_MagicalVolume);
                this.m_PreviousPosition = position;
            }
        }
    }
}

