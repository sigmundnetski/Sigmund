using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Omnibus.Settings
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Omnibus.WindowSettings;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Omnibus.WindowSettings.Save();
        }
    }
}
