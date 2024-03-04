using System;
using System.IO;
using System.Windows.Forms;

namespace Lineups_creator
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Lineup_creator());

            Application.Exit();

            DirectoryInfo dict = new DirectoryInfo(@"temp\");
            foreach(FileInfo file in dict.EnumerateFiles())
            {
                file.Delete();
            }
        }
    }
}
