namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [Tooltip("Stops playing the Movie Texture, and rewinds it to the beginning."), ActionCategory(ActionCategory.Movie)]
    public class StopMovieTexture : FsmStateAction
    {
        [RequiredField, ObjectType(typeof(MovieTexture))]
        public FsmObject movieTexture;

        public override void OnEnter()
        {
            MovieTexture texture = this.movieTexture.Value as MovieTexture;
            if (texture != null)
            {
                texture.Stop();
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.movieTexture = null;
        }
    }
}

