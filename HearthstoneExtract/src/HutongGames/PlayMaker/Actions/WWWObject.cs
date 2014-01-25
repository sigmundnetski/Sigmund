namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Gets data from a url and store it in variables. See Unity WWW docs for more details."), ActionCategory("Web Player")]
    public class WWWObject : FsmStateAction
    {
        [UIHint(UIHint.Variable), Tooltip("Error message if there was an error during the download.")]
        public FsmString errorString;
        [Tooltip("Event to send when the data has finished loading (progress = 1)."), ActionSection("Events")]
        public FsmEvent isDone;
        [Tooltip("Event to send if there was an error.")]
        public FsmEvent isError;
        [Tooltip("How far the download progressed (0-1)."), UIHint(UIHint.Variable)]
        public FsmFloat progress;
        [ObjectType(typeof(MovieTexture)), UIHint(UIHint.Variable), Tooltip("Gets a Texture from the url.")]
        public FsmObject storeMovieTexture;
        [ActionSection("Results"), UIHint(UIHint.Variable), Tooltip("Gets text from the url.")]
        public FsmString storeText;
        [Tooltip("Gets a Texture from the url."), UIHint(UIHint.Variable)]
        public FsmTexture storeTexture;
        [RequiredField, Tooltip("Url to download data from.")]
        public FsmString url;
        private WWW wwwObject;

        public override void OnEnter()
        {
            if (string.IsNullOrEmpty(this.url.Value))
            {
                base.Finish();
            }
            else
            {
                this.wwwObject = new WWW(this.url.Value);
            }
        }

        public override void OnUpdate()
        {
            if (this.wwwObject == null)
            {
                this.errorString.Value = "WWW Object is Null!";
                base.Finish();
            }
            else
            {
                this.errorString.Value = this.wwwObject.error;
                if (!string.IsNullOrEmpty(this.wwwObject.error))
                {
                    base.Finish();
                    base.Fsm.Event(this.isError);
                }
                else
                {
                    this.progress.Value = this.wwwObject.progress;
                    if (this.progress.Value.Equals((float) 1f))
                    {
                        this.storeText.Value = this.wwwObject.text;
                        this.storeTexture.Value = this.wwwObject.texture;
                        this.storeMovieTexture.Value = this.wwwObject.movie;
                        this.errorString.Value = this.wwwObject.error;
                        base.Fsm.Event(!string.IsNullOrEmpty(this.errorString.Value) ? this.isError : this.isDone);
                        base.Finish();
                    }
                }
            }
        }

        public override void Reset()
        {
            this.url = null;
            this.storeText = null;
            this.storeTexture = null;
            this.errorString = null;
            this.progress = null;
            this.isDone = null;
        }
    }
}

