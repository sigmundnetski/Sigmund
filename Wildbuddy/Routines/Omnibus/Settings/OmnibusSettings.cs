using Buddy.Common;
using Buddy.Wildstar.Engine;
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
    public class OmnibusSettings : JsonSettings
    {
        private static OmnibusSettings _instance;

        public static OmnibusSettings Instance
        {
            get { return _instance ?? (_instance = new OmnibusSettings("Omnibus-Settings")); }
        }


        public OmnibusSettings(string filename)
            : base(Path.Combine("Settings", filename + ".json"))
        {
        }


        [Setting]
        [DefaultValue(true)]
        public bool Debug { get; set; }

        [Setting]
        [Category("Customization")]
        [DisplayName("Tank"), Description("Enable Tank rotation if available for class")]
        [DefaultValue(false)]
        public bool EnableTank { get; set; }

        [Setting]
        [Category("Customization")]
        [DisplayName("Healer"), Description("Enable Healing rotation if available for class")]
        [DefaultValue(false)]
        public bool EnableHeal { get; set; }

        [Setting]
        [Category("Customization")]
        [DisplayName("Movement"), Description("Enable movement (Facing/Moving)")]
        [DefaultValue(true)]
        public bool EnableMovement { get; set; }

		[Setting]
		[Category("Customization")]
		[DisplayName("Evade"), Description("Enable Evading Telegraphs")]
		[DefaultValue(false)]
		public bool EnableEvade { get; set; }

        [Setting]
        [Category("Customization")]
        [DisplayName("Pull Range"), Description("Default pull range")]
        [DefaultValue(5)]
        public float PullRange { get; set; }
    }
}
