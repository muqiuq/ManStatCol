namespace ManualStatisticsCollector
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTrackingProject = new System.Windows.Forms.TextBox();
            this.labelUpdateUrl = new System.Windows.Forms.Label();
            this.textBoxUpdateUrl = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tracking project name:";
            // 
            // textBoxTrackingProject
            // 
            this.textBoxTrackingProject.Location = new System.Drawing.Point(174, 6);
            this.textBoxTrackingProject.Name = "textBoxTrackingProject";
            this.textBoxTrackingProject.Size = new System.Drawing.Size(229, 23);
            this.textBoxTrackingProject.TabIndex = 1;
            this.textBoxTrackingProject.TextChanged += new System.EventHandler(this.textBoxTrackingProject_TextChanged);
            // 
            // labelUpdateUrl
            // 
            this.labelUpdateUrl.AutoSize = true;
            this.labelUpdateUrl.Location = new System.Drawing.Point(12, 43);
            this.labelUpdateUrl.Name = "labelUpdateUrl";
            this.labelUpdateUrl.Size = new System.Drawing.Size(65, 15);
            this.labelUpdateUrl.TabIndex = 2;
            this.labelUpdateUrl.Text = "Update url:";
            // 
            // textBoxUpdateUrl
            // 
            this.textBoxUpdateUrl.Location = new System.Drawing.Point(174, 40);
            this.textBoxUpdateUrl.Name = "textBoxUpdateUrl";
            this.textBoxUpdateUrl.Size = new System.Drawing.Size(229, 23);
            this.textBoxUpdateUrl.TabIndex = 3;
            this.textBoxUpdateUrl.TextChanged += new System.EventHandler(this.textBoxUpdateUrl_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(303, 79);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save + Close";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 114);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxUpdateUrl);
            this.Controls.Add(this.labelUpdateUrl);
            this.Controls.Add(this.textBoxTrackingProject);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(390, 75);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBoxTrackingProject;
        private Label labelUpdateUrl;
        private TextBox textBoxUpdateUrl;
        private Button buttonSave;
    }
}