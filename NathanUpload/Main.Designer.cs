namespace NathanUpload
{
    partial class Main
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
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
          this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
          this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.mainMenuStripNewProject = new System.Windows.Forms.ToolStripMenuItem();
          this.mainMenuStripOpenProject = new System.Windows.Forms.ToolStripMenuItem();
          this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.importIPsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.exportIPsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.exittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.editProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
          this.addTargetToProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.editSelectedTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.mainTabControl = new System.Windows.Forms.TabControl();
          this.contextMenuTabContol = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.btnConnections = new System.Windows.Forms.Button();
          this.btnEdit = new System.Windows.Forms.Button();
          this.btnStop = new System.Windows.Forms.Button();
          this.btnStart = new System.Windows.Forms.Button();
          this.mainMenuStrip.SuspendLayout();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.contextMenuTabContol.SuspendLayout();
          this.SuspendLayout();
          // 
          // mainMenuStrip
          // 
          this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
          this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
          this.mainMenuStrip.Name = "mainMenuStrip";
          this.mainMenuStrip.Size = new System.Drawing.Size(1028, 24);
          this.mainMenuStrip.TabIndex = 0;
          this.mainMenuStrip.Text = "menuStrip1";
          // 
          // newToolStripMenuItem
          // 
          this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuStripNewProject,
            this.mainMenuStripOpenProject,
            this.saveProjectToolStripMenuItem,
            this.importExportToolStripMenuItem,
            this.closeProjectToolStripMenuItem,
            this.exittToolStripMenuItem});
          this.newToolStripMenuItem.Name = "newToolStripMenuItem";
          this.newToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
          this.newToolStripMenuItem.Text = "&File";
          // 
          // mainMenuStripNewProject
          // 
          this.mainMenuStripNewProject.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuStripNewProject.Image")));
          this.mainMenuStripNewProject.Name = "mainMenuStripNewProject";
          this.mainMenuStripNewProject.Size = new System.Drawing.Size(153, 22);
          this.mainMenuStripNewProject.Text = "&New Project";
          this.mainMenuStripNewProject.Click += new System.EventHandler(this.mainMenuStripNewProject_Click);
          // 
          // mainMenuStripOpenProject
          // 
          this.mainMenuStripOpenProject.Image = ((System.Drawing.Image)(resources.GetObject("mainMenuStripOpenProject.Image")));
          this.mainMenuStripOpenProject.Name = "mainMenuStripOpenProject";
          this.mainMenuStripOpenProject.Size = new System.Drawing.Size(153, 22);
          this.mainMenuStripOpenProject.Text = "&Open Project";
          this.mainMenuStripOpenProject.Click += new System.EventHandler(this.mainMenuStripOpenProject_Click);
          // 
          // saveProjectToolStripMenuItem
          // 
          this.saveProjectToolStripMenuItem.Enabled = false;
          this.saveProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectToolStripMenuItem.Image")));
          this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
          this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
          this.saveProjectToolStripMenuItem.Text = "&Save Project";
          this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.saveProjectToolStripMenuItem_Click);
          // 
          // importExportToolStripMenuItem
          // 
          this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importIPsToolStripMenuItem1,
            this.exportIPsToolStripMenuItem});
          this.importExportToolStripMenuItem.Enabled = false;
          this.importExportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importExportToolStripMenuItem.Image")));
          this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
          this.importExportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
          this.importExportToolStripMenuItem.Text = "Import/Export";
          // 
          // importIPsToolStripMenuItem1
          // 
          this.importIPsToolStripMenuItem1.Name = "importIPsToolStripMenuItem1";
          this.importIPsToolStripMenuItem1.Size = new System.Drawing.Size(135, 22);
          this.importIPsToolStripMenuItem1.Text = "Import IPs";
          this.importIPsToolStripMenuItem1.Click += new System.EventHandler(this.importIPsToolStripMenuItem1_Click);
          // 
          // exportIPsToolStripMenuItem
          // 
          this.exportIPsToolStripMenuItem.Name = "exportIPsToolStripMenuItem";
          this.exportIPsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
          this.exportIPsToolStripMenuItem.Text = "Export IPs";
          this.exportIPsToolStripMenuItem.Click += new System.EventHandler(this.exportIPsToolStripMenuItem_Click);
          // 
          // closeProjectToolStripMenuItem
          // 
          this.closeProjectToolStripMenuItem.Enabled = false;
          this.closeProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeProjectToolStripMenuItem.Image")));
          this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
          this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
          this.closeProjectToolStripMenuItem.Text = "&Close Project";
          this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.closeProjectToolStripMenuItem_Click);
          // 
          // exittToolStripMenuItem
          // 
          this.exittToolStripMenuItem.Name = "exittToolStripMenuItem";
          this.exittToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
          this.exittToolStripMenuItem.Text = "E&xit";
          this.exittToolStripMenuItem.Click += new System.EventHandler(this.exittToolStripMenuItem_Click);
          // 
          // editToolStripMenuItem
          // 
          this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editProjectToolStripMenuItem1,
            this.addTargetToProjectToolStripMenuItem,
            this.editSelectedTargetToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
          this.editToolStripMenuItem.Name = "editToolStripMenuItem";
          this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
          this.editToolStripMenuItem.Text = "Edit";
          // 
          // editProjectToolStripMenuItem1
          // 
          this.editProjectToolStripMenuItem1.Enabled = false;
          this.editProjectToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("editProjectToolStripMenuItem1.Image")));
          this.editProjectToolStripMenuItem1.Name = "editProjectToolStripMenuItem1";
          this.editProjectToolStripMenuItem1.Size = new System.Drawing.Size(203, 22);
          this.editProjectToolStripMenuItem1.Text = "Edit Project";
          this.editProjectToolStripMenuItem1.Click += new System.EventHandler(this.editProjectToolStripMenuItem1_Click);
          // 
          // addTargetToProjectToolStripMenuItem
          // 
          this.addTargetToProjectToolStripMenuItem.Enabled = false;
          this.addTargetToProjectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTargetToProjectToolStripMenuItem.Image")));
          this.addTargetToProjectToolStripMenuItem.Name = "addTargetToProjectToolStripMenuItem";
          this.addTargetToProjectToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
          this.addTargetToProjectToolStripMenuItem.Text = "Add Target";
          this.addTargetToProjectToolStripMenuItem.Click += new System.EventHandler(this.addTargetToProjectToolStripMenuItem_Click);
          // 
          // editSelectedTargetToolStripMenuItem
          // 
          this.editSelectedTargetToolStripMenuItem.Enabled = false;
          this.editSelectedTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editSelectedTargetToolStripMenuItem.Image")));
          this.editSelectedTargetToolStripMenuItem.Name = "editSelectedTargetToolStripMenuItem";
          this.editSelectedTargetToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
          this.editSelectedTargetToolStripMenuItem.Text = "Edit Selected Target";
          this.editSelectedTargetToolStripMenuItem.Click += new System.EventHandler(this.editSelectedTargetToolStripMenuItem_Click);
          // 
          // deleteSelectedToolStripMenuItem
          // 
          this.deleteSelectedToolStripMenuItem.Enabled = false;
          this.deleteSelectedToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteSelectedToolStripMenuItem.Image")));
          this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
          this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
          this.deleteSelectedToolStripMenuItem.Text = "Remove Selected Target";
          this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
          this.helpToolStripMenuItem.Text = "&Help";
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
          this.aboutToolStripMenuItem.Text = "About";
          this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
          // 
          // splitContainer1
          // 
          this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
          this.splitContainer1.Location = new System.Drawing.Point(0, 24);
          this.splitContainer1.Name = "splitContainer1";
          this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.mainTabControl);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.btnConnections);
          this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
          this.splitContainer1.Panel2.Controls.Add(this.btnStop);
          this.splitContainer1.Panel2.Controls.Add(this.btnStart);
          this.splitContainer1.Size = new System.Drawing.Size(1028, 526);
          this.splitContainer1.SplitterDistance = 480;
          this.splitContainer1.SplitterWidth = 1;
          this.splitContainer1.TabIndex = 2;
          // 
          // mainTabControl
          // 
          this.mainTabControl.ContextMenuStrip = this.contextMenuTabContol;
          this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
          this.mainTabControl.Location = new System.Drawing.Point(0, 0);
          this.mainTabControl.Name = "mainTabControl";
          this.mainTabControl.SelectedIndex = 0;
          this.mainTabControl.Size = new System.Drawing.Size(1026, 478);
          this.mainTabControl.TabIndex = 1;
          this.mainTabControl.Visible = false;
          this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged_1);
          this.mainTabControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mainTabControl_MouseDown_1);
          // 
          // contextMenuTabContol
          // 
          this.contextMenuTabContol.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
          this.contextMenuTabContol.Name = "contextMenuTabContol";
          this.contextMenuTabContol.Size = new System.Drawing.Size(112, 26);
          // 
          // closeToolStripMenuItem
          // 
          this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
          this.closeToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
          this.closeToolStripMenuItem.Text = "Close";
          this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
          // 
          // btnConnections
          // 
          this.btnConnections.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
          this.btnConnections.Enabled = false;
          this.btnConnections.Location = new System.Drawing.Point(337, 11);
          this.btnConnections.Name = "btnConnections";
          this.btnConnections.Size = new System.Drawing.Size(109, 23);
          this.btnConnections.TabIndex = 3;
          this.btnConnections.Text = "Test Connections";
          this.btnConnections.UseVisualStyleBackColor = true;
          this.btnConnections.Click += new System.EventHandler(this.btnConnections_Click);
          // 
          // btnEdit
          // 
          this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
          this.btnEdit.Enabled = false;
          this.btnEdit.Location = new System.Drawing.Point(452, 11);
          this.btnEdit.Name = "btnEdit";
          this.btnEdit.Size = new System.Drawing.Size(75, 23);
          this.btnEdit.TabIndex = 3;
          this.btnEdit.Text = "Edit Project";
          this.btnEdit.UseVisualStyleBackColor = true;
          this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
          // 
          // btnStop
          // 
          this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
          this.btnStop.Enabled = false;
          this.btnStop.Location = new System.Drawing.Point(614, 11);
          this.btnStop.Name = "btnStop";
          this.btnStop.Size = new System.Drawing.Size(75, 23);
          this.btnStop.TabIndex = 2;
          this.btnStop.Text = "Stop All";
          this.btnStop.UseVisualStyleBackColor = true;
          this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
          // 
          // btnStart
          // 
          this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
          this.btnStart.Enabled = false;
          this.btnStart.Location = new System.Drawing.Point(533, 11);
          this.btnStart.Name = "btnStart";
          this.btnStart.Size = new System.Drawing.Size(75, 23);
          this.btnStart.TabIndex = 0;
          this.btnStart.Text = "Start All";
          this.btnStart.UseVisualStyleBackColor = true;
          this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
          // 
          // Main
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.BackColor = System.Drawing.SystemColors.Control;
          this.ClientSize = new System.Drawing.Size(1028, 550);
          this.Controls.Add(this.splitContainer1);
          this.Controls.Add(this.mainMenuStrip);
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MainMenuStrip = this.mainMenuStrip;
          this.Name = "Main";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "FTP Uploader";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
          this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
          this.mainMenuStrip.ResumeLayout(false);
          this.mainMenuStrip.PerformLayout();
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          this.contextMenuTabContol.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuStripNewProject;
        private System.Windows.Forms.ToolStripMenuItem mainMenuStripOpenProject;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTargetToProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuTabContol;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.Button btnConnections;
        private System.Windows.Forms.ToolStripMenuItem exittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importIPsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportIPsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSelectedTargetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editProjectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;        
    }
}

