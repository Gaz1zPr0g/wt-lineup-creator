
namespace Lineups_creator
{
    partial class VehicleScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VehicleScreen));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VehicleText = new System.Windows.Forms.TextBox();
            this.LinkCombobox = new System.Windows.Forms.ComboBox();
            this.VehicleTextLable = new System.Windows.Forms.Label();
            this.BackgroundCombobox = new System.Windows.Forms.ComboBox();
            this.VehicleName = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PrevievPanel = new System.Windows.Forms.Panel();
            this.iconPanel = new System.Windows.Forms.Panel();
            this.PrevievPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // VehicleText
            // 
            resources.ApplyResources(this.VehicleText, "VehicleText");
            this.VehicleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VehicleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VehicleText.ForeColor = System.Drawing.Color.White;
            this.VehicleText.Name = "VehicleText";
            this.VehicleText.TextChanged += new System.EventHandler(this.VehicleText_TextChanged);
            // 
            // LinkCombobox
            // 
            resources.ApplyResources(this.LinkCombobox, "LinkCombobox");
            this.LinkCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LinkCombobox.ForeColor = System.Drawing.Color.White;
            this.LinkCombobox.FormattingEnabled = true;
            this.LinkCombobox.Name = "LinkCombobox";
            this.LinkCombobox.SelectedIndexChanged += new System.EventHandler(this.LinkCombobox_SelectedIndexChanged);
            // 
            // VehicleTextLable
            // 
            resources.ApplyResources(this.VehicleTextLable, "VehicleTextLable");
            this.VehicleTextLable.BackColor = System.Drawing.Color.Transparent;
            this.VehicleTextLable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VehicleTextLable.ForeColor = System.Drawing.Color.White;
            this.VehicleTextLable.Name = "VehicleTextLable";
            // 
            // BackgroundCombobox
            // 
            resources.ApplyResources(this.BackgroundCombobox, "BackgroundCombobox");
            this.BackgroundCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundCombobox.ForeColor = System.Drawing.Color.White;
            this.BackgroundCombobox.FormattingEnabled = true;
            this.BackgroundCombobox.Items.AddRange(new object[] {
            resources.GetString("BackgroundCombobox.Items"),
            resources.GetString("BackgroundCombobox.Items1"),
            resources.GetString("BackgroundCombobox.Items2")});
            this.BackgroundCombobox.Name = "BackgroundCombobox";
            this.BackgroundCombobox.SelectedIndexChanged += new System.EventHandler(this.BackgroundCombobox_SelectedIndexChanged);
            // 
            // VehicleName
            // 
            resources.ApplyResources(this.VehicleName, "VehicleName");
            this.VehicleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VehicleName.ForeColor = System.Drawing.Color.White;
            this.VehicleName.FormattingEnabled = true;
            this.VehicleName.Name = "VehicleName";
            this.VehicleName.SelectedIndexChanged += new System.EventHandler(this.VehicleName_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PrevievPanel
            // 
            resources.ApplyResources(this.PrevievPanel, "PrevievPanel");
            this.PrevievPanel.BackColor = System.Drawing.Color.Black;
            this.PrevievPanel.Controls.Add(this.VehicleTextLable);
            this.PrevievPanel.Controls.Add(this.iconPanel);
            this.PrevievPanel.Name = "PrevievPanel";
            // 
            // iconPanel
            // 
            resources.ApplyResources(this.iconPanel, "iconPanel");
            this.iconPanel.BackColor = System.Drawing.Color.Transparent;
            this.iconPanel.Name = "iconPanel";
            // 
            // VehicleScreen
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.VehicleName);
            this.Controls.Add(this.BackgroundCombobox);
            this.Controls.Add(this.PrevievPanel);
            this.Controls.Add(this.LinkCombobox);
            this.Controls.Add(this.VehicleText);
            this.Name = "VehicleScreen";
            this.PrevievPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox VehicleText;
        private System.Windows.Forms.ComboBox LinkCombobox;
        private System.Windows.Forms.ComboBox BackgroundCombobox;
        private System.Windows.Forms.ComboBox VehicleName;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label VehicleTextLable;
        private System.Windows.Forms.Panel PrevievPanel;
        private System.Windows.Forms.Panel iconPanel;
    }
}