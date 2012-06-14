using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace NathanUpload
{
  /// <summary>
  /// A form that allows a user to add a target IP address to the project.  Also can edit existing targets using this form.
  /// Specifying Target IP, destination path, username, password and port number.
  /// </summary>
  public partial class frmAddTarget : Form
  {

    private TargetSettings _tSettings;            //Upload's target settings
    private List<TargetSettings> _lstCurTargets;  //List of all the other settings currently in the project.  Used for duplicate IP check.
    private string _oldIP;                        //Old IP address of edited target

    ///
    /// <summary>
    /// Target constructor.  Called when new target is being added.
    /// </summary>
    /// <param name="currentTargetList">Current IP addresses in use</param>
    public frmAddTarget(List<TargetSettings> currentTargetList)
    {
      _tSettings = new TargetSettings();
      _lstCurTargets = currentTargetList;
      InitializeComponent();
      txtCommunity.Text = "management";
      txtRootPath.Text = @"D:\";
      txtDestPath.Text = "/Transfer/Nathan/";             //Delete
      txtTargetServer.Text = "172.29.200.96";             //Delete
      txtUserName.Text = "dvm_user";                      //Delete
      txtPassword.Text = "dvm";                           //Delete
    }

    ///
    /// <summary>
    /// Constructor.  Called when editing an existing.
    /// </summary>
    /// <param name="currentTargetList">Current IP addresses in use</param>
    /// <param name="oldTs">Target settings of the target being edited</param>
    public frmAddTarget(List<TargetSettings> currentTargetList, TargetSettings oldTs)
    {
      
      _tSettings = oldTs;
      _oldIP = oldTs.TargetServer;
      _lstCurTargets = currentTargetList;
      InitializeComponent();
      this.Text = "Edit Target";
      txtTargetServer.Text = oldTs.TargetServer; //!!
      txtDestPath.Text = oldTs.DestinationFolder;
      txtRootPath.Text = oldTs.RootPath;
      txtUserName.Text = oldTs.UserName;
      txtPassword.Text = oldTs.UserPassword;
      txtCommunity.Text = oldTs.Community;
      numUploadRate.Value = oldTs.UploadRate;
    }

    ///
    /// <summary>
    /// Returns the user defined settings for an upload.
    /// </summary>
    /// <returns>New/ edited target settings</returns>
    public TargetSettings getTargetSettings()
    {
      return _tSettings;
    }

    ///
    /// <summary>
    /// Checks to see if the IP address is valid and in the correct format.
    /// </summary>
    /// <param name="strLine">IP address</param>
    /// <returns>True if IP address is valid</returns>
    private bool checkValidity(string strLine)
    {
      string expression = (@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                          + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                          + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\."
                          + @"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b"); //IP address regular expression

      Regex ipAddress = new Regex(expression);

      if(ipAddress.Match(strLine).Success)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    ///
    /// <summary>
    /// Validates user input.  Assigns text box values to TargetSettings variables.
    /// </summary>
    private void saveSettings()
    {
      if(txtTargetServer.Text == "")   //Checks if a target have been entered
      {
        MessageBox.Show("No target IP address as been input", "No Target Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if(checkValidity(this.txtTargetServer.Text) == false)
      {
        MessageBox.Show("IP address is not in a valid format", "Invalid IP address", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if((txtDestPath.Text.StartsWith("/") && txtDestPath.Text.EndsWith("/")) == false)        //Checks if destination path is in a valid format
      {
        MessageBox.Show("Destination path is invalid.  It must start and end with ' / '", "Destination Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else if((txtRootPath.Text == "") || (txtRootPath.Text.EndsWith("\\") == false))
      {
        MessageBox.Show("Root path is invalid.  It must end with ' \\ ' ", "Root Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
      else
      {
        foreach(TargetSettings ts in _lstCurTargets)    //Checks if IP address is already present in the project
        {
          if((ts.TargetServer == txtTargetServer.Text) && (_oldIP != txtTargetServer.Text))
          {
            MessageBox.Show("Project already contains this Target IP.  Cannot upload to duplicate targets", "Duplicate Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
          }
        }

        _tSettings.TargetServer = txtTargetServer.Text;
        _tSettings.DestinationFolder = txtDestPath.Text;
        _tSettings.RootPath = txtRootPath.Text;
        _tSettings.UserName = txtUserName.Text;
        _tSettings.UserPassword = txtPassword.Text;
        _tSettings.Community = txtCommunity.Text;
        _tSettings.UploadRate = numUploadRate.Value;
        this.DialogResult = DialogResult.OK;
      }
    }

    #region Events
    ///
    /// <summary>
    /// Cancel button event.  Closes form.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    ///
    /// <summary>
    /// Ok button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnOk_Click(object sender, EventArgs e)
    {
      saveSettings();
    }
    #endregion

  }
}
