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
    internal class EsperSettings : OmnibusSettings
    {
        public EsperSettings(string filename = "Esper-Settings")
            : base(filename)
        {
        }

        #region Heal Category 
        [Setting, Category("Heal")]
        [DisplayName("Catharsis HP Percent"), Description("")]
        [DefaultValue(60)]
        public float CatharsisHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Catharsis Debuff Count"), Description("")]
        [DefaultValue(2)]
        public float CatharsisBuff { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Phantasmal Armor HP Percent"), Description("")]
        [DefaultValue(60)]
        public float PhantasmalArmorHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Mental Boon HP Percent"), Description("")]
        [DefaultValue(60)]
        public float MentalBoonHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Reverie (AVG) HP Percent"), Description("")]
        [DefaultValue(70)]
        public float ReverieHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Mending Banner (AVG) HP Percent"), Description("")]
        [DefaultValue(70)]
        public float MendingBannerHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Projected Spirit (AVG) HP Percent"), Description("")]
        [DefaultValue(70)]
        public float ProjectedSpiritHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Meditate HP Percent"), Description("")]
        [DefaultValue(70)]
        public float MeditateHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Pyrokinetic Flame (AVG) HP Percent"), Description("")]
        [DefaultValue(70)]
        public float PyrokineticFlameHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Warden HP Percent"), Description("")]
        [DefaultValue(70)]
        public float WardenHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Warden (Ally) HP Percent"), Description("")]
        [DefaultValue(70)]
        public float WardenAllyHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Mirage HP Percent"), Description("")]
        [DefaultValue(70)]
        public float MirageHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Soothe HP Percent"), Description("")]
        [DefaultValue(70)]
        public float SootheHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Bolster HP Percent"), Description("")]
        [DefaultValue(70)]
        public float BolsterHP { get; set; }

        [Setting, Category("Heal")]
        [DisplayName("Mind Over Body HP Percent"), Description("")]
        [DefaultValue(70)]
        public float MindOverBodyHP { get; set; }

        #endregion 
    }
}
