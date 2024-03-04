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
        private string country;
        private int backgroundImage;
        private int type;
        private int row;
        private int column;


        Image[] backgrounds =
        {
            Image.FromFile(@"config\OWN.png"),
            Image.FromFile(@"config\PREMIUM.png"),
            Image.FromFile(@"config\SQUAD.png")
        };

        public VehicleScreen(string country, int type, int senderrow, int sendercolumn, Control sender, Lineup_creator linc)
        {
            // 0 - tank | 1 - plane | 2 - heli | 3 - coastal | 4 - bluewater
            senderButton = sender;
            this.country = country;
            this.type = type;
            row = senderrow;
            column = sendercolumn;
            lc = linc;
            senderData = new VehicleData("BT-5", type, "https://encyclopedia.warthunder.com/i/slots/ussr_bt_5.png", 0);


            templates = new Templates(country);
            InitializeComponent();
            foreach (string name in templates.GetDataByCountry(country).Keys)
            {
                if (templates.GetDataByCountry(country)[name].type == type)
                {
                    VehicleName.Items.Add(name);
                    LinkCombobox.Items.Add(name);
                }
            }
        }

        public VehicleScreen(string country, int type, int senderrow, int sendercolumn, Control sender, VehicleData data, Lineup_creator linc)
        {
            this.country = country;
            this.type = type;
            row = senderrow;
            column = sendercolumn;
            senderButton = sender;
            senderData = data;
            name = senderData.name;
            text = senderData.name;
            backgroundImage = senderData.backgroudType;
            lc = linc;

            templates = new Templates(country);
            InitializeComponent();
            foreach (string name in templates.GetDataByCountry(country).Keys)
            {
                if (templates.GetDataByCountry(country)[name].type == type)
                {
                    VehicleName.Items.Add(name);
                    LinkCombobox.Items.Add(name);
                }
            }
            
            ChangeBackground();
            ChangeIcon(senderData.imageLink);
            VehicleTextLable.Text = name;
            VehicleName.SelectedItem = name;

        }


        private void BackgroundCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string backgroundChoice = BackgroundCombobox.SelectedItem.ToString();

            switch(backgroundChoice)
            {
                case "Own (blue)":
                    backgroundImage = 0;
                    break;
                case "Premium (golden)":
                    backgroundImage = 1;
                    break;
                case "Squadron (green)":
                    backgroundImage = 2;
                    break;
            }

            ChangeBackground();
        }


        private void ChangeBackground()
        {
            senderData.backgroudType = backgroundImage;
            PrevievPanel.BackgroundImage = backgrounds[backgroundImage];
        }

        private void ChangeIcon(string link)
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

        private void VehicleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = VehicleName.SelectedItem.ToString();
            if (templates.GetDataByCountry(country).ContainsKey(key))
            {
                VehicleData data = templates.GetDataByCountry(country)[key];
                VehicleText.Text = data.name;
                name = country + data.name;

                LinkCombobox.SelectedItem = data;
                ChangeIcon(data.imageLink);
                backgroundImage = data.backgroudType;
                ChangeBackground();
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
            
            lc.ChangeData(senderData, type, row, column);

            Bitmap bitmap = new Bitmap(backgrounds[backgroundImage]);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                using (Font verdanaFont = new Font("Verdana", 10, new FontStyle()))
                {
                    Image icon = iconPanel.BackgroundImage;
                    graphics.DrawImage(icon, 5, 5, icon.Width, icon.Height);

                    var format = new StringFormat() { Alignment = StringAlignment.Far };
                    var rect = new RectangleF(5, 5, 110, 38);

                    graphics.DrawString(text, verdanaFont, Brushes.White, rect, format);
                }
            }
            bitmap.Save($@"temp\{row}-{column}-{type}.png", System.Drawing.Imaging.ImageFormat.Png);
            senderData.buttonImage = $@"temp\{row}-{column}-{type}.png";
            senderButton.BackgroundImage = bitmap;
            
        }

        private void LinkCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeIcon(templates.GetLinkByName(country, LinkCombobox.SelectedItem.ToString()));
        }
    }
}
