using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NathanUpload
{
    public partial class TabPageControl : UserControl
    {
        Main Main;                                                              //Reference to Main form

        public TabPageControl(Main Main)
        {
            InitializeComponent();
            this.Main = Main;
        }


        #region Update Folders
        /**
         * Updates the view on screen for the files to be uploaded 
         */
        public void updateTargets(List<TargetInfo> lstTargets)
        {
            listViewUploads.Items.Clear();
            foreach(TargetInfo ta in lstTargets)
            {
                ListViewItem lviNewRow = new ListViewItem(ta.TargetServer);
                lviNewRow.SubItems.Add(ta.DestinationFolder);
                lviNewRow.SubItems.Add(ta.UserName);
                this.listViewUploads.Items.Add(lviNewRow);               
            }
        }
        #endregion


        #region Update Settings
        /**
         * Adds the project details to the ListView
         */
        public void updateSettings(ProjectSettings proSettings)
        {
           
        }
        #endregion


        #region Add Target
        private void toolStripMenuItemAdd_Click(object sender, EventArgs e)
        {
            Main.addFolderToProjectToolStripMenuItem_Click(this, null); 
        }
        #endregion



        #region Remove Target
        public void toolStripMenuItemRemove_Click(object sender, EventArgs e)
        {
            if(listViewUploads.SelectedItems.Count > 0)                                     //Checks if and item exists
            {
                string strFolderPath = listViewUploads.SelectedItems[0].SubItems[1].Text;   //Folder path
                listViewUploads.Items.Remove(listViewUploads.SelectedItems[0]);             //Remove item from list
                Main.removeFolder(this.Name, strFolderPath);
            }
        }
        #endregion

    }
}
