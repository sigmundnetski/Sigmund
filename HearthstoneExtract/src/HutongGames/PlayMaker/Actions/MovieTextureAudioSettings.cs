namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Movie), Tooltip("Sets the Game Object as the Audio Source associated with the Movie Texture. The Game Object must have an AudioSource Component.")]
    public class MovieTextureAudioSettings : FsmStateAction
    {
        [CheckForComponent(typeof(AudioSource)), RequiredField]
        public FsmGameObject gameObject;
        [RequiredField, ObjectType(typeof(MovieTexture))]
        public FsmObject movieTexture;

        public override void OnEnter()
        {
            MovieTexture texture = this.movieTexture.Value as MovieTexture;
            if ((texture != null) && (this.gameObject.Value != null))
            {
                AudioSource audio = this.gameObject.Value.audio;
                if (audio != null)
                {
                    audio.clip = texture.audioClip;
                }
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.movieTexture = null;
            this.gameObject = null;
        }
    }
}

