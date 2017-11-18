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

        private void ClientModuleView_Load(object sender, EventArgs e)
        {
            List<moduleDTO> list = moduleRepo.GetAllModulesByStatus();
            list.Add(new moduleDTO() { ModuleCode = "0", ModuleName = "No Modules" });
            ((ListBox)chklstModules).DataSource = list;
            ((ListBox)chklstModules).DisplayMember = "ModuleName";
            ((ListBox)chklstModules).ValueMember = "ModuleCode";
        }
    }
}
