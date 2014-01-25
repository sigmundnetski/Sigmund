namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Pauses a Movie Texture."), ActionCategory(ActionCategory.Movie)]
    public class PauseMovieTexture : FsmStateAction
    {
        [ObjectType(typeof(MovieTexture)), RequiredField]
        public FsmObject movieTexture;

        public override void OnEnter()
        {
            MovieTexture texture = this.movieTexture.Value as MovieTexture;
            if (texture != null)
            {
                texture.Pause();
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.movieTexture = null;
        }
    }
}

