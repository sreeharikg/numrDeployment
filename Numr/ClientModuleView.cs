using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DTO;
using DAL;

namespace Numr
{
    public partial class ClientModuleView : Form
    {
        clientRepository clientRepo = new clientRepository();
        moduleRepository moduleRepo = new moduleRepository();
        public ClientModuleView()
        {
            InitializeComponent();
        }
        public clientDTO selectedClient = new clientDTO();

        private void ClientModuleView_Load(object sender, EventArgs e)
        {
            fillData();
        }
        private void fillData()
        {
            List<moduleDTO> list = moduleRepo.GetAllModulesByStatus();
            ((ListBox)chklstModules).DataSource = list;
            ((ListBox)chklstModules).DisplayMember = "ModuleName";
            ((ListBox)chklstModules).ValueMember = "ModuleCode";

            foreach (moduleDTO module in selectedClient.allowedModulesList)
            {
                if (module != null)
                {
                    int index = chklstModules.FindStringExact(module.ModuleName);
                    if (index >= 0)
                        chklstModules.SetItemChecked(index, true);
                }
            }

        }
        private void chkDenyModule_CheckedChanged(object sender, EventArgs e)
        {
            foreach (int checkedItemIndex in chklstModules.CheckedIndices)
                chklstModules.SetItemChecked(checkedItemIndex, false);
        }

        private void chklstModules_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            chkDenyModule.Checked = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            selectedClient.allowedModules = null;
            foreach (object itemChecked in chklstModules.CheckedItems)
                selectedClient.allowedModules += "'" + ((moduleDTO)itemChecked).ModuleCode + "',";

            if (selectedClient.allowedModules != null)
                selectedClient.allowedModules = selectedClient.allowedModules.Substring(0, selectedClient.allowedModules.Length - 1);
            else
                selectedClient.allowedModules = "0";
            if (clientRepo.UpdateClientAllowedModules(selectedClient))
                MessageBox.Show("Updated.");
        }
    }
}
