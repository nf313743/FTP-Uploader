using System.Windows.Forms;
using System.Drawing;
using System;
namespace NathanUpload
{
    partial class cTabPage
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
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          this.components = new System.ComponentModel.Container();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cTabPage));
          this.targetList = new NathanUpload.ListViewEx();
          this.colTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colProgress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.colMaxSpeed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
          this.targetListMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
          this.addTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.removeTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.editTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.startTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.stopTargetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.splitContainer1 = new System.Windows.Forms.SplitContainer();
          this.txtInstall = new System.Windows.Forms.TextBox();
          this.lblInstall = new System.Windows.Forms.Label();
          this.lblProxyName = new System.Windows.Forms.Label();
          this.txtProxyName = new System.Windows.Forms.TextBox();
          this.txtArgument = new System.Windows.Forms.TextBox();
          this.txtInterrupt = new System.Windows.Forms.TextBox();
          this.txtSource = new System.Windows.Forms.TextBox();
          this.txtProName = new System.Windows.Forms.TextBox();
          this.lblArgument = new System.Windows.Forms.Label();
          this.lblInterrupt = new System.Windows.Forms.Label();
          this.lblFolder = new System.Windows.Forms.Label();
          this.lblProName = new System.Windows.Forms.Label();
          this.targetListMenu.SuspendLayout();
          this.splitContainer1.Panel1.SuspendLayout();
          this.splitContainer1.Panel2.SuspendLayout();
          this.splitContainer1.SuspendLayout();
          this.SuspendLayout();
          // 
          // targetList
          // 
          this.targetList.AllowColumnReorder = true;
          this.targetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTarget,
            this.colProgress,
            this.colPercent,
            this.colStatus,
            this.colSpeed,
            this.colDestination,
            this.colMaxSpeed});
          this.targetList.ContextMenuStrip = this.targetListMenu;
          this.targetList.Dock = System.Windows.Forms.DockStyle.Fill;
          this.targetList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.targetList.FullRowSelect = true;
          this.targetList.GridLines = true;
          this.targetList.HideSelection = false;
          this.targetList.Location = new System.Drawing.Point(0, 0);
          this.targetList.MultiSelect = false;
          this.targetList.Name = "targetList";
          this.targetList.Size = new System.Drawing.Size(966, 456);
          this.targetList.TabIndex = 0;
          this.targetList.UseCompatibleStateImageBehavior = false;
          this.targetList.View = System.Windows.Forms.View.Details;
          this.targetList.SelectedIndexChanged += new System.EventHandler(this.targetList_SelectedIndexChanged);
          this.targetList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.targetList_MouseClick);
          // 
          // colTarget
          // 
          this.colTarget.Text = "Target Server";
          this.colTarget.Width = 151;
          // 
          // colProgress
          // 
          this.colProgress.Text = "Progress";
          this.colProgress.Width = 286;
          // 
          // colPercent
          // 
          this.colPercent.Text = "%";
          // 
          // colStatus
          // 
          this.colStatus.Text = "Status";
          this.colStatus.Width = 177;
          // 
          // colSpeed
          // 
          this.colSpeed.Text = "Speed";
          this.colSpeed.Width = 76;
          // 
          // colDestination
          // 
          this.colDestination.Text = "Destination Folder";
          this.colDestination.Width = 350;
          // 
          // colMaxSpeed
          // 
          this.colMaxSpeed.Text = "Maximum Speed";
          this.colMaxSpeed.Width = 130;
          // 
          // targetListMenu
          // 
          this.targetListMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTargetToolStripMenuItem,
            this.removeTargetToolStripMenuItem,
            this.editTargetToolStripMenuItem,
            this.startTargetToolStripMenuItem,
            this.stopTargetToolStripMenuItem});
          this.targetListMenu.Name = "targetListMenu";
          this.targetListMenu.Size = new System.Drawing.Size(160, 114);
          this.targetListMenu.Opening += new System.ComponentModel.CancelEventHandler(this.targetListMenu_Opening);
          // 
          // addTargetToolStripMenuItem
          // 
          this.addTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addTargetToolStripMenuItem.Image")));
          this.addTargetToolStripMenuItem.Name = "addTargetToolStripMenuItem";
          this.addTargetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
          this.addTargetToolStripMenuItem.Text = "Add Target";
          this.addTargetToolStripMenuItem.Click += new System.EventHandler(this.addTargetToolStripMenuItem_Click);
          // 
          // removeTargetToolStripMenuItem
          // 
          this.removeTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removeTargetToolStripMenuItem.Image")));
          this.removeTargetToolStripMenuItem.Name = "removeTargetToolStripMenuItem";
          this.removeTargetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
          this.removeTargetToolStripMenuItem.Text = "Remove Target";
          this.removeTargetToolStripMenuItem.Click += new System.EventHandler(this.removeTargetToolStripMenuItem_Click);
          // 
          // editTargetToolStripMenuItem
          // 
          this.editTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editTargetToolStripMenuItem.Image")));
          this.editTargetToolStripMenuItem.Name = "editTargetToolStripMenuItem";
          this.editTargetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
          this.editTargetToolStripMenuItem.Text = "Edit Target";
          this.editTargetToolStripMenuItem.Click += new System.EventHandler(this.editTargetToolStripMenuItem_Click);
          // 
          // startTargetToolStripMenuItem
          // 
          this.startTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("startTargetToolStripMenuItem.Image")));
          this.startTargetToolStripMenuItem.Name = "startTargetToolStripMenuItem";
          this.startTargetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
          this.startTargetToolStripMenuItem.Text = "Start Target";
          this.startTargetToolStripMenuItem.Click += new System.EventHandler(this.startTargetToolStripMenuItem_Click);
          // 
          // stopTargetToolStripMenuItem
          // 
          this.stopTargetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("stopTargetToolStripMenuItem.Image")));
          this.stopTargetToolStripMenuItem.Name = "stopTargetToolStripMenuItem";
          this.stopTargetToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
          this.stopTargetToolStripMenuItem.Text = "Stop Target";
          this.stopTargetToolStripMenuItem.Click += new System.EventHandler(this.stopTargetToolStripMenuItem_Click);
          // 
          // splitContainer1
          // 
          this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
          this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
          this.splitContainer1.IsSplitterFixed = true;
          this.splitContainer1.Location = new System.Drawing.Point(0, 0);
          this.splitContainer1.Name = "splitContainer1";
          this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
          // 
          // splitContainer1.Panel1
          // 
          this.splitContainer1.Panel1.Controls.Add(this.txtInstall);
          this.splitContainer1.Panel1.Controls.Add(this.lblInstall);
          this.splitContainer1.Panel1.Controls.Add(this.lblProxyName);
          this.splitContainer1.Panel1.Controls.Add(this.txtProxyName);
          this.splitContainer1.Panel1.Controls.Add(this.txtArgument);
          this.splitContainer1.Panel1.Controls.Add(this.txtInterrupt);
          this.splitContainer1.Panel1.Controls.Add(this.txtSource);
          this.splitContainer1.Panel1.Controls.Add(this.txtProName);
          this.splitContainer1.Panel1.Controls.Add(this.lblArgument);
          this.splitContainer1.Panel1.Controls.Add(this.lblInterrupt);
          this.splitContainer1.Panel1.Controls.Add(this.lblFolder);
          this.splitContainer1.Panel1.Controls.Add(this.lblProName);
          // 
          // splitContainer1.Panel2
          // 
          this.splitContainer1.Panel2.Controls.Add(this.targetList);
          this.splitContainer1.Size = new System.Drawing.Size(966, 590);
          this.splitContainer1.SplitterDistance = 130;
          this.splitContainer1.TabIndex = 1;
          // 
          // txtInstall
          // 
          this.txtInstall.BackColor = System.Drawing.SystemColors.Window;
          this.txtInstall.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtInstall.Location = new System.Drawing.Point(639, 11);
          this.txtInstall.Name = "txtInstall";
          this.txtInstall.ReadOnly = true;
          this.txtInstall.Size = new System.Drawing.Size(30, 22);
          this.txtInstall.TabIndex = 28;
          // 
          // lblInstall
          // 
          this.lblInstall.AutoSize = true;
          this.lblInstall.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblInstall.Location = new System.Drawing.Point(498, 14);
          this.lblInstall.Name = "lblInstall";
          this.lblInstall.Size = new System.Drawing.Size(135, 14);
          this.lblInstall.TabIndex = 27;
          this.lblInstall.Text = "Install After Update:";
          // 
          // lblProxyName
          // 
          this.lblProxyName.AutoSize = true;
          this.lblProxyName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblProxyName.Location = new System.Drawing.Point(11, 70);
          this.lblProxyName.Name = "lblProxyName";
          this.lblProxyName.Size = new System.Drawing.Size(115, 14);
          this.lblProxyName.TabIndex = 26;
          this.lblProxyName.Text = "Proxy Username:";
          this.lblProxyName.Visible = false;
          // 
          // txtProxyName
          // 
          this.txtProxyName.BackColor = System.Drawing.SystemColors.Window;
          this.txtProxyName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtProxyName.Location = new System.Drawing.Point(131, 67);
          this.txtProxyName.Name = "txtProxyName";
          this.txtProxyName.ReadOnly = true;
          this.txtProxyName.Size = new System.Drawing.Size(290, 22);
          this.txtProxyName.TabIndex = 24;
          this.txtProxyName.Visible = false;
          // 
          // txtArgument
          // 
          this.txtArgument.BackColor = System.Drawing.SystemColors.Window;
          this.txtArgument.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtArgument.Location = new System.Drawing.Point(639, 67);
          this.txtArgument.Name = "txtArgument";
          this.txtArgument.ReadOnly = true;
          this.txtArgument.Size = new System.Drawing.Size(290, 22);
          this.txtArgument.TabIndex = 23;
          this.txtArgument.Visible = false;
          // 
          // txtInterrupt
          // 
          this.txtInterrupt.BackColor = System.Drawing.SystemColors.Window;
          this.txtInterrupt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtInterrupt.Location = new System.Drawing.Point(639, 39);
          this.txtInterrupt.Name = "txtInterrupt";
          this.txtInterrupt.ReadOnly = true;
          this.txtInterrupt.Size = new System.Drawing.Size(30, 22);
          this.txtInterrupt.TabIndex = 22;
          this.txtInterrupt.Visible = false;
          // 
          // txtSource
          // 
          this.txtSource.BackColor = System.Drawing.SystemColors.Window;
          this.txtSource.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtSource.Location = new System.Drawing.Point(131, 39);
          this.txtSource.Name = "txtSource";
          this.txtSource.ReadOnly = true;
          this.txtSource.Size = new System.Drawing.Size(290, 22);
          this.txtSource.TabIndex = 19;
          // 
          // txtProName
          // 
          this.txtProName.BackColor = System.Drawing.SystemColors.Window;
          this.txtProName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.txtProName.Location = new System.Drawing.Point(131, 11);
          this.txtProName.Name = "txtProName";
          this.txtProName.ReadOnly = true;
          this.txtProName.Size = new System.Drawing.Size(290, 22);
          this.txtProName.TabIndex = 18;
          // 
          // lblArgument
          // 
          this.lblArgument.AutoSize = true;
          this.lblArgument.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblArgument.Location = new System.Drawing.Point(463, 70);
          this.lblArgument.Name = "lblArgument";
          this.lblArgument.Size = new System.Drawing.Size(170, 14);
          this.lblArgument.TabIndex = 17;
          this.lblArgument.Text = "Command Line Argument:";
          this.lblArgument.Visible = false;
          // 
          // lblInterrupt
          // 
          this.lblInterrupt.AutoSize = true;
          this.lblInterrupt.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblInterrupt.Location = new System.Drawing.Point(469, 42);
          this.lblInterrupt.Name = "lblInterrupt";
          this.lblInterrupt.Size = new System.Drawing.Size(164, 14);
          this.lblInterrupt.TabIndex = 15;
          this.lblInterrupt.Text = "Continue After Interrupt:";
          this.lblInterrupt.Visible = false;
          // 
          // lblFolder
          // 
          this.lblFolder.AutoSize = true;
          this.lblFolder.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblFolder.Location = new System.Drawing.Point(27, 42);
          this.lblFolder.Name = "lblFolder";
          this.lblFolder.Size = new System.Drawing.Size(98, 14);
          this.lblFolder.TabIndex = 13;
          this.lblFolder.Text = "Source Folder:";
          // 
          // lblProName
          // 
          this.lblProName.AutoSize = true;
          this.lblProName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblProName.Location = new System.Drawing.Point(33, 14);
          this.lblProName.Name = "lblProName";
          this.lblProName.Size = new System.Drawing.Size(96, 14);
          this.lblProName.TabIndex = 12;
          this.lblProName.Text = "Project Name:";
          // 
          // cTabPage
          // 
          this.Controls.Add(this.splitContainer1);
          this.Name = "cTabPage";
          this.Size = new System.Drawing.Size(966, 590);
          this.targetListMenu.ResumeLayout(false);
          this.splitContainer1.Panel1.ResumeLayout(false);
          this.splitContainer1.Panel1.PerformLayout();
          this.splitContainer1.Panel2.ResumeLayout(false);
          this.splitContainer1.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        private ListViewEx targetList;
        private System.Windows.Forms.ColumnHeader colTarget;
        private System.Windows.Forms.ColumnHeader colProgress;
        private System.Windows.Forms.ColumnHeader colDestination;
        #endregion
        private SplitContainer splitContainer1;
        private TextBox txtArgument;
        private TextBox txtInterrupt;
        private TextBox txtSource;
        private TextBox txtProName;
        private Label lblArgument;
        private Label lblInterrupt;
        private Label lblFolder;
        private Label lblProName;
        private ContextMenuStrip targetListMenu;
        private ToolStripMenuItem removeTargetToolStripMenuItem;
        private ToolStripMenuItem addTargetToolStripMenuItem;
        private ColumnHeader colStatus;
        private ToolStripMenuItem stopTargetToolStripMenuItem;
        private ToolStripMenuItem startTargetToolStripMenuItem;
        private ColumnHeader colSpeed;
        private ColumnHeader colMaxSpeed;
        private Label lblProxyName;
        private TextBox txtProxyName;
        private ColumnHeader colPercent;
        private TextBox txtInstall;
        private Label lblInstall;
        private ToolStripMenuItem editTargetToolStripMenuItem;
    }
}
