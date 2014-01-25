namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;
    using UnityEngine;

    [ActionCategory(ActionCategory.GameObject), Tooltip("Finds a Game Object by Name and/or Tag.")]
    public class FindGameObject : FsmStateAction
    {
        [Tooltip("The name of the GameObject to find. You can leave this empty if you specify a Tag.")]
        public FsmString objectName;
        [Tooltip("Store the result in a GameObject variable."), UIHint(UIHint.Variable), RequiredField]
        public FsmGameObject store;
        [Tooltip("Find a GameObject with this tag. If Object Name is specified then both name and Tag must match."), UIHint(UIHint.Tag)]
        public FsmString withTag;

        public override string ErrorCheck()
        {
            if (string.IsNullOrEmpty(this.objectName.Value) && string.IsNullOrEmpty(this.withTag.Value))
            {
                return "Specify Name, Tag, or both.";
            }
            return null;
        }

        public override void OnEnter()
        {
            base.Finish();
            if (this.withTag.Value != "Untagged")
            {
                if (!string.IsNullOrEmpty(this.objectName.Value))
                {
                    foreach (GameObject obj2 in GameObject.FindGameObjectsWithTag(this.withTag.Value))
                    {
                        if (obj2.name == this.objectName.Value)
                        {
                            this.store.Value = obj2;
                            return;
                        }
                    }
                    this.store.Value = null;
                }
                else
                {
                    this.store.Value = GameObject.FindGameObjectWithTag(this.withTag.Value);
                }
            }
            else
            {
                this.store.Value = GameObject.Find(this.objectName.Value);
            }
        }

        public override void Reset()
        {
            this.objectName = string.Empty;
            this.withTag = "Untagged";
            this.store = null;
        }
    }
}

