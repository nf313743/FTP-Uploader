namespace NathanUpload
{
    partial class frmProjectSettings
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
          this.btnOK = new System.Windows.Forms.Button();
          this.btnCancel = new System.Windows.Forms.Button();
          this.txtProjectName = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.ckbAdvancedOptions = new System.Windows.Forms.CheckBox();
          this.lblCmd = new System.Windows.Forms.Label();
          this.ckbInterrupt = new System.Windows.Forms.CheckBox();
          this.txtCommandLine = new System.Windows.Forms.TextBox();
          this.lblProxyName = new System.Windows.Forms.Label();
          this.txtProxyUser = new System.Windows.Forms.TextBox();
          this.txtAddFile = new System.Windows.Forms.TextBox();
          this.btnAddFolder = new System.Windows.Forms.Button();
          this.lblProxyPass = new System.Windows.Forms.Label();
          this.txtProxyPass = new System.Windows.Forms.TextBox();
          this.ckbInstall = new System.Windows.Forms.CheckBox();
          this.lblContinue = new System.Windows.Forms.Label();
          this.SuspendLayout();
          // 
          // btnOK
          // 
          this.btnOK.Location = new System.Drawing.Point(282, 248);
          this.btnOK.Name = "btnOK";
          this.btnOK.Size = new System.Drawing.Size(75, 23);
          this.btnOK.TabIndex = 9;
          this.btnOK.Text = "OK";
          this.btnOK.UseVisualStyleBackColor = true;
          this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
          // 
          // btnCancel
          // 
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Location = new System.Drawing.Point(363, 248);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(75, 23);
          this.btnCancel.TabIndex = 10;
          this.btnCancel.Text = "Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          // 
          // txtProjectName
          // 
          this.txtProjectName.Location = new System.Drawing.Point(122, 13);
          this.txtProjectName.Name = "txtProjectName";
          this.txtProjectName.Size = new System.Drawing.Size(321, 20);
          this.txtProjectName.TabIndex = 0;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(38, 13);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(78, 15);
          this.label1.TabIndex = 4;
          this.label1.Text = "Project Name";
          // 
          // ckbAdvancedOptions
          // 
          this.ckbAdvancedOptions.AutoSize = true;
          this.ckbAdvancedOptions.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.ckbAdvancedOptions.Location = new System.Drawing.Point(12, 106);
          this.ckbAdvancedOptions.Name = "ckbAdvancedOptions";
          this.ckbAdvancedOptions.Size = new System.Drawing.Size(125, 19);
          this.ckbAdvancedOptions.TabIndex = 4;
          this.ckbAdvancedOptions.Text = "Advanced Settings";
          this.ckbAdvancedOptions.UseVisualStyleBackColor = true;
          this.ckbAdvancedOptions.CheckedChanged += new System.EventHandler(this.ckbAdvancedOptions_CheckedChanged);
          // 
          // lblCmd
          // 
          this.lblCmd.AutoSize = true;
          this.lblCmd.Enabled = false;
          this.lblCmd.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblCmd.Location = new System.Drawing.Point(9, 214);
          this.lblCmd.Name = "lblCmd";
          this.lblCmd.Size = new System.Drawing.Size(147, 15);
          this.lblCmd.TabIndex = 17;
          this.lblCmd.Text = "Command Line Argument";
          // 
          // ckbInterrupt
          // 
          this.ckbInterrupt.AutoSize = true;
          this.ckbInterrupt.Checked = true;
          this.ckbInterrupt.CheckState = System.Windows.Forms.CheckState.Checked;
          this.ckbInterrupt.Enabled = false;
          this.ckbInterrupt.Location = new System.Drawing.Point(162, 190);
          this.ckbInterrupt.Name = "ckbInterrupt";
          this.ckbInterrupt.Size = new System.Drawing.Size(15, 14);
          this.ckbInterrupt.TabIndex = 7;
          this.ckbInterrupt.UseVisualStyleBackColor = true;
          // 
          // txtCommandLine
          // 
          this.txtCommandLine.Enabled = false;
          this.txtCommandLine.Location = new System.Drawing.Point(162, 212);
          this.txtCommandLine.Name = "txtCommandLine";
          this.txtCommandLine.Size = new System.Drawing.Size(273, 20);
          this.txtCommandLine.TabIndex = 8;
          // 
          // lblProxyName
          // 
          this.lblProxyName.AutoSize = true;
          this.lblProxyName.Enabled = false;
          this.lblProxyName.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblProxyName.Location = new System.Drawing.Point(9, 136);
          this.lblProxyName.Name = "lblProxyName";
          this.lblProxyName.Size = new System.Drawing.Size(100, 15);
          this.lblProxyName.TabIndex = 20;
          this.lblProxyName.Text = "Proxy User Name";
          // 
          // txtProxyUser
          // 
          this.txtProxyUser.Enabled = false;
          this.txtProxyUser.Location = new System.Drawing.Point(115, 131);
          this.txtProxyUser.Name = "txtProxyUser";
          this.txtProxyUser.Size = new System.Drawing.Size(321, 20);
          this.txtProxyUser.TabIndex = 5;
          // 
          // txtAddFile
          // 
          this.txtAddFile.Location = new System.Drawing.Point(122, 39);
          this.txtAddFile.Name = "txtAddFile";
          this.txtAddFile.Size = new System.Drawing.Size(321, 20);
          this.txtAddFile.TabIndex = 2;
          // 
          // btnAddFolder
          // 
          this.btnAddFolder.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnAddFolder.Location = new System.Drawing.Point(12, 37);
          this.btnAddFolder.Name = "btnAddFolder";
          this.btnAddFolder.Size = new System.Drawing.Size(104, 23);
          this.btnAddFolder.TabIndex = 1;
          this.btnAddFolder.Text = "Add Source";
          this.btnAddFolder.UseVisualStyleBackColor = true;
          this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
          // 
          // lblProxyPass
          // 
          this.lblProxyPass.AutoSize = true;
          this.lblProxyPass.Enabled = false;
          this.lblProxyPass.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblProxyPass.Location = new System.Drawing.Point(9, 162);
          this.lblProxyPass.Name = "lblProxyPass";
          this.lblProxyPass.Size = new System.Drawing.Size(92, 15);
          this.lblProxyPass.TabIndex = 24;
          this.lblProxyPass.Text = "Proxy Password";
          // 
          // txtProxyPass
          // 
          this.txtProxyPass.Enabled = false;
          this.txtProxyPass.Location = new System.Drawing.Point(115, 157);
          this.txtProxyPass.Name = "txtProxyPass";
          this.txtProxyPass.PasswordChar = '*';
          this.txtProxyPass.Size = new System.Drawing.Size(321, 20);
          this.txtProxyPass.TabIndex = 6;
          // 
          // ckbInstall
          // 
          this.ckbInstall.AutoSize = true;
          this.ckbInstall.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.ckbInstall.Location = new System.Drawing.Point(12, 81);
          this.ckbInstall.Name = "ckbInstall";
          this.ckbInstall.Size = new System.Drawing.Size(247, 19);
          this.ckbInstall.TabIndex = 3;
          this.ckbInstall.Text = "Automatically Install Update After Upload";
          this.ckbInstall.UseVisualStyleBackColor = true;
          // 
          // lblContinue
          // 
          this.lblContinue.AutoSize = true;
          this.lblContinue.Enabled = false;
          this.lblContinue.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblContinue.Location = new System.Drawing.Point(9, 189);
          this.lblContinue.Name = "lblContinue";
          this.lblContinue.Size = new System.Drawing.Size(137, 15);
          this.lblContinue.TabIndex = 15;
          this.lblContinue.Text = "Continue After Interrupt";
          // 
          // frmProjectSettings
          // 
          this.AcceptButton = this.btnOK;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size(450, 283);
          this.Controls.Add(this.ckbInstall);
          this.Controls.Add(this.lblProxyPass);
          this.Controls.Add(this.txtProxyPass);
          this.Controls.Add(this.txtAddFile);
          this.Controls.Add(this.btnAddFolder);
          this.Controls.Add(this.lblProxyName);
          this.Controls.Add(this.txtProxyUser);
          this.Controls.Add(this.txtCommandLine);
          this.Controls.Add(this.ckbInterrupt);
          this.Controls.Add(this.lblCmd);
          this.Controls.Add(this.lblContinue);
          this.Controls.Add(this.ckbAdvancedOptions);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.txtProjectName);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOK);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.Name = "frmProjectSettings";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "New Project";
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbAdvancedOptions;
        private System.Windows.Forms.Label lblCmd;
        private System.Windows.Forms.CheckBox ckbInterrupt;
        private System.Windows.Forms.TextBox txtCommandLine;
        private System.Windows.Forms.Label lblProxyName;
        private System.Windows.Forms.TextBox txtProxyUser;
        private System.Windows.Forms.TextBox txtAddFile;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Label lblProxyPass;
        private System.Windows.Forms.TextBox txtProxyPass;
        private System.Windows.Forms.CheckBox ckbInstall;
        private System.Windows.Forms.Label lblContinue;

    }
}