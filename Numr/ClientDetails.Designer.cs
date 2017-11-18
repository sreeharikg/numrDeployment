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
            this.mchineList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdResultList = new System.Windows.Forms.DataGridView();
            this.txtTestId = new System.Windows.Forms.TextBox();
            this.lblBillNo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDlt = new System.Windows.Forms.DataGridViewImageColumn();
            this.grdEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.pcNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lanMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wlanMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currMAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currBuild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Completed_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currUSER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mchineList
            // 
            this.mchineList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mchineList.FormattingEnabled = true;
            this.mchineList.Items.AddRange(new object[] {
            "Toshiba TBA-25FR",
            "Toshiba TBA-40FR",
            "Cobas E-411",
            "Pentra"});
            this.mchineList.Location = new System.Drawing.Point(19, 22);
            this.mchineList.Name = "mchineList";
            this.mchineList.Size = new System.Drawing.Size(165, 21);
            this.mchineList.TabIndex = 87;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mchineList);
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
            // 
            // grdResultList
            // 
            this.grdResultList.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
            this.grdResultList.AllowUserToAddRows = false;
            this.grdResultList.AllowUserToDeleteRows = false;
            this.grdResultList.AllowUserToOrderColumns = true;
            this.grdResultList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdDlt,
            this.grdEdit,
            this.pcNAME,
            this.ip,
            this.lanMAC,
            this.wlanMAC,
            this.SampleID,
            this.currMAC,
            this.currBuild,
            this.Completed_date,
            this.currUSER,
            this.shortNum,
            this.Id});
            this.grdResultList.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdResultList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.grdResultList.EnableHeadersVisualStyles = false;
            this.grdResultList.Location = new System.Drawing.Point(1, 92);
            this.grdResultList.MultiSelect = false;
            this.grdResultList.Name = "grdResultList";
            this.grdResultList.RowHeadersVisible = false;
            this.grdResultList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultList.Size = new System.Drawing.Size(1353, 564);
            this.grdResultList.TabIndex = 105;
            // 
            // txtTestId
            // 
            this.txtTestId.Location = new System.Drawing.Point(52, 19);
            this.txtTestId.Name = "txtTestId";
            this.txtTestId.Size = new System.Drawing.Size(200, 20);
            this.txtTestId.TabIndex = 107;
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
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtTestId);
            this.groupBox2.Controls.Add(this.lblBillNo);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(582, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 54);
            this.groupBox2.TabIndex = 109;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(384, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 109;
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
            // grdDlt
            // 
            this.grdDlt.HeaderText = "Delete";
            this.grdDlt.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.grdDlt.Name = "grdDlt";
            this.grdDlt.ReadOnly = true;
            this.grdDlt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDlt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdDlt.Width = 45;
            // 
            // grdEdit
            // 
            this.grdEdit.HeaderText = "Edit";
            this.grdEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.grdEdit.Name = "grdEdit";
            this.grdEdit.ReadOnly = true;
            this.grdEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdEdit.Width = 45;
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
            this.lanMAC.Width = 130;
            // 
            // wlanMAC
            // 
            this.wlanMAC.DataPropertyName = "wlanMAC";
            this.wlanMAC.HeaderText = "WIFI MAC";
            this.wlanMAC.Name = "wlanMAC";
            this.wlanMAC.Width = 130;
            // 
            // SampleID
            // 
            this.SampleID.DataPropertyName = "sampleId";
            this.SampleID.HeaderText = "ALLOWED MODULES";
            this.SampleID.Name = "SampleID";
            this.SampleID.Width = 200;
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
            this.currBuild.DataPropertyName = "currBuild";
            this.currBuild.HeaderText = "CURRENT BUILD";
            this.currBuild.Name = "currBuild";
            this.currBuild.Width = 130;
            // 
            // Completed_date
            // 
            this.Completed_date.DataPropertyName = "completedDate";
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
            this.Controls.Add(this.grdResultList);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmClientDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Machine Data";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmClientDetails_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox mchineList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdResultList;
        private System.Windows.Forms.TextBox txtTestId;
        private System.Windows.Forms.Label lblBillNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn grdDlt;
        private System.Windows.Forms.DataGridViewImageColumn grdEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn lanMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn wlanMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn currMAC;
        private System.Windows.Forms.DataGridViewTextBoxColumn currBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn Completed_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn currUSER;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}