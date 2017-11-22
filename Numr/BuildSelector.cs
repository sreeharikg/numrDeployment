using DAL;
using DTO;
using Numr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numr
{
    public partial class BuildSelector : Form
    {
        public BuildSelector()
        {
            InitializeComponent();
        }
        clientDTO currentSystem = new clientDTO();
        clientRepository clientRepo = new clientRepository();
        moduleRepository moduleRepo = new moduleRepository();
        Util fun = new Util();
        List<moduleDTO> list = new List<moduleDTO>();
        private void BuildSelector_Load(object sender, EventArgs e)
        {
            loadFormData();
            currentSystem = fun.GetMacAddress();
            currentSystem.ip =fun.GetAllLocalIPv4();
            currentSystem.name = fun.GetMachineName();
            currentSystem.pcDescription = fun.GetComputerDescription();
            clientRepo.RegisterOrUpdateClientDetails(currentSystem);
            list = moduleRepo.GetAllAllowedModulesByEthernetMAC(currentSystem.lanMAC);
            loadAllowedMdis();
        }

        private void loadFormData()
        {
            CompanyDetails com= clientRepo.GetCompanydetails();
            lblCompany.Text = com.Name;
            using (var ms = new System.IO.MemoryStream(com.Logoimg))
            {
                logoCompany.Image =  Image.FromStream(ms);
            }
        }

        private void loadAllowedMdis()
        {
            for (int i = 0,x=120,y=100; i < list.Count;i++,x+=120)
            {
                Button btn = new Button();
                btn.Text = list[i].ModuleName;
                btn.Tag = list[i].ModuleCode;
                btn.BackColor = Color.FromArgb(255, 232, 232);
                btn.Size = new Size(81, 26);
                if (!(this.Width / x > 1))
                { x = 120; y += 50; }

                btn.Location = new System.Drawing.Point(x, y);

                btn.Click += new EventHandler(btnOpen_Click);
                this.Controls.Add(btn);
               // btn.BringToFront();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            moduleDTO app2Open = list.Where(x => x.ModuleCode == ((Button)sender).Tag.ToString()).FirstOrDefault();
            Process[] pname = Process.GetProcessesByName(app2Open.BuildName.Trim());
            if (pname.Length != 0)
            {
                ((Button)sender).Enabled = true;
                Cursor.Current = Cursors.Default;
                return;
            }
            Process p = Process.Start(app2Open.pathToBuild);
            ((Button)sender).Enabled = true;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
