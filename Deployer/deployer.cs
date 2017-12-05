using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Deployer
{
    public partial class deployer : Form
    {
        public deployer()
        {
            InitializeComponent();
        }

        private void deployer_Load(object sender, EventArgs e)
        {
           cmbBuild.DataSource= new moduleRepository().GetAllModulesByStatus();
           cmbBuild.DisplayMember = "ModuleName";
           cmbBuild.ValueMember = "ModuleCode";
            cmbBuild_SelectedIndexChanged(null, null);
        }

        private void txtCurrentPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtCurrentPath.Text= dialog.SelectedPath;
        }

        private void cmbBuild_SelectedIndexChanged(object sender, EventArgs e)
        {
            setHostPath(cmbBuild.SelectedValue.ToString());
        }

        private void setHostPath(string selectedValue)
        {
            switch (selectedValue)
            {
                case "FO":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\FrontOfice\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\FrontOfice\";
                    txtPathToHost.Tag = "Numr.FrontOffice.exe";
                    break;
                case "CSH":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\Cash\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Cash\";
                    txtPathToHost.Tag = "Numr.CashBilling.exe";
                    break;
                case "LAB":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\Lab\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Lab\";
                    txtPathToHost.Tag = "Numr.Lab.exe";
                    break;
                case "DSCHRG":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\Discharge\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Discharge\";
                    txtPathToHost.Tag = "Numr.Discharge.exe";
                    break;
                case "BLL":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\Billing\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Billing\";
                    txtPathToHost.Tag = "Numr.Billing.exe";
                    break;
                case "PHY":
                    txtPathToHost.Text = @"\\192.168.1.102\tiatech\NUMR BUILDS FOR TOOL\Pharmacy\";
                    txtSecondaryPath.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Pharmacy\";
                    txtPathToHost.Tag = "Numr.Pharmacy.exe";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button1.Text = "Deploying please wait!!";
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                DateTime current = new moduleRepository().GetDate();
                string folderName = current.ToString("dd-MM-yyyy HH.mm");
                DirectoryInfo to = Directory.CreateDirectory(txtPathToHost.Text +folderName);
                DirectoryInfo to2 = Directory.CreateDirectory(txtSecondaryPath.Text + folderName);
                DirectoryInfo from = new DirectoryInfo(txtCurrentPath.Text);
                FileInfo[] files = from.GetFiles();
                //foreach (FileInfo tempfile in files)
                //    tempfile.CopyTo(Path.Combine(to.FullName, tempfile.Name));

                foreach (string dirPath in Directory.GetDirectories(from.FullName, "*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dirPath.Replace(from.FullName, to.FullName));
                    Directory.CreateDirectory(dirPath.Replace(from.FullName, to2.FullName));
                }

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(from.FullName, "*.*", SearchOption.AllDirectories))
                {
                    File.Copy(newPath, newPath.Replace(from.FullName, to.FullName), true);
                    File.Copy(newPath, newPath.Replace(from.FullName, to2.FullName), true);
                }

                new moduleRepository().deployNewBuildByModule(new moduleDTO { pathToBuild = to.FullName+"\\"+txtPathToHost.Tag.ToString(),pathToBuildSecondary= to2.FullName + "\\" + txtPathToHost.Tag.ToString(), BuildVersion = folderName,BuildName=txtPathToHost.Tag.ToString().Replace(".exe","") });
                MessageBox.Show("Deployed successfully.","Done");
            }
            catch (Exception eg)
            {
                MessageBox.Show("Error on deployment "+eg.StackTrace);
            }
            button1.Enabled = true;
            button1.Text = "Deploy";
            Cursor.Current = Cursors.Default;
        }
    }
}
