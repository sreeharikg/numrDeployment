namespace Numr
{
    partial class frmClientDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientDetails));
            this.moduleList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPCname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvClientRecord = new System.Windows.Forms.DataGridView();
            this.grdDlt = new System.Windows.Forms.DataGridViewImageColumn();
            this.grdEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.pcNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lanMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wlanMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allowedModules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currBuild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currUSER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // moduleList
            // 
            this.moduleList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moduleList.FormattingEnabled = true;
            this.moduleList.Location = new System.Drawing.Point(19, 22);
            this.moduleList.Name = "moduleList";
            this.moduleList.Size = new System.Drawing.Size(165, 21);
            this.moduleList.TabIndex = 87;
            this.moduleList.SelectedIndexChanged += new System.EventHandler(this.loadDataToGrid);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.moduleList);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(185, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 54);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select module";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(609, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 21);
            this.btnSearch.TabIndex = 88;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.loadDataToGrid);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(52, 19);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(200, 20);
            this.txtIP.TabIndex = 107;
            // 
            // lblBillNo
            // 
            this.lblBillNo.AutoSize = true;
            this.lblBillNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.White;
            this.lblBillNo.Location = new System.Drawing.Point(23, 19);
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Size = new System.Drawing.Size(23, 19);
            this.lblBillNo.TabIndex = 106;
            this.lblBillNo.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPCname);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtIP);
            this.groupBox2.Controls.Add(this.lblBillNo);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(582, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 54);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // txtPCname
            // 
            this.txtPCname.Location = new System.Drawing.Point(384, 16);
            this.txtPCname.Name = "txtPCname";
            this.txtPCname.Size = new System.Drawing.Size(200, 20);
            this.txtPCname.TabIndex = 109;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(299, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 108;
            this.label1.Text = "PC NAME";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Delete";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 60;
            // 
            // dgvClientRecord
            // 
            this.dgvClientRecord.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.dgvClientRecord.AllowUserToAddRows = false;
            this.dgvClientRecord.AllowUserToDeleteRows = false;
            this.dgvClientRecord.AllowUserToOrderColumns = true;
            this.dgvClientRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdDlt,
            this.grdEdit,
            this.pcNAME,
            this.ip,
            this.lanMAC,
            this.wlanMAC,
            this.allowedModules,
            this.currMAC,
            this.currBuild,
            this.Completed_date,
            this.currUSER,
            this.shortNum,
            this.Id});
            this.dgvClientRecord.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvClientRecord.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dgvClientRecord.EnableHeadersVisualStyles = false;
            this.dgvClientRecord.Location = new System.Drawing.Point(1, 92);
            this.dgvClientRecord.MultiSelect = false;
            this.dgvClientRecord.Name = "dgvClientRecord";
            this.dgvClientRecord.RowHeadersVisible = false;
            this.dgvClientRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientRecord.Size = new System.Drawing.Size(1364, 580);
            this.dgvClientRecord.TabIndex = 105;
            this.dgvClientRecord.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClientRecord_CellContentClick);
            // 
            // grdDlt
            // 
            this.grdDlt.HeaderText = "Delete";
            this.grdDlt.Image = ((System.Drawing.Image)(resources.GetObject("grdDlt.Image")));
            this.grdDlt.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.grdDlt.Name = "grdDlt";
            this.grdDlt.ReadOnly = true;
            this.grdDlt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDlt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdDlt.Width = 40;
            // 
            // grdEdit
            // 
            this.grdEdit.HeaderText = "Edit";
            this.grdEdit.Image = ((System.Drawing.Image)(resources.GetObject("grdEdit.Image")));
            this.grdEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.grdEdit.Name = "grdEdit";
            this.grdEdit.ReadOnly = true;
            this.grdEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdEdit.Width = 30;
            // 
            // pcNAME
            // 
            this.pcNAME.DataPropertyName = "name";
            this.pcNAME.HeaderText = "PC NAME";
            this.pcNAME.Name = "pcNAME";
            this.pcNAME.Width = 130;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "ip";
            this.ip.HeaderText = "CURRENT IP ADDRESS";
            this.ip.Name = "ip";
            this.ip.Width = 150;
            // 
            // lanMAC
            // 
            this.lanMAC.DataPropertyName = "lanMAC";
            this.lanMAC.HeaderText = "LAN MAC";
            this.lanMAC.Name = "lanMAC";
            this.lanMAC.Width = 120;
            // 
            // wlanMAC
            // 
            this.wlanMAC.DataPropertyName = "wlanMAC";
            this.wlanMAC.HeaderText = "WIFI MAC";
            this.wlanMAC.Name = "wlanMAC";
            this.wlanMAC.Width = 120;
            // 
            // allowedModules
            // 
            this.allowedModules.DataPropertyName = "allowedModules";
            this.allowedModules.HeaderText = "ALLOWED MODULES";
            this.allowedModules.Name = "allowedModules";
            this.allowedModules.Width = 200;
            // 
            // currMAC
            // 
            this.currMAC.DataPropertyName = "currentMAC";
            this.currMAC.HeaderText = "CURRENT MAC";
            this.currMAC.Name = "currMAC";
            this.currMAC.Width = 130;
            // 
            // currBuild
            // 
            this.currBuild.DataPropertyName = "currentBuild";
            this.currBuild.HeaderText = "CURRENT BUILD";
            this.currBuild.Name = "currBuild";
            this.currBuild.Width = 130;
            // 
            // Completed_date
            // 
            this.Completed_date.DataPropertyName = "loggedDATE";
            this.Completed_date.HeaderText = "LAST LOGGED IN";
            this.Completed_date.Name = "Completed_date";
            this.Completed_date.ReadOnly = true;
            this.Completed_date.Width = 125;
            // 
            // currUSER
            // 
            this.currUSER.DataPropertyName = "currentUser";
            this.currUSER.HeaderText = "CURRENT USER";
            this.currUSER.Name = "currUSER";
            // 
            // shortNum
            // 
            this.shortNum.DataPropertyName = "pcDescription";
            this.shortNum.HeaderText = "SHORT NUMBER";
            this.shortNum.Name = "shortNum";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // frmClientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1354, 525);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvClientRecord);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmClientDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Clients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClientDetails_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox moduleList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox txtPCname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClientRecord;
        private System.Windows.Forms.DataGridViewImageColumn grdDlt;
        private System.Windows.Forms.DataGridViewImageColumn grdEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn lanMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn wlanMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn allowedModules;
        private System.Windows.Forms.DataGridViewTextBoxColumn currMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn currBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn Completed_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn currUSER;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}