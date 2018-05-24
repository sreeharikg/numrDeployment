using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleanUpdates
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

                Thread.Sleep(1500);
          doClean();
            Thread.Sleep(1500);
            Process.Start(new ProcessStartInfo(Application.StartupPath + "\\" + "Numr.Client.Desktop.exe"));

        }
        static bool doClean()
        {
            try
            {
                string[] ExcusionFiles = { "Numr.Client.Update.exe", "Numr.Client.Update.pdb","Numr.Client.Update.exe.config","MetroFramework.Design.dll","MetroFramework.dll"
        ,"Numr.Client.Update.vshost.exe","MetroFramework.Fonts.dll"};
                foreach (FileInfo fi in new DirectoryInfo(Application.StartupPath).GetFiles())
                {
                    if (ExcusionFiles.Contains(fi.Name))
                        fi.Delete();
                }
                foreach (FileInfo fi in new DirectoryInfo(Application.StartupPath).GetFiles())
                {
                    if (fi.Name.Contains("{latest}"))
                        fi.MoveTo(fi.Directory.FullName + "\\" + fi.Name.Replace("{latest}", ""));
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
