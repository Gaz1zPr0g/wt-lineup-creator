using System;
using System.IO;
using System.Windows.Forms;

namespace Lineups_creator
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string dir = Application.StartupPath;


            if (Directory.Exists($@"{dir}\temp"))
            {
                foreach (string filePath in Directory.GetFiles($@"{dir}\temp"))
                {
                    FileInfo fi = new FileInfo(filePath);
                    fi.Delete();
                }
                Directory.Delete($@"{dir}\temp");
            }
            
            Application.Run(new Lineup_creator());




            Application.Exit();

            DirectoryInfo dict = new DirectoryInfo(@"temp\");
            foreach(FileInfo file in dict.EnumerateFiles())
            {
                file.Delete();
            }
            dict.Delete();
        }
    }


}
