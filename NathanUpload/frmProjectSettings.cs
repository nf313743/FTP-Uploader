using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NathanUpload
{
  ///
  /// <summary>
  /// This form allows the user to specify the project's settings:
  ///   Project name
  ///   Folder to upload
  ///   Continue after interrupt
  ///   Number of upload retries
  ///   Upload rate
  ///   Custom command line argument
  /// </summary>
  public partial class frmProjectSettings : Form
  {
    private List<string> _lstProNames;          //Used to test if project name already exists
    private ProjectSettings _proSettings;    //Seetings used by the project
    private string _strOldName;        //This is used so an edited project can keep it's oringinal name, and not think that it is already in use

    ///
    /// <summary>
    /// Used for creating a new project.
    /// Sets project values to default.
    /// </summary>
    /// <param name="lstProNames">Project names already in use</param>
    public frmProjectSettings(List<string> lstProNames)
    {
      this.Text = "New Project";
      _lstProNames = lstProNames;
      InitializeComponent();
      _proSettings = new ProjectSettings();
      _proSettings.InstallUpdate = false;
      _proSettings.AdvancedEnabled = false;
      _proSettings.Interrupt = true;              //True - Continue upload from previous
      _proSettings.CommandLine = "";
    }

    ///
    /// <summary>
    /// Used for editing an existing project.
    /// Sets project values to the current settings
    /// </summary>
    /// <param name="lstProNames">Project names already in use</param>
    /// <param name="_proSettings">Projects old/current settigns</param>
    public frmProjectSettings(List<string> lstProNames, ProjectSettings proSettings)
    {
      _proSettings = new ProjectSettings();
      _lstProNames = lstProNames;
      InitializeComponent();
      _strOldName = proSettings.ProjectName;

      //Add text to component's fields
      Text = proSettings.ProjectName;
      txtProjectName.Text = proSettings.ProjectName;
      txtProjectName.Text = proSettings.ProjectName;
      txtAddFile.Text = proSettings.SourcePath;
      ckbInstall.Checked = proSettings.InstallUpdate;
      ckbAdvancedOptions.Checked = proSettings.AdvancedEnabled;
      txtProxyUser.Text = proSettings.ProxyName;
      txtProxyPass.Text = proSettings.ProxyPass;
      ckbInterrupt.Checked = proSettings.Interrupt;
      txtCommandLine.Text = proSettings.CommandLine;
    }

    ///
    /// <summary>
    /// Returns the project settings
    /// </summary>
    /// <returns>Project settings</returns>
    public ProjectSettings getSettings()
    {
      return _proSettings;
    }

    ///
    /// <summary>
    /// Adds upload folder.
    /// </summary>
    private void addFolder()
    {
      FolderBrowserDialog fBDialog = new FolderBrowserDialog();

      if((fBDialog.ShowDialog() == DialogResult.OK) && (fBDialog.SelectedPath != ""))
      {
        this._proSettings.SourcePath = fBDialog.SelectedPath;
        this.txtAddFile.Text = fBDialog.SelectedPath;
      }
    }

    ///
    /// <summary>
    /// Assigns user selected values to project settings, and sets DialogResult to OK.
    /// </summary>
    private void assignSettings()
    {
      if(checkSettings() != true)
      {
        return;
      }

      this._proSettings.ProjectName = this.txtProjectName.Text;
      this._proSettings.SourcePath = this.txtAddFile.Text;
      this._proSettings.InstallUpdate = this.ckbInstall.Checked;

      if(_proSettings.InstallUpdate == true)
      {
        DialogResult result = MessageBox.Show("Are you sure you want to install the update after it has been uploaded?"
                                              + "\nThe target machine will restart once the installation is complete."
                                              , "Install After Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if(result == DialogResult.No)
        {
          return;
        }
      }

      if(this.ckbAdvancedOptions.Checked == true)
      {
        _proSettings.AdvancedEnabled = true;
        _proSettings.ProxyName = this.txtProxyUser.Text;
        _proSettings.ProxyPass = this.txtProxyPass.Text;
        _proSettings.Interrupt = this.ckbInterrupt.Checked;
        _proSettings.CommandLine = this.txtCommandLine.Text;
      }
      this.DialogResult = DialogResult.OK;                            //Everything has been validated and accepted.
    }

    ///
    /// <summary>
    /// Toggles display between advanced and non-advanced options.
    /// Called whenever the check box changes.
    /// </summary>
    private void checkAdvancedOptions()
    {
      if(ckbAdvancedOptions.Checked == true)
      {
        this.txtProxyUser.Enabled = true; this.lblProxyName.Enabled = true;
        this.txtProxyPass.Enabled = true; this.lblProxyPass.Enabled = true;
        this.ckbInterrupt.Enabled = true; this.lblContinue.Enabled = true;
        this.txtCommandLine.Enabled = true; this.lblCmd.Enabled = true;
      }
      else if(ckbAdvancedOptions.Checked == false)
      {
        this.txtProxyUser.Enabled = false; this.lblProxyName.Enabled = false;
        this.txtProxyPass.Enabled = false; this.lblProxyPass.Enabled = false;
        this.ckbInterrupt.Enabled = false; this.lblContinue.Enabled = false;
        this.txtCommandLine.Enabled = false; this.lblCmd.Enabled = false;
      }
    }
 
    ///
    /// <summary>
    /// Checks if project name has been entered, and whether it already exists.
    /// Also checks if an upload folder has been selected.
    /// </summary>
    private bool checkSettings()
    {
      if(this.txtProjectName.Text == "")
      {
        MessageBox.Show("No project name has been entered", "No Project Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      else if(_lstProNames.Contains(txtProjectName.Text) && (txtProjectName.Text != _strOldName))
      {
        MessageBox.Show("A project with the same name is already in use.  Please choose another", "Project Name Already In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      else if(this.txtAddFile.Text == "")
      {
        MessageBox.Show("No folder has been selected", "No Folder Selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
      }
      return true;
    }

    #region Events
    private void btnAddFolder_Click(object sender, EventArgs e)
    {
      addFolder();
    }
    
    private void btnOK_Click(object sender, EventArgs e)
    {
      assignSettings();
    }
    
    private void ckbAdvancedOptions_CheckedChanged(object sender, EventArgs e)
    {
      checkAdvancedOptions();
    }
    #endregion
  }
}
