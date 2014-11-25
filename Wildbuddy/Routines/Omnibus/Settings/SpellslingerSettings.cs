using Buddy.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omnibus.Settings
{
    internal class SpellslingerSettings : OmnibusSettings
    {
        public SpellslingerSettings(string filename = "Spellslinger-Settings")
            : base(filename)
        {
        }

        #region Healing
        [Setting, Category("Healing")]
        [DisplayName("Runic Healing HP Percent"), Description("")]
        [DefaultValue(60)]
        public float RunicHealingHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Runes of Protection SP Percent"), Description("")]
        [DefaultValue(60)]
        public float RunesOfProtectionSPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Vitality Burst HP Percent"), Description("")]
        [DefaultValue(60)]
        public float VitalityBurstHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Astral Infusion HP Percent"), Description("")]
        [DefaultValue(60)]
        public float AstralInfusionHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Dual Fire HP Percent"), Description("")]
        [DefaultValue(60)]
        public float DualFireHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Healing Torrent HP Percent"), Description("")]
        [DefaultValue(60)]
        public float HealingTorrentHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Void Spring HP Percent"), Description("")]
        [DefaultValue(60)]
        public float VoidSpringHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Regenerative Pulse HP Percent"), Description("")]
        [DefaultValue(60)]
        public float RegenerativePulseHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Purify HP Percent"), Description("")]
        [DefaultValue(60)]
        public float PurifyHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Sustain HP Percent"), Description("")]
        [DefaultValue(60)]
        public float SustainHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Affinity HP Percent"), Description("")]
        [DefaultValue(60)]
        public float AffinityHPPercent { get; set; }
        #endregion 
    }
}
