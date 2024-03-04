using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Lineups_creator
{
    public partial class FlagEditor : Form
    {
        string dir;
        Lineup_creator lc;

        public FlagEditor(string directory, Lineup_creator linc)
        {
            lc = linc;
            InitializeComponent();
            dir = directory;

        }
        // Normal position - 16; 175

        // download image via link
        private void linkButton_CheckedChanged(object sender, EventArgs e)
        {
            fileButton.Checked = false;
            linkPanel.Visible = true; filePanel.Visible = false;
        }
        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string link = linkBox.Text;

                WebClient webClient = new WebClient();
                webClient.DownloadFile(link, @"temp\flag_raw.bmp");
                webClient.Dispose();

                ChangePreview(@"temp\flag_raw.bmp");

                FileInfo file = new FileInfo(@"temp\flag_raw.bmp");
                file.Delete();

            }
            catch
            {
                lc.StatusChange("Wrong link", Color.FromArgb(192, 0, 0));
            }
        }

        // open via file explorer
        private void fileButton_CheckedChanged(object sender, EventArgs e)
        {
            linkButton.Checked = false;
            filePanel.Visible = true; linkPanel.Visible = false;
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG file |*.png|Jpeg file |*.jpeg";
            openFileDialog.Title = "Open flag";
            openFileDialog.InitialDirectory = $@"{dir}\saves";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                try
                {
                    ChangePreview(openFileDialog.FileName);
                }
                catch
                {
                    lc.StatusChange("Wrong file name", Color.FromArgb(192, 0, 0));
                }
            }

        }


        // save 
        private void saveButton_Click(object sender, EventArgs e)
        {
            lc.OpenFlag();
        }

        private void ChangePreview(string path)
        {
            Image flagImage = Image.FromFile(path);
            Image flag = new Bitmap(flagImage);
            flagImage.Dispose();

            float ratio = flag.Height / 48f;
            int width = Convert.ToInt32(flag.Width / ratio);
            flag = new Bitmap(flag, new Size(width, 48));
            flag.Save(@"temp\flag.png", System.Drawing.Imaging.ImageFormat.Png);
            flag.Dispose();

            Image flagtocopy = Image.FromFile(@"temp\flag.png");

            flag = new Bitmap(flagtocopy);
            flagtocopy.Dispose();


            flagPreviewPanel.Size = new Size(flag.Width * 2, 96);
            flagPreviewPanel.BackgroundImage = flag;
            flagPreviewPanel.Location = new Point(Size.Width / 2 - flag.Width, flagPreviewPanel.Location.Y);
            
        }

        
    }
}
