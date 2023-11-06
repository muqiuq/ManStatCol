using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualStatisticsCollector
{
    public partial class SettingsForm : Form
    {
        private readonly ManStatColSettings settings;

        public SettingsForm(ManStatColSettings settings)
        {
            InitializeComponent();
            this.settings = settings;

            textBoxTrackingProject.Text = settings.TrackingProject;
            textBoxUpdateUrl.Text = settings.UpdateUrl;
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!checkUserInputs())
            {
                e.Cancel = true;
            }
        }

        private bool checkUserInputs()
        {
            if (!IsUrlValid())
            {
                MessageBox.Show("Please supply valid url", "invalid url", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (textBoxTrackingProject.Text == "")
            {
                MessageBox.Show("Tracking projec value cannot be empty. Please insert unknown if not known.", "missing required value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            settings.TrackingProject = textBoxTrackingProject.Text.Trim();
            settings.UpdateUrl = textBoxUpdateUrl.Text.Trim();
            settings.Save();
            Close();
        }

        public bool IsUrlValid()
        {
            bool result = Uri.TryCreate(textBoxUpdateUrl.Text, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return textBoxUpdateUrl.Text.Trim() == "" || result;
        }

        private void textBoxUpdateUrl_TextChanged(object sender, EventArgs e)
        {
            textBoxUpdateUrl.BackColor = IsUrlValid() ? Color.White : Color.LightPink;
        }

        private void textBoxTrackingProject_TextChanged(object sender, EventArgs e)
        {
            textBoxTrackingProject.BackColor = textBoxTrackingProject.Text.Trim() != "" ? Color.White : Color.LightPink;
        }
    }
}
