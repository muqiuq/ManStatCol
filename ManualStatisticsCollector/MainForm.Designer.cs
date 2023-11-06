namespace ManualStatisticsCollector
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelState = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forceUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLastUploadMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportXLSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabelSpacer = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonPause = new System.Windows.Forms.Button();
            this.listBoxOpenActivities = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxWorkTasks = new System.Windows.Forms.ComboBox();
            this.labelWorkTask = new System.Windows.Forms.Label();
            this.saveFileDialogExcel = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelState.Location = new System.Drawing.Point(12, 63);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(28, 30);
            this.labelState.TabIndex = 0;
            this.labelState.Text = "...";
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStart.Location = new System.Drawing.Point(12, 111);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(149, 89);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStop.Location = new System.Drawing.Point(198, 111);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(149, 89);
            this.buttonStop.TabIndex = 2;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton1,
            this.toolStripStatusLabelSpacer,
            this.toolStripStatusLabelMain});
            this.statusStrip1.Location = new System.Drawing.Point(0, 482);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(537, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.forceUploadToolStripMenuItem,
            this.showLastUploadMessageToolStripMenuItem,
            this.exportXLSXToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(65, 20);
            this.toolStripSplitButton1.Text = "Options";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // forceUploadToolStripMenuItem
            // 
            this.forceUploadToolStripMenuItem.Name = "forceUploadToolStripMenuItem";
            this.forceUploadToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.forceUploadToolStripMenuItem.Text = "Force Upload";
            this.forceUploadToolStripMenuItem.Click += new System.EventHandler(this.forceUploadToolStripMenuItem_Click);
            // 
            // showLastUploadMessageToolStripMenuItem
            // 
            this.showLastUploadMessageToolStripMenuItem.Name = "showLastUploadMessageToolStripMenuItem";
            this.showLastUploadMessageToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.showLastUploadMessageToolStripMenuItem.Text = "Show last upload message";
            this.showLastUploadMessageToolStripMenuItem.Click += new System.EventHandler(this.showLastUploadMessageToolStripMenuItem_Click);
            // 
            // exportXLSXToolStripMenuItem
            // 
            this.exportXLSXToolStripMenuItem.Name = "exportXLSXToolStripMenuItem";
            this.exportXLSXToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.exportXLSXToolStripMenuItem.Text = "Export (XLSX)";
            this.exportXLSXToolStripMenuItem.Click += new System.EventHandler(this.exportXLSXToolStripMenuItem_Click);
            // 
            // toolStripStatusLabelSpacer
            // 
            this.toolStripStatusLabelSpacer.Name = "toolStripStatusLabelSpacer";
            this.toolStripStatusLabelSpacer.Size = new System.Drawing.Size(52, 17);
            this.toolStripStatusLabelSpacer.Text = "               ";
            // 
            // toolStripStatusLabelMain
            // 
            this.toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            this.toolStripStatusLabelMain.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabelMain.Text = "...";
            // 
            // buttonPause
            // 
            this.buttonPause.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPause.Location = new System.Drawing.Point(381, 111);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(149, 89);
            this.buttonPause.TabIndex = 4;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // listBoxOpenActivities
            // 
            this.listBoxOpenActivities.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxOpenActivities.FormattingEnabled = true;
            this.listBoxOpenActivities.ItemHeight = 21;
            this.listBoxOpenActivities.Location = new System.Drawing.Point(12, 237);
            this.listBoxOpenActivities.Name = "listBoxOpenActivities";
            this.listBoxOpenActivities.ScrollAlwaysVisible = true;
            this.listBoxOpenActivities.Size = new System.Drawing.Size(518, 235);
            this.listBoxOpenActivities.TabIndex = 5;
            this.listBoxOpenActivities.DoubleClick += new System.EventHandler(this.listBoxOpenActivities_DoubleClick);
            this.listBoxOpenActivities.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxOpenActivities_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Continue task (Double click):";
            // 
            // comboBoxWorkTasks
            // 
            this.comboBoxWorkTasks.FormattingEnabled = true;
            this.comboBoxWorkTasks.Location = new System.Drawing.Point(207, 12);
            this.comboBoxWorkTasks.Name = "comboBoxWorkTasks";
            this.comboBoxWorkTasks.Size = new System.Drawing.Size(318, 23);
            this.comboBoxWorkTasks.TabIndex = 7;
            this.comboBoxWorkTasks.SelectedIndexChanged += new System.EventHandler(this.comboBoxWorkTasks_SelectedIndexChanged);
            this.comboBoxWorkTasks.SelectedValueChanged += new System.EventHandler(this.comboBoxWorkTasks_SelectedValueChanged);
            this.comboBoxWorkTasks.TextChanged += new System.EventHandler(this.comboBoxWorkTasks_TextChanged);
            this.comboBoxWorkTasks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // labelWorkTask
            // 
            this.labelWorkTask.AutoSize = true;
            this.labelWorkTask.Location = new System.Drawing.Point(12, 16);
            this.labelWorkTask.Name = "labelWorkTask";
            this.labelWorkTask.Size = new System.Drawing.Size(189, 15);
            this.labelWorkTask.TabIndex = 8;
            this.labelWorkTask.Text = "Select or enter new work task type:";
            // 
            // saveFileDialogExcel
            // 
            this.saveFileDialogExcel.Filter = "XLSX|*.xlsx";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 504);
            this.Controls.Add(this.labelWorkTask);
            this.Controls.Add(this.comboBoxWorkTasks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOpenActivities);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelState);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "Manual Statistics Collector V1.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelState;
        private Button buttonStart;
        private Button buttonStop;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabelMain;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabelSpacer;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem forceUploadToolStripMenuItem;
        private ToolStripMenuItem showLastUploadMessageToolStripMenuItem;
        private Button buttonPause;
        private ListBox listBoxOpenActivities;
        private Label label1;
        private ComboBox comboBoxWorkTasks;
        private Label labelWorkTask;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem exportXLSXToolStripMenuItem;
        private SaveFileDialog saveFileDialogExcel;
    }
}