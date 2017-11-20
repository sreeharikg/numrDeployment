namespace Numr
{
    partial class ClientModuleView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientModuleView));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDenyModule = new System.Windows.Forms.CheckBox();
            this.chklstModules = new System.Windows.Forms.CheckedListBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDenyModule);
            this.groupBox2.Controls.Add(this.chklstModules);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox2.Location = new System.Drawing.Point(12, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 310);
            this.groupBox2.TabIndex = 100;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Allowed Modules";
            // 
            // chkDenyModule
            // 
            this.chkDenyModule.AutoSize = true;
            this.chkDenyModule.Location = new System.Drawing.Point(51, 276);
            this.chkDenyModule.Name = "chkDenyModule";
            this.chkDenyModule.Size = new System.Drawing.Size(83, 17);
            this.chkDenyModule.TabIndex = 113;
            this.chkDenyModule.Text = "Not Allowed";
            this.chkDenyModule.UseVisualStyleBackColor = true;
            this.chkDenyModule.CheckedChanged += new System.EventHandler(this.chkDenyModule_CheckedChanged);
            // 
            // chklstModules
            // 
            this.chklstModules.FormattingEnabled = true;
            this.chklstModules.Location = new System.Drawing.Point(19, 28);
            this.chklstModules.Name = "chklstModules";
            this.chklstModules.Size = new System.Drawing.Size(362, 229);
            this.chklstModules.TabIndex = 112;
            this.chklstModules.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstModules_ItemCheck);
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Location = new System.Drawing.Point(207, 273);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 21);
            this.btnUpdate.TabIndex = 110;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ClientModuleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(432, 367);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientModuleView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Allowed Modules";
            this.Load += new System.EventHandler(this.ClientModuleView_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.CheckedListBox chklstModules;
        private System.Windows.Forms.CheckBox chkDenyModule;
    }
}