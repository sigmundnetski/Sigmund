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
    internal class MedicSettings : OmnibusSettings
    {
        public MedicSettings(string filename = "Medic-Settings")
            : base(filename)
        {
        }

        #region Healing 
        [Setting, Category("Healing")]
        [DisplayName("Crisis Wave HP Percent"), Description("")]
        [DefaultValue(60)]
        public float CrisisWaveHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Dual Shock HP Percent"), Description("")]
        [DefaultValue(60)]
        public float DualShockHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Mending Probes HP Percent"), Description("")]
        [DefaultValue(60)]
        public float MendingProbesHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Triage HP Percent"), Description("")]
        [DefaultValue(60)]
        public float TriageHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Triage SP Percent"), Description("")]
        [DefaultValue(60)]
        public float TriageSPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Flash HP Percent"), Description("")]
        [DefaultValue(60)]
        public float FlashHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Barrier HP Percent"), Description("")]
        [DefaultValue(60)]
        public float BarrierHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Barrier SP Percent"), Description("")]
        [DefaultValue(60)]
        public float BarrierSPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Rejuvenator HP Percent"), Description("")]
        [DefaultValue(60)]
        public float RejuvenatorHPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Shield Surge SP Percent"), Description("")]
        [DefaultValue(60)]
        public float ShieldSurgeSPPercent { get; set; }

        [Setting, Category("Healing")]
        [DisplayName("Extricate HP Percent"), Description("")]
        [DefaultValue(60)]
        public float ExtricateHPPercent { get; set; }
        #endregion 
    }
}
