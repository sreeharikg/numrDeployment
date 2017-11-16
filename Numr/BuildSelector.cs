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
        clientDTO dto = new clientDTO();
        Util fun = new Util();
        private void BuildSelector_Load(object sender, EventArgs e)
        {
            dto=fun.GetMacAddress();
            dto.ip =fun.GetAllLocalIPv4();
            dto.name = fun.GetMachineName();
        }
        private void loadAllowedMdis()
        {
            cboModule.DataSource = fun.GetAllAllowedModulesByEthernetMAC(dto.lanMAC);
            cboModule.DisplayMember = "ModuleName";
            cboModule.ValueMember = "ModuleID";
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
