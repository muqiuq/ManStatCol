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
    public partial class SetNameForm : Form
    {
        public bool Successfull { get; private set; } = false;

        public string ActivityName { get; private set; } = "";

        public SetNameForm()
        {
            InitializeComponent();

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            buttonSave.Enabled = textBoxName.Text.Trim().Length > 0;
        }

        private void SetNameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!Successfull)
            {
                var result = MessageBox.Show("Are you sure you want to discard the activity?", "Discard activity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ActivityName = textBoxName.Text;
            Successfull = true;
            Close();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                buttonSave_Click(sender, e);
            }
        }

        private void SetNameForm_Shown(object sender, EventArgs e)
        {
            textBoxName.Focus();
        }
    }
}
