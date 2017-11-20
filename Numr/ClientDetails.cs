using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Numr
{
    public partial class frmClientDetails : Form
    {
        public frmClientDetails()
        {
            InitializeComponent();
        }
        clientDTO currentSystem = new clientDTO();
        clientRepository clientRepo = new clientRepository();
        moduleRepository moduleRepo = new moduleRepository();
        Util fun = new Util();
        private void frmClientDetails_Load(object sender, EventArgs e)
        {
            loadModules();
            loadDataToGrid(null, null);
        }

        private void loadModules()
        {
            List<moduleDTO> list = moduleRepo.GetAllModulesByStatus();
            list.Add(new moduleDTO() { ModuleCode = "0", ModuleName = "Not Registered" });
            moduleList.DataSource = list;
            moduleList.DisplayMember = "ModuleName";
            moduleList.ValueMember = "ModuleCode";
        }


        private void loadDataToGrid(object sender, EventArgs e)
        {
            searchParam param = new searchParam();
            param.ip = txtIP.Text;
            param.name = txtPCname.Text;
            param.moduleCode = moduleList.SelectedValue.ToString();
            dgvClientRecord.AutoGenerateColumns = false;
            List<clientDTO> list = clientRepo.GetAllClientDataByParam(param);
            dgvClientRecord.DataSource = list;
        }

        private void dgvClientRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientRecord.Columns[e.ColumnIndex].Name == "grdEdit")
            {
                ClientModuleView frm = new Numr.ClientModuleView(); 
                frm.selectedClient=(clientDTO)dgvClientRecord.CurrentRow.DataBoundItem;
                if (frm.ShowDialog(this) == DialogResult.Cancel)
                {
                    loadDataToGrid(null, null);
                }
            }
            if (dgvClientRecord.Columns[e.ColumnIndex].Name == "grdDlt")
            {

            }
        }
    }
}