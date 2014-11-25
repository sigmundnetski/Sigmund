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
    internal class EngineerSettings : OmnibusSettings
    {
        public EngineerSettings(string filename = "Engineer-Settings")
            : base(filename)
        {
        }

        #region Combat
        [Setting, Category("Combat")]
        [DisplayName("Pulse Blast Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float PulseBlastIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Electrocute Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float ElectrocuteIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Energy Auger Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float EnergyAugerIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Mortar Strike Innate Percent"), Description("")]
        [DefaultValue(50)]
        public float MortarStrikeIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Target Acquisition Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float TargetAquisitionIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Bolt Caster Innate Percent"), Description("")]
        [DefaultValue(25)]
        public float BoltCasterIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Bruiserbot Surrounding Amount"), Description("")]
        [DefaultValue(1)]
        public float BruiserbotSurroundAmount { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Flak Cannon Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float FlakCannonIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Ricochet Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float RicochetIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Disruptive Module Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float DisruptiveModuleIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Disruptive Module Shield Percent"), Description("")]
        [DefaultValue(50)]
        public float DisruptiveModuleSPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Shock Pulse Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float ShockPulseIPercent { get; set; }

        [Setting, Category("Combat")]
        [DisplayName("Volatile Injection Innate Percent"), Description("")]
        [DefaultValue(90)]
        public float VolatileInjectionIPercent { get; set; }
        #endregion

        #region Tank 

        [Setting, Category("Tank")]
        [DisplayName("Recursive Matrix Surrounding Amount"), Description("")]
        [DefaultValue(1)]
        public float RecursiveMatrixSurroundAmount { get; set; }

        [Setting, Category("Tank")]
        [DisplayName("Repairbot Shield Percent"), Description("")]
        [DefaultValue(50)]
        public float RepairbotSPercent { get; set; }
        #endregion 
    }
}
