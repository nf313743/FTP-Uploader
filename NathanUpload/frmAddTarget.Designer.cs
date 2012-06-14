namespace NathanUpload
{
    partial class frmAddTarget
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
          this.btnOk = new System.Windows.Forms.Button();
          this.btnCancel = new System.Windows.Forms.Button();
          this.txtTargetServer = new System.Windows.Forms.TextBox();
          this.label1 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.txtUserName = new System.Windows.Forms.TextBox();
          this.label5 = new System.Windows.Forms.Label();
          this.txtPassword = new System.Windows.Forms.TextBox();
          this.label7 = new System.Windows.Forms.Label();
          this.txtDestPath = new System.Windows.Forms.TextBox();
          this.lblMax = new System.Windows.Forms.Label();
          this.numUploadRate = new System.Windows.Forms.NumericUpDown();
          this.lblUpload = new System.Windows.Forms.Label();
          this.label2 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.txtRootPath = new System.Windows.Forms.TextBox();
          this.txtCommunity = new System.Windows.Forms.TextBox();
          ((System.ComponentModel.ISupportInitialize)(this.numUploadRate)).BeginInit();
          this.SuspendLayout();
          // 
          // btnOk
          // 
          this.btnOk.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnOk.Location = new System.Drawing.Point(263, 199);
          this.btnOk.Name = "btnOk";
          this.btnOk.Size = new System.Drawing.Size(75, 23);
          this.btnOk.TabIndex = 8;
          this.btnOk.Text = "OK";
          this.btnOk.UseVisualStyleBackColor = true;
          this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
          // 
          // btnCancel
          // 
          this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this.btnCancel.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.btnCancel.Location = new System.Drawing.Point(344, 199);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(75, 23);
          this.btnCancel.TabIndex = 9;
          this.btnCancel.Text = "Cancel";
          this.btnCancel.UseVisualStyleBackColor = true;
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // txtTargetServer
          // 
          this.txtTargetServer.Location = new System.Drawing.Point(146, 12);
          this.txtTargetServer.Name = "txtTargetServer";
          this.txtTargetServer.Size = new System.Drawing.Size(262, 20);
          this.txtTargetServer.TabIndex = 1;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label1.Location = new System.Drawing.Point(48, 15);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(92, 13);
          this.label1.TabIndex = 6;
          this.label1.Text = "Target Server:";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label4.Location = new System.Drawing.Point(65, 93);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(75, 13);
          this.label4.TabIndex = 10;
          this.label4.Text = "User Name:";
          // 
          // txtUserName
          // 
          this.txtUserName.Location = new System.Drawing.Point(146, 90);
          this.txtUserName.Name = "txtUserName";
          this.txtUserName.Size = new System.Drawing.Size(262, 20);
          this.txtUserName.TabIndex = 4;
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label5.Location = new System.Drawing.Point(74, 119);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(66, 13);
          this.label5.TabIndex = 12;
          this.label5.Text = "Password:";
          // 
          // txtPassword
          // 
          this.txtPassword.Location = new System.Drawing.Point(146, 116);
          this.txtPassword.Name = "txtPassword";
          this.txtPassword.PasswordChar = '*';
          this.txtPassword.Size = new System.Drawing.Size(262, 20);
          this.txtPassword.TabIndex = 5;
          // 
          // label7
          // 
          this.label7.AutoSize = true;
          this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label7.Location = new System.Drawing.Point(4, 41);
          this.label7.Name = "label7";
          this.label7.Size = new System.Drawing.Size(129, 13);
          this.label7.TabIndex = 16;
          this.label7.Text = "FTP Destination Path:";
          // 
          // txtDestPath
          // 
          this.txtDestPath.Location = new System.Drawing.Point(146, 38);
          this.txtDestPath.Name = "txtDestPath";
          this.txtDestPath.Size = new System.Drawing.Size(262, 20);
          this.txtDestPath.TabIndex = 2;
          // 
          // lblMax
          // 
          this.lblMax.AutoSize = true;
          this.lblMax.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblMax.Location = new System.Drawing.Point(223, 170);
          this.lblMax.Name = "lblMax";
          this.lblMax.Size = new System.Drawing.Size(145, 15);
          this.lblMax.TabIndex = 21;
          this.lblMax.Text = "(KiB/s  0.0 for Maximum) ";
          // 
          // numUploadRate
          // 
          this.numUploadRate.DecimalPlaces = 1;
          this.numUploadRate.Location = new System.Drawing.Point(146, 168);
          this.numUploadRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
          this.numUploadRate.Name = "numUploadRate";
          this.numUploadRate.Size = new System.Drawing.Size(71, 20);
          this.numUploadRate.TabIndex = 7;
          this.numUploadRate.ThousandsSeparator = true;
          // 
          // lblUpload
          // 
          this.lblUpload.AutoSize = true;
          this.lblUpload.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblUpload.Location = new System.Drawing.Point(28, 170);
          this.lblUpload.Name = "lblUpload";
          this.lblUpload.Size = new System.Drawing.Size(112, 13);
          this.lblUpload.TabIndex = 20;
          this.lblUpload.Text = "Upload Rate Limit:";
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label2.Location = new System.Drawing.Point(7, 145);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(137, 13);
          this.label2.TabIndex = 23;
          this.label2.Text = "SNMP Set Community:";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.label3.Location = new System.Drawing.Point(49, 67);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(91, 13);
          this.label3.TabIndex = 25;
          this.label3.Text = "FTP Root Path:";
          // 
          // txtRootPath
          // 
          this.txtRootPath.Location = new System.Drawing.Point(146, 64);
          this.txtRootPath.Name = "txtRootPath";
          this.txtRootPath.Size = new System.Drawing.Size(262, 20);
          this.txtRootPath.TabIndex = 3;
          // 
          // txtCommunity
          // 
          this.txtCommunity.Location = new System.Drawing.Point(146, 142);
          this.txtCommunity.Name = "txtCommunity";
          this.txtCommunity.Size = new System.Drawing.Size(262, 20);
          this.txtCommunity.TabIndex = 6;
          // 
          // frmAddTarget
          // 
          this.AcceptButton = this.btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this.btnCancel;
          this.ClientSize = new System.Drawing.Size(431, 234);
          this.Controls.Add(this.txtCommunity);
          this.Controls.Add(this.label3);
          this.Controls.Add(this.txtRootPath);
          this.Controls.Add(this.label2);
          this.Controls.Add(this.lblMax);
          this.Controls.Add(this.numUploadRate);
          this.Controls.Add(this.lblUpload);
          this.Controls.Add(this.label7);
          this.Controls.Add(this.txtDestPath);
          this.Controls.Add(this.label5);
          this.Controls.Add(this.txtPassword);
          this.Controls.Add(this.label4);
          this.Controls.Add(this.txtUserName);
          this.Controls.Add(this.label1);
          this.Controls.Add(this.txtTargetServer);
          this.Controls.Add(this.btnCancel);
          this.Controls.Add(this.btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.Name = "frmAddTarget";
          this.ShowIcon = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Add Target";
          ((System.ComponentModel.ISupportInitialize)(this.numUploadRate)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTargetServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.NumericUpDown numUploadRate;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRootPath;
        private System.Windows.Forms.TextBox txtCommunity;
    }
}