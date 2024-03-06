
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
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // VehicleText
            // 
            this.VehicleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VehicleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VehicleText.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VehicleText.ForeColor = System.Drawing.Color.White;
            this.VehicleText.Location = new System.Drawing.Point(138, 42);
            this.VehicleText.Multiline = true;
            this.VehicleText.Name = "VehicleText";
            this.VehicleText.Size = new System.Drawing.Size(209, 66);
            this.VehicleText.TabIndex = 2;
            this.VehicleText.Text = "Vehicle text";
            this.VehicleText.TextChanged += new System.EventHandler(this.VehicleText_TextChanged);
            // 
            // LinkCombobox
            // 
            this.LinkCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.LinkCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LinkCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinkCombobox.ForeColor = System.Drawing.Color.White;
            this.LinkCombobox.FormattingEnabled = true;
            this.LinkCombobox.Location = new System.Drawing.Point(12, 113);
            this.LinkCombobox.Name = "LinkCombobox";
            this.LinkCombobox.Size = new System.Drawing.Size(335, 24);
            this.LinkCombobox.TabIndex = 3;
            this.LinkCombobox.Text = "Linked icon";
            this.LinkCombobox.SelectedIndexChanged += new System.EventHandler(this.LinkCombobox_SelectedIndexChanged);
            // 
            // VehicleTextLable
            // 
            this.VehicleTextLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleTextLable.BackColor = System.Drawing.Color.Transparent;
            this.VehicleTextLable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VehicleTextLable.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VehicleTextLable.ForeColor = System.Drawing.Color.White;
            this.VehicleTextLable.Location = new System.Drawing.Point(46, 1);
            this.VehicleTextLable.Name = "VehicleTextLable";
            this.VehicleTextLable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VehicleTextLable.Size = new System.Drawing.Size(74, 47);
            this.VehicleTextLable.TabIndex = 0;
            this.VehicleTextLable.Text = "Vehicle text";
            this.VehicleTextLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // BackgroundCombobox
            // 
            this.BackgroundCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BackgroundCombobox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackgroundCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackgroundCombobox.ForeColor = System.Drawing.Color.White;
            this.BackgroundCombobox.FormattingEnabled = true;
            this.BackgroundCombobox.Items.AddRange(new object[] {
            "Own (blue)",
            "Premium (golden)",
            "Squadron (green)"});
            this.BackgroundCombobox.Location = new System.Drawing.Point(12, 143);
            this.BackgroundCombobox.Name = "BackgroundCombobox";
            this.BackgroundCombobox.Size = new System.Drawing.Size(335, 24);
            this.BackgroundCombobox.TabIndex = 5;
            this.BackgroundCombobox.Text = "Background";
            this.BackgroundCombobox.SelectedIndexChanged += new System.EventHandler(this.BackgroundCombobox_SelectedIndexChanged);
            // 
            // VehicleName
            // 
            this.VehicleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VehicleName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.VehicleName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VehicleName.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VehicleName.ForeColor = System.Drawing.Color.White;
            this.VehicleName.FormattingEnabled = true;
            this.VehicleName.Location = new System.Drawing.Point(138, 12);
            this.VehicleName.Name = "VehicleName";
            this.VehicleName.Size = new System.Drawing.Size(209, 24);
            this.VehicleName.TabIndex = 6;
            this.VehicleName.Text = "Vehicle name";
            this.VehicleName.SelectedIndexChanged += new System.EventHandler(this.VehicleName_SelectedIndexChanged);
            // 
            // SaveButton
            // 
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(12, 68);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 40);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "SAVE";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PrevievPanel
            // 
            this.PrevievPanel.BackColor = System.Drawing.Color.Black;
            this.PrevievPanel.Controls.Add(this.VehicleTextLable);
            this.PrevievPanel.Controls.Add(this.iconPanel);
            this.PrevievPanel.Location = new System.Drawing.Point(12, 12);
            this.PrevievPanel.Name = "PrevievPanel";
            this.PrevievPanel.Size = new System.Drawing.Size(120, 48);
            this.PrevievPanel.TabIndex = 4;
            // 
            // iconPanel
            // 
            this.iconPanel.BackColor = System.Drawing.Color.Transparent;
            this.iconPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.iconPanel.Location = new System.Drawing.Point(3, 3);
            this.iconPanel.Name = "iconPanel";
            this.iconPanel.Size = new System.Drawing.Size(45, 45);
            this.iconPanel.TabIndex = 1;
            // 
            // VehicleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(359, 179);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.VehicleName);
            this.Controls.Add(this.BackgroundCombobox);
            this.Controls.Add(this.PrevievPanel);
            this.Controls.Add(this.LinkCombobox);
            this.Controls.Add(this.VehicleText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VehicleScreen";
            this.Text = "vehicle";
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