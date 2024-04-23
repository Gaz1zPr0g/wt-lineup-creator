
namespace Lineups_creator
{
    partial class FlagEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlagEditor));
            this.flagPreviewPanel = new System.Windows.Forms.Panel();
            this.radioPanel = new System.Windows.Forms.Panel();
            this.fileButton = new System.Windows.Forms.RadioButton();
            this.linkButton = new System.Windows.Forms.RadioButton();
            this.linkPanel = new System.Windows.Forms.Panel();
            this.downloadButton = new System.Windows.Forms.Button();
            this.linkBox = new System.Windows.Forms.TextBox();
            this.filePanel = new System.Windows.Forms.Panel();
            this.openButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.radioPanel.SuspendLayout();
            this.linkPanel.SuspendLayout();
            this.filePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flagPreviewPanel
            // 
            resources.ApplyResources(this.flagPreviewPanel, "flagPreviewPanel");
            this.flagPreviewPanel.BackColor = System.Drawing.Color.Black;
            this.flagPreviewPanel.Name = "flagPreviewPanel";
            // 
            // radioPanel
            // 
            resources.ApplyResources(this.radioPanel, "radioPanel");
            this.radioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radioPanel.Controls.Add(this.fileButton);
            this.radioPanel.Controls.Add(this.linkButton);
            this.radioPanel.Name = "radioPanel";
            // 
            // fileButton
            // 
            resources.ApplyResources(this.fileButton, "fileButton");
            this.fileButton.ForeColor = System.Drawing.Color.White;
            this.fileButton.Name = "fileButton";
            this.fileButton.TabStop = true;
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.CheckedChanged += new System.EventHandler(this.fileButton_CheckedChanged);
            // 
            // linkButton
            // 
            resources.ApplyResources(this.linkButton, "linkButton");
            this.linkButton.ForeColor = System.Drawing.Color.White;
            this.linkButton.Name = "linkButton";
            this.linkButton.TabStop = true;
            this.linkButton.UseVisualStyleBackColor = true;
            this.linkButton.CheckedChanged += new System.EventHandler(this.linkButton_CheckedChanged);
            // 
            // linkPanel
            // 
            resources.ApplyResources(this.linkPanel, "linkPanel");
            this.linkPanel.Controls.Add(this.downloadButton);
            this.linkPanel.Controls.Add(this.linkBox);
            this.linkPanel.Name = "linkPanel";
            // 
            // downloadButton
            // 
            resources.ApplyResources(this.downloadButton, "downloadButton");
            this.downloadButton.ForeColor = System.Drawing.Color.White;
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // linkBox
            // 
            resources.ApplyResources(this.linkBox, "linkBox");
            this.linkBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.linkBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkBox.ForeColor = System.Drawing.Color.White;
            this.linkBox.Name = "linkBox";
            // 
            // filePanel
            // 
            resources.ApplyResources(this.filePanel, "filePanel");
            this.filePanel.Controls.Add(this.openButton);
            this.filePanel.Name = "filePanel";
            // 
            // openButton
            // 
            resources.ApplyResources(this.openButton, "openButton");
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Name = "openButton";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FlagEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.linkPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.radioPanel);
            this.Controls.Add(this.flagPreviewPanel);
            this.Name = "FlagEditor";
            this.radioPanel.ResumeLayout(false);
            this.radioPanel.PerformLayout();
            this.linkPanel.ResumeLayout(false);
            this.linkPanel.PerformLayout();
            this.filePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel flagPreviewPanel;
        private System.Windows.Forms.Panel radioPanel;
        private System.Windows.Forms.RadioButton fileButton;
        private System.Windows.Forms.RadioButton linkButton;
        private System.Windows.Forms.Panel linkPanel;
        private System.Windows.Forms.TextBox linkBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button saveButton;
    }
}