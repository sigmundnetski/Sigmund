namespace HutongGames.PlayMaker.Actions
{
    using HutongGames.PlayMaker;
    using System;

    [Tooltip("Select a random Color from an array of Colors."), ActionCategory(ActionCategory.Color)]
    public class SelectRandomColor : FsmStateAction
    {
        [CompoundArray("Colors", "Color", "Weight")]
        public FsmColor[] colors;
        [UIHint(UIHint.Variable), RequiredField]
        public FsmColor storeColor;
        [HasFloatSlider(0f, 1f)]
        public FsmFloat[] weights;

        private void DoSelectRandomColor()
        {
            if (((this.colors != null) && (this.colors.Length != 0)) && (this.storeColor != null))
            {
                int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(this.weights);
                if (randomWeightedIndex != -1)
                {
                    this.storeColor.Value = this.colors[randomWeightedIndex].Value;
                }
            }
        }

        public override void OnEnter()
        {
            this.DoSelectRandomColor();
            base.Finish();
        }

        public override void Reset()
        {
            this.colors = new FsmColor[3];
            this.weights = new FsmFloat[] { 1f, 1f, 1f };
            this.storeColor = null;
        }
    }
}

