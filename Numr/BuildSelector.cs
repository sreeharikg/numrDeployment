﻿using DAL;
using DTO;
using Numr;
using Numr.Properties;
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
        List<moduleDTO> list,allMdis = new List<moduleDTO>();
        private void BuildSelector_Load(object sender, EventArgs e)
        {
            
            //this.ShowInTaskbar = false;
            if (networkAvailable())
            {
                loadFormData();
                currentSystem = fun.GetMacAddress();
                currentSystem.ip = fun.GetAllLocalIPv4();
                currentSystem.name = fun.GetMachineName();
                currentSystem.pcDescription = fun.GetComputerDescription();
                clientRepo.RegisterOrUpdateClientDetails(currentSystem);
                list = moduleRepo.GetAllAllowedModulesByEthernetMAC(currentSystem.lanMAC);
                allMdis = moduleRepo.GetAllModulesByStatus();
                loadAllowedMdis();
            }
        }

        private bool networkAvailable()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                return true;
            else
            {
                if (MessageBox.Show("No Network found. Contact IT Department", "Warning", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    if (networkAvailable())
                        return true;
            }
            return false;
        }

        private void loadFormData()
        {
            CompanyDetails com= clientRepo.GetCompanydetails();
            lblCompany.Text = com.Name;
            if(com.Logoimg!=null)
            using (var ms = new System.IO.MemoryStream(com.Logoimg))
            {
                logoCompany.Image =  Image.FromStream(ms);
            }
        }

        private void loadAllowedMdis()
        {
            for (int i = 0,x=80,y=120; i < allMdis.Count;i++,x+=150)
            {
                Button btn = new Button();
                btn.Text = allMdis[i].ModuleName;
                btn.Tag = allMdis[i].ModuleCode;
                if (list.Where(c => c.ModuleCode == btn.Tag.ToString()).FirstOrDefault() == null)
                    btn.Enabled = false;
                btn.BackColor = Color.FromArgb(87, 192, 237);
                btn.Size = new Size(81, 26);
                if (!(this.Width >= x+25 ))
                { x = 80; y += 50; }

                btn.Location = new System.Drawing.Point(x, y);

                btn.Click += new EventHandler(btnOpen_Click);
                this.Controls.Add(btn);
                btn.BringToFront();
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (networkAvailable())
            {
                allMdis = moduleRepo.GetAllModulesByStatus();
                toggleButton(false);
                moduleDTO app2Open = allMdis.Where(x => x.ModuleCode == ((Button)sender).Tag.ToString()).FirstOrDefault();
                Process[] pname = Process.GetProcessesByName(app2Open.BuildName.Trim());
                if (pname.Length != 0)
                {
                    toggleButton(true);
                    Cursor.Current = Cursors.Default;
                    return;
                }
                try
                {
                    Process.Start(app2Open.pathToBuild.TrimStart().TrimEnd());
                }
                catch (Exception eg)
                {
                    if (MessageBox.Show("Seems there is no build found in Network or something went wrong on build deployment.\nPlease contact IT Department!", "Error", MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                        Process.Start(app2Open.pathToBuildSecondary.TrimStart().TrimEnd());
                }
                toggleButton(true);
                currentSystem.currentBuild = app2Open.BuildVersion;
                currentSystem.currentModuleId = app2Open.ModuleID;
                clientRepo.updateCurrentBuildVersionByMac(currentSystem);
            }
        }
        private void toggleButton(bool enabled)
        {
            foreach (Control btn in this.Controls)
                if (btn.GetType() == typeof(Button))
                    if (list.Where(c => c.ModuleCode == btn.Tag.ToString()).FirstOrDefault() != null)
                        btn.Enabled = true;

        }
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox2, "Exit");
            Cursor.Current = Cursors.Hand;
        }

    }
}
