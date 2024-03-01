
namespace Lineups_creator
{
    partial class Lineup_creator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lineup_creator));
            this.importButton = new System.Windows.Forms.Button();
            this.saveScheme = new System.Windows.Forms.Button();
            this.countryCombo = new System.Windows.Forms.ComboBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BluewaterPanel = new System.Windows.Forms.Panel();
            this.AddColumnBluewater = new System.Windows.Forms.Button();
            this.BluewaterTable = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowBluewater = new System.Windows.Forms.Button();
            this.bluewaterlabel = new System.Windows.Forms.Label();
            this.CoastalfleetPanel = new System.Windows.Forms.Panel();
            this.AddColumnCoastalFleet = new System.Windows.Forms.Button();
            this.CoastalfleetTable = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowCoastalFleet = new System.Windows.Forms.Button();
            this.coastalfleetlabel = new System.Windows.Forms.Label();
            this.HelicoptersPanel = new System.Windows.Forms.Panel();
            this.AddColumnHeli = new System.Windows.Forms.Button();
            this.HeliTable = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowHeli = new System.Windows.Forms.Button();
            this.helicopterslabel = new System.Windows.Forms.Label();
            this.PlanesPanel = new System.Windows.Forms.Panel();
            this.AddColumnPlanes = new System.Windows.Forms.Button();
            this.PlanesTable = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowPlanes1 = new System.Windows.Forms.Button();
            this.PlanesLabel = new System.Windows.Forms.Label();
            this.TanksPanel = new System.Windows.Forms.Panel();
            this.TanksTable = new System.Windows.Forms.TableLayoutPanel();
            this.AddRowTanks1 = new System.Windows.Forms.Button();
            this.AddColumnTanks = new System.Windows.Forms.Button();
            this.tanksLable = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.supportButton = new System.Windows.Forms.Button();
            this.flagPanel = new System.Windows.Forms.Button();
            this.copyrights = new System.Windows.Forms.Label();
            this.ModeInfo = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.BluewaterPanel.SuspendLayout();
            this.BluewaterTable.SuspendLayout();
            this.CoastalfleetPanel.SuspendLayout();
            this.CoastalfleetTable.SuspendLayout();
            this.HelicoptersPanel.SuspendLayout();
            this.HeliTable.SuspendLayout();
            this.PlanesPanel.SuspendLayout();
            this.PlanesTable.SuspendLayout();
            this.TanksPanel.SuspendLayout();
            this.TanksTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.importButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.importButton.ForeColor = System.Drawing.Color.White;
            this.importButton.Location = new System.Drawing.Point(12, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(120, 48);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "IMPORT";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // saveScheme
            // 
            this.saveScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveScheme.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveScheme.ForeColor = System.Drawing.Color.White;
            this.saveScheme.Location = new System.Drawing.Point(138, 12);
            this.saveScheme.Name = "saveScheme";
            this.saveScheme.Size = new System.Drawing.Size(120, 48);
            this.saveScheme.TabIndex = 1;
            this.saveScheme.Text = "SAVE";
            this.saveScheme.UseVisualStyleBackColor = true;
            this.saveScheme.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // countryCombo
            // 
            this.countryCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countryCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.countryCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.countryCombo.ForeColor = System.Drawing.Color.White;
            this.countryCombo.FormattingEnabled = true;
            this.countryCombo.Items.AddRange(new object[] {
            "USA",
            "Germany",
            "USSR",
            "Great Britain",
            "Japan",
            "China",
            "Italy",
            "France",
            "Sweden",
            "Israel"});
            this.countryCombo.Location = new System.Drawing.Point(952, 39);
            this.countryCombo.Name = "countryCombo";
            this.countryCombo.Size = new System.Drawing.Size(120, 21);
            this.countryCombo.TabIndex = 2;
            this.countryCombo.Text = "Country";
            this.countryCombo.SelectedIndexChanged += new System.EventHandler(this.countryCombo_SelectedIndexChanged);
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoScroll = true;
            this.MainPanel.AutoScrollMargin = new System.Drawing.Size(10, 0);
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.BluewaterPanel);
            this.MainPanel.Controls.Add(this.CoastalfleetPanel);
            this.MainPanel.Controls.Add(this.HelicoptersPanel);
            this.MainPanel.Controls.Add(this.PlanesPanel);
            this.MainPanel.Controls.Add(this.TanksPanel);
            this.MainPanel.Location = new System.Drawing.Point(12, 69);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1060, 600);
            this.MainPanel.TabIndex = 3;
            // 
            // BluewaterPanel
            // 
            this.BluewaterPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BluewaterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BluewaterPanel.Controls.Add(this.AddColumnBluewater);
            this.BluewaterPanel.Controls.Add(this.BluewaterTable);
            this.BluewaterPanel.Controls.Add(this.bluewaterlabel);
            this.BluewaterPanel.Location = new System.Drawing.Point(0, 1850);
            this.BluewaterPanel.Name = "BluewaterPanel";
            this.BluewaterPanel.Size = new System.Drawing.Size(1030, 500);
            this.BluewaterPanel.TabIndex = 4;
            // 
            // AddColumnBluewater
            // 
            this.AddColumnBluewater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddColumnBluewater.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColumnBluewater.Location = new System.Drawing.Point(135, 39);
            this.AddColumnBluewater.Name = "AddColumnBluewater";
            this.AddColumnBluewater.Size = new System.Drawing.Size(15, 48);
            this.AddColumnBluewater.TabIndex = 2;
            this.AddColumnBluewater.Text = "+";
            this.AddColumnBluewater.UseVisualStyleBackColor = true;
            this.AddColumnBluewater.Click += new System.EventHandler(this.AddColumnBluewaterFleet_Click);
            // 
            // BluewaterTable
            // 
            this.BluewaterTable.AutoSize = true;
            this.BluewaterTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BluewaterTable.ColumnCount = 1;
            this.BluewaterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BluewaterTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BluewaterTable.Controls.Add(this.AddRowBluewater, 0, 0);
            this.BluewaterTable.Location = new System.Drawing.Point(6, 36);
            this.BluewaterTable.Name = "BluewaterTable";
            this.BluewaterTable.RowCount = 1;
            this.BluewaterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BluewaterTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.BluewaterTable.Size = new System.Drawing.Size(126, 54);
            this.BluewaterTable.TabIndex = 1;
            // 
            // AddRowBluewater
            // 
            this.AddRowBluewater.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRowBluewater.Location = new System.Drawing.Point(3, 3);
            this.AddRowBluewater.Name = "AddRowBluewater";
            this.AddRowBluewater.Size = new System.Drawing.Size(120, 48);
            this.AddRowBluewater.TabIndex = 0;
            this.AddRowBluewater.Text = "Add row";
            this.AddRowBluewater.UseVisualStyleBackColor = true;
            this.AddRowBluewater.Click += new System.EventHandler(this.AddRowBluewaterFleet_Click);
            // 
            // bluewaterlabel
            // 
            this.bluewaterlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bluewaterlabel.AutoSize = true;
            this.bluewaterlabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bluewaterlabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bluewaterlabel.Location = new System.Drawing.Point(445, 0);
            this.bluewaterlabel.Name = "bluewaterlabel";
            this.bluewaterlabel.Size = new System.Drawing.Size(142, 23);
            this.bluewaterlabel.TabIndex = 0;
            this.bluewaterlabel.Text = "Bluewater fleet";
            // 
            // CoastalfleetPanel
            // 
            this.CoastalfleetPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CoastalfleetPanel.AutoScroll = true;
            this.CoastalfleetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CoastalfleetPanel.Controls.Add(this.AddColumnCoastalFleet);
            this.CoastalfleetPanel.Controls.Add(this.CoastalfleetTable);
            this.CoastalfleetPanel.Controls.Add(this.coastalfleetlabel);
            this.CoastalfleetPanel.Location = new System.Drawing.Point(0, 1340);
            this.CoastalfleetPanel.Name = "CoastalfleetPanel";
            this.CoastalfleetPanel.Size = new System.Drawing.Size(1030, 500);
            this.CoastalfleetPanel.TabIndex = 3;
            // 
            // AddColumnCoastalFleet
            // 
            this.AddColumnCoastalFleet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddColumnCoastalFleet.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColumnCoastalFleet.Location = new System.Drawing.Point(135, 39);
            this.AddColumnCoastalFleet.Name = "AddColumnCoastalFleet";
            this.AddColumnCoastalFleet.Size = new System.Drawing.Size(15, 48);
            this.AddColumnCoastalFleet.TabIndex = 2;
            this.AddColumnCoastalFleet.Text = "+";
            this.AddColumnCoastalFleet.UseVisualStyleBackColor = true;
            this.AddColumnCoastalFleet.Click += new System.EventHandler(this.AddColumnCoastalFleet_Click);
            // 
            // CoastalfleetTable
            // 
            this.CoastalfleetTable.AutoSize = true;
            this.CoastalfleetTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CoastalfleetTable.ColumnCount = 1;
            this.CoastalfleetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoastalfleetTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoastalfleetTable.Controls.Add(this.AddRowCoastalFleet, 0, 0);
            this.CoastalfleetTable.Location = new System.Drawing.Point(6, 36);
            this.CoastalfleetTable.Name = "CoastalfleetTable";
            this.CoastalfleetTable.RowCount = 1;
            this.CoastalfleetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoastalfleetTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CoastalfleetTable.Size = new System.Drawing.Size(126, 54);
            this.CoastalfleetTable.TabIndex = 1;
            // 
            // AddRowCoastalFleet
            // 
            this.AddRowCoastalFleet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRowCoastalFleet.Location = new System.Drawing.Point(3, 3);
            this.AddRowCoastalFleet.Name = "AddRowCoastalFleet";
            this.AddRowCoastalFleet.Size = new System.Drawing.Size(120, 48);
            this.AddRowCoastalFleet.TabIndex = 0;
            this.AddRowCoastalFleet.Text = "Add row";
            this.AddRowCoastalFleet.UseVisualStyleBackColor = true;
            this.AddRowCoastalFleet.Click += new System.EventHandler(this.AddRowCoastalFleet_Click);
            // 
            // coastalfleetlabel
            // 
            this.coastalfleetlabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.coastalfleetlabel.AutoSize = true;
            this.coastalfleetlabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coastalfleetlabel.Location = new System.Drawing.Point(455, 0);
            this.coastalfleetlabel.Name = "coastalfleetlabel";
            this.coastalfleetlabel.Size = new System.Drawing.Size(121, 23);
            this.coastalfleetlabel.TabIndex = 0;
            this.coastalfleetlabel.Text = "Coastal fleet";
            // 
            // HelicoptersPanel
            // 
            this.HelicoptersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HelicoptersPanel.AutoScroll = true;
            this.HelicoptersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelicoptersPanel.Controls.Add(this.AddColumnHeli);
            this.HelicoptersPanel.Controls.Add(this.HeliTable);
            this.HelicoptersPanel.Controls.Add(this.helicopterslabel);
            this.HelicoptersPanel.Location = new System.Drawing.Point(0, 1030);
            this.HelicoptersPanel.Name = "HelicoptersPanel";
            this.HelicoptersPanel.Size = new System.Drawing.Size(1030, 300);
            this.HelicoptersPanel.TabIndex = 2;
            // 
            // AddColumnHeli
            // 
            this.AddColumnHeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddColumnHeli.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColumnHeli.Location = new System.Drawing.Point(135, 39);
            this.AddColumnHeli.Name = "AddColumnHeli";
            this.AddColumnHeli.Size = new System.Drawing.Size(15, 48);
            this.AddColumnHeli.TabIndex = 2;
            this.AddColumnHeli.Text = "+";
            this.AddColumnHeli.UseVisualStyleBackColor = true;
            this.AddColumnHeli.Click += new System.EventHandler(this.AddColumnHeli_Click);
            // 
            // HeliTable
            // 
            this.HeliTable.AutoSize = true;
            this.HeliTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.HeliTable.ColumnCount = 1;
            this.HeliTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeliTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeliTable.Controls.Add(this.AddRowHeli, 0, 0);
            this.HeliTable.Location = new System.Drawing.Point(6, 36);
            this.HeliTable.Name = "HeliTable";
            this.HeliTable.RowCount = 1;
            this.HeliTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeliTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.HeliTable.Size = new System.Drawing.Size(126, 54);
            this.HeliTable.TabIndex = 1;
            // 
            // AddRowHeli
            // 
            this.AddRowHeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRowHeli.Location = new System.Drawing.Point(3, 3);
            this.AddRowHeli.Name = "AddRowHeli";
            this.AddRowHeli.Size = new System.Drawing.Size(120, 48);
            this.AddRowHeli.TabIndex = 0;
            this.AddRowHeli.Text = "Add row";
            this.AddRowHeli.UseVisualStyleBackColor = true;
            this.AddRowHeli.Click += new System.EventHandler(this.AddRowHeli_Click);
            // 
            // helicopterslabel
            // 
            this.helicopterslabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.helicopterslabel.AutoSize = true;
            this.helicopterslabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helicopterslabel.Location = new System.Drawing.Point(461, 0);
            this.helicopterslabel.Name = "helicopterslabel";
            this.helicopterslabel.Size = new System.Drawing.Size(108, 23);
            this.helicopterslabel.TabIndex = 0;
            this.helicopterslabel.Text = "Helicopters";
            this.helicopterslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlanesPanel
            // 
            this.PlanesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanesPanel.AutoScroll = true;
            this.PlanesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlanesPanel.Controls.Add(this.AddColumnPlanes);
            this.PlanesPanel.Controls.Add(this.PlanesTable);
            this.PlanesPanel.Controls.Add(this.PlanesLabel);
            this.PlanesPanel.Location = new System.Drawing.Point(0, 520);
            this.PlanesPanel.Name = "PlanesPanel";
            this.PlanesPanel.Size = new System.Drawing.Size(1030, 500);
            this.PlanesPanel.TabIndex = 1;
            // 
            // AddColumnPlanes
            // 
            this.AddColumnPlanes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddColumnPlanes.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddColumnPlanes.Location = new System.Drawing.Point(135, 39);
            this.AddColumnPlanes.Name = "AddColumnPlanes";
            this.AddColumnPlanes.Size = new System.Drawing.Size(15, 48);
            this.AddColumnPlanes.TabIndex = 2;
            this.AddColumnPlanes.Text = "+";
            this.AddColumnPlanes.UseVisualStyleBackColor = true;
            this.AddColumnPlanes.Click += new System.EventHandler(this.AddColumnPlanes_Click);
            // 
            // PlanesTable
            // 
            this.PlanesTable.AutoSize = true;
            this.PlanesTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.PlanesTable.ColumnCount = 1;
            this.PlanesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlanesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlanesTable.Controls.Add(this.AddRowPlanes1, 0, 0);
            this.PlanesTable.Location = new System.Drawing.Point(3, 36);
            this.PlanesTable.Name = "PlanesTable";
            this.PlanesTable.RowCount = 1;
            this.PlanesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlanesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PlanesTable.Size = new System.Drawing.Size(126, 54);
            this.PlanesTable.TabIndex = 1;
            // 
            // AddRowPlanes1
            // 
            this.AddRowPlanes1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRowPlanes1.Location = new System.Drawing.Point(3, 3);
            this.AddRowPlanes1.Name = "AddRowPlanes1";
            this.AddRowPlanes1.Size = new System.Drawing.Size(120, 48);
            this.AddRowPlanes1.TabIndex = 0;
            this.AddRowPlanes1.Text = "Add row";
            this.AddRowPlanes1.UseVisualStyleBackColor = true;
            this.AddRowPlanes1.Click += new System.EventHandler(this.AddRowPlanes_Click);
            // 
            // PlanesLabel
            // 
            this.PlanesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlanesLabel.AutoSize = true;
            this.PlanesLabel.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlanesLabel.Location = new System.Drawing.Point(480, 0);
            this.PlanesLabel.Name = "PlanesLabel";
            this.PlanesLabel.Size = new System.Drawing.Size(69, 23);
            this.PlanesLabel.TabIndex = 0;
            this.PlanesLabel.Text = "Planes";
            this.PlanesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TanksPanel
            // 
            this.TanksPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TanksPanel.AutoScroll = true;
            this.TanksPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TanksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TanksPanel.Controls.Add(this.TanksTable);
            this.TanksPanel.Controls.Add(this.AddColumnTanks);
            this.TanksPanel.Controls.Add(this.tanksLable);
            this.TanksPanel.Location = new System.Drawing.Point(0, 10);
            this.TanksPanel.Name = "TanksPanel";
            this.TanksPanel.Size = new System.Drawing.Size(1030, 500);
            this.TanksPanel.TabIndex = 0;
            // 
            // TanksTable
            // 
            this.TanksTable.AutoSize = true;
            this.TanksTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TanksTable.ColumnCount = 1;
            this.TanksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TanksTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TanksTable.Controls.Add(this.AddRowTanks1, 0, 0);
            this.TanksTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TanksTable.Location = new System.Drawing.Point(3, 36);
            this.TanksTable.Name = "TanksTable";
            this.TanksTable.RowCount = 1;
            this.TanksTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TanksTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TanksTable.Size = new System.Drawing.Size(126, 54);
            this.TanksTable.TabIndex = 0;
            // 
            // AddRowTanks1
            // 
            this.AddRowTanks1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AddRowTanks1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddRowTanks1.Location = new System.Drawing.Point(3, 3);
            this.AddRowTanks1.Name = "AddRowTanks1";
            this.AddRowTanks1.Size = new System.Drawing.Size(120, 48);
            this.AddRowTanks1.TabIndex = 0;
            this.AddRowTanks1.Text = "Add row";
            this.AddRowTanks1.UseVisualStyleBackColor = true;
            this.AddRowTanks1.Click += new System.EventHandler(this.AddRowTanks_Click);
            // 
            // AddColumnTanks
            // 
            this.AddColumnTanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddColumnTanks.Font = new System.Drawing.Font("Arial Narrow", 10F);
            this.AddColumnTanks.Location = new System.Drawing.Point(135, 39);
            this.AddColumnTanks.Name = "AddColumnTanks";
            this.AddColumnTanks.Size = new System.Drawing.Size(15, 48);
            this.AddColumnTanks.TabIndex = 1;
            this.AddColumnTanks.Text = "+";
            this.AddColumnTanks.UseVisualStyleBackColor = true;
            this.AddColumnTanks.Click += new System.EventHandler(this.AddColumnTanks_Click);
            // 
            // tanksLable
            // 
            this.tanksLable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tanksLable.AutoSize = true;
            this.tanksLable.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tanksLable.Location = new System.Drawing.Point(485, 0);
            this.tanksLable.Name = "tanksLable";
            this.tanksLable.Size = new System.Drawing.Size(61, 23);
            this.tanksLable.TabIndex = 0;
            this.tanksLable.Text = "Tanks";
            this.tanksLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exportButton
            // 
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exportButton.Location = new System.Drawing.Point(264, 12);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(120, 48);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "EXPORT";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportButton.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reportButton.Location = new System.Drawing.Point(952, 12);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(60, 27);
            this.reportButton.TabIndex = 7;
            this.reportButton.Text = "Report";
            this.reportButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // supportButton
            // 
            this.supportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.supportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.supportButton.Font = new System.Drawing.Font("Verdana", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.supportButton.Location = new System.Drawing.Point(1012, 12);
            this.supportButton.Name = "supportButton";
            this.supportButton.Size = new System.Drawing.Size(60, 27);
            this.supportButton.TabIndex = 8;
            this.supportButton.Text = "Support";
            this.supportButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.supportButton.UseVisualStyleBackColor = true;
            this.supportButton.Click += new System.EventHandler(this.supportButton_Click);
            // 
            // flagPanel
            // 
            this.flagPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flagPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flagPanel.Location = new System.Drawing.Point(862, 12);
            this.flagPanel.Name = "flagPanel";
            this.flagPanel.Size = new System.Drawing.Size(87, 48);
            this.flagPanel.TabIndex = 9;
            this.flagPanel.Text = "flag";
            this.flagPanel.UseVisualStyleBackColor = true;
            this.flagPanel.Click += new System.EventHandler(this.flagPanel_Click);
            // 
            // copyrights
            // 
            this.copyrights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrights.AutoSize = true;
            this.copyrights.Location = new System.Drawing.Point(907, 669);
            this.copyrights.Name = "copyrights";
            this.copyrights.Size = new System.Drawing.Size(179, 13);
            this.copyrights.TabIndex = 10;
            this.copyrights.Text = "RailGunToaster 2024 v.1.0.1.4";
            // 
            // ModeInfo
            // 
            this.ModeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ModeInfo.AutoSize = true;
            this.ModeInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ModeInfo.Location = new System.Drawing.Point(0, 669);
            this.ModeInfo.Name = "ModeInfo";
            this.ModeInfo.Size = new System.Drawing.Size(64, 13);
            this.ModeInfo.TabIndex = 11;
            this.ModeInfo.Text = "Edit mode";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(100, 669);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(21, 13);
            this.StatusLabel.TabIndex = 12;
            this.StatusLabel.Text = "ok";
            // 
            // Lineup_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(1084, 681);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ModeInfo);
            this.Controls.Add(this.copyrights);
            this.Controls.Add(this.flagPanel);
            this.Controls.Add(this.supportButton);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.countryCombo);
            this.Controls.Add(this.saveScheme);
            this.Controls.Add(this.importButton);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Lineup_creator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Lineup creator";
            this.MainPanel.ResumeLayout(false);
            this.BluewaterPanel.ResumeLayout(false);
            this.BluewaterPanel.PerformLayout();
            this.BluewaterTable.ResumeLayout(false);
            this.CoastalfleetPanel.ResumeLayout(false);
            this.CoastalfleetPanel.PerformLayout();
            this.CoastalfleetTable.ResumeLayout(false);
            this.HelicoptersPanel.ResumeLayout(false);
            this.HelicoptersPanel.PerformLayout();
            this.HeliTable.ResumeLayout(false);
            this.PlanesPanel.ResumeLayout(false);
            this.PlanesPanel.PerformLayout();
            this.PlanesTable.ResumeLayout(false);
            this.TanksPanel.ResumeLayout(false);
            this.TanksPanel.PerformLayout();
            this.TanksTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button saveScheme;
        private System.Windows.Forms.ComboBox countryCombo;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel TanksPanel;
        private System.Windows.Forms.TableLayoutPanel TanksTable;
        private System.Windows.Forms.Button AddRowTanks1;
        private System.Windows.Forms.Label tanksLable;
        private System.Windows.Forms.Button AddColumnTanks;
        private System.Windows.Forms.Panel PlanesPanel;
        private System.Windows.Forms.TableLayoutPanel PlanesTable;
        private System.Windows.Forms.Button AddRowPlanes1;
        private System.Windows.Forms.Label PlanesLabel;
        private System.Windows.Forms.Button AddColumnPlanes;
        private System.Windows.Forms.Panel HelicoptersPanel;
        private System.Windows.Forms.Label helicopterslabel;
        private System.Windows.Forms.TableLayoutPanel HeliTable;
        private System.Windows.Forms.Button AddRowHeli;
        private System.Windows.Forms.Panel CoastalfleetPanel;
        private System.Windows.Forms.Button AddColumnCoastalFleet;
        private System.Windows.Forms.TableLayoutPanel CoastalfleetTable;
        private System.Windows.Forms.Button AddRowCoastalFleet;
        private System.Windows.Forms.Label coastalfleetlabel;
        private System.Windows.Forms.Button AddColumnHeli;
        private System.Windows.Forms.Panel BluewaterPanel;
        private System.Windows.Forms.TableLayoutPanel BluewaterTable;
        private System.Windows.Forms.Button AddRowBluewater;
        private System.Windows.Forms.Label bluewaterlabel;
        private System.Windows.Forms.Button AddColumnBluewater;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button supportButton;
        private System.Windows.Forms.Button flagPanel;
        private System.Windows.Forms.Label copyrights;
        private System.Windows.Forms.Label ModeInfo;
        private System.Windows.Forms.Label StatusLabel;
    }
}

