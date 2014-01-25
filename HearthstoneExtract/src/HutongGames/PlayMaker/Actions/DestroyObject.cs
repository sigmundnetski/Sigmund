namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Destroys a Game Object.")]
    public class DestroyObject : FsmStateAction
    {
        [Tooltip("Optional delay before destroying the Game Object."), HasFloatSlider(0f, 5f)]
        public FsmFloat delay;
        [Tooltip("Detach children before destroying the Game Object.")]
        public FsmBool detachChildren;
        [Tooltip("The GameObject to destroy."), RequiredField]
        public FsmGameObject gameObject;

        public override void OnEnter()
        {
            GameObject obj2 = this.gameObject.Value;
            if (obj2 != null)
            {
                if (this.delay.Value <= 0f)
                {
                    UnityEngine.Object.Destroy(obj2);
                }
                else
                {
                    UnityEngine.Object.Destroy(obj2, this.delay.Value);
                }
                if (this.detachChildren.Value)
                {
                    obj2.transform.DetachChildren();
                }
            }
            base.Finish();
        }

        public override void OnUpdate()
        {
        }

        public override void Reset()
        {
            this.gameObject = null;
            this.delay = 0f;
        }
    }
}

