using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;

namespace Lineups_creator
{

    public partial class Lineup_creator : Form
    {
        string country;
        string dir = Directory.GetCurrentDirectory();
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
        bool customFlagUsed = false;
        Timer timer;
        ArraySizes arrSizes = new ArraySizes();
        VehicleData[,] tanksData;
        VehicleData[,] planesData;
        VehicleData[,] helicoptersData;
        VehicleData[,] coastalFleetData;
        VehicleData[,] bluewaterFleetData;

        public Lineup_creator()
        {
            
            InitializeComponent();

            Directory.CreateDirectory($@"{dir}\config");
            WebClient webClient = new WebClient();
            var client = new WebClient();

            if (!webClient.DownloadString("https://github.com/Gaz1zPr0g/wt-lineup-creator/blob/main/config/version%20info.txt").Contains("version 1.0.1.4"))
            {
                DialogResult dialogResult = MessageBox.Show(text:"New version is available! Do you want to install it?", caption:"Version info", buttons:MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (File.Exists(@"config\Setup.exe"))
                            File.Delete(@"config\Setup.exe");
                        if (File.Exists(@"config\Setup.msi"))
                            File.Delete(@"config\Setup.msi");
                        client.DownloadFile("https://drive.usercontent.google.com/u/0/uc?id=1qhtEpp-XYxKvPioTfbpy_D_bp6RTST24&export=download", @"config\Setup.zip");
                        client.Dispose();
                        string zipPath = @"config\Setup.zip";
                        ZipFile.ExtractToDirectory(zipPath, $@"{dir}\config");
                        File.Delete(@"config\Setup.zip");

                        Process process = new Process();
                        process.StartInfo.FileName = "msiexec";
                        process.StartInfo.Arguments = String.Format(@"/i config\Setup.msi");

                        this.Close();
                        process.Start();
                    } catch
                    {

                    }
                }

            }
            Directory.CreateDirectory($@"{dir}\temp");
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

                webClient.DownloadFile("https://wiki.warthunder.com/images/1/15/Item_prem.png", @"config\PREMIUM.png");

                imagetocopy = Image.FromFile(@"config\PREMIUM.png");
                image = new Bitmap(imagetocopy);
                imagetocopy.Dispose();
                File.Delete(@"config\PREMIUM.png");
                image.Save(@"config\PREMIUM.png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();

                webClient.DownloadFile("https://wiki.warthunder.com/images/7/70/Item_squad.png", @"config\SQUAD.png");

                imagetocopy = Image.FromFile(@"config\SQUAD.png");
                image = new Bitmap(imagetocopy);
                imagetocopy.Dispose();
                File.Delete(@"config\SQUAD.png");
                image.Save(@"config\SQUAD.png", System.Drawing.Imaging.ImageFormat.Png);
                image.Dispose();
            }

        }

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
                            string[] rowColType = imageFile.Split('-');
                            int row = Convert.ToInt32(rowColType[0]);
                            int col = Convert.ToInt32(rowColType[1]);
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
                            TanksTable.Controls.Add(AddRowTanks1, 0, maxTrow[0]);
                            AddColumnTanks.Location = new Point(135 + 126 * (arrSizes.tanks.Item2 - 1), 39);
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
                                        Button newAddRow = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = "Add row",
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newAddRow.Click += AddRowTanks_Click;
                                        TanksTable.Controls.Add(newAddRow, col, maxTrow[col]);
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
                            PlanesTable.Controls.Add(AddRowPlanes1, 0, maxProw[0]);
                            AddColumnPlanes.Location = new Point(135 + 126 * (arrSizes.planes.Item2 - 1), 39);
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
                                        Button newAddRow = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = "Add row",
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newAddRow.Click += AddRowPlanes_Click;
                                        PlanesTable.Controls.Add(newAddRow, col, maxProw[col]);
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
                            HeliTable.Controls.Add(AddRowHeli, 0, maxHrow[0]);
                            AddColumnHeli.Location = new Point(135 + 126 * (arrSizes.helis.Item2 - 1), 39);
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
                                        Button newAddRow = new Button()
                                                {
                                                    Width = 120,
                                                    Height = 48,
                                                    Text = "Add row",
                                                    Margin = new Padding(3, 3, 3, 3),
                                                    FlatStyle = FlatStyle.Flat,
                                                };
                                        newAddRow.Click += AddRowHeli_Click;
                                        HeliTable.Controls.Add(newAddRow, col, maxHrow[col]);
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
                            CoastalfleetTable.Controls.Add(AddRowCoastalFleet, 0, maxCrow[0]);
                            AddColumnCoastalFleet.Location = new Point(135 + 126 * (arrSizes.coastalFleet.Item2 - 1), 39);
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
                                        Button newAddRow = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = "Add row",
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newAddRow.Click += AddRowCoastalFleet_Click;
                                        CoastalfleetTable.Controls.Add(newAddRow, col, maxCrow[col]);
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
                            BluewaterTable.Controls.Add(AddRowBluewater, 0, maxBrow[0]);
                            AddColumnBluewater.Location = new Point(135 + 126 * (arrSizes.bluewaterFleet.Item2 - 1), 39);
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
                                        Button newAddRow = new Button()
                                        {
                                            Width = 120,
                                            Height = 48,
                                            Text = "Add row",
                                            Margin = new Padding(3, 3, 3, 3),
                                            FlatStyle = FlatStyle.Flat,
                                        };
                                        newAddRow.Click += AddRowBluewaterFleet_Click;
                                        BluewaterTable.Controls.Add(newAddRow, col, maxBrow[col]);
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
                Image[] backgrounds =
            {
                Image.FromFile(@"config\OWN.png"),
                Image.FromFile(@"config\PREMIUM.png"),
                Image.FromFile(@"config\SQUAD.png")
            };
                WebClient webClient = new WebClient();
                webClient.DownloadFile(vd.imageLink, $@"temp\icon{row}-{col}-{type}.bmp");
                webClient.Dispose();

                Image icontocopy = Image.FromFile($@"temp\icon{row}-{col}-{type}.bmp");

                Image icon = new Bitmap(icontocopy);
                icontocopy.Dispose();

                FileInfo file = new FileInfo($@"temp\icon{row}-{col}-{type}.bmp");
                file.Delete();

                float ratio = icon.Height / 42f;
                int width = Convert.ToInt32(icon.Width / ratio);
                icon = new Bitmap(icon, new Size(width, 42));

                Bitmap bitmap = (Bitmap)backgrounds[vd.backgroudType];

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Font verdanaFont = new Font("Verdana", 10, new FontStyle()))
                    {
                        graphics.DrawImage(icon, 5, 5, icon.Width, icon.Height);

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
                        foreach (VehicleData vd in tanksData)
                        {
                            if (vd.name != null)
                            {
                                output = JsonConvert.SerializeObject(vd);
                                sw.WriteLine(output);
                            }                  
                        }
                    }
                    if (planesData != null)
                    {
                        foreach(VehicleData vd in planesData)
                        {
                            if (vd.name != null)
                            {
                                output = JsonConvert.SerializeObject(vd);
                                sw.WriteLine(output);
                            }
                        }
                    }
                    if (helicoptersData != null)
                    {
                        foreach(VehicleData vd in helicoptersData)
                        {
                            if (vd.name != null)
                            {
                                output = JsonConvert.SerializeObject(vd);
                                sw.WriteLine(output);
                            }
                        }
                    }
                    if (coastalFleetData != null)
                    {
                        foreach(VehicleData vd in coastalFleetData)
                        {
                            if (vd.name != null)
                            {
                                output = JsonConvert.SerializeObject(vd);
                                sw.WriteLine(output);
                            }
                        }
                    }
                    if (bluewaterFleetData != null)
                    {
                        foreach (VehicleData vd in bluewaterFleetData)
                        {
                            if (vd.name != null)
                            {
                                output = JsonConvert.SerializeObject(vd);
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
                Filter = "PNG file (*.png)|*.png",
                Title = "Choose file to save",
                InitialDirectory = $@"{dir}\export",
            };
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
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
                            bitmap.SetPixel(x, y, Color.FromArgb(36, 46, 51));
                        }
                    }

                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font backgroundFont = new Font("Verdana", 8, new FontStyle()))
                        {
                            graphics.DrawString("https://github.com/Gaz1zPr0g/wt-lineup-creator", backgroundFont, new SolidBrush(Color.FromArgb(255, 43, 53, 58)), 5, 5);
                        }
                    }

                    x = 0; y = 20;
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font textFont = new Font("Verdana", 12, new FontStyle()))
                        {
                            Pen pen = new Pen(Brushes.White) { Width = 2 };
                            if (File.Exists(@"temp\flag.png"))
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

                            if (arrSizes.tanks.Item1 >= 1 && arrSizes.tanks.Item2 >= 1)
                            {
                                x += 5; y += 10;
                                graphics.DrawString("Tanks", textFont, Brushes.White, x, y);
                                y += 19;
                                graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                y += 5;
                                for (int i = 0; i < arrSizes.tanks.Item1; i++)
                                {
                                    for (int j = 0; j < arrSizes.tanks.Item2; j++)
                                    {
                                        if (tanksData[i, j].name != null)
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

                            if (arrSizes.coastalFleet.Item1 >= 1 && arrSizes.coastalFleet.Item2 >= 1)
                            {
                                x = 5; y += 10;
                                graphics.DrawString("Coastal Fleet", textFont, Brushes.White, x, y);
                                y += 19;
                                graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                y += 5;
                                for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
                                {
                                    for (int j = 0; j < arrSizes.coastalFleet.Item2; j++)
                                    {
                                        if (coastalFleetData[i, j].name != null)
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

                            if (arrSizes.bluewaterFleet.Item1 >= 1 && arrSizes.bluewaterFleet.Item2 >= 1)
                            {
                                x = 5; y += 10;
                                graphics.DrawString("Bluewater fleet", textFont, Brushes.White, x, y);
                                y += 19;
                                graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                y += 5;
                                for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
                                {
                                    for (int j = 0; j < arrSizes.bluewaterFleet.Item2; j++)
                                    {
                                        if (bluewaterFleetData[i, j].name != null)
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

                            if (arrSizes.planes.Item1 >= 1 && arrSizes.planes.Item2 >= 1)
                            {
                                x = 5; y += 10;
                                graphics.DrawString("Planes", textFont, Brushes.White, x, y);
                                y += 19;
                                graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                y += 5;
                                for (int i = 0; i < arrSizes.planes.Item1; i++)
                                {
                                    for (int j = 0; j < arrSizes.planes.Item2; j++)
                                    {
                                        if (planesData[i, j].name != null)
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

                            if (arrSizes.helis.Item1 >= 1 && arrSizes.helis.Item2 >= 1)
                            {
                                x = 5; y += 10;
                                graphics.DrawString("Helicopters", textFont, Brushes.White, x, y);
                                y += 19;
                                graphics.DrawLine(pen, new Point(x, y), new Point(bitmap.Width - x, y));
                                y += 5;
                                for (int i = 0; i < arrSizes.helis.Item1; i++)
                                {
                                    for (int j = 0; j < arrSizes.helis.Item2; j++)
                                    {
                                        if (helicoptersData[i, j].name != null)
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

                        }
                    }
                    bitmap.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    bitmap.Dispose();

                    StatusLabel.Text = "export completed";
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
        
        // tanks id = 0
        private void AddColumnTanks_Click(object sender, EventArgs e)
        {
            TanksTable.ColumnCount++;

            VehicleData[,] newTanksData = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];
            for (int i = 0; i < arrSizes.tanks.Item1; i++)
            {
                for (int j = 0; j < arrSizes.tanks.Item2; j++)
                {
                    newTanksData[i, j] = tanksData[i, j];
                }
            }
            arrSizes.tanks.Item2++;
            for (int i = 0; i < arrSizes.tanks.Item1; i++)
            {
                newTanksData[i, arrSizes.tanks.Item2 - 1] = new VehicleData();
            }
            tanksData = newTanksData;


            Button new_AddRowButton = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "Add row",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };

            new_AddRowButton.Click += AddRowTanks_Click;
            TanksTable.Controls.Add(new_AddRowButton, TanksTable.ColumnCount - 1, 0);
            AddColumnTanks.Location = new Point(AddColumnTanks.Location.X + 126, AddColumnTanks.Location.Y);
            AddColumnTanks.Text = "+";
        }
        private void AddRowTanks_Click(object sender, EventArgs e)
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
                TanksTable.RowCount = TanksTable.RowCount + 1;
                TanksTable.Controls.Add(curButton, colPos, TanksTable.RowCount - 1);
                TanksTable.Controls.Add(tank, colPos, TanksTable.RowCount - 2);

                if (tanksData != null)
                {
                    VehicleData[,] newTanksData = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];
                    for (int i = 0; i < arrSizes.tanks.Item1; i++)
                    {
                        for (int j = 0; j < arrSizes.tanks.Item2; j++)
                        {
                            tanksData[i, j] = tanksData[i, j] == null ? new VehicleData() { type = 0 } : tanksData[i, j];
                            newTanksData[i, j] = tanksData[i, j];
                        }
                    }
                    arrSizes.tanks.Item1 += 1;
                    for (int i = 0; i < arrSizes.tanks.Item2; i++)
                        newTanksData[arrSizes.tanks.Item1 - 1, i] = new VehicleData() { type = 0 };
                    tanksData = newTanksData;
                } else
                {
                    tanksData = new VehicleData[TanksTable.RowCount - 1, TanksTable.ColumnCount];
                    
                    arrSizes.tanks.Item1 = 1; arrSizes.tanks.Item2 = 1;
                }
            } else
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
            }else {
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
        private void AddColumnPlanes_Click(object sender, EventArgs e)
        {
            PlanesTable.ColumnCount++;

            VehicleData[,] newPlanesData = new VehicleData[PlanesTable.RowCount - 1, PlanesTable.ColumnCount];
            for (int i = 0; i < arrSizes.planes.Item1; i++)
            {
                for (int j = 0; j < arrSizes.planes.Item2; j++)
                {
                    newPlanesData[i, j] = planesData[i, j];
                }
            }
            arrSizes.planes.Item2++;
            for (int i = 0; i < arrSizes.planes.Item1; i++)
            {
                newPlanesData[i, arrSizes.planes.Item2 - 1] = new VehicleData();
            }
            planesData = newPlanesData;
            Button new_AddRowButton = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "Add row",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };

            new_AddRowButton.Click += AddRowPlanes_Click;
            PlanesTable.Controls.Add(new_AddRowButton, PlanesTable.ColumnCount - 1, 0);
            AddColumnPlanes.Location = new Point(AddColumnPlanes.Location.X + 126, AddColumnPlanes.Location.Y);
            AddColumnPlanes.Text = "+";

        }
        private void AddRowPlanes_Click(object sender, EventArgs e)
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
                        newPlanesData[arrSizes.planes.Item1- 1, i] = new VehicleData() { type = 1 };
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
        private void AddColumnHeli_Click(object sender, EventArgs e)
        {
            HeliTable.ColumnCount++;

            VehicleData[,] newHeliData = new VehicleData[HeliTable.RowCount - 1, HeliTable.ColumnCount];
            for (int i = 0; i < arrSizes.helis.Item1; i++)
            {
                for (int j = 0; j < arrSizes.helis.Item2; j++)
                {
                    newHeliData[i, j] = helicoptersData[i, j];
                }
            }
            arrSizes.helis.Item2++;
            for (int i = 0; i < arrSizes.helis.Item1; i++)
            {
                newHeliData[i, arrSizes.helis.Item2 - 1] = new VehicleData();
            }
            helicoptersData = newHeliData;


            Button new_AddRowButton = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "Add row",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };

            new_AddRowButton.Click += AddRowHeli_Click;
            HeliTable.Controls.Add(new_AddRowButton, HeliTable.ColumnCount - 1, 0);
            AddColumnHeli.Location = new Point(AddColumnHeli.Location.X + 126, AddColumnHeli.Location.Y);
            AddColumnHeli.Text = "+";
        }
        private void AddRowHeli_Click(object sender, EventArgs e)
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
                        newHeliData[arrSizes.helis.Item1- 1, i] = new VehicleData() { type = 2 };
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
                
                helicoptersData[row, col] = new VehicleData();
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // coastal fleet id = 3
        private void AddColumnCoastalFleet_Click(object sender, EventArgs e)
        {
            CoastalfleetTable.ColumnCount++;

            VehicleData[,] newCoastalData = new VehicleData[CoastalfleetTable.RowCount - 1, CoastalfleetTable.ColumnCount];
            for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
            {
                for (int j = 0; j < arrSizes.coastalFleet.Item2; j++)
                {
                    newCoastalData[i, j] = coastalFleetData[i, j];
                }
            }
            arrSizes.coastalFleet.Item2++;
            for (int i = 0; i < arrSizes.coastalFleet.Item1; i++)
            {
                newCoastalData[i, arrSizes.coastalFleet.Item2 - 1] = new VehicleData();
            }
            coastalFleetData = newCoastalData;


            Button new_AddRowButton = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "Add row",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };

            new_AddRowButton.Click += AddRowCoastalFleet_Click;
            CoastalfleetTable.Controls.Add(new_AddRowButton, CoastalfleetTable.ColumnCount - 1, 0);
            AddColumnCoastalFleet.Location = new Point(AddColumnCoastalFleet.Location.X + 126, AddColumnCoastalFleet.Location.Y);
            AddColumnCoastalFleet.Text = "+";
        }
        private void AddRowCoastalFleet_Click(object sender, EventArgs e)
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
                        newCoastalData[arrSizes.coastalFleet.Item1- 1, i] = new VehicleData() { type = 3 };
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
                
                coastalFleetData[row, col] = new VehicleData();
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }

        // bluewater fleet id = 4
        private void AddColumnBluewaterFleet_Click(object sender, EventArgs e)
        {
            BluewaterTable.ColumnCount++;

            VehicleData[,] newBluewaterData = new VehicleData[BluewaterTable.RowCount - 1, BluewaterTable.ColumnCount];
            for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
            {
                for (int j = 0; j < arrSizes.bluewaterFleet.Item2; j++)
                {
                    newBluewaterData[i, j] = bluewaterFleetData[i, j];
                }
            }
            arrSizes.bluewaterFleet.Item2++;
            for (int i = 0; i < arrSizes.bluewaterFleet.Item1; i++)
            {
                newBluewaterData[i, arrSizes.bluewaterFleet.Item2 - 1] = new VehicleData();
            }
            bluewaterFleetData = newBluewaterData;


            Button new_AddRowButton = new Button()
            {
                Width = 120,
                Height = 48,
                Text = "Add row",
                Margin = new Padding(3, 3, 3, 3),
                FlatStyle = FlatStyle.Flat,
            };

            new_AddRowButton.Click += AddRowBluewaterFleet_Click;
            BluewaterTable.Controls.Add(new_AddRowButton, BluewaterTable.ColumnCount - 1, 0);
            AddColumnBluewater.Location = new Point(AddColumnBluewater.Location.X + 126, AddColumnBluewater.Location.Y);
            AddColumnBluewater.Text = "+";
        }
        private void AddRowBluewaterFleet_Click(object sender, EventArgs e)
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
                        newBluewaterData[arrSizes.bluewaterFleet.Item1- 1, i] = new VehicleData() { type = 4 };
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
                
                bluewaterFleetData[row, col] = new VehicleData();
                curButton.BackgroundImage = base.BackgroundImage;
                curButton.BackColor = Color.FromArgb(31, 31, 31);
            }
        }


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

        // Special buttons
        private void reportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Gaz1zPr0g/wt-lineup-creator/issues");
        }
        private void supportButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://boosty.to/railguntoaster");
        }
        private void flagPanel_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpeg files |*.jpeg|PNG files |*.png";
            openFileDialog.Title = "Open flag";
            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                Image flagtocopy = Image.FromFile(openFileDialog.FileName);

                Image flag = new Bitmap(flagtocopy);
                flagtocopy.Dispose();

                float ratio = flag.Height / 48f;
                int width = Convert.ToInt32(flag.Width / ratio);
                flag = new Bitmap(flag, new Size(width, 48));
                flag.Save(@"temp\flag.png", System.Drawing.Imaging.ImageFormat.Png);

                flagPanel.Size = new Size(width, 48);
                flagPanel.Location = new Point(reportButton.Location.X - 3 - width, flagPanel.Location.Y);
                flagPanel.Text = "";
                flagPanel.BackgroundImage = flag;
                customFlagUsed = true;
            }
        }
        private void countryCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            country = countryCombo.SelectedItem.ToString();
            if (!customFlagUsed)
            {
                DownloadFlag(flagsURL[countryCombo.SelectedIndex]);
            }
            
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

            flagPanel.Size = new Size(width, 48);
            flagPanel.Location = new Point(reportButton.Location.X - 3 - width, flagPanel.Location.Y);
            flagPanel.Text = "";
            flagPanel.BackgroundImage = flag;
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
                ModeInfo.Text = "Delete mode";
                ModeInfo.ForeColor = Color.FromArgb(192, 0, 0);
                return true;
            } else if (keyData == Keys.E)
            {
                deleteMode = false;
                ModeInfo.Text = "Edit mode";
                ModeInfo.ForeColor = Color.FromArgb(0, 192, 0);
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                DialogResult dialogResult = MessageBox.Show(text: "Tanks table will be regenerated", caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    tanksData = null;
                    TanksTable.Controls.Clear();
                    arrSizes.tanks = (0, 1);
                    TanksTable.RowCount = 1; TanksTable.ColumnCount = 1;
                    TanksTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    TanksTable.Controls.Add(AddRowTanks1, 0, 0);
                    TanksTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                    AddColumnTanks.Location = new Point(135, 39);
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.P))
            {
                DialogResult dialogResult = MessageBox.Show(text: "Planes table will be regenerated", caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    planesData = null;
                    PlanesTable.Controls.Clear();
                    arrSizes.planes = (0, 1);
                    PlanesTable.RowCount = 1; PlanesTable.ColumnCount = 1;
                    PlanesTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    PlanesTable.Controls.Add(AddRowPlanes1, 0, 0);
                    PlanesTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                    AddColumnPlanes.Location = new Point(135, 39);
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.H))
            {
                DialogResult dialogResult = MessageBox.Show(text: "Helicopters table will be regenerated", caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    helicoptersData = null;
                    HeliTable.Controls.Clear();
                    arrSizes.helis = (0, 1);
                    HeliTable.RowCount = 1; HeliTable.ColumnCount = 1;
                    HeliTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    HeliTable.Controls.Add(AddRowHeli, 0, 0);
                    HeliTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                    AddColumnHeli.Location = new Point(135, 39);
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.C))
            {
                DialogResult dialogResult = MessageBox.Show(text: "Coastal fleet table will be regenerated", caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    coastalFleetData = null; 
                    CoastalfleetTable.Controls.Clear();
                    arrSizes.coastalFleet = (0, 1);
                    CoastalfleetTable.RowCount = 1; CoastalfleetTable.ColumnCount = 1;
                    CoastalfleetTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    CoastalfleetTable.Controls.Add(AddRowCoastalFleet, 0, 0);
                    CoastalfleetTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                    AddColumnCoastalFleet.Location = new Point(135, 39);
                }
                return true;
            } else if (keyData == (Keys.Control | Keys.Shift | Keys.B))
            {
                DialogResult dialogResult = MessageBox.Show(text: "Bluewater fleet table will be regenerated", caption: "Warning", buttons: MessageBoxButtons.OKCancel);

                if (dialogResult == DialogResult.OK)
                {
                    bluewaterFleetData = null;
                    BluewaterTable.Controls.Clear();
                    arrSizes.bluewaterFleet = (0, 1);
                    BluewaterTable.RowCount = 1; BluewaterTable.ColumnCount = 1;
                    BluewaterTable.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
                    BluewaterTable.Controls.Add(AddRowBluewater, 0, 0);
                    BluewaterTable.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
                    AddColumnBluewater.Location = new Point(135, 39);

                    Console.WriteLine(BluewaterTable.GetPositionFromControl(AddRowBluewater));

                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            StatusLabel.Text = "ok";
            StatusLabel.ForeColor = Color.White;
        }

    }

    public class VehicleData
    {
        public string name;
        public int type = -1;
        public string imageLink;
        public int backgroudType = 0; // 0 - standart, 1 - premium, 2 - squadron
        public string buttonImage;

        public VehicleData() { }

        public VehicleData(string name, int type, string imageLink, int backgroundType)
        {
            this.name = name;
            this.type = type;
            this.imageLink = imageLink;
            this.backgroudType = backgroundType;
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
