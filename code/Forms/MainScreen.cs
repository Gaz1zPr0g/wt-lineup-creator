using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace Lineups_creator
{

    public partial class Lineup_creator : Form
    {
        int country = -1;
        string dir = Application.StartupPath;
        string[] flagsURL =
        {
            "https://wiki.warthunder.com/images/thumb/9/9f/USA_flag.png/130px-USA_flag.png",
            "https://wiki.warthunder.com/images/thumb/4/49/Germany_flag.png/130px-Germany_flag.png",
            "https://wiki.warthunder.com/images/thumb/f/f9/USSR_flag.png/130px-USSR_flag.png",
            "https://wiki.warthunder.com/images/thumb/d/d0/Britain_flag.png/130px-Britain_flag.png",
            "https://wiki.warthunder.com/images/thumb/2/2e/Japan_flag.png/130px-Japan_flag.png",
            "https://wiki.warthunder.com/images/thumb/a/ac/China_flag.png/130px-China_flag.png",
            "https://wiki.warthunder.com/images/thumb/e/e9/Italy_flag.png/130px-Italy_flag.png",
            "https://wiki.warthunder.com/images/thumb/7/73/France_flag.png/130px-France_flag.png",
            "https://wiki.warthunder.com/images/thumb/c/ca/Sweden_flag.png/130px-Sweden_flag.png",
            "https://wiki.warthunder.com/images/thumb/f/f9/Israel_flag.png/130px-Israel_flag.png"
        };
        bool deleteMode = false;
        bool flagLocked = false;
        bool drawDecor = true;
        string decorText = "◊";
        Timer timer;
        ArraySizes arrSizes = new ArraySizes();
        VehicleData[,] tanksData;
        VehicleData[,] planesData;
        VehicleData[,] helicoptersData;
        VehicleData[,] coastalFleetData;
        VehicleData[,] bluewaterFleetData;

        public string[] backgroundImagesPaths;


        int[] generatorIndexes = { 0, 1, 2, 3, 4 };

        Color imageBackgroundColor = Color.FromArgb(36, 46, 51);
        Color waterMarkColor = Color.FromArgb(46, 56, 61);

        public Lineup_creator()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }

            InitializeComponent();
            copyrights.Text = $"RailGunToaster 2024 {Application.ProductVersion}";

            Directory.CreateDirectory($@"{dir}\temp");
            Directory.CreateDirectory($@"{dir}\config");
            WebClient webClient = new WebClient();

            string urlVersion = "https://www.dropbox.com/scl/fi/d2er1hozhboimxe40dsm6/version.txt?rlkey=2rdsq80onzl7iu24y8segjs7x&st=fveasz1g&dl=1";
            webClient.DownloadFile(new System.Uri(urlVersion), $@"{dir}\temp\version.txt");
            webClient.Dispose();

            StreamReader sr = new StreamReader(@"temp\version.txt");
            var newVersionstr = sr.ReadLine();
            sr.Dispose();

            var currentVersion = Application.ProductVersion.ToString();
            var newVersion = newVersionstr;
            newVersion = newVersion.Replace(".", "");
            currentVersion = currentVersion.Replace(".", "");

            if (Convert.ToInt32(newVersion) > Convert.ToInt32(currentVersion))
            {
                DialogResult dialogResult = MessageBox.Show(text: $"{newVersionstr}\n{res.LocalisationRes.newVersion}", caption: "Version info", buttons: MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    webClient.DownloadFile(new Uri("https://www.dropbox.com/scl/fi/qqx1fbvl1pz0ync68icii/Setup.zip?rlkey=oy297ynt9xvu1t9vi7zyydgbb&st=6g62t2zh&dl=1"), @"temp\Setup.zip");
                    webClient.Dispose();
                    

                    ZipFile.ExtractToDirectory(@"temp\Setup.zip", @"temp\");
                    File.Delete(@"temp\Setup.zip");

                    Process p = new Process();
                    p.StartInfo.FileName = "msiexec.exe";
                    p.StartInfo.Arguments = string.Format("/i temp\\Setup.msi");
                    
                    p.Start();
                    Environment.Exit(1);
                }

            }

            
            Directory.CreateDirectory($@"{dir}\export");
            Directory.CreateDirectory($@"{dir}\saves");

            if (!Directory.Exists($@"{dir}\config\OWN.png"))
            {
                webClient.DownloadFile("https://wiki.warthunder.com/images/3/39/Item_own.png", @"config\OWN.png");

                Image imagetocopy = Image.FromFile(@"config\OWN.png");
                Image image = new Bitmap(imagetocopy);
                imagetocopy.Dispose();
                File.Delete(@"config\OWN.png");
                image.Save(@"config\OWN.png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();
            };
            if (!Directory.Exists($@"{dir}\config\PREMIUM.png"))
            {
                webClient.DownloadFile("https://wiki.warthunder.com/images/1/15/Item_prem.png", @"config\PREMIUM.png");

                Image imagetocopy = Image.FromFile(@"config\PREMIUM.png");
                Image image = new Bitmap(imagetocopy);
                imagetocopy.Dispose();
                File.Delete(@"config\PREMIUM.png");
                image.Save(@"config\PREMIUM.png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();
            }
            if (!Directory.Exists($@"{dir}\config\SQUAD.png"))
            {
                webClient.DownloadFile("https://wiki.warthunder.com/images/7/70/Item_squad.png", @"config\SQUAD.png");

                Image imagetocopy = Image.FromFile(@"config\SQUAD.png");
                Image image = new Bitmap(imagetocopy);
                imagetocopy.Dispose();
                File.Delete(@"config\SQUAD.png");
                image.Save(@"config\SQUAD.png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();
            }
        

            DirectoryInfo configDirInfo = new DirectoryInfo($@"{ dir }\config");
            int pngNum = 0;
            foreach (FileInfo fi in configDirInfo.GetFiles())
            {
                if (fi.Name.Contains(".png"))
                {
                    pngNum++;
                }
            }

            backgroundImagesPaths = new string[configDirInfo.GetFiles().Length];

            backgroundImagesPaths[0] = @"config\OWN.png";
            backgroundImagesPaths[1] = @"config\PREMIUM.png";
            backgroundImagesPaths[2] = @"config\SQUAD.png";


            int i = 3;
            foreach (FileInfo fi in configDirInfo.GetFiles())
            {
                if (fi.Name.Contains(".png") && i < pngNum && (!fi.Name.Contains("OWN.png") || !fi.Name.Contains("PREMIUM.png") || !fi.Name.Contains("SQUAD.png")))
                {
                    backgroundImagesPaths[i] = @"config\" + fi.Name;
                    i++;
                }
            }


            comboBoxPos1.SelectedItem = 0;
            comboBoxPos2.SelectedItem = 1;
            comboBoxPos3.SelectedItem = 2;
            comboBoxPos4.SelectedItem = 3;
            comboBoxPos5.SelectedItem = 4;
        }


        // cell size 120x48


        // Imports
        private void importButton_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON file |*.json";
            openFileDialog.Title = "Open scheme";
            openFileDialog.InitialDirectory = $@"{dir}\saves";
            openFileDialog.ShowDialog();


            if (openFileDialog.FileName != "")
            {
                StatusLabel.Text = "Opening file";
                StatusLabel.ForeColor = Color.FromArgb(239, 170, 58);



                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        string sizeline = sr.ReadLine();
                        arrSizes = JsonConvert.DeserializeObject<ArraySizes>(sizeline);

                        tanksData = new VehicleData[arrSizes.tanks.Item1, arrSizes.tanks.Item2];
                        planesData = new VehicleData[arrSizes.planes.Item1, arrSizes.planes.Item2];
                        helicoptersData = new VehicleData[arrSizes.helis.Item1, arrSizes.helis.Item2];
                        coastalFleetData = new VehicleData[arrSizes.coastalFleet.Item1, arrSizes.coastalFleet.Item2];
                        bluewaterFleetData = new VehicleData[arrSizes.bluewaterFleet.Item1, arrSizes.bluewaterFleet.Item2];

                        int[] maxTrow = new int[arrSizes.tanks.Item2];
                        int[] maxProw = new int[arrSizes.planes.Item2];
                        int[] maxHrow = new int[arrSizes.helis.Item2];
                        int[] maxCrow = new int[arrSizes.coastalFleet.Item2];
                        int[] maxBrow = new int[arrSizes.bluewaterFleet.Item2];
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            VehicleData vd = JsonConvert.DeserializeObject<VehicleData>(line);
                            string imageFile = vd.buttonImage.Substring(5);
                            imageFile = imageFile.Substring(0, imageFile.IndexOf('.'));
                            int row = vd.pos[0]; int col = vd.pos[1];
                            vd.buttonImage = $@"temp\{row}-{col}-{vd.type}.png";
                            switch (vd.type)
                            {
                                case 0:
                                    tanksData[row, col] = vd;
                                    maxTrow[col] = Math.Max(maxTrow[col], row + 1);
                                    break;
                                case 1:
                                    planesData[row, col] = vd;
                                    maxProw[col] = Math.Max(maxProw[col], row + 1);
                                    break;
                                case 2:
                                    helicoptersData[row, col] = vd;
                                    maxHrow[col] = Math.Max(maxHrow[col], row + 1);
                                    break;
                                case 3:
                                    coastalFleetData[row, col] = vd;
                                    maxCrow[col] = Math.Max(maxHrow[col], row + 1);
                                    break;
                                case 4:
                                    bluewaterFleetData[row, col] = vd;
                                    maxBrow[col] = Math.Max(maxBrow[col], row + 1);
                                    break;
                            }
                        }
                        sr.Close();

                        if (arrSizes.tanks.Item1 > 0 && arrSizes.tanks.Item2 > 0)
                        {
                            TanksTable.Controls.Clear();
                            TanksTable.RowCount = arrSizes.tanks.Item1 + 1; TanksTable.ColumnCount = arrSizes.tanks.Item2 + 1;
                            TanksTable.Controls.Add(ResizeTanks, 0, maxTrow[0]);
                            for (int row = 0; row < arrSizes.tanks.Item1; row++)
                            {
                                for (int col = 0; col < arrSizes.tanks.Item2; col++)
                                {
                                    
                                    if (tanksData[row, col] == null)
                                    {
                                        tanksData[row, col] = new VehicleData() { type = 0 };
                                    }
                                    if (col != 0 && row == 0)
                                    {
                                        Button newResize = new Button()
                                        {
                                            Width = 120,
                                            Height = 48, 
                                            Text = res.LocalisationRes.resize,
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newResize.MouseUp += ResizeTanks_MouseUp;
                                        TanksTable.Controls.Add(newResize, col, maxTrow[col]);
                                    }
                                    if (row < maxTrow[col])
                                    {
                                        Create_Button(row, col, 0, TanksTable, tanksData[row, col]);
                                    }
                                }
                            }
                        };

                        if (arrSizes.planes.Item1 > 0 && arrSizes.planes.Item2 > 0)
                        {
                            PlanesTable.Controls.Clear();
                            PlanesTable.RowCount = arrSizes.planes.Item1 + 1; PlanesTable.ColumnCount = arrSizes.planes.Item2 + 1;
                            PlanesTable.Controls.Add(ResizePlanes, 0, maxProw[0]);
                            for (int row = 0; row < arrSizes.planes.Item1; row++)
                            {
                                for (int col = 0; col < arrSizes.planes.Item2; col++)
                                {
                                    if (planesData[row, col] == null)
                                    {
                                        planesData[row, col] = new VehicleData() { type = 1 };
                                    }
                                    if (col != 0 && row == 0)
                                    {
                                        Button newResize = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = res.LocalisationRes.resize,
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newResize.MouseUp += ResizePlanes_MouseUp;
                                        PlanesTable.Controls.Add(newResize, col, maxProw[col]);
                                    }
                                    if (row < maxProw[col])
                                    {
                                        Create_Button(row, col, 1, PlanesTable, planesData[row, col]);
                                    }
                                }
                            }
                        };

                        if (arrSizes.helis.Item1 > 0 && arrSizes.helis.Item2 > 0)
                        {
                            HeliTable.Controls.Clear();
                            HeliTable.RowCount = arrSizes.helis.Item1 + 1; HeliTable.ColumnCount = arrSizes.helis.Item2 + 1;
                            HeliTable.Controls.Add(ResizeHeli, 0, maxHrow[0]);
                            for (int row = 0; row < arrSizes.helis.Item1; row++)
                            {
                                for (int col = 0; col < arrSizes.helis.Item2; col++)
                                {
                                    if (tanksData[row, col] == null)
                                    {
                                        tanksData[row, col] = new VehicleData() { type = 2 };
                                    }
                                    if (col != 0 && row == 0)
                                    {
                                        Button newResize = new Button()
                                                {
                                                    Width = 120,
                                                    Height = 48,
                                                    Text = res.LocalisationRes.resize,
                                                    Margin = new Padding(3, 3, 3, 3),
                                                    FlatStyle = FlatStyle.Flat,
                                                };
                                        newResize.MouseUp += ResizeHeli_MouseUp;
                                        HeliTable.Controls.Add(newResize, col, maxHrow[col]);
                                    }
                                    if (row < maxHrow[col])
                                    {
                                        Create_Button(row, col, 2, HeliTable, helicoptersData[row, col]);
                                    }
                                }
                            }
                        };

                        if (arrSizes.coastalFleet.Item1 > 0 && arrSizes.coastalFleet.Item2 > 0)
                        {
                            CoastalfleetTable.Controls.Clear();
                            CoastalfleetTable.RowCount = arrSizes.coastalFleet.Item1 + 1; CoastalfleetTable.ColumnCount = arrSizes.coastalFleet.Item2 + 1;
                            CoastalfleetTable.Controls.Add(ResizeCoastalFleet, 0, maxCrow[0]);
                            for (int row = 0; row < arrSizes.coastalFleet.Item1; row++)
                            {
                                for (int col = 0; col < arrSizes.coastalFleet.Item2; col++)
                                {
                                    if (coastalFleetData[row, col] == null)
                                    {
                                        coastalFleetData[row, col] = new VehicleData() { type = 3 };
                                    }
                                    if (col != 0 && row == 0)
                                    {
                                        Button newResize = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = res.LocalisationRes.resize,
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newResize.MouseUp += ResizeCoastalFleet_MouseUp;
                                        CoastalfleetTable.Controls.Add(newResize, col, maxCrow[col]);
                                    }
                                    if (row < maxCrow[col])
                                    {
                                        Create_Button(row, col, 3, CoastalfleetTable, coastalFleetData[row, col]);
                                    }
                                }
                            }
                        };

                        if (arrSizes.bluewaterFleet.Item1 > 0 && arrSizes.bluewaterFleet.Item2 > 0)
                        {
                            BluewaterTable.Controls.Clear();
                            BluewaterTable.RowCount = arrSizes.bluewaterFleet.Item1 + 1; BluewaterTable.ColumnCount = arrSizes.bluewaterFleet.Item2 + 1;
                            BluewaterTable.Controls.Add(ResizeBluewater, 0, maxBrow[0]);
                            for (int row = 0; row < arrSizes.bluewaterFleet.Item1; row++)
                            {
                                for (int col = 0; col < arrSizes.bluewaterFleet.Item2; col++)
                                {
                                    if (bluewaterFleetData[row, col] == null)
                                    {
                                        bluewaterFleetData[row, col] = new VehicleData() { type = 4 };
                                    }
                                    if (col != 0 && row == 0)
                                    {
                                        Button newResize = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = res.LocalisationRes.resize,
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newResize.MouseUp += ResizeBluewater_MouseUp;
                                        BluewaterTable.Controls.Add(newResize, col, maxBrow[col]);
                                    }
                                    if (row < maxBrow[col])
                                    {
                                        Create_Button(row, col, 4, BluewaterTable, bluewaterFleetData[row, col]);
                                    }
                                }
                                
                            }
                        };
                    }

                    StatusLabel.Text = "import complete";
                    StatusLabel.ForeColor = Color.FromArgb(0, 192, 0);
                    timer = new Timer { Interval = 5000 };
                    timer.Tick += TimerTick;
                    timer.Enabled = true;
                } catch
                {
                    StatusLabel.Text = "somthing went wrong!";
                    StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                    timer = new Timer { Interval = 5000 };
                    timer.Tick += TimerTick;
                    timer.Enabled = true;
                }
            }
            else
            {
                StatusLabel.Text = "Wrong file name";
                StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                timer = new Timer { Interval = 5000 };
                timer.Tick += TimerTick;
                timer.Enabled = true;
            }

        }
        private void Create_Button(int row, int col, int type, TableLayoutPanel tlp, VehicleData vd)
        {
            Button vehicle = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };



            if (vd.name != null)
            {
                Image icon = new Bitmap(1, 1);
                Image[] backgrounds = new Image[backgroundImagesPaths.Length];
                for (int i = 0; i < backgrounds.Length; i++)
                {
                    backgrounds[i] = Image.FromFile(backgroundImagesPaths[i]);
                }

                if(vd.imageLink != "N/A")
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(vd.imageLink, $@"temp\icon{row}-{col}-{type}.bmp");
                    webClient.Dispose();

                    Image icontocopy = Image.FromFile($@"temp\icon{row}-{col}-{type}.bmp");

                    icon = new Bitmap(icontocopy);
                    icontocopy.Dispose();

                    FileInfo file = new FileInfo($@"temp\icon{row}-{col}-{type}.bmp");
                    file.Delete();

                    float ratio = icon.Height / 42f;
                    int width = Convert.ToInt32(icon.Width / ratio);
                    icon = new Bitmap(icon, new Size(width, 42));
                }
                Bitmap bitmap = new Bitmap(1, 1);
                if (vd.backgroudType < backgrounds.Length)
                {
                    bitmap = (Bitmap)backgrounds[vd.backgroudType];
                } else
                {
                    bitmap = (Bitmap)backgrounds[0];
                }
                

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font verdanaFont = new Font("Verdana", 10, new FontStyle()))
                    {
                        if (vd.imageLink != "N/A")
                        {
                            graphics.DrawImage(icon, 5, 5, icon.Width, icon.Height);
                        }
                        
                        var format = new StringFormat() { Alignment = StringAlignment.Far };
                        var rect = new RectangleF(5, 5, 110, 38);

                        graphics.DrawString(vd.name, verdanaFont, Brushes.White, rect, format);
                    }
                }
                vehicle.BackgroundImage = bitmap;
                bitmap.Save(vd.buttonImage);
            }

            switch (type)
            {
                case 0:
                    vehicle.Click += TankButton_Click;
                    break;
                case 1:
                    vehicle.Click += PlaneButton_Click;
                    break;
                case 2:
                    vehicle.Click += HeliButton_Click;
                    break;
                case 3:
                    vehicle.Click += CoastalButton_Click;
                    break;
                case 4:
                    vehicle.Click += BluewaterButton_Click;
                    break;
            }
            if (col > 0)
            {
                tlp.Controls.Add(vehicle, col, row);
            }
            else
            {
                tlp.Controls.Add(vehicle, col, row);
            }

        }

        // Exports
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON file |*.json";
            saveFileDialog1.Title = "Save scheme";
            saveFileDialog1.InitialDirectory = $@"{dir}\saves";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    string output = JsonConvert.SerializeObject(arrSizes);
                    sw.WriteLine(output);
                    if (tanksData != null)
                    {
                        for (int row = 0; row < arrSizes.tanks.Item1; row++)
                        {
                            for (int col = 0; col < arrSizes.tanks.Item2; col++)
                            {
                                if (tanksData[row, col] != null && tanksData[row, col].name != null)
                                {
                                        tanksData[row, col].pos = new int[] { row, col };
                                        output = JsonConvert.SerializeObject(tanksData[row, col]);
                                        sw.WriteLine(output);
                                }
                                
                            }
                        }
                    }
                    if (planesData != null)
                    {
                        for (int row = 0; row < arrSizes.planes.Item1; row++)
                        {
                            for (int col = 0; col < arrSizes.planes.Item2; col++)
                            {
                                if (planesData[row, col] != null && planesData[row, col].name != null)
                                {
                                    planesData[row, col].pos = new int[] { row, col };
                                    output = JsonConvert.SerializeObject(planesData[row, col]);
                                    sw.WriteLine(output);
                                }
                            }
                        }

                        foreach(VehicleData vd in planesData)
                        {
                            if (vd != null)
                            {
                                if (vd.name != null)
                                {
                                    output = JsonConvert.SerializeObject(vd);
                                    sw.WriteLine(output);
                                }
                            }
                            
                        }
                    }
                    if (helicoptersData != null)
                    {
                        for (int row = 0; row < arrSizes.helis.Item1; row++)
                        {
                            for (int col = 0; col < arrSizes.helis.Item2; col++)
                            {
                                if (helicoptersData[row, col] != null && helicoptersData[row, col].name != null)
                                {
                                    helicoptersData[row, col].pos = new int[] { row, col };
                                    output = JsonConvert.SerializeObject(helicoptersData[row, col]);
                                    sw.WriteLine(output);
                                }
                            }
                        }
                    }
                    if (coastalFleetData != null)
                    {
                        for (int row = 0; row < arrSizes.coastalFleet.Item1; row++)
                        {
                            for (int col = 0; col < arrSizes.coastalFleet.Item2; col++)
                            {
                                if (coastalFleetData[row, col] != null && coastalFleetData[row, col].name != null)
                                {
                                    coastalFleetData[row, col].pos = new int[] { row, col };
                                    output = JsonConvert.SerializeObject(coastalFleetData[row, col]);
                                    sw.WriteLine(output);
                                }
                            }
                        }
                    }
                    if (bluewaterFleetData != null)
                    {
                        for (int row = 0; row < arrSizes.bluewaterFleet.Item1; row++)
                        {
                            for (int col = 0; col < arrSizes.bluewaterFleet.Item2; col++)
                            {
                                bluewaterFleetData[row, col].pos = new int[] { row, col };
                                output = JsonConvert.SerializeObject(bluewaterFleetData[row, col]);
                                sw.WriteLine(output);
                            }
                        }
                    }
                }
                StatusLabel.Text = "saved";
                StatusLabel.ForeColor = Color.FromArgb(0, 192, 0);
                timer = new Timer { Interval = 5000 };
                timer.Tick += TimerTick;
                timer.Enabled = true;
            }
            else
            {
                StatusLabel.Text = "Wrong file name";
                StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                timer = new Timer { Interval = 5000 };
                timer.Tick += TimerTick;
                timer.Enabled = true;
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = "",
                Filter = "PNG file (*.png)|*.png|TXT file (*.txt)|*.txt",
                Title = "Choose file to save",
                InitialDirectory = $@"{dir}\export",
            };
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "" )
            {
                if (saveFileDialog.FilterIndex == 1)
                {
                    try
                    {
                        int tsizeX = (arrSizes.tanks.Item1 >= 1 && arrSizes.tanks.Item2 >= 1) ? 48 + 5 + 52 * arrSizes.tanks.Item1 : 0;
                        int tsizeY = arrSizes.tanks.Item2 >= 1 ? 10 + 124 * arrSizes.tanks.Item2 : 0;

                        int psizeX = (arrSizes.planes.Item1 >= 1 && arrSizes.planes.Item2 >= 1) ? 48 + 5 + 52 * arrSizes.planes.Item1 : 0;
                        int psizeY = arrSizes.planes.Item2 >= 1 ? 10 + 124 * arrSizes.planes.Item2 : 0;
                        int maxx = Math.Max(tsizeY, psizeY);
                        int hsizeX = (arrSizes.helis.Item1 >= 1 && arrSizes.helis.Item2 >= 1) ? 48 + 5 + 52 * arrSizes.helis.Item1 : 0;
                        int hsizeY = arrSizes.helis.Item2 >= 1 ? 10 + 124 * arrSizes.helis.Item2 : 0;
                        maxx = Math.Max(maxx, hsizeY);
                        int csizeX = (arrSizes.coastalFleet.Item1 >= 1 && arrSizes.coastalFleet.Item2 >= 1) ? 48 + 5 + 52 * arrSizes.coastalFleet.Item1 : 0;
                        int csizeY = arrSizes.coastalFleet.Item2 >= 1 ? 10 + 124 * arrSizes.coastalFleet.Item2 : 0;
                        maxx = Math.Max(maxx, csizeY);
                        int bsizeX = (arrSizes.bluewaterFleet.Item1 >= 1 && arrSizes.bluewaterFleet.Item2 >= 1) ? 48 + 5 + 52 * arrSizes.bluewaterFleet.Item1 : 0;
                        int bsizeY = arrSizes.bluewaterFleet.Item2 >= 1 ? 10 + 124 * arrSizes.bluewaterFleet.Item2 : 0;
                        maxx = Math.Max(maxx, bsizeY);
                        Bitmap bitmap = new Bitmap(maxx, tsizeX + psizeX + hsizeX + csizeX + bsizeX);
                        int x; int y;
                        for (x = 0; x < bitmap.Width; x++)
                        {
                            for (y = 0; y < bitmap.Height; y++)
                            {
                                bitmap.SetPixel(x, y, imageBackgroundColor);
                            }
                        }

                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (Font backgroundFont = new Font("Verdana", 8, new FontStyle()))
                            {
                                graphics.DrawString("https://github.com/Gaz1zPr0g/wt-lineup-creator", backgroundFont, new SolidBrush(waterMarkColor), 5, 5);
                                if (drawDecor)
                                {
                                    for (y = 0; y < bitmap.Height; y += 8)
                                    {
                                        if (y < 16)
                                        {
                                            x = y == 0 ? 280 : 288;
                                        }
                                        else
                                        {
                                            x = y % 16 == 0 ? 0 : 8;
                                        }
                                        while (x < bitmap.Width)
                                        {
                                            graphics.DrawString(decorText, backgroundFont, new SolidBrush(waterMarkColor), x, y);
                                            x += decorText.Length * 4 + 16;
                                        }
                                    }
                                }
                            }
                        }

                        x = 0; y = 20;
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            using (Font textFont = new Font("Verdana", 12, new FontStyle()))
                            {
                                Pen pen = new Pen(Brushes.White) { Width = 2 };
                                if (File.Exists(@"temp\flag.png") && country != -1)
                                {
                                    Image flagtocopy = Image.FromFile(@"temp\flag.png");

                                    Image flag = new Bitmap(flagtocopy);
                                    flagtocopy.Dispose();

                                    float ratio = flag.Height / 40f;
                                    int width = Convert.ToInt32(flag.Width / ratio);
                                    flag = new Bitmap(flag, new Size(width, 40));
                                    graphics.DrawImage(flag, bitmap.Width - flag.Width - 5, 5, flag.Width, flag.Height);
                                    flag.Dispose();
                                }

                                for (int index = 0; index < 5; index++)
                                {
                                    if (arrSizes.tanks.Item1 >= 1 && arrSizes.tanks.Item2 >= 1 && generatorIndexes[index] == 0)
                                    {
                                        x += 5; y += 10;
                                        graphics.DrawString(res.LocalisationRes.tanks, textFont, Brushes.White, x, y);
                                        y += 19;
                                        graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                        y += 5;
                                        for (int i = 0; i < arrSizes.tanks.Item1; i++)
                                        {
                                            for (int j = 0; j < arrSizes.tanks.Item2; j++)
                                            {
                                                if (tanksData[i, j].buttonImage != null)
                                                {
                                                    Image im = Image.FromFile(tanksData[i, j].buttonImage);
                                                    graphics.DrawImage(im, x, y, im.Width, im.Height);
                                                    im.Dispose();
                                                }

                                                x += 124;
                                            }
                                            x = 5;
                                            y += 52;
                                        }
                                    }
                                    else if (arrSizes.planes.Item1 >= 1 && arrSizes.planes.Item2 >= 1 && generatorIndexes[index] == 1)
                                    {
                                        x = 5; y += 10;
                                        graphics.DrawString(res.LocalisationRes.planes, textFont, Brushes.White, x, y);
                                        y += 19;
                                        graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                        y += 5;
                                        for (int i = 0; i < arrSizes.planes.Item1; i++)
                                        {
                                            for (int j = 0; j < arrSizes.planes.Item2; j++)
                                            {
                                                if (planesData[i, j].buttonImage != null)
                                                {
                                                    Image im = Image.FromFile(planesData[i, j].buttonImage);
                                                    graphics.DrawImage(im, x, y, im.Width, im.Height);
                                                    im.Dispose();
                                                }
                                                x += 124;
                                            }
                                            x = 5;
                                            y += 52;
                                        }
                                    }
                                    else if (arrSizes.helis.Item1 >= 1 && arrSizes.helis.Item2 >= 1 && generatorIndexes[index] == 2)
                                    {
                                        x = 5; y += 10;
                                        graphics.DrawString(res.LocalisationRes.helicopters, textFont, Brushes.White, x, y);
                                        y += 19;
                                        graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                        y += 5;
                                        for (int i = 0; i < arrSizes.helis.Item1; i++)
                                        {
                                            for (int j = 0; j < arrSizes.helis.Item2; j++)
                                            {
                                                if (helicoptersData[i, j].buttonImage != null)
                                                {
                                                    Image im = Image.FromFile(helicoptersData[i, j].buttonImage);
                                                    graphics.DrawImage(im, x, y, im.Width, im.Height);
                                                    im.Dispose();
                                                }
                                                x += 124;
                                            }
                                            x = 5;
                                            y += 52;
                                        }
                                    }
                                    else if (arrSizes.coastalFleet.Item1 >= 1 && arrSizes.coastalFleet.Item2 >= 1 && generatorIndexes[index] == 3)
                                    {
                                        x = 5; y += 10;
                                        graphics.DrawString(res.LocalisationRes.coastalFleet, textFont, Brushes.White, x, y);
                                        y += 19;
                                        graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                        y += 5;
                                        for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
                                        {
                                            for (int j = 0; j < arrSizes.coastalFleet.Item2; j++)
                                            {
                                                if (coastalFleetData[i, j].buttonImage != null)
                                                {
                                                    Image im = Image.FromFile(coastalFleetData[i, j].buttonImage);
                                                    graphics.DrawImage(im, x, y, im.Width, im.Height);
                                                    im.Dispose();
                                                }
                                                x += 124;
                                            }
                                            x = 5;
                                            y += 52;
                                        }
                                    }
                                    else if (arrSizes.bluewaterFleet.Item1 >= 1 && arrSizes.bluewaterFleet.Item2 >= 1 && generatorIndexes[index] == 4)
                                    {
                                        x = 5; y += 10;
                                        graphics.DrawString(res.LocalisationRes.bluewaterFleet, textFont, Brushes.White, x, y);
                                        y += 19;
                                        graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                        y += 5;
                                        for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
                                        {
                                            for (int j = 0; j < arrSizes.bluewaterFleet.Item2; j++)
                                            {
                                                if (bluewaterFleetData[i, j].buttonImage != null)
                                                {
                                                    Image im = Image.FromFile(bluewaterFleetData[i, j].buttonImage);
                                                    graphics.DrawImage(im, x, y, im.Width, im.Height);
                                                    im.Dispose();
                                                }
                                                x += 124;
                                            }
                                            x = 5;
                                            y += 52;
                                        }
                                    }
                                }

                            }
                        }
                        bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        bitmap.Dispose();

                        StatusLabel.Text = "export to png completed!";
                        StatusLabel.ForeColor = Color.FromArgb(0, 192, 0);
                        timer = new Timer { Interval = 5000 };
                        timer.Tick += TimerTick;
                        timer.Enabled = true;

                    }
                    catch
                    {
                        StatusLabel.Text = "somthing went wrong!";
                        StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                        timer = new Timer { Interval = 5000 };
                        timer.Tick += TimerTick;
                        timer.Enabled = true;
                    }
                } 
                else if (saveFileDialog.FilterIndex == 2)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        string unlimitedUnits = "";
                        string limitedUnits = "";
                        if (tanksData != null)
                        {
                            foreach (VehicleData item in tanksData)
                            {
                                if (item.name != null && item.wtID != "N/A")
                                {
                                    if (item.numberOfUnits == 0)
                                    {
                                        unlimitedUnits += $"\t{item.wtID}:b=yes\n";
                                    }
                                    else
                                    {
                                        limitedUnits += $"\t{item.wtID}:i={item.numberOfUnits}\n";
                                    }
                                }
                            }
                        }
                        if (planesData != null)
                        {
                            foreach (VehicleData item in planesData)
                            {
                                if (item.name != null && item.wtID != "N/A")
                                {
                                    if (item.numberOfUnits == 0)
                                    {
                                        unlimitedUnits += $"\t{item.wtID}:b=yes\n";
                                    }
                                    else
                                    {
                                        limitedUnits += $"\t{item.wtID}:i={item.numberOfUnits}\n";
                                    }
                                }
                            }
                        }
                        if (helicoptersData != null)
                        {
                            foreach (VehicleData item in helicoptersData)
                            {
                                if (item.name != null && item.wtID != "N/A")
                                {
                                    if (item.numberOfUnits == 0)
                                    {
                                        unlimitedUnits += $"\t{item.wtID}:b=yes\n";
                                    }
                                    else
                                    {
                                        limitedUnits += $"\t{item.wtID}:i={item.numberOfUnits}\n";
                                    }
                                }
                            }
                        }
                        if (coastalFleetData != null)
                        {
                            foreach (VehicleData item in coastalFleetData)
                            {
                                if (item.name != null && item.wtID != "N/A")
                                {
                                    if (item.numberOfUnits == 0)
                                    {
                                        unlimitedUnits += $"\t{item.wtID}:b=yes\n";
                                    }
                                    else
                                    {
                                        limitedUnits += $"\t{item.wtID}:i={item.numberOfUnits}\n";
                                    }
                                }
                            }
                        }
                        if (bluewaterFleetData != null)
                        {
                            foreach (VehicleData item in bluewaterFleetData)
                            {
                                if (item.name != null && item.wtID != "N/A")
                                {
                                    if (item.numberOfUnits == 0)
                                    {
                                        unlimitedUnits += $"\t{item.wtID}:b=yes\n";
                                    }
                                    else
                                    {
                                        limitedUnits += $"\t{item.wtID}:i={item.numberOfUnits}\n";
                                    }
                                }
                            }
                        }

                        sw.WriteLine("limitedUnits{");
                        sw.WriteLine(limitedUnits);
                        sw.WriteLine("}\nunlimitedUnits{");
                        sw.WriteLine(unlimitedUnits);
                        sw.WriteLine("}");
                    }

                    StatusLabel.Text = "export to txt completed!";
                    StatusLabel.ForeColor = Color.FromArgb(0, 192, 0);
                    timer = new Timer { Interval = 5000 };
                    timer.Tick += TimerTick;
                    timer.Enabled = true;
                }
            }
            else
            {
                StatusLabel.Text = "Wrong file name";
                StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                timer = new Timer { Interval = 5000 };
                timer.Tick += TimerTick;
                timer.Enabled = true;
            }

        }

        // Menu buttons
        private void flagLockedButton_Click(object sender, EventArgs e)
        {
            flagLocked = !(flagLockedButton.Text == res.LocalisationRes.flagLocked);
            flagLockedButton.Text = flagLocked ? res.LocalisationRes.flagLocked : res.LocalisationRes.flagUnlocked;
        }
        private void modeInfoButton_Click(object sender, EventArgs e)
        {
            if (deleteMode)
            {
                deleteMode = false;
                modeInfoButton.Text = res.LocalisationRes.EditModeStr;
                modeInfoButton.ForeColor = Color.FromArgb(0, 192, 0);
            }
            else
            {
                deleteMode = true;
                modeInfoButton.Text = res.LocalisationRes.DeleteModeStr;
                modeInfoButton.ForeColor = Color.FromArgb(192, 0, 0);
            }
        }
        private void reportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Gaz1zPr0g/wt-lineup-creator/issues");
        }
        private void supportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://boosty.to/railguntoaster");
        }
        private void countryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                country = countryCombo.SelectedIndex;
                if (!flagLocked)
                {
                    DownloadFlag(flagsURL[countryCombo.SelectedIndex]);
                }
            } catch
            {

            }
        }
        private void backgroundColorText_TextChanged(object sender, EventArgs e)
        {
            string text = backgroundColorText.Text;

            if (text.Contains("#"))
            {
                try
                {
                    imageBackgroundColor = ColorTranslator.FromHtml(text);
                    backgroundColorText.BackColor = imageBackgroundColor;
                    byte redInd = Convert.ToByte(imageBackgroundColor.R + 10);
                    byte greenInd = Convert.ToByte(imageBackgroundColor.G + 10);
                    byte blueInd = Convert.ToByte(imageBackgroundColor.B + 10);
                    waterMarkColor = Color.FromArgb(redInd, greenInd, blueInd);
                    if (redInd > 127 || greenInd > 127 || blueInd > 127)
                    {
                        backgroundColorText.ForeColor = Color.Black;
                    } else
                    {
                        backgroundColorText.ForeColor = Color.White;
                    }
                }
                catch
                {

                }
            }
            else
            {
                try
                {
                    text.Replace(',', ' ');
                    string[] textSplit = text.Split(',');
                    byte redInd = Convert.ToByte(textSplit[0] + 10);
                    byte greenInd = Convert.ToByte(textSplit[1] + 10);
                    byte blueInd = Convert.ToByte(textSplit[2] + 10);
                    imageBackgroundColor = Color.FromArgb(redInd, greenInd, blueInd);
                    backgroundColorText.BackColor = imageBackgroundColor;
                    waterMarkColor = Color.FromArgb(redInd, greenInd, blueInd);
                    if (redInd > 127 || greenInd > 127 || blueInd > 127)
                    {
                        backgroundColorText.ForeColor = Color.Black;
                    }
                    else
                    {
                        backgroundColorText.ForeColor = Color.White;
                    }
                }
                catch
                {

                }

            }

        }
        private void decorTextButton_Click(object sender, EventArgs e)
        {
            drawDecor = !(decorTextButton.Text == res.LocalisationRes.decorTextOn);
            decorTextButton.Text = drawDecor ? res.LocalisationRes.decorTextOn : res.LocalisationRes.decorTextOff;
        }
        private void decorTextTextbox_TextChanged(object sender, EventArgs e)
        {
            decorText = decorTextTextbox.Text;
        }
        private void languageCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageCombo.SelectedIndex == 0)
            {
                Properties.Settings.Default.Language = "ru";
            } else if (languageCombo.SelectedIndex == 1)
            {
                Properties.Settings.Default.Language = "en";
            }

            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
        }

        // Generator queue
        private void changeIfindexOccuped(int index)
        {
            int occupedIndex = generatorIndexes[index];
            for (int i = 0; i < 5; i++)
            {
                if (i != index && generatorIndexes[i] == occupedIndex)
                {
                    ToolStripComboBox cb = (ToolStripComboBox)vehicleTipesOrderButton.DropDownItems[i];
                    cb.SelectedIndex = 5;
                }
            }
        }

        private void comboBoxPos1_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatorIndexes[0] = comboBoxPos1.SelectedIndex;
            changeIfindexOccuped(0);
        }
        private void comboBoxPos2_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatorIndexes[1] = comboBoxPos2.SelectedIndex;
            changeIfindexOccuped(1);
        }
        private void comboBoxPos3_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatorIndexes[2] = comboBoxPos3.SelectedIndex;
            changeIfindexOccuped(2);
        }
        private void comboBoxPos4_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatorIndexes[3] = comboBoxPos4.SelectedIndex;
            changeIfindexOccuped(3);
        }
        private void comboBoxPos5_SelectedIndexChanged(object sender, EventArgs e)
        {
            generatorIndexes[4] = comboBoxPos5.SelectedIndex;
            changeIfindexOccuped(4);
        }

        // tanks id = 0
        private void ResizeTanks_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Left)
            {
                Button tank = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = "",
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                tank.Click += TankButton_Click;

                Control curButton = (Control)sender;

                int rowPos = TanksTable.GetCellPosition(curButton).Row;
                int colPos = TanksTable.GetCellPosition(curButton).Column;

                if (rowPos == TanksTable.RowCount - 1)
                {
                    TanksTable.RowCount += 1;
                    TanksTable.Controls.Add(curButton, colPos, TanksTable.RowCount - 1);
                    TanksTable.Controls.Add(tank, colPos, TanksTable.RowCount - 2);

                    if (tanksData != null)
                    {
                        VehicleData[,] newTanksDatas = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];
                        for (int i = 0; i < arrSizes.tanks.Item1; i++)
                        {
                            for (int j = 0; j < arrSizes.tanks.Item2; j++)
                            {
                                tanksData[i, j] = tanksData[i, j] == null ? new VehicleData() { type = 0 } : tanksData[i, j];
                                newTanksDatas[i, j] = tanksData[i, j];
                            }
                        }
                        arrSizes.tanks.Item1 += 1;
                        for (int i = 0; i < arrSizes.tanks.Item2; i++)
                            newTanksDatas[arrSizes.tanks.Item1 - 1, i] = new VehicleData() { type = 0 };
                        tanksData = newTanksDatas;
                    }
                    else
                    {
                        tanksData = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];

                        arrSizes.tanks.Item1 = 1; arrSizes.tanks.Item2 = 1;
                    }
                }
                else
                {
                    tanksData[rowPos, colPos] = new VehicleData() { type = 0 };

                    TanksTable.Controls.Add(curButton, colPos, rowPos + 1);
                    TanksTable.Controls.Add(tank, colPos, rowPos);
                };
                for (int i = 0; i < arrSizes.tanks.Item1; i++)
                {
                    for (int j = 0; j < arrSizes.tanks.Item2; j++)
                    {
                        tanksData[i, j] = tanksData[i, j] == null ? new VehicleData() { type = 0 } : tanksData[i, j];
                    }
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                int newCol = TanksTable.GetColumn((Control)sender) + 1;
                TanksTable.ColumnCount++;
                VehicleData[,] newTanksData = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];
                arrSizes.tanks.Item2++;
                for (int col = arrSizes.tanks.Item2 - 1; col >= 0 ; col--)
                {
                    for (int row = 0; row < arrSizes.tanks.Item1; row++)
                    {
                        if (col < newCol)
                        {
                            newTanksData[row, col] = tanksData[row, col];
                        }
                        else if (col == newCol)
                        {
                            newTanksData[row, col] = new VehicleData() { type = 0 };
                        }
                        else
                        {
                            newTanksData[row, col] = tanksData[row, col - 1];
                            
                            if(File.Exists($@"temp\{row}-{col - 1}-{0}.png"))
                            {
                                newTanksData[row, col].buttonImage = $@"temp\{row}-{col}-{0}.png";
                                Image img = Image.FromFile($@"temp\{row}-{col - 1}-{0}.png");
                                img.Save($@"temp\{row}-{col}-{0}.png");
                                img.Dispose();

                                FileInfo file = new FileInfo($@"temp\{row}-{col - 1}-{0}.png");
                                file.Delete();
                            }
                        }
                    }
                }
                tanksData = newTanksData;

                for (int col = TanksTable.ColumnCount; col >= newCol; col--)
                {
                    for (int row = 0; row < TanksTable.RowCount; row++)
                    {
                        if (TanksTable.GetControlFromPosition(col, row) != null)
                            TanksTable.Controls.Add(TanksTable.GetControlFromPosition(col, row), col + 1, row);
                    }
                }

                Button newResizeButton = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = res.LocalisationRes.resize,
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                newResizeButton.MouseUp += ResizeTanks_MouseUp;
                TanksTable.Controls.Add(newResizeButton, newCol, 0);
            }
        }
        private void TankButton_Click(object sender, EventArgs ae)
        {
            Control curButton = (Control)sender;

            int row = TanksTable.GetCellPosition(curButton).Row;
            int col = TanksTable.GetCellPosition(curButton).Column;

            if (deleteMode)
            {
                tanksData[row, col] = new VehicleData() { type = 0 };
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            } else {
                VehicleScreen vehicleScreen;
                if (tanksData[row, col].name != null)
                {
                    vehicleScreen = new VehicleScreen(country, 0, row, col, curButton, tanksData[row, col], this);
                }
                else
                {
                    vehicleScreen = new VehicleScreen(country, 0, row, col, curButton, this);
                }
                vehicleScreen.Show();
            }
            

        }

        // planes id = 1
        private void ResizePlanes_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Left)
            {
                Button plane = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = "",
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                plane.Click += PlaneButton_Click;

                Control curButton = (Control)sender;

                int rowPos = PlanesTable.GetCellPosition(curButton).Row;
                int colPos = PlanesTable.GetCellPosition(curButton).Column;

                if (rowPos == PlanesTable.RowCount - 1)
                {
                    PlanesTable.RowCount++;
                    PlanesTable.Controls.Add(curButton, colPos, PlanesTable.RowCount - 1);
                    PlanesTable.Controls.Add(plane, colPos, PlanesTable.RowCount - 2);

                    if (planesData != null)
                    {
                        VehicleData[,] newPlanesData = new VehicleData[PlanesTable.RowCount - 1, PlanesTable.ColumnCount];
                        for (int i = 0; i < arrSizes.planes.Item1; i++)
                        {
                            for (int j = 0; j < arrSizes.planes.Item2; j++)
                            {
                                newPlanesData[i, j] = planesData[i, j];
                            }
                        }
                        arrSizes.planes.Item1 += 1;
                        for (int i = 0; i < arrSizes.planes.Item2; i++)
                            newPlanesData[arrSizes.planes.Item1 - 1, i] = new VehicleData() { type = 1 };
                        planesData = newPlanesData;
                    }
                    else
                    {
                        planesData = new VehicleData[PlanesTable.RowCount - 1, PlanesTable.ColumnCount];
                        planesData[0, 0] = new VehicleData() { type = 1 };
                        arrSizes.planes.Item1 = 1; arrSizes.planes.Item2 = 1;
                    }
                }
                else
                {
                    planesData[rowPos, colPos] = new VehicleData() { type = 1 };
                    PlanesTable.Controls.Add(curButton, colPos, rowPos + 1);
                    PlanesTable.Controls.Add(plane, colPos, rowPos);
                };
                
            } 
            else if (me.Button == MouseButtons.Right)
            {
                int newCol = PlanesTable.GetColumn((Control)sender) + 1;
                PlanesTable.ColumnCount++;
                VehicleData[,] newPlanesData = new VehicleData[PlanesTable.RowCount - 1, PlanesTable.ColumnCount];
                arrSizes.planes.Item2++;
                for (int col = arrSizes.planes.Item2 - 1; col >= 0; col--)
                {
                    for (int row = 0; row < arrSizes.planes.Item1; row++)
                    {
                        if (col < newCol)
                        {
                            newPlanesData[row, col] = planesData[row, col];
                        }
                        else if (col == newCol)
                        {
                            newPlanesData[row, col] = new VehicleData() { type = 1 };
                        }
                        else
                        {
                            newPlanesData[row, col] = planesData[row, col - 1];

                            if (File.Exists($@"temp\{row}-{col - 1}-{1}.png"))
                            {
                                newPlanesData[row, col].buttonImage = $@"temp\{row}-{col}-{1}.png";
                                Image img = Image.FromFile($@"temp\{row}-{col - 1}-{1}.png");
                                img.Save($@"temp\{row}-{col}-{1}.png");
                                img.Dispose();

                                FileInfo file = new FileInfo($@"temp\{row}-{col - 1}-{1}.png");
                                file.Delete();
                            }
                        }
                    }
                }
                planesData = newPlanesData;

                for (int col = PlanesTable.ColumnCount; col >= newCol; col--)
                {
                    for (int row = 0; row < PlanesTable.RowCount; row++)
                    {
                        if (PlanesTable.GetControlFromPosition(col, row) != null)
                            PlanesTable.Controls.Add(PlanesTable.GetControlFromPosition(col, row), col + 1, row);
                    }
                }

                Button newResizeButton = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = res.LocalisationRes.resize,
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                newResizeButton.MouseUp += ResizePlanes_MouseUp;
                PlanesTable.Controls.Add(newResizeButton, newCol, 0);
            }
            for (int i = 0; i < arrSizes.planes.Item1; i++)
            {
                for (int j = 0; j < arrSizes.planes.Item2; j++)
                {
                    planesData[i, j] = planesData[i, j] == null ? new VehicleData() { type = 1 } : planesData[i, j];
                }
            }
        }
        private void PlaneButton_Click(object sender, EventArgs e)
        {
            Control curButton = (Control)sender;

            int row = PlanesTable.GetCellPosition(curButton).Row;
            int col = PlanesTable.GetCellPosition(curButton).Column;
            
            if (!deleteMode)
            {
                VehicleScreen vehicleScreen;
                if (planesData[row, col].name != null)
                {
                    vehicleScreen = new VehicleScreen(country, 1, row, col, curButton, planesData[row, col], this);
                }
                else
                {
                    vehicleScreen = new VehicleScreen(country, 1, row, col, curButton, this);
                }

                vehicleScreen.Show();
            }
            else
            {
                planesData[row, col] = new VehicleData() { type = 1 };
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // helicopters id = 2
        private void ResizeHeli_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Left)
            {
                Button heli = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = "",
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                heli.Click += HeliButton_Click;

                Control curButton = (Control)sender;

                int rowPos = HeliTable.GetCellPosition(curButton).Row;
                int colPos = HeliTable.GetCellPosition(curButton).Column;

                if (rowPos == HeliTable.RowCount - 1)
                {
                    HeliTable.RowCount++;
                    HeliTable.Controls.Add(curButton, colPos, HeliTable.RowCount - 1);
                    HeliTable.Controls.Add(heli, colPos, HeliTable.RowCount - 2);

                    if (helicoptersData != null)
                    {
                        VehicleData[,] newHeliData = new VehicleData[HeliTable.RowCount - 1, HeliTable.ColumnCount];
                        for (int i = 0; i < arrSizes.helis.Item1; i++)
                        {
                            for (int j = 0; j < arrSizes.helis.Item2; j++)
                            {
                                newHeliData[i, j] = helicoptersData[i, j];
                            }
                        }
                        arrSizes.helis.Item1 += 1;
                        for (int i = 0; i < arrSizes.helis.Item2; i++)
                            newHeliData[arrSizes.helis.Item1 - 1, i] = new VehicleData() { type = 2 };
                        helicoptersData = newHeliData;
                    }
                    else
                    {
                        helicoptersData = new VehicleData[HeliTable.RowCount - 1, HeliTable.ColumnCount];
                        helicoptersData[0, 0] = new VehicleData() { type = 2 };
                        arrSizes.helis.Item1 = 1; arrSizes.helis.Item2 = 1;
                    }
                }
                else
                {
                    helicoptersData[rowPos, colPos] = new VehicleData() { type = 2 };
                    HeliTable.Controls.Add(curButton, colPos, rowPos + 1);
                    HeliTable.Controls.Add(heli, colPos, rowPos);
                };
                for (int i = 0; i < arrSizes.helis.Item1; i++)
                {
                    for (int j = 0; j < arrSizes.helis.Item2; j++)
                    {
                        helicoptersData[i, j] = helicoptersData[i, j] == null ? new VehicleData() { type = 2 } : helicoptersData[i, j];
                    }
                }
            } 
            else if (me.Button == MouseButtons.Right)
            {
                int newCol = HeliTable.GetColumn((Control)sender) + 1;
                HeliTable.ColumnCount++;
                VehicleData[,] newHelisData = new VehicleData[HeliTable.RowCount - 1, HeliTable.ColumnCount];
                arrSizes.helis.Item2++;
                for (int col = arrSizes.helis.Item2 - 1; col >= 0; col--)
                {
                    for (int row = 0; row < arrSizes.helis.Item1; row++)
                    {
                        if (col < newCol)
                        {
                            newHelisData[row, col] = helicoptersData[row, col];
                        }
                        else if (col == newCol)
                        {
                            newHelisData[row, col] = new VehicleData() { type = 2 };
                        }
                        else
                        {
                            newHelisData[row, col] = helicoptersData[row, col - 1];

                            if (File.Exists($@"temp\{row}-{col - 1}-{2}.png"))
                            {
                                newHelisData[row, col].buttonImage = $@"temp\{row}-{col}-{2}.png";
                                Image img = Image.FromFile($@"temp\{row}-{col - 1}-{2}.png");
                                img.Save($@"temp\{row}-{col}-{2}.png");
                                img.Dispose();

                                FileInfo file = new FileInfo($@"temp\{row}-{col - 1}-{2}.png");
                                file.Delete();
                            }
                            
                        }
                    }
                }
                helicoptersData = newHelisData;
                for (int col = HeliTable.ColumnCount; col >= newCol; col--)
                {
                    for (int row = 0; row < HeliTable.RowCount; row++)
                    {
                        if (HeliTable.GetControlFromPosition(col, row) != null)
                            HeliTable.Controls.Add(HeliTable.GetControlFromPosition(col, row), col + 1, row);
                    }
                }

                Button newResizeButton = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = res.LocalisationRes.resize,
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                newResizeButton.MouseUp += ResizeHeli_MouseUp;
                HeliTable.Controls.Add(newResizeButton, newCol, 0);
            }
        }
        private void HeliButton_Click(object sender, EventArgs e)
        {
            Control curButton = (Control)sender;

            int row = HeliTable.GetCellPosition(curButton).Row;
            int col = HeliTable.GetCellPosition(curButton).Column;
            
            if (!deleteMode)
            {
                VehicleScreen vehicleScreen;
                if (helicoptersData[row, col].name != null)
                {
                    vehicleScreen = new VehicleScreen(country, 2, row, col, curButton, helicoptersData[row, col], this);
                }
                else
                {
                    vehicleScreen = new VehicleScreen(country, 2, row, col, curButton, this);
                }

                vehicleScreen.Show();
            }
            else
            {
                
                helicoptersData[row, col] = new VehicleData() { type = 2 };
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // coastal fleet id = 3
        private void ResizeCoastalFleet_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Left)
            {
                Button ship = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = "",
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                ship.Click += CoastalButton_Click;

                Control curButton = (Control)sender;

                int rowPos = CoastalfleetTable.GetCellPosition(curButton).Row;
                int colPos = CoastalfleetTable.GetCellPosition(curButton).Column;

                if (rowPos == CoastalfleetTable.RowCount - 1)
                {
                    CoastalfleetTable.RowCount++;
                    CoastalfleetTable.Controls.Add(curButton, colPos, CoastalfleetTable.RowCount - 1);
                    CoastalfleetTable.Controls.Add(ship, colPos, CoastalfleetTable.RowCount - 2);

                    if (coastalFleetData != null)
                    {
                        VehicleData[,] newCoastalData = new VehicleData[CoastalfleetTable.RowCount - 1, CoastalfleetTable.ColumnCount];
                        for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
                        {
                            for (int j = 0; j < arrSizes.coastalFleet.Item2; j++)
                            {
                                newCoastalData[i, j] = coastalFleetData[i, j];
                            }
                        }
                        arrSizes.coastalFleet.Item1 += 1;
                        for (int i = 0; i < arrSizes.coastalFleet.Item2; i++)
                            newCoastalData[arrSizes.coastalFleet.Item1 - 1, i] = new VehicleData() { type = 3 };
                        coastalFleetData = newCoastalData;
                    }
                    else
                    {
                        coastalFleetData = new VehicleData[CoastalfleetTable.RowCount - 1, CoastalfleetTable.ColumnCount];
                        coastalFleetData[0, 0] = new VehicleData() { type = 3 };
                        arrSizes.coastalFleet.Item1 = 1; arrSizes.coastalFleet.Item2 = 1;
                    }
                }
                else
                {
                    coastalFleetData[rowPos, colPos] = new VehicleData() { type = 3 };
                    CoastalfleetTable.Controls.Add(curButton, colPos, rowPos + 1);
                    CoastalfleetTable.Controls.Add(ship, colPos, rowPos);
                };
                for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
                {
                    for (int j = 0; j < arrSizes.coastalFleet.Item2; j++)
                    {
                        coastalFleetData[i, j] = coastalFleetData[i, j] == null ? new VehicleData() { type = 3 } : coastalFleetData[i, j];
                    }
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                int newCol = CoastalfleetTable.GetColumn((Control)sender) + 1;

                CoastalfleetTable.ColumnCount++;
                VehicleData[,] newCoastalData = new VehicleData[CoastalfleetTable.RowCount - 1, CoastalfleetTable.ColumnCount];
                arrSizes.coastalFleet.Item2++;
                for (int col = arrSizes.coastalFleet.Item2 - 1; col >= 0; col--)
                {
                    for (int row = 0; row < arrSizes.coastalFleet.Item1; row++)
                    {
                        if (col < newCol)
                        {
                            newCoastalData[row, col] = coastalFleetData[row, col];
                        }
                        else if (col == newCol)
                        {
                            newCoastalData[row, col] = new VehicleData() { type = 3 };
                        }
                        else
                        {
                            newCoastalData[row, col] = coastalFleetData[row, col - 1];

                            if (File.Exists($@"temp\{row}-{col - 1}-{3}.png"))
                            {
                                newCoastalData[row, col].buttonImage = $@"temp\{row}-{col}-{3}.png";
                                Image img = Image.FromFile($@"temp\{row}-{col - 1}-{3}.png");
                                img.Save($@"temp\{row}-{col}-{3}.png");
                                img.Dispose();

                                FileInfo file = new FileInfo($@"temp\{row}-{col - 1}-{3}.png");
                                file.Delete();
                            }
                            
                        }
                    }
                }
                coastalFleetData = newCoastalData;

                for (int col = CoastalfleetTable.ColumnCount; col >= newCol; col--)
                {
                    for (int row = 0; row < CoastalfleetTable.RowCount; row++)
                    {
                        if (CoastalfleetTable.GetControlFromPosition(col, row) != null)
                            CoastalfleetTable.Controls.Add(CoastalfleetTable.GetControlFromPosition(col, row), col + 1, row);
                    }
                }

                Button newResizeButton = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = res.LocalisationRes.resize,
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                newResizeButton.MouseUp += ResizeCoastalFleet_MouseUp;
                CoastalfleetTable.Controls.Add(newResizeButton, newCol, 0);
            }
        }
        private void CoastalButton_Click(object sender, EventArgs e)
        {
            Control curButton = (Control)sender;

            int row = CoastalfleetTable.GetCellPosition(curButton).Row;
            int col = CoastalfleetTable.GetCellPosition(curButton).Column;
            
            if (!deleteMode)
            {
                VehicleScreen vehicleScreen;
                if (coastalFleetData[row, col].name != null)
                {
                    vehicleScreen = new VehicleScreen(country, 3, row, col, curButton, coastalFleetData[row, col], this);
                }
                else
                {
                    vehicleScreen = new VehicleScreen(country, 3, row, col, curButton, this);
                }

                vehicleScreen.Show();
            }
            else
            {
                
                coastalFleetData[row, col] = new VehicleData() { type = 3 };
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // bluewater fleet id = 4
        private void ResizeBluewater_MouseUp(object sender, MouseEventArgs me)
        {
            if (me.Button == MouseButtons.Left)
            {
                Button ship = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = "",
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                ship.Click += BluewaterButton_Click;

                Control curButton = (Control)sender;

                int rowPos = BluewaterTable.GetCellPosition(curButton).Row;
                int colPos = BluewaterTable.GetCellPosition(curButton).Column;

                if (rowPos == BluewaterTable.RowCount - 1)
                {
                    BluewaterTable.RowCount++;
                    BluewaterTable.Controls.Add(curButton, colPos, BluewaterTable.RowCount - 1);
                    BluewaterTable.Controls.Add(ship, colPos, BluewaterTable.RowCount - 2);

                    if (bluewaterFleetData != null)
                    {
                        VehicleData[,] newBluewaterData = new VehicleData[BluewaterTable.RowCount - 1, BluewaterTable.ColumnCount];
                        for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
                        {
                            for (int j = 0; j < arrSizes.bluewaterFleet.Item2; j++)
                            {
                                newBluewaterData[i, j] = bluewaterFleetData[i, j];
                            }
                        }
                        arrSizes.bluewaterFleet.Item1 += 1;
                        for (int i = 0; i < arrSizes.bluewaterFleet.Item2; i++)
                            newBluewaterData[arrSizes.bluewaterFleet.Item1 - 1, i] = new VehicleData() { type = 4 };
                        bluewaterFleetData = newBluewaterData;
                    }
                    else
                    {
                        bluewaterFleetData = new VehicleData[BluewaterTable.RowCount - 1, BluewaterTable.ColumnCount];
                        bluewaterFleetData[0, 0] = new VehicleData() { type = 4 };
                        arrSizes.bluewaterFleet = (1, 1);
                    }
                }
                else
                {
                    bluewaterFleetData[rowPos, colPos] = new VehicleData() { type = 4 };
                    BluewaterTable.Controls.Add(curButton, colPos, rowPos + 1);
                    BluewaterTable.Controls.Add(ship, colPos, rowPos);
                };
                for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
                {
                    for (int j = 0; j < arrSizes.bluewaterFleet.Item2; j++)
                    {
                        bluewaterFleetData[i, j] = bluewaterFleetData[i, j] == null ? new VehicleData() { type = 4 } : bluewaterFleetData[i, j];
                    }
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                int newCol = BluewaterTable.GetColumn((Control)sender) + 1;

                BluewaterTable.ColumnCount++;
                VehicleData[,] newBluewaterData = new VehicleData[BluewaterTable.RowCount - 1, BluewaterTable.ColumnCount];
                arrSizes.bluewaterFleet.Item2++;
                for (int col = arrSizes.bluewaterFleet.Item2 - 1; col >= 0; col--)
                {
                    for (int row = 0; row < arrSizes.bluewaterFleet.Item1; row++)
                    {
                        if (col < newCol)
                        {
                            newBluewaterData[row, col] = bluewaterFleetData[row, col];
                        }
                        else if (col == newCol)
                        {
                            newBluewaterData[row, col] = new VehicleData() { type = 3 };
                        }
                        else
                        {
                            newBluewaterData[row, col] = bluewaterFleetData[row, col - 1];

                            if (File.Exists($@"temp\{row}-{col - 1}-{4}.png"))
                            {
                                newBluewaterData[row, col].buttonImage = $@"temp\{row}-{col}-{4}.png";
                                Image img = Image.FromFile($@"temp\{row}-{col - 1}-{4}.png");
                                img.Save($@"temp\{row}-{col}-{4}.png");
                                img.Dispose();

                                FileInfo file = new FileInfo($@"temp\{row}-{col - 1}-{4}.png");
                                file.Delete();
                            }
                            
                        }
                    }
                }
                bluewaterFleetData = newBluewaterData;

                for (int col = BluewaterTable.ColumnCount; col >= newCol; col--)
                {
                    for (int row = 0; row < BluewaterTable.RowCount; row++)
                    {
                        if (BluewaterTable.GetControlFromPosition(col, row) != null)
                            BluewaterTable.Controls.Add(BluewaterTable.GetControlFromPosition(col, row), col + 1, row);
                    }
                }

                Button newResizeButton = new Button()
                {
                    Width = 120,
                    Height = 48,
                    Text = res.LocalisationRes.resize,
                    Margin = new Padding(3, 3, 3, 3),
                    FlatStyle = FlatStyle.Flat,
                };

                newResizeButton.MouseUp += ResizeBluewater_MouseUp;
                BluewaterTable.Controls.Add(newResizeButton, newCol, 0);
            }
        }
        private void BluewaterButton_Click(object sender, EventArgs e)
        {
            Control curButton = (Control)sender;

            int row = BluewaterTable.GetCellPosition(curButton).Row;
            int col = BluewaterTable.GetCellPosition(curButton).Column;
            
            if (!deleteMode)
            {
                VehicleScreen vehicleScreen;
                if (bluewaterFleetData[row, col].name != null)
                {
                    vehicleScreen = new VehicleScreen(country, 4, row, col, curButton, bluewaterFleetData[row, col], this);
                }
                else
                {
                    vehicleScreen = new VehicleScreen(country, 4, row, col, curButton, this);
                }

                vehicleScreen.Show();
            }
            else
            {
                
                bluewaterFleetData[row, col] = new VehicleData() { type = 4 };
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // Special buttons
        private void flagButton_Click(object sender, EventArgs e)
        {
            FlagEditor flagEditor = new FlagEditor(dir, this);

            flagEditor.Show();
        }
        private void DownloadFlag(string link)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(link, @"temp\flag.png");
            wc.Dispose();
            Image flagtocopy = Image.FromFile(@"temp\flag.png");

            Image flag = new Bitmap(flagtocopy);
            flagtocopy.Dispose();

            float ratio = flag.Height / 48f;
            int width = Convert.ToInt32(flag.Width / ratio);
            flag = new Bitmap(flag, new Size(width, 48));
            flag.Save(@"temp\flag.png", System.Drawing.Imaging.ImageFormat.Png);
            flag.Dispose();

            OpenFlag();

        }

        // shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                saveScheme.PerformClick();
                return true;
            } else if (keyData == (Keys.Control | Keys.O))
            {
                importButton.PerformClick();
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                exportButton.PerformClick();
                return true;
            } else if (keyData == Keys.D)
            {
                deleteMode = true;
                modeInfoButton.Text = res.LocalisationRes.DeleteModeStr;
                modeInfoButton.ForeColor = Color.FromArgb(192, 0, 0);
                return true;
            } else if (keyData == Keys.E)
            {
                deleteMode = false;
                modeInfoButton.Text = res.LocalisationRes.EditModeStr;
                modeInfoButton.ForeColor = Color.FromArgb(0, 192, 0);
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                DialogResult dialogResult = MessageBox.Show(text: res.LocalisationRes.warningTanks, caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    tanksData = null;
                    TanksTable.Controls.Clear();
                    arrSizes.tanks = (0, 1);
                    TanksTable.RowCount = 1; TanksTable.ColumnCount = 1;
                    TanksTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    TanksTable.Controls.Add(ResizeTanks, 0, 0);
                    TanksTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.P))
            {
                DialogResult dialogResult = MessageBox.Show(text: res.LocalisationRes.warningPlanes, caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    planesData = null;
                    PlanesTable.Controls.Clear();
                    arrSizes.planes = (0, 1);
                    PlanesTable.RowCount = 1; PlanesTable.ColumnCount = 1;
                    PlanesTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    PlanesTable.Controls.Add(ResizePlanes, 0, 0);
                    PlanesTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.H))
            {
                DialogResult dialogResult = MessageBox.Show(text: res.LocalisationRes.warningHelis, caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    helicoptersData = null;
                    HeliTable.Controls.Clear();
                    arrSizes.helis = (0, 1);
                    HeliTable.RowCount = 1; HeliTable.ColumnCount = 1;
                    HeliTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    HeliTable.Controls.Add(ResizeHeli, 0, 0);
                    HeliTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                DialogResult dialogResult = MessageBox.Show(text: res.LocalisationRes.warningCoastal, caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    coastalFleetData = null; 
                    CoastalfleetTable.Controls.Clear();
                    arrSizes.coastalFleet = (0, 1);
                    CoastalfleetTable.RowCount = 1; CoastalfleetTable.ColumnCount = 1;
                    CoastalfleetTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    CoastalfleetTable.Controls.Add(ResizeCoastalFleet, 0, 0);
                    CoastalfleetTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.B))
            {
                DialogResult dialogResult = MessageBox.Show(text: res.LocalisationRes.warningBluewater, caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    bluewaterFleetData = null;
                    BluewaterTable.Controls.Clear();
                    arrSizes.bluewaterFleet = (0, 1);
                    BluewaterTable.RowCount = 1; BluewaterTable.ColumnCount = 1;
                    BluewaterTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    BluewaterTable.Controls.Add(ResizeBluewater, 0, 0);
                    BluewaterTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            StatusLabel.Text = "ok";
            StatusLabel.ForeColor = Color.Black;
        }

        // public funcs
        public void OpenFlag()
        {
            try
            {
                Image flagtocopy = Image.FromFile(@"temp\flag.png");
                Image flag = new Bitmap(flagtocopy);
                flagtocopy.Dispose();
                int width = flag.Width;
                flagButton.Size = new Size(width, 48);
                flagButton.Location = new Point(Size.Width - width - 28, flagButton.Location.Y);
                flagButton.Text = "";
                flagButton.BackgroundImage = flag;

            }
            catch
            {
                StatusLabel.Text = "No flag image";
                StatusLabel.ForeColor = Color.FromArgb(192, 0, 0);
                timer = new Timer { Interval = 5000 };
                timer.Tick += TimerTick;
                timer.Enabled = true;
            }

        }
        public void StatusChange(string message, Color color)
        {
            StatusLabel.Text = message;
            StatusLabel.ForeColor = color;
            timer = new Timer { Interval = 5000 };
            timer.Tick += TimerTick;
            timer.Enabled = true;
        }

        // changes data in cell from vehicle screen
        public void ChangeData(VehicleData senderData, int type, int row, int column)
        {
            switch (type)
            {
                case 0:
                    tanksData[row, column] = senderData;
                    break;
                case 1:
                    planesData[row, column] = senderData;
                    break;
                case 2:
                    helicoptersData[row, column] = senderData;
                    break;
                case 3:
                    coastalFleetData[row, column] = senderData;
                    break;
                case 4:
                    bluewaterFleetData[row, column] = senderData;
                    break;
            }
        }


        private void Lineup_creator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (languageCombo.SelectedIndex == 0)
            {
                Properties.Settings.Default.Language = "en";
            } else
            {
                Properties.Settings.Default.Language = "ru";
            }
            
            Properties.Settings.Default.Save();
        }

        private void Lineup_creator_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                languageCombo.SelectedItem = Properties.Settings.Default.Language;
            }
        }

        
    }

    public class VehicleData
    {
        public string name;
        public int type = -1;
        public string imageLink;
        public int backgroudType = 0; // 0 - standart, 1 - premium, 2 - squadron
        public string buttonImage;
        public int[] pos = new int[2]; // row, col
        public string wtID;
        public int numberOfUnits = 0; // - yes, 1->inf 

        public VehicleData() { }

        public VehicleData(string name, int type, string imageLink, int backgroundType, string wtID, int numberOfUnits)
        {
            this.name = name;
            this.type = type;
            this.imageLink = imageLink;
            this.backgroudType = backgroundType;
            this.wtID = wtID;
            this.numberOfUnits = numberOfUnits;
        }

    }

    public class ArraySizes {
        // Item1 - rows | Item2 - columns
        public (int, int) tanks = (0, 1);
        public (int, int) planes = (0, 1);
        public (int, int) helis = (0, 1);
        public (int, int) coastalFleet = (0, 1);
        public (int, int) bluewaterFleet = (0, 1);
    }
}
