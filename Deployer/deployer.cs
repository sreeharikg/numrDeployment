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
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\FrontOfice\";
                    break;
                case "CSH":
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Cash\";
                    break;
                case "LAB":
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Lab\";
                    break;
                case "DSCHRG":
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Discharge\";
                    break;
                case "BLL":
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Billing\";
                    break;
                case "PHY":
                    txtPathToHost.Text = @"\\192.168.1.95\savikas\NUMR BUILDS FOR TOOL\Pharmacy\";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                DateTime current = new moduleRepository().GetDate();
                string folderName = current.ToString("dd-MM-yyyy HH.mm");
                DirectoryInfo to = Directory.CreateDirectory(txtPathToHost.Text +folderName);
                DirectoryInfo from = new DirectoryInfo(txtCurrentPath.Text);
                FileInfo[] files = from.GetFiles();
                foreach (FileInfo tempfile in files)
                    tempfile.CopyTo(Path.Combine(to.FullName, tempfile.Name));

                new moduleRepository().deployNewBuildByModule(new moduleDTO { pathToBuild = "", BuildVersion = folderName });

            }
            catch (Exception eg)
            {
                MessageBox.Show("Error on deployment "+eg.Data);
            }
        }
    }
}
