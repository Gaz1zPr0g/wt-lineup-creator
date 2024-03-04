
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
            this.flagPreviewPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flagPreviewPanel.BackColor = System.Drawing.Color.Black;
            this.flagPreviewPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flagPreviewPanel.Location = new System.Drawing.Point(16, 16);
            this.flagPreviewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flagPreviewPanel.Name = "flagPreviewPanel";
            this.flagPreviewPanel.Size = new System.Drawing.Size(240, 96);
            this.flagPreviewPanel.TabIndex = 0;
            // 
            // radioPanel
            // 
            this.radioPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radioPanel.Controls.Add(this.fileButton);
            this.radioPanel.Controls.Add(this.linkButton);
            this.radioPanel.Location = new System.Drawing.Point(16, 115);
            this.radioPanel.Name = "radioPanel";
            this.radioPanel.Size = new System.Drawing.Size(240, 51);
            this.radioPanel.TabIndex = 1;
            // 
            // fileButton
            // 
            this.fileButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fileButton.AutoSize = true;
            this.fileButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fileButton.ForeColor = System.Drawing.Color.White;
            this.fileButton.Location = new System.Drawing.Point(156, 10);
            this.fileButton.Margin = new System.Windows.Forms.Padding(10);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(34, 33);
            this.fileButton.TabIndex = 1;
            this.fileButton.TabStop = true;
            this.fileButton.Text = "File";
            this.fileButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.CheckedChanged += new System.EventHandler(this.fileButton_CheckedChanged);
            // 
            // linkButton
            // 
            this.linkButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkButton.AutoSize = true;
            this.linkButton.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.linkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkButton.ForeColor = System.Drawing.Color.White;
            this.linkButton.Location = new System.Drawing.Point(40, 10);
            this.linkButton.Margin = new System.Windows.Forms.Padding(10);
            this.linkButton.Name = "linkButton";
            this.linkButton.Size = new System.Drawing.Size(40, 33);
            this.linkButton.TabIndex = 0;
            this.linkButton.TabStop = true;
            this.linkButton.Text = "Link";
            this.linkButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkButton.UseVisualStyleBackColor = true;
            this.linkButton.CheckedChanged += new System.EventHandler(this.linkButton_CheckedChanged);
            // 
            // linkPanel
            // 
            this.linkPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkPanel.Controls.Add(this.downloadButton);
            this.linkPanel.Controls.Add(this.linkBox);
            this.linkPanel.Location = new System.Drawing.Point(16, 175);
            this.linkPanel.Name = "linkPanel";
            this.linkPanel.Size = new System.Drawing.Size(240, 100);
            this.linkPanel.TabIndex = 2;
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.ForeColor = System.Drawing.Color.White;
            this.downloadButton.Location = new System.Drawing.Point(60, 35);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(120, 48);
            this.downloadButton.TabIndex = 1;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // linkBox
            // 
            this.linkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.linkBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.linkBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkBox.ForeColor = System.Drawing.Color.White;
            this.linkBox.Location = new System.Drawing.Point(3, 2);
            this.linkBox.Name = "linkBox";
            this.linkBox.Size = new System.Drawing.Size(234, 24);
            this.linkBox.TabIndex = 0;
            this.linkBox.Text = "Link to the image (.png / .jpeg)";
            this.linkBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // filePanel
            // 
            this.filePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel.Controls.Add(this.openButton);
            this.filePanel.Location = new System.Drawing.Point(16, 175);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(240, 100);
            this.filePanel.TabIndex = 3;
            this.filePanel.Visible = false;
            // 
            // openButton
            // 
            this.openButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openButton.ForeColor = System.Drawing.Color.White;
            this.openButton.Location = new System.Drawing.Point(60, 35);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(120, 48);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "LOAD";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(16, 285);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(241, 34);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FlagEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(272, 346);
            this.Controls.Add(this.linkPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.radioPanel);
            this.Controls.Add(this.flagPreviewPanel);
            this.Font = new System.Drawing.Font("Verdana", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FlagEditor";
            this.Text = "FlagEditor";
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