
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BluewaterPanel = new System.Windows.Forms.Panel();
            this.BluewaterTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResizeBluewater = new System.Windows.Forms.Button();
            this.bluewaterlabel = new System.Windows.Forms.Label();
            this.CoastalfleetPanel = new System.Windows.Forms.Panel();
            this.CoastalfleetTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResizeCoastalFleet = new System.Windows.Forms.Button();
            this.coastalfleetlabel = new System.Windows.Forms.Label();
            this.HelicoptersPanel = new System.Windows.Forms.Panel();
            this.HeliTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResizeHeli = new System.Windows.Forms.Button();
            this.helicopterslabel = new System.Windows.Forms.Label();
            this.PlanesPanel = new System.Windows.Forms.Panel();
            this.PlanesTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResizePlanes = new System.Windows.Forms.Button();
            this.PlanesLabel = new System.Windows.Forms.Label();
            this.TanksPanel = new System.Windows.Forms.Panel();
            this.TanksTable = new System.Windows.Forms.TableLayoutPanel();
            this.ResizeTanks = new System.Windows.Forms.Button();
            this.tanksLable = new System.Windows.Forms.Label();
            this.flagButton = new System.Windows.Forms.Button();
            this.copyrights = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileItemList = new System.Windows.Forms.ToolStripMenuItem();
            this.saveScheme = new System.Windows.Forms.ToolStripMenuItem();
            this.importButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSettings_itemList = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleTipesOrderButton = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBoxPos1 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBoxPos2 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBoxPos3 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBoxPos4 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBoxPos5 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.decorTextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.decorTextTextbox = new System.Windows.Forms.ToolStripTextBox();
            this.decorONOFF = new System.Windows.Forms.ToolStripMenuItem();
            this.цветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorText = new System.Windows.Forms.ToolStripTextBox();
            this.backgroundColorPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.countryCombo = new System.Windows.Forms.ToolStripComboBox();
            this.flagLockedButton = new System.Windows.Forms.ToolStripMenuItem();
            this.modeInfoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpControls = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpEditingControls = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpEditModeKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpDeleteModeKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpFileControls = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpSaveKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpSaveAsKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpOpenKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpTablesControls = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpCleartanksKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpClearPlanesKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpClearHeliKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpClearCoastalKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpClearBluewaterKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpVTEControls = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpVESavenCloseKey = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpVECloseKey = new System.Windows.Forms.ToolStripMenuItem();
            this.reportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpGitHubPage = new System.Windows.Forms.ToolStripMenuItem();
            this.supportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.changeLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusLabel = new System.Windows.Forms.ToolStripMenuItem();
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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.BluewaterPanel);
            this.MainPanel.Controls.Add(this.CoastalfleetPanel);
            this.MainPanel.Controls.Add(this.HelicoptersPanel);
            this.MainPanel.Controls.Add(this.PlanesPanel);
            this.MainPanel.Controls.Add(this.TanksPanel);
            this.MainPanel.Name = "MainPanel";
            // 
            // BluewaterPanel
            // 
            resources.ApplyResources(this.BluewaterPanel, "BluewaterPanel");
            this.BluewaterPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BluewaterPanel.Controls.Add(this.BluewaterTable);
            this.BluewaterPanel.Controls.Add(this.bluewaterlabel);
            this.BluewaterPanel.Name = "BluewaterPanel";
            // 
            // BluewaterTable
            // 
            resources.ApplyResources(this.BluewaterTable, "BluewaterTable");
            this.BluewaterTable.Controls.Add(this.ResizeBluewater, 0, 0);
            this.BluewaterTable.Name = "BluewaterTable";
            // 
            // ResizeBluewater
            // 
            resources.ApplyResources(this.ResizeBluewater, "ResizeBluewater");
            this.ResizeBluewater.Name = "ResizeBluewater";
            this.ResizeBluewater.UseVisualStyleBackColor = true;
            this.ResizeBluewater.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeBluewater_MouseUp);
            // 
            // bluewaterlabel
            // 
            resources.ApplyResources(this.bluewaterlabel, "bluewaterlabel");
            this.bluewaterlabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bluewaterlabel.Name = "bluewaterlabel";
            // 
            // CoastalfleetPanel
            // 
            resources.ApplyResources(this.CoastalfleetPanel, "CoastalfleetPanel");
            this.CoastalfleetPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CoastalfleetPanel.Controls.Add(this.CoastalfleetTable);
            this.CoastalfleetPanel.Controls.Add(this.coastalfleetlabel);
            this.CoastalfleetPanel.Name = "CoastalfleetPanel";
            // 
            // CoastalfleetTable
            // 
            resources.ApplyResources(this.CoastalfleetTable, "CoastalfleetTable");
            this.CoastalfleetTable.Controls.Add(this.ResizeCoastalFleet, 0, 0);
            this.CoastalfleetTable.Name = "CoastalfleetTable";
            // 
            // ResizeCoastalFleet
            // 
            resources.ApplyResources(this.ResizeCoastalFleet, "ResizeCoastalFleet");
            this.ResizeCoastalFleet.Name = "ResizeCoastalFleet";
            this.ResizeCoastalFleet.UseVisualStyleBackColor = true;
            this.ResizeCoastalFleet.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeCoastalFleet_MouseUp);
            // 
            // coastalfleetlabel
            // 
            resources.ApplyResources(this.coastalfleetlabel, "coastalfleetlabel");
            this.coastalfleetlabel.Name = "coastalfleetlabel";
            // 
            // HelicoptersPanel
            // 
            resources.ApplyResources(this.HelicoptersPanel, "HelicoptersPanel");
            this.HelicoptersPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelicoptersPanel.Controls.Add(this.HeliTable);
            this.HelicoptersPanel.Controls.Add(this.helicopterslabel);
            this.HelicoptersPanel.Name = "HelicoptersPanel";
            // 
            // HeliTable
            // 
            resources.ApplyResources(this.HeliTable, "HeliTable");
            this.HeliTable.Controls.Add(this.ResizeHeli, 0, 0);
            this.HeliTable.Name = "HeliTable";
            // 
            // ResizeHeli
            // 
            resources.ApplyResources(this.ResizeHeli, "ResizeHeli");
            this.ResizeHeli.Name = "ResizeHeli";
            this.ResizeHeli.UseVisualStyleBackColor = true;
            this.ResizeHeli.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeHeli_MouseUp);
            // 
            // helicopterslabel
            // 
            resources.ApplyResources(this.helicopterslabel, "helicopterslabel");
            this.helicopterslabel.Name = "helicopterslabel";
            // 
            // PlanesPanel
            // 
            resources.ApplyResources(this.PlanesPanel, "PlanesPanel");
            this.PlanesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PlanesPanel.Controls.Add(this.PlanesTable);
            this.PlanesPanel.Controls.Add(this.PlanesLabel);
            this.PlanesPanel.Name = "PlanesPanel";
            // 
            // PlanesTable
            // 
            resources.ApplyResources(this.PlanesTable, "PlanesTable");
            this.PlanesTable.Controls.Add(this.ResizePlanes, 0, 0);
            this.PlanesTable.Name = "PlanesTable";
            // 
            // ResizePlanes
            // 
            resources.ApplyResources(this.ResizePlanes, "ResizePlanes");
            this.ResizePlanes.Name = "ResizePlanes";
            this.ResizePlanes.UseVisualStyleBackColor = true;
            this.ResizePlanes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizePlanes_MouseUp);
            // 
            // PlanesLabel
            // 
            resources.ApplyResources(this.PlanesLabel, "PlanesLabel");
            this.PlanesLabel.Name = "PlanesLabel";
            // 
            // TanksPanel
            // 
            resources.ApplyResources(this.TanksPanel, "TanksPanel");
            this.TanksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TanksPanel.Controls.Add(this.TanksTable);
            this.TanksPanel.Controls.Add(this.tanksLable);
            this.TanksPanel.Name = "TanksPanel";
            // 
            // TanksTable
            // 
            resources.ApplyResources(this.TanksTable, "TanksTable");
            this.TanksTable.Controls.Add(this.ResizeTanks, 0, 0);
            this.TanksTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.TanksTable.Name = "TanksTable";
            // 
            // ResizeTanks
            // 
            resources.ApplyResources(this.ResizeTanks, "ResizeTanks");
            this.ResizeTanks.Name = "ResizeTanks";
            this.ResizeTanks.UseVisualStyleBackColor = true;
            this.ResizeTanks.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizeTanks_MouseUp);
            // 
            // tanksLable
            // 
            resources.ApplyResources(this.tanksLable, "tanksLable");
            this.tanksLable.Name = "tanksLable";
            // 
            // flagButton
            // 
            resources.ApplyResources(this.flagButton, "flagButton");
            this.flagButton.Name = "flagButton";
            this.flagButton.UseVisualStyleBackColor = true;
            this.flagButton.Click += new System.EventHandler(this.flagButton_Click);
            // 
            // copyrights
            // 
            resources.ApplyResources(this.copyrights, "copyrights");
            this.copyrights.Name = "copyrights";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItemList,
            this.exportSettings_itemList,
            this.countryCombo,
            this.flagLockedButton,
            this.modeInfoButton,
            this.toolStripMenuItem1,
            this.changeLanguage,
            this.StatusLabel});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            // 
            // fileItemList
            // 
            this.fileItemList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importButton,
            this.saveScheme,
            this.exportButton});
            this.fileItemList.ForeColor = System.Drawing.Color.Black;
            this.fileItemList.Name = "fileItemList";
            resources.ApplyResources(this.fileItemList, "fileItemList");
            // 
            // saveScheme
            // 
            this.saveScheme.Name = "saveScheme";
            resources.ApplyResources(this.saveScheme, "saveScheme");
            this.saveScheme.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // importButton
            // 
            this.importButton.Name = "importButton";
            resources.ApplyResources(this.importButton, "importButton");
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Name = "exportButton";
            resources.ApplyResources(this.exportButton, "exportButton");
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // exportSettings_itemList
            // 
            this.exportSettings_itemList.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleTipesOrderButton,
            this.toolStripSeparator2,
            this.decorTextButton,
            this.цветФонаToolStripMenuItem});
            this.exportSettings_itemList.ForeColor = System.Drawing.Color.Black;
            this.exportSettings_itemList.Name = "exportSettings_itemList";
            resources.ApplyResources(this.exportSettings_itemList, "exportSettings_itemList");
            // 
            // vehicleTipesOrderButton
            // 
            this.vehicleTipesOrderButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comboBoxPos1,
            this.comboBoxPos2,
            this.comboBoxPos3,
            this.comboBoxPos4,
            this.comboBoxPos5});
            this.vehicleTipesOrderButton.Name = "vehicleTipesOrderButton";
            resources.ApplyResources(this.vehicleTipesOrderButton, "vehicleTipesOrderButton");
            // 
            // comboBoxPos1
            // 
            this.comboBoxPos1.Items.AddRange(new object[] {
            resources.GetString("comboBoxPos1.Items"),
            resources.GetString("comboBoxPos1.Items1"),
            resources.GetString("comboBoxPos1.Items2"),
            resources.GetString("comboBoxPos1.Items3"),
            resources.GetString("comboBoxPos1.Items4"),
            resources.GetString("comboBoxPos1.Items5")});
            this.comboBoxPos1.Name = "comboBoxPos1";
            resources.ApplyResources(this.comboBoxPos1, "comboBoxPos1");
            this.comboBoxPos1.SelectedIndexChanged += new System.EventHandler(this.comboBoxPos1_SelectedIndexChanged);
            // 
            // comboBoxPos2
            // 
            this.comboBoxPos2.Items.AddRange(new object[] {
            resources.GetString("comboBoxPos2.Items"),
            resources.GetString("comboBoxPos2.Items1"),
            resources.GetString("comboBoxPos2.Items2"),
            resources.GetString("comboBoxPos2.Items3"),
            resources.GetString("comboBoxPos2.Items4"),
            resources.GetString("comboBoxPos2.Items5")});
            this.comboBoxPos2.Name = "comboBoxPos2";
            resources.ApplyResources(this.comboBoxPos2, "comboBoxPos2");
            this.comboBoxPos2.SelectedIndexChanged += new System.EventHandler(this.comboBoxPos2_SelectedIndexChanged);
            // 
            // comboBoxPos3
            // 
            this.comboBoxPos3.Items.AddRange(new object[] {
            resources.GetString("comboBoxPos3.Items"),
            resources.GetString("comboBoxPos3.Items1"),
            resources.GetString("comboBoxPos3.Items2"),
            resources.GetString("comboBoxPos3.Items3"),
            resources.GetString("comboBoxPos3.Items4"),
            resources.GetString("comboBoxPos3.Items5")});
            this.comboBoxPos3.Name = "comboBoxPos3";
            resources.ApplyResources(this.comboBoxPos3, "comboBoxPos3");
            this.comboBoxPos3.SelectedIndexChanged += new System.EventHandler(this.comboBoxPos3_SelectedIndexChanged);
            // 
            // comboBoxPos4
            // 
            this.comboBoxPos4.Items.AddRange(new object[] {
            resources.GetString("comboBoxPos4.Items"),
            resources.GetString("comboBoxPos4.Items1"),
            resources.GetString("comboBoxPos4.Items2"),
            resources.GetString("comboBoxPos4.Items3"),
            resources.GetString("comboBoxPos4.Items4"),
            resources.GetString("comboBoxPos4.Items5")});
            this.comboBoxPos4.Name = "comboBoxPos4";
            resources.ApplyResources(this.comboBoxPos4, "comboBoxPos4");
            this.comboBoxPos4.SelectedIndexChanged += new System.EventHandler(this.comboBoxPos4_SelectedIndexChanged);
            // 
            // comboBoxPos5
            // 
            this.comboBoxPos5.Items.AddRange(new object[] {
            resources.GetString("comboBoxPos5.Items"),
            resources.GetString("comboBoxPos5.Items1"),
            resources.GetString("comboBoxPos5.Items2"),
            resources.GetString("comboBoxPos5.Items3"),
            resources.GetString("comboBoxPos5.Items4"),
            resources.GetString("comboBoxPos5.Items5")});
            this.comboBoxPos5.Name = "comboBoxPos5";
            resources.ApplyResources(this.comboBoxPos5, "comboBoxPos5");
            this.comboBoxPos5.SelectedIndexChanged += new System.EventHandler(this.comboBoxPos5_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // decorTextButton
            // 
            this.decorTextButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.decorTextTextbox,
            this.decorONOFF});
            this.decorTextButton.Name = "decorTextButton";
            resources.ApplyResources(this.decorTextButton, "decorTextButton");
            // 
            // decorTextTextbox
            // 
            this.decorTextTextbox.Name = "decorTextTextbox";
            resources.ApplyResources(this.decorTextTextbox, "decorTextTextbox");
            this.decorTextTextbox.TextChanged += new System.EventHandler(this.decorTextTextbox_TextChanged);
            // 
            // decorONOFF
            // 
            this.decorONOFF.Name = "decorONOFF";
            resources.ApplyResources(this.decorONOFF, "decorONOFF");
            this.decorONOFF.Click += new System.EventHandler(this.decorTextButton_Click);
            // 
            // цветФонаToolStripMenuItem
            // 
            this.цветФонаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorText,
            this.backgroundColorPreview});
            this.цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
            resources.ApplyResources(this.цветФонаToolStripMenuItem, "цветФонаToolStripMenuItem");
            // 
            // backgroundColorText
            // 
            this.backgroundColorText.Name = "backgroundColorText";
            resources.ApplyResources(this.backgroundColorText, "backgroundColorText");
            this.backgroundColorText.TextChanged += new System.EventHandler(this.backgroundColorText_TextChanged);
            // 
            // backgroundColorPreview
            // 
            this.backgroundColorPreview.Name = "backgroundColorPreview";
            resources.ApplyResources(this.backgroundColorPreview, "backgroundColorPreview");
            // 
            // countryCombo
            // 
            resources.ApplyResources(this.countryCombo, "countryCombo");
            this.countryCombo.Items.AddRange(new object[] {
            resources.GetString("countryCombo.Items"),
            resources.GetString("countryCombo.Items1"),
            resources.GetString("countryCombo.Items2"),
            resources.GetString("countryCombo.Items3"),
            resources.GetString("countryCombo.Items4"),
            resources.GetString("countryCombo.Items5"),
            resources.GetString("countryCombo.Items6"),
            resources.GetString("countryCombo.Items7"),
            resources.GetString("countryCombo.Items8"),
            resources.GetString("countryCombo.Items9")});
            this.countryCombo.Name = "countryCombo";
            this.countryCombo.SelectedIndexChanged += new System.EventHandler(this.countryCombo_SelectedIndexChanged);
            // 
            // flagLockedButton
            // 
            this.flagLockedButton.ForeColor = System.Drawing.Color.Black;
            this.flagLockedButton.Name = "flagLockedButton";
            resources.ApplyResources(this.flagLockedButton, "flagLockedButton");
            this.flagLockedButton.Click += new System.EventHandler(this.flagLockedButton_Click);
            // 
            // modeInfoButton
            // 
            this.modeInfoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.modeInfoButton.Name = "modeInfoButton";
            resources.ApplyResources(this.modeInfoButton, "modeInfoButton");
            this.modeInfoButton.Click += new System.EventHandler(this.modeInfoButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpControls,
            this.reportButton,
            this.HelpGitHubPage,
            this.supportButton});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // HelpControls
            // 
            this.HelpControls.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HelpEditingControls,
            this.HelpEditModeKey,
            this.HelpDeleteModeKey,
            this.HelpFileControls,
            this.HelpSaveKey,
            this.HelpSaveAsKey,
            this.HelpOpenKey,
            this.HelpTablesControls,
            this.HelpCleartanksKey,
            this.HelpClearPlanesKey,
            this.HelpClearHeliKey,
            this.HelpClearCoastalKey,
            this.HelpClearBluewaterKey,
            this.HelpVTEControls,
            this.HelpVESavenCloseKey,
            this.HelpVECloseKey});
            this.HelpControls.Name = "HelpControls";
            resources.ApplyResources(this.HelpControls, "HelpControls");
            // 
            // HelpEditingControls
            // 
            this.HelpEditingControls.Name = "HelpEditingControls";
            resources.ApplyResources(this.HelpEditingControls, "HelpEditingControls");
            // 
            // HelpEditModeKey
            // 
            this.HelpEditModeKey.Name = "HelpEditModeKey";
            resources.ApplyResources(this.HelpEditModeKey, "HelpEditModeKey");
            // 
            // HelpDeleteModeKey
            // 
            this.HelpDeleteModeKey.Name = "HelpDeleteModeKey";
            resources.ApplyResources(this.HelpDeleteModeKey, "HelpDeleteModeKey");
            // 
            // HelpFileControls
            // 
            this.HelpFileControls.Name = "HelpFileControls";
            resources.ApplyResources(this.HelpFileControls, "HelpFileControls");
            // 
            // HelpSaveKey
            // 
            this.HelpSaveKey.Name = "HelpSaveKey";
            resources.ApplyResources(this.HelpSaveKey, "HelpSaveKey");
            // 
            // HelpSaveAsKey
            // 
            this.HelpSaveAsKey.Name = "HelpSaveAsKey";
            resources.ApplyResources(this.HelpSaveAsKey, "HelpSaveAsKey");
            // 
            // HelpOpenKey
            // 
            this.HelpOpenKey.Name = "HelpOpenKey";
            resources.ApplyResources(this.HelpOpenKey, "HelpOpenKey");
            // 
            // HelpTablesControls
            // 
            this.HelpTablesControls.Name = "HelpTablesControls";
            resources.ApplyResources(this.HelpTablesControls, "HelpTablesControls");
            // 
            // HelpCleartanksKey
            // 
            this.HelpCleartanksKey.Name = "HelpCleartanksKey";
            resources.ApplyResources(this.HelpCleartanksKey, "HelpCleartanksKey");
            // 
            // HelpClearPlanesKey
            // 
            this.HelpClearPlanesKey.Name = "HelpClearPlanesKey";
            resources.ApplyResources(this.HelpClearPlanesKey, "HelpClearPlanesKey");
            // 
            // HelpClearHeliKey
            // 
            this.HelpClearHeliKey.Name = "HelpClearHeliKey";
            resources.ApplyResources(this.HelpClearHeliKey, "HelpClearHeliKey");
            // 
            // HelpClearCoastalKey
            // 
            this.HelpClearCoastalKey.Name = "HelpClearCoastalKey";
            resources.ApplyResources(this.HelpClearCoastalKey, "HelpClearCoastalKey");
            // 
            // HelpClearBluewaterKey
            // 
            this.HelpClearBluewaterKey.Name = "HelpClearBluewaterKey";
            resources.ApplyResources(this.HelpClearBluewaterKey, "HelpClearBluewaterKey");
            // 
            // HelpVTEControls
            // 
            this.HelpVTEControls.Name = "HelpVTEControls";
            resources.ApplyResources(this.HelpVTEControls, "HelpVTEControls");
            // 
            // HelpVESavenCloseKey
            // 
            this.HelpVESavenCloseKey.Name = "HelpVESavenCloseKey";
            resources.ApplyResources(this.HelpVESavenCloseKey, "HelpVESavenCloseKey");
            // 
            // HelpVECloseKey
            // 
            this.HelpVECloseKey.Name = "HelpVECloseKey";
            resources.ApplyResources(this.HelpVECloseKey, "HelpVECloseKey");
            // 
            // reportButton
            // 
            this.reportButton.Name = "reportButton";
            resources.ApplyResources(this.reportButton, "reportButton");
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // HelpGitHubPage
            // 
            this.HelpGitHubPage.Name = "HelpGitHubPage";
            resources.ApplyResources(this.HelpGitHubPage, "HelpGitHubPage");
            this.HelpGitHubPage.Click += new System.EventHandler(this.HelpGitHubPage_Click);
            // 
            // supportButton
            // 
            this.supportButton.Name = "supportButton";
            resources.ApplyResources(this.supportButton, "supportButton");
            this.supportButton.Click += new System.EventHandler(this.supportButton_Click);
            // 
            // changeLanguage
            // 
            this.changeLanguage.ForeColor = System.Drawing.Color.Black;
            this.changeLanguage.Name = "changeLanguage";
            resources.ApplyResources(this.changeLanguage, "changeLanguage");
            this.changeLanguage.Click += new System.EventHandler(this.changeLanguage_Click);
            // 
            // StatusLabel
            // 
            this.StatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StatusLabel.Name = "StatusLabel";
            resources.ApplyResources(this.StatusLabel, "StatusLabel");
            // 
            // Lineup_creator
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.Controls.Add(this.flagButton);
            this.Controls.Add(this.copyrights);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Lineup_creator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel TanksPanel;
        private System.Windows.Forms.TableLayoutPanel TanksTable;
        private System.Windows.Forms.Button ResizeTanks;
        private System.Windows.Forms.Label tanksLable;
        private System.Windows.Forms.Panel PlanesPanel;
        private System.Windows.Forms.TableLayoutPanel PlanesTable;
        private System.Windows.Forms.Button ResizePlanes;
        private System.Windows.Forms.Label PlanesLabel;
        private System.Windows.Forms.Panel HelicoptersPanel;
        private System.Windows.Forms.Label helicopterslabel;
        private System.Windows.Forms.TableLayoutPanel HeliTable;
        private System.Windows.Forms.Button ResizeHeli;
        private System.Windows.Forms.Panel CoastalfleetPanel;
        private System.Windows.Forms.TableLayoutPanel CoastalfleetTable;
        private System.Windows.Forms.Button ResizeCoastalFleet;
        private System.Windows.Forms.Label coastalfleetlabel;
        private System.Windows.Forms.Panel BluewaterPanel;
        private System.Windows.Forms.TableLayoutPanel BluewaterTable;
        private System.Windows.Forms.Button ResizeBluewater;
        private System.Windows.Forms.Label bluewaterlabel;
        private System.Windows.Forms.Button flagButton;
        private System.Windows.Forms.Label copyrights;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileItemList;
        private System.Windows.Forms.ToolStripMenuItem saveScheme;
        private System.Windows.Forms.ToolStripMenuItem importButton;
        private System.Windows.Forms.ToolStripMenuItem exportButton;
        private System.Windows.Forms.ToolStripMenuItem exportSettings_itemList;
        private System.Windows.Forms.ToolStripMenuItem vehicleTipesOrderButton;
        private System.Windows.Forms.ToolStripComboBox countryCombo;
        private System.Windows.Forms.ToolStripMenuItem flagLockedButton;
        private System.Windows.Forms.ToolStripMenuItem modeInfoButton;
        private System.Windows.Forms.ToolStripMenuItem StatusLabel;
        private System.Windows.Forms.ToolStripComboBox comboBoxPos1;
        private System.Windows.Forms.ToolStripComboBox comboBoxPos2;
        private System.Windows.Forms.ToolStripComboBox comboBoxPos3;
        private System.Windows.Forms.ToolStripComboBox comboBoxPos4;
        private System.Windows.Forms.ToolStripComboBox comboBoxPos5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem decorTextButton;
        private System.Windows.Forms.ToolStripTextBox decorTextTextbox;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportButton;
        private System.Windows.Forms.ToolStripMenuItem supportButton;
        private System.Windows.Forms.ToolStripMenuItem HelpControls;
        private System.Windows.Forms.ToolStripMenuItem HelpGitHubPage;
        private System.Windows.Forms.ToolStripMenuItem HelpEditModeKey;
        private System.Windows.Forms.ToolStripMenuItem HelpDeleteModeKey;
        private System.Windows.Forms.ToolStripMenuItem HelpSaveKey;
        private System.Windows.Forms.ToolStripMenuItem HelpSaveAsKey;
        private System.Windows.Forms.ToolStripMenuItem HelpCleartanksKey;
        private System.Windows.Forms.ToolStripMenuItem HelpClearPlanesKey;
        private System.Windows.Forms.ToolStripMenuItem HelpClearHeliKey;
        private System.Windows.Forms.ToolStripMenuItem HelpClearCoastalKey;
        private System.Windows.Forms.ToolStripMenuItem HelpClearBluewaterKey;
        private System.Windows.Forms.ToolStripMenuItem HelpEditingControls;
        private System.Windows.Forms.ToolStripMenuItem HelpFileControls;
        private System.Windows.Forms.ToolStripMenuItem HelpOpenKey;
        private System.Windows.Forms.ToolStripMenuItem HelpTablesControls;
        private System.Windows.Forms.ToolStripMenuItem HelpVTEControls;
        private System.Windows.Forms.ToolStripMenuItem HelpVESavenCloseKey;
        private System.Windows.Forms.ToolStripMenuItem HelpVECloseKey;
        private System.Windows.Forms.ToolStripMenuItem decorONOFF;
        private System.Windows.Forms.ToolStripMenuItem цветФонаToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox backgroundColorText;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorPreview;
        private System.Windows.Forms.ToolStripMenuItem changeLanguage;
    }
}

