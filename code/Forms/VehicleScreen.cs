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
        private string[] countries =
        {
            "USA", 
            "Germany", 
            "USSR",
            "Great Britain",
            "Japan",
            "China",
            "Italy",
            "France",
            "Sweden",
            "Israel"
        };

        private string country;
        private int backgroundindex;
        private int type;
        private int row;
        private int column;

        public VehicleScreen(int countryID, int type, int senderrow, int sendercolumn, Control sender, Lineup_creator linc)
        {
            // 0 - tank | 1 - plane | 2 - heli | 3 - coastal | 4 - bluewater
            senderButton = sender;
            if (countryID != -1)
                country = countries[countryID];
            this.type = type;
            row = senderrow;
            column = sendercolumn;
            lc = linc;
            senderData = new VehicleData("N/A", type, "N/A", 0, "N/A", 0);

            templates = new Templates(country);
            InitializeComponent();

            foreach (string path in linc.backgroundImagesPaths)
            {
                BackgroundCombobox.Items.Add(path.Substring(7));
            }


            foreach (string name in templates.GetDataByCountry(country).Keys)
            {
                VehicleData fillData = templates.GetDataByCountry(country)[name];
                if (fillData.type == type)
                {
                    VehicleName.Items.Add(name);
                    LinkCombobox.Items.Add(name);
                    WTIDCombobox.Items.Add(fillData.wtID);
                }
            }
        }

        public VehicleScreen(int countryID, int type, int senderrow, int sendercolumn, Control sender, VehicleData data, Lineup_creator linc)
        {
            if (countryID != -1)
                country = countries[countryID];
            this.type = type;
            row = senderrow;
            column = sendercolumn;
            senderButton = sender;
            senderData = data;
            name = senderData.name;
            text = senderData.name;
            backgroundindex = senderData.backgroudType;
            lc = linc;
            
            templates = new Templates(country);
            InitializeComponent();
            foreach (string name in templates.GetDataByCountry(country).Keys)
            {
                VehicleData fillData = templates.GetDataByCountry(country)[name];
                if (fillData.type == type)
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
            unitsNumberInput.Value = senderData.numberOfUnits;
            WTIDCombobox.SelectedItem = senderData.wtID;
        }


        private void BackgroundCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            backgroundindex = BackgroundCombobox.SelectedIndex;
            ChangeBackground();
        }

        private void ChangeBackground()
        {
            senderData.backgroudType = backgroundindex;

            Image backgroundToCopy = Image.FromFile(lc.backgroundImagesPaths[backgroundindex]);

            Image background = new Bitmap(backgroundToCopy);
            backgroundToCopy.Dispose();

            PrevievPanel.BackgroundImage = background;
        }

        private void ChangeIcon(string link)
        {
            if (link != "N/A")
            {
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
            
        }

        private void VehicleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = VehicleName.SelectedItem.ToString();
            if (templates.GetDataByCountry(country).ContainsKey(key))
            {
                VehicleData data = templates.GetDataByCountry(country)[key];
                VehicleText.Text = data.name;

                LinkCombobox.SelectedItem = data.name;
                WTIDCombobox.SelectedItem = data.wtID;
                backgroundindex = data.backgroudType;
                ChangeIcon(data.imageLink);
                ChangeBackground();

                senderData = data;


            }
        }

        private void VehicleText_TextChanged(object sender, EventArgs e)
        {
            senderData.name = VehicleText.Text;
            VehicleTextLable.Text = VehicleText.Text;
            text = VehicleText.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save_data();
        }

        private void Save_data()
        {
            try
            {
                Image background = Image.FromFile(lc.backgroundImagesPaths[backgroundindex]);
                Bitmap bitmap = new Bitmap(background);

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font verdanaFont = new Font("Verdana", 10, new FontStyle()))
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

                        graphics.DrawString(text, verdanaFont, Brushes.White, rect, format);
                    }
                }
                bitmap.Save($@"temp\{row}-{column}-{type}.png", System.Drawing.Imaging.ImageFormat.Png);
                senderData.buttonImage = $@"temp\{row}-{column}-{type}.png";
                senderData.pos = new int[] { row, column };
                senderButton.BackgroundImage = bitmap;
                lc.ChangeData(senderData, type, row, column);

            }
            catch
            {

            }
        }


        private void LinkCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIcon(templates.GetLinkByName(country, LinkCombobox.SelectedItem.ToString()));
        }

        private void WTIDCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            senderData.wtID = WTIDCombobox.SelectedItem.ToString();
        }

        private void unitsNumberInput_ValueChanged(object sender, EventArgs e)
        {
            senderData.numberOfUnits = Convert.ToInt32(unitsNumberInput.Value);
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
