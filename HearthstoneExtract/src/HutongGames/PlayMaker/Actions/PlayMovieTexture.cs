namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.Movie), Tooltip("Plays a Movie Texture. Use the Movie Texture in a Material, or in the GUI.")]
    public class PlayMovieTexture : FsmStateAction
    {
        public FsmBool loop;
        [ObjectType(typeof(MovieTexture)), RequiredField]
        public FsmObject movieTexture;

        public override void OnEnter()
        {
            MovieTexture texture = this.movieTexture.Value as MovieTexture;
            if (texture != null)
            {
                texture.loop = this.loop.Value;
                texture.Play();
            }
            base.Finish();
        }

        public override void Reset()
        {
            this.movieTexture = null;
            this.loop = 0;
        }
    }
}

