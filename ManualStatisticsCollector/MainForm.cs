using ManualStatisticsCollector.Utils;
using System.Diagnostics;
using static ManualStatisticsCollector.Models.LocalWorkActivitiesStorage;

namespace ManualStatisticsCollector
{
    public partial class MainForm : Form
    {
        WorkActivityEngine engine = Global.Engine;
        private System.Threading.Timer updateTimer;

        UploadResultDelegate uploadResultDelegate;
        private System.Threading.Timer uploadTimer;
        private string lastUplaodMessage;

        public MainForm()
        {
            InitializeComponent();

            if (engine.TrackingProjectRequired)
            {
                showSettings();
            }
            updateState();
            uploadResultDelegate = new UploadResultDelegate(SetUpdateResult);

            uploadTimer = new System.Threading.Timer((e) =>
            {
                engine.Upload(uploadResultDelegate, false);
            }, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(10));

            listBoxOpenActivities.Items.AddRange(engine.PausedActivities().ToArray());

            comboBoxWorkTasks.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxWorkTasks.AutoCompleteSource = AutoCompleteSource.ListItems;

            comboBoxWorkTasks.Items.AddRange(engine.GetWorkActivitiesTypes().ToArray());

            buttonStart.Enabled = comboBoxWorkTasks.SelectedItem != null;
        }

        private void showSettings()
        {
            SettingsForm settingsForm = new SettingsForm(engine.Settings);
            settingsForm.ShowDialog(this);
        }

        public void updateState()
        {
            buttonStart.Enabled = !engine.IsActivityActive();
            buttonStop.Enabled = engine.IsActivityActive();
            buttonPause.Enabled = engine.IsActivityActive();
            comboBoxWorkTasks.Enabled = !engine.IsActivityActive();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            startActivity();
        }

        private void startActivity()
        {
            if(comboBoxWorkTasks.SelectedItem == null)
            {
                MessageBox.Show("Please enter new or select work task type before clicking on start", "work task type required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxWorkTasks.Focus();
                return;
            }
            engine.StartActivity((string)comboBoxWorkTasks.SelectedItem);
            updateState();
            startUpdateTimer();
        }

        private void startUpdateTimer()
        {
            updateTimer = new System.Threading.Timer((e) =>
            {
                UpdateTime();
            }, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopActivity();
        }

        private void stopActivity()
        {
            if (engine.StopActivity())
            {
                labelState.Text = "last duration " + labelState.Text;
            }
            else
            {
                labelState.Text = "discareded";
            }
            updateState();
            updateTimer.Dispose();
        }

        public void UpdateTime()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { UpdateTime(); }));
                return;
            }
            if (engine.IsActivityActive())
            {
                labelState.Text = engine.GetElapsedTimeWithName();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showSettings();
        }

        public void SetUpdateResult(bool success, string message, bool forcedUpload)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => { SetUpdateResult(success, message, forcedUpload); }));
                return;
            }
            if (success)
            {
                toolStripStatusLabelMain.Text = $"last upload ({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")})";
            }
            else
            {
                toolStripStatusLabelMain.Text = $"Upload failed ({DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")})";
                if (forcedUpload)
                {
                    MessageBox.Show(message, "upload failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            lastUplaodMessage = message;
        }

        private void forceUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.Upload(uploadResultDelegate, true);
        }

        private void showLastUploadMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastUplaodMessage != null && lastUplaodMessage != "")
            {
                MessageBox.Show(lastUplaodMessage);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (engine.IsActivityActive())
            {
                stopActivity();
            }
            uploadTimer.Dispose();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(c) Philipp Albrecht <info@uisa.ch>\nPortUp GmbH\nZürich\nwww.portup.ch", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBoxOpenActivities_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxOpenActivities.SelectedItem != null && !engine.IsActivityActive())
            {
                var activityToContinue = (ManualStatisticsCollectorLib.Entities.WorkActivity)listBoxOpenActivities.SelectedItem;
                listBoxOpenActivities.Items.Remove(listBoxOpenActivities.SelectedItem);
                engine.ContinueActivity(activityToContinue);
                if(!comboBoxWorkTasks.Items.Contains(activityToContinue.WorkTask))
                {
                    comboBoxWorkTasks.Items.Add(activityToContinue.WorkTask);
                }
                comboBoxWorkTasks.SelectedItem = activityToContinue.WorkTask;
                updateState();
                startUpdateTimer();
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            var pausedActivity = engine.PauseActivity();

            if (pausedActivity != null)
            {
                if (pausedActivity.Name == null || pausedActivity.Name == "")
                {
                    var setNameDialog = new SetNameForm();
                    setNameDialog.ShowDialog(this);
                    if (!setNameDialog.Successfull)
                    {
                        engine.RemoveActivity(pausedActivity);
                        labelState.Text = "discarded";
                        return;
                    }
                    pausedActivity.Name = setNameDialog.ActivityName;
                }
                listBoxOpenActivities.Items.Add(pausedActivity);
                labelState.Text = "paused";
                updateState();
                updateTimer.Dispose();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                if (buttonStart.Enabled)
                    buttonStart_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.P)
            {
                if (buttonPause.Enabled)
                    buttonPause_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.T)
            {
                if (buttonStop.Enabled)
                    buttonStop_Click(sender, e);
            }
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.L)
            {
                listBoxOpenActivities.Focus();
            }
        }

        private void listBoxOpenActivities_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && listBoxOpenActivities.SelectedItem != null)
            {
                var activityToContinue = listBoxOpenActivities.SelectedItem;
                listBoxOpenActivities.Items.Remove(listBoxOpenActivities.SelectedItem);
                engine.RemoveActivity((ManualStatisticsCollectorLib.Entities.WorkActivity)activityToContinue);
            }
            if (e.KeyCode == Keys.Enter && listBoxOpenActivities.SelectedItem != null)
            {
                listBoxOpenActivities_DoubleClick(sender, e);
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!comboBoxWorkTasks.Items.Contains(comboBoxWorkTasks.Text))
                {
                    comboBoxWorkTasks.Items.Add(comboBoxWorkTasks.Text);
                    engine.SyncWorkActivitiesType(comboBoxWorkTasks.Items.Cast<string>());
                }
                comboBoxWorkTasks.SelectedItem = comboBoxWorkTasks.Text;
                e.Handled = true;
                e.SuppressKeyPress = true;

                if (e.Modifiers == Keys.Control)
                {
                    if (!engine.IsActivityActive())
                    {
                        startActivity();
                    }
                }
            }
            if(e.KeyCode == Keys.Delete && e.Modifiers == Keys.Control 
                && comboBoxWorkTasks.SelectedItem != null && (string)comboBoxWorkTasks.SelectedItem == comboBoxWorkTasks.Text)
            {
                comboBoxWorkTasks.Items.Remove(comboBoxWorkTasks.SelectedItem);
                engine.SyncWorkActivitiesType(comboBoxWorkTasks.Items.Cast<string>());
            }
        }

        private void comboBoxWorkTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            engine.SyncWorkActivitiesType(comboBoxWorkTasks.Items.Cast<string>());
            buttonStart.Enabled = comboBoxWorkTasks.SelectedItem != null;
        }

        private void comboBoxWorkTasks_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBoxWorkTasks_TextChanged(object sender, EventArgs e)
        {
            if (!comboBoxWorkTasks.Items.Contains(comboBoxWorkTasks.Text))
            {
                buttonStart.Enabled = false;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            comboBoxWorkTasks.Focus();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shortcuts:\nCtrl+S: Start\nCtrl+P: Pause\nCtrl+T: Stop\n\nTo add entry in work task type use Ctrl+Enter.\nTo delete selected entry use Ctrl+Delete\n\nTo delete entry in paused activities use Delete key.", "Help");
        }

        private void exportXLSXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = saveFileDialogExcel.ShowDialog(this);
            if(dialog == DialogResult.OK)
            {
                ExcelWorkActivitiesExport.SaveWorkActivitiesToExcel(saveFileDialogExcel.FileName, engine.GetAllActivities());
            }
        }
    }
}