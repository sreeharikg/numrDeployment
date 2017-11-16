using DAL;
using DTO;
using Numr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Util fun = new Util();
        private void BuildSelector_Load(object sender, EventArgs e)
        {
            currentSystem = fun.GetMacAddress();
            currentSystem.ip =fun.GetAllLocalIPv4();
            currentSystem.name = fun.GetMachineName();
            currentSystem.pcDescription = fun.GetComputerDescription();
            currentSystem = clientRepo.RegisterOrUpdateClientDetails(currentSystem);
        }
        private void loadAllowedMdis()
        {
            cboModule.DataSource = fun.GetAllAllowedModulesByEthernetMAC(currentSystem.lanMAC);
            cboModule.DisplayMember = "ModuleName";
            cboModule.ValueMember = "ModuleID";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
