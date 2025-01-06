using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Net;

namespace Lineups_creator
{
    public partial class VehicleScreen : Form
    {
        private Templates templates;
        Lineup_creator lc;
        private Control senderButton;
        private VehicleData senderData = new VehicleData();
        private string text;
        private string name;
        private float fontSize = Properties.Settings.Default.FontSize;

        private int backgroundindex;
        private int type;
        private int row;
        private int column;

        public VehicleScreen(int countryID, int type, int senderrow, int sendercolumn, Control sender, Lineup_creator linc)
        {
            // 0 - tank | 1 - plane | 2 - heli | 3 - coastal | 4 - bluewater
            senderButton = sender;

            this.type = type;
            row = senderrow;
            column = sendercolumn;
            lc = linc;
            senderData = new VehicleData("N/A", type, "N/A", 0, "N/A", 0);

            templates = new Templates(countryID);

            
            Text = $"{res.LocalisationRes.tile}[{row},{column}]";
            InitializeComponent();
            fontSizeInput.Text = $"{fontSize}";
            int i = 0;
            foreach (string path in linc.backgroundImagePaths)
            {
                if (path == null || !path.Contains(".png"))
                {
                    continue;
                }
                if (i < 3)
                {
                    BackgroundCombobox.Items.Add(path);
                    i++;
                } else
                {
                    BackgroundCombobox.Items.Add(path.Substring(7));
                }
            }


            foreach (string name in templates.template.Keys)
            {
                VehicleData fillData = templates.template[name];
                if (fillData.type == type || type == -1)
                {
                    VehicleName.Items.Add(name);
                    LinkCombobox.Items.Add(name);
                    WTIDCombobox.Items.Add(fillData.wtID);
                }
            };
            VehicleTextLable.Font = new Font(lc.pfc.Families[0], VehicleTextLable.Font.Size);
            VehicleText.Font = new Font(lc.pfc.Families[0], VehicleTextLable.Font.Size);
        }

        public VehicleScreen(int countryID, int type, int senderrow, int sendercolumn, Control sender, VehicleData data, Lineup_creator linc)
        {

            this.type = type;
            row = senderrow;
            column = sendercolumn;
            senderButton = sender;
            senderData = data;
            senderData.numberOfUnits = data.numberOfUnits;
            name = senderData.name;
            text = senderData.name;
            backgroundindex = senderData.backgroudType;
            lc = linc;
            
            templates = new Templates(countryID);

            Text = $"{res.LocalisationRes.tile}[{row},{column}]";
            InitializeComponent();
            foreach (string path in linc.backgroundImagePaths)
            {
                BackgroundCombobox.Items.Add(path.Substring(7));
            }
            fontSizeInput.Text = $"{fontSize}";
            

            foreach (string name in templates.template.Keys)
            {
                VehicleData fillData = templates.template[name];
                if (fillData.type == type || type == -1)
                {
                    VehicleName.Items.Add(name);
                    LinkCombobox.Items.Add(name);
                    WTIDCombobox.Items.Add(fillData.wtID);
                }
            }
            ChangeBackground();
            ChangeIcon(senderData.imageLink);
            
            VehicleTextLable.Text = name;
            VehicleName.SelectedItem = name;
            LinkCombobox.SelectedItem = senderData.name;
            unitsNumberInput.Value = data.numberOfUnits;
            WTIDCombobox.SelectedItem = senderData.wtID;

            VehicleTextLable.Font = new Font(lc.pfc.Families[0], VehicleTextLable.Font.Size);
            VehicleText.Font = new Font(lc.pfc.Families[0], VehicleTextLable.Font.Size);
        }


        // Background
        private void BackgroundCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            backgroundindex = BackgroundCombobox.SelectedIndex;
            ChangeBackground();
        }
        private void ChangeBackground()
        {
            senderData.backgroudType = backgroundindex;
            Image background;
            switch (backgroundindex)
            {
                case 0:
                    background = Properties.Resources.bg_base;
                    break;
                case 1:
                    background = Properties.Resources.bg_premium;
                    break;
                case 2:
                    background = Properties.Resources.bg_squad;
                    break;
                default:
                    Image backgroundToCopy = Image.FromFile(lc.backgroundImagePaths[backgroundindex]);

                    background = new Bitmap(backgroundToCopy);
                    backgroundToCopy.Dispose();
                    break;
            }
            BackgroundCombobox.SelectedIndex = backgroundindex;
            PrevievPanel.BackgroundImage = background;
        }

        // Icon
        private void ChangeIcon(string link)
        {
            if (link == "N/A")
            {
                return;
            }

            WebClient webClient = new WebClient();

            webClient.DownloadFile(link, $@"temp\icon{row}-{column}-{type}.bmp");
            webClient.Dispose();

            Image icontocopy = Image.FromFile($@"temp\icon{row}-{column}-{type}.bmp");

            Image icon = new Bitmap(icontocopy);
            icontocopy.Dispose();

            FileInfo file = new FileInfo($@"temp\icon{row}-{column}-{type}.bmp");
            file.Delete();

            float ratio = icon.Height / 42f;
            int width = Convert.ToInt32(icon.Width / ratio);
            icon = new Bitmap(icon, new Size(width, 42));

            iconPanel.BackgroundImage = icon;

            senderData.imageLink = link;
        }
        private void LinkCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIcon(templates.GetLinkByName(LinkCombobox.SelectedItem.ToString()));
        }

        // Text
        private void VehicleText_TextChanged(object sender, EventArgs e)
        {
            senderData.name = VehicleText.Text;
            VehicleTextLable.Text = VehicleText.Text;
            text = VehicleText.Text;
        }
        private void fontSizeInput_TextChanged(object sender, EventArgs e)
        {
            try
            {
                fontSize = float.Parse(fontSizeInput.Text);
                VehicleTextLable.Font = new Font(lc.pfc.Families[0], fontSize, new FontStyle());
                Properties.Settings.Default.FontSize = fontSize;
                Properties.Settings.Default.Save();
            }
            catch
            {

            }
        }

        // CDK
        private void WTIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            senderData.wtID = WTIDCombobox.SelectedItem.ToString();
        }
        private void unitsNumberInput_ValueChanged(object sender, EventArgs e)
        {
            senderData.numberOfUnits = Convert.ToInt32(unitsNumberInput.Value);
        }

        // Template changed
        private void VehicleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = VehicleName.SelectedItem.ToString();
            if (templates.template.ContainsKey(key))
            {
                VehicleData data = templates.template[key];
                VehicleText.Text = data.name;

                LinkCombobox.SelectedItem = data.name;
                WTIDCombobox.SelectedItem = data.wtID;
                backgroundindex = data.backgroudType;
                ChangeIcon(data.imageLink);
                ChangeBackground();

                senderData = data;
            }
        }
        
        // Save
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save_data();
        }
        private void Save_data()
        {
            try
            {
                Image background;
                switch (backgroundindex)
                {
                    case 0:
                        background = Properties.Resources.bg_base;
                        break;
                    case 1:
                        background = Properties.Resources.bg_premium;
                        break;
                    case 2:
                        background = Properties.Resources.bg_squad;
                        break;
                    default:
                        background = Image.FromFile(lc.backgroundImagePaths[backgroundindex]);
                        break;
                }
                Bitmap bitmap = new Bitmap(background);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font verdanaWTFont = new Font(lc.pfc.Families[0], VehicleTextLable.Font.Size))
                    {
                        Image icon = iconPanel.BackgroundImage;
                        if (icon == null)
                        {
                            senderData.imageLink = "N/A";
                        }
                        else
                        {
                            graphics.DrawImage(icon, 5, 5, icon.Width, icon.Height);
                        }

                        var format = new StringFormat() { Alignment = StringAlignment.Far };
                        var rect = new RectangleF(5, 5, 110, 38);

                        graphics.DrawString(text, verdanaWTFont, Brushes.White, rect, format);
                    }
                }
                string path = type == -1 ? $@"temp\{row}-{column}-m.png" : $@"temp\{row}-{column}-{type}.png";
                bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                senderData.buttonImage = path;
                senderData.pos = new int[] { row, column };
                senderButton.BackgroundImage = bitmap;
                lc.ChangeData(senderData, type, row, column);


            }
            catch
            {

            }
        }

        // shotcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter | Keys.Control))
            {
                Save_data();
                Close();
            }
            else if (keyData == Keys.Escape)
            {
                Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
