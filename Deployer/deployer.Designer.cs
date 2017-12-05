namespace Deployer
{
    partial class deployer
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
            this.cmbBuild = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtCurrentPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPathToHost = new System.Windows.Forms.TextBox();
            this.txtSecondaryPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbBuild
            // 
            this.cmbBuild.FormattingEnabled = true;
            this.cmbBuild.Location = new System.Drawing.Point(93, 19);
            this.cmbBuild.Name = "cmbBuild";
            this.cmbBuild.Size = new System.Drawing.Size(162, 21);
            this.cmbBuild.TabIndex = 0;
            this.cmbBuild.SelectedIndexChanged += new System.EventHandler(this.cmbBuild_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Build";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Deploy";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtCurrentPath
            // 
            this.txtCurrentPath.Location = new System.Drawing.Point(93, 55);
            this.txtCurrentPath.Multiline = true;
            this.txtCurrentPath.Name = "txtCurrentPath";
            this.txtCurrentPath.Size = new System.Drawing.Size(346, 51);
            this.txtCurrentPath.TabIndex = 3;
            this.txtCurrentPath.Click += new System.EventHandler(this.txtCurrentPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current Path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Path to Deploy";
            // 
            // txtPathToHost
            // 
            this.txtPathToHost.Location = new System.Drawing.Point(93, 119);
            this.txtPathToHost.Multiline = true;
            this.txtPathToHost.Name = "txtPathToHost";
            this.txtPathToHost.Size = new System.Drawing.Size(346, 46);
            this.txtPathToHost.TabIndex = 6;
            // 
            // txtSecondaryPath
            // 
            this.txtSecondaryPath.Location = new System.Drawing.Point(93, 182);
            this.txtSecondaryPath.Multiline = true;
            this.txtSecondaryPath.Name = "txtSecondaryPath";
            this.txtSecondaryPath.Size = new System.Drawing.Size(346, 48);
            this.txtSecondaryPath.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "Secondary Path to Deploy";
            // 
            // deployer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 281);
            this.Controls.Add(this.txtSecondaryPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPathToHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentPath);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBuild);
            this.Name = "deployer";
            this.Text = "deployer";
            this.Load += new System.EventHandler(this.deployer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBuild;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtCurrentPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPathToHost;
        private System.Windows.Forms.TextBox txtSecondaryPath;
        private System.Windows.Forms.Label label4;
    }
}