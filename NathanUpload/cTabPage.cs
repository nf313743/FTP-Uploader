
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Collections;

namespace NathanUpload
{
  ///
  /// <summary>
  /// Inherits from the System.Windows.Forms.TabPage class.
  /// A custom TabPage class with components already layed out.
  /// Displays projects settings and upload targets.  Contains methods for 
  /// updating the progress and status the uploads.
  /// </summary>
  public partial class cTabPage : TabPage
  {
    private string _strProName;              //Project's name
    private TabPageInterface _tabInterface;  
    private List<string> _lstStopList;       //List containing Target address that have been stopped by the user
    private bool _stopAll;                   //Flag for all uploads to be stopped

    ///
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="_strProName">Project's name the tab belongs to</param>
    /// <param name="_tabInterface">TabPageInterface Reference</param>
    public cTabPage(string strProName, TabPageInterface tabInterface)
    {
      _strProName = strProName;
      _tabInterface = tabInterface;
      _lstStopList = new List<string>();
      _stopAll = false; 
      InitializeComponent();
    }

    ///
    /// <summary>
    /// Used for adding multiple new targets to the ListView
    /// </summary>
    /// <param name="lstTS">List of new targets and their settings</param>
    public void addMultipleTargets(List<TargetSettings> lstTS)
    {
      foreach(TargetSettings ts in lstTS)
      {
        addSingleTarget(ts);
        //ListViewItem lviNewRow = new ListViewItem(_ts.TargetServer);
        //lviNewRow.Name = _ts.TargetServer;                           //Sets ListItem a name as target value
        //lviNewRow.SubItems.Add("");                                 //Progress bar goes here
        //lviNewRow.SubItems.Add("");                                 //%
        //lviNewRow.SubItems.Add("");                                 //Status Column
        //lviNewRow.SubItems.Add("");                                 //Speed Column
        //lviNewRow.SubItems.Add(_ts.DestinationFolder);
        //this.currentTargetList.Items.Add(lviNewRow);                       //Adds Item to List

        //ProgressBar pb = new ProgressBar();                         //Creates progress bar
        //pb.Name = _ts.TargetServer;
        //int row = currentTargetList.Items.IndexOf(lviNewRow);              //Gets row of current item being added    
        //this.currentTargetList.AddEmbeddedControl(pb, 1, row);
      }
    }
    
    ///
    /// <summary>
    /// Adds new columns/target to the list view when called.
    /// </summary>
    /// <param name="_ts">The new target's settings</param>
    public void addSingleTarget(TargetSettings ts)
    {
      ListViewItem lviNewRow = new ListViewItem(ts.TargetServer);
      lviNewRow.Name = ts.TargetServer;                           //Sets ListItem a name as target value
      lviNewRow.SubItems.Add("");                                 //Progress bar goes here
      lviNewRow.SubItems.Add("");                                 //%
      lviNewRow.SubItems.Add("");                                 //Status Column
      lviNewRow.SubItems.Add("");                                 //Speed Column
      lviNewRow.SubItems.Add(ts.DestinationFolder);

      if(ts.UploadRate == 0)
      {
        lviNewRow.SubItems.Add("Maximum");
      }
      else
      {
        lviNewRow.SubItems.Add(ts.UploadRate.ToString() + "KiB/S"); //Maximum Upload Speed
      }

      this.targetList.Items.Add(lviNewRow);             //Adds Item to List
      ProgressBar pb = new ProgressBar();               //Creates progress bar
      pb.Name = ts.TargetServer;                        //Progress bar identifier
      int row = targetList.Items.IndexOf(lviNewRow);    //Gets row of current item being added    
      this.targetList.AddEmbeddedControl(pb, 1, row);   //'Paints' the control over the desired location
    }

    ///
    /// <summary>
    /// Used for testing connections before the uploading process begins.
    /// If the ping, FTP login or site name fails, this event is raised.
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    /// <param name="msg">Message indicating what is wrong</param>
    public void connectionFail(string strTarget, string msg)
    {
      updateStatus(strTarget, msg);
    }

    ///
    /// <summary>
    /// Returns IP address of the user selected row.
    /// </summary>
    /// <returns>IP address</returns>
    public string getSelectIP()
    {
      try
      {
        string strTarget = this.targetList.SelectedItems[0].Name;
        return strTarget;
      }
      catch
      {
        //No item selected
        return "";
      }
    }

    ///
    /// <summary>
    /// Used if "Receive-Error: Connection broke down".
    /// </summary>
    /// <param name="strTarget"> Target IP address </param>
    public void processErrorEvent(ProcessErrorEventArgs e)
    {
      _stopAll = true;                  //Adds IPs to stop list
      foreach(ListViewItem lvi in targetList.Items)
      {
        updateStatus(lvi.Name, e.msg);  //Update status to "Connection Failed"
      }
    }

    ///
    /// <summary>
    /// Signals a single process or all processes to be stopped.
    /// </summary>
    /// <param name="e">The target IP that has been stopped</param>
    public void processStopEvent(ProcessEventArgs e)
    {
      if(e.strTarget == "")                         //If "", all have been stopped
      {
        _stopAll = true;
      }
      else
      {
        if(_lstStopList.Contains(e.strTarget) != true)
        {
          _lstStopList.Add(e.strTarget);
        }
      }
    }

    ///
    /// <summary>
    /// Removes a selected target from the project.
    /// </summary>
    public string removeTarget()
    {
      if(targetList.SelectedItems.Count > 0)                              //Checks if and item exists
      {
        string strTarget = targetList.SelectedItems[0].SubItems[0].Text;  //Get target address
        targetList.Items.Remove(targetList.SelectedItems[0]);             //Remove item from list
        targetList.RemoveEmbeddedControl(strTarget);
        return strTarget;
      }
      else
      {
        return "";
      }
    }

    ///
    /// <summary>
    /// Resets all of the stop flags.
    /// </summary>
    public void resetStatus()
    {
      _stopAll = false;
      _lstStopList.Clear();
    }

    ///
    /// <summary>
    /// Updates progress of the progress bar and status of a given target.
    /// Uses SafeBeginInvoke to test whether it is safe for the two threads
    /// (the Main Thread and the TargetUpload Thread) to communicate/pass information.
    /// Because of the nature of SafeBeginInvoke, it is not always safe to communicate 
    /// between the two Threads.  Therefore, not all calls are successful to OnUpdateProgress().
    /// Because calls to OnUpdateProgress() are put into a queue, when the upload Processes and 
    /// Threads are terminated the progress bar and status field continue to update for a small
    /// amount of time.  _lstStopList and _stopAll are used to flag that the upload process
    /// has been stopped, so any OnUpdateProgress() calls left in the queue with not effect the display/status
    /// of the List View screen.
    /// </summary>
    /// <param name="e">Contains the target address, progress, and speed of an upload</param>
    public void updateProgress(OutputEventArgs e)
    {
      this.targetList.SafeBeginInvoke(new Action(() =>                                //Tests whether is it safe to communicate
      {
        if(targetList.Items.ContainsKey(e.strTarget) == true)                         //Checks if ListView item exists for target IP
        {
          if((_lstStopList.Contains(e.strTarget)) || (_stopAll == true))    //Checks if IP has been flagged to stop
          {
            if(_lstStopList.Contains(e.strTarget))
            {
              targetList.Items[e.strTarget].SubItems[3].Text = "Stopped";       //Sets target's status to 'Stopped'
              targetList.Items[e.strTarget].SubItems[4].Text = "";
            }
            else
            {
              updateStatus("", "Stopped");                                            //Sets all targets to 'Stopped'
            }
          }
          else
          {
            int percentageDone = (int)e.percent;
            int row = targetList.Items[e.strTarget].Index;                            //Finds row of target
            ProgressBar pb = targetList.GetEmbeddedControl(e.strTarget) as ProgressBar;  //Fetches progress bar

            if(percentageDone <= 100)
            {
              pb.Value = percentageDone;
            }

            targetList.Items[e.strTarget].SubItems[2].Text = percentageDone.ToString() + "%";
            targetList.Items[e.strTarget].SubItems[3].Text = "Running";
            targetList.Items[e.strTarget].SubItems[4].Text = e.strSpeed;

            if(percentageDone >= 100)
            {
              targetList.Items[e.strTarget].SubItems[3].Text = "Done";
              targetList.Items[e.strTarget].SubItems[4].Text = "";
            }
          }
        }
      }));
    }
 
    ///
    /// <summary>
    /// Assigns values to components that display the project's settings.
    /// If advanced settings have been selected, they will be displayed.
    /// Else, advanced settings are hidden.
    /// </summary>
    /// <param name="pSettings">The project's settings</param>
    public void updateSettings(ProjectSettings pSettings)
    {
      this.splitContainer1.SplitterDistance = 65;         //Hides the advanced settings
      this.Text = pSettings.ProjectName;
      this.Name = pSettings.ProjectName;
      this.txtProName.Text = pSettings.ProjectName;
      this.txtSource.Text = pSettings.SourcePath;
      
      if(pSettings.InstallUpdate == true)
      {
        this.txtInstall.Text = "Yes";
      }
      else
      {
        this.txtInstall.Text = "No";
      }

      if(pSettings.AdvancedEnabled == true)
      {
        this.splitContainer1.SplitterDistance = 120;                            //Creates space for advanced components
        this.txtProxyName.Visible = true; this.lblProxyName.Visible = true;     //Sets the components to visible     
        this.txtInterrupt.Visible = true; this.lblInterrupt.Visible = true;
        this.txtArgument.Visible = true; this.lblArgument.Visible = true;

        this.txtProxyName.Text = pSettings.ProxyName;

        if(pSettings.Interrupt == true)
        {
          this.txtInterrupt.Text = "Yes";
        }
        else
        {
          this.txtInterrupt.Text = "No";
        }
        this.txtArgument.Text = pSettings.CommandLine;
      }
    }

    /// <summary>
    /// Changes the status in the ListView from the passed message.
    /// </summary>
    /// <param name="strTarget">Identifier for which row/upload to update</param>
    /// <param name="strMessage">The text to be displayed</param>
    public void updateStatus(string strTarget, string strMessage)
    {
      this.targetList.SafeBeginInvoke(new Action(() =>              //Needed for communication between Threads
      {
        if(strMessage == "Stopped")
        {
          checkStopped(strTarget);
        }
        else if(strTarget != "")
        {
          this.targetList.Items[strTarget].SubItems[3].Text = strMessage;
        }
        else
        {
          int itemCount = this.targetList.Items.Count;

          for(int i = 0; i < itemCount; i++)
          {
            targetList.Items[i].SubItems[3].Text = strMessage;
          }
        }
      }));
    }

    ///
    /// <summary>
    /// Adds a new upload target to project.
    /// </summary>
    private void addTarget()
    {
      _tabInterface.addTargetEvent(); //Parameters do not contain any usable information
    }

    ///
    /// <summary>
    /// Checks if an item in the ListView has been selected.
    /// </summary>
    private void checkIfSelected()
    {
      try
      {
        string strTarget = targetList.SelectedItems[0].SubItems[0].Text;    //Check if a target is selected
        enableTargetButtons(true, strTarget);
      }
      catch
      {
        enableTargetButtons(false, "");
      }
    }

    ///
    /// <summary>
    /// Checks whether target status indicates the upload has been completed.
    /// If so, there is no need to update the status to "Stopped".
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    private void checkStopped(string strTarget)
    {
      try
      {
        if(strTarget != "")
        {
          if(this.targetList.Items[strTarget].SubItems[3].Text != "Done")
          {
            this.targetList.Items[strTarget].SubItems[3].Text = "Stopped";
          }
        }
        else
        {
          int itemCount = this.targetList.Items.Count;

          for(int i = 0; i < itemCount; i++)
          {
            if(this.targetList.Items[i].SubItems[3].Text != "Done")
            {
              this.targetList.Items[i].SubItems[3].Text = "Stopped";
            }
          }
        }
      }
      catch
      {
        //Caught if target has been removed before stopping it
      }
    }
    
    ///
    /// <summary>
    /// Used to enable and disable onscreen buttons depending on whether
    /// targets, projects are available/active to use them.
    /// </summary>
    /// <param name="p">Used for enabling and disabling buttons</param>
    /// <param name="strTarget">Target address</param>
    private void enableTargetButtons(bool p, string strTarget)
    {
      if(p == true)
      {
        if(_tabInterface.checkIfActive(_strProName, strTarget) == true)
        {
          removeTargetToolStripMenuItem.Enabled = true;
          stopTargetToolStripMenuItem.Enabled = true;
          editTargetToolStripMenuItem.Enabled = false;
          startTargetToolStripMenuItem.Enabled = false;
          _tabInterface.enableSelectedTargetButtons(false);
        }
        else
        {
          removeTargetToolStripMenuItem.Enabled = true;
          stopTargetToolStripMenuItem.Enabled = false;
          editTargetToolStripMenuItem.Enabled = true;
          startTargetToolStripMenuItem.Enabled = true;
          _tabInterface.enableSelectedTargetButtons(true);
        }
      }
      else
      {
        removeTargetToolStripMenuItem.Enabled = false;
        stopTargetToolStripMenuItem.Enabled = false;

        editTargetToolStripMenuItem.Enabled = false;
        startTargetToolStripMenuItem.Enabled = false;
        _tabInterface.enableSelectedTargetButtons(false);
      }
    }

    ///
    /// <summary>
    /// Starts uploading the selected target.
    /// </summary>
    private void startTarget()
    {
      if(targetList.SelectedItems.Count > 0)                                //Checks if and item exists
      {
        string strTarget = targetList.SelectedItems[0].SubItems[0].Text;    //Get target address
        _tabInterface.startProcess(_strProName, strTarget);
      }
    }

    ///
    /// <summary>
    /// Stops an individual upload process.
    /// </summary>
    private void stopTarget()
    {
      if(targetList.SelectedItems.Count > 0)                                  //Checks if and item exists
      {
        string strTarget = targetList.SelectedItems[0].SubItems[0].Text;    //Get target address
        _tabInterface.stopProcess(this.Name, strTarget);                             //Addresses _Main Class, sends project name and target to remove
      }

    }

    #region Events
    /// <summary>
    ///   Add target event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void addTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      addTarget();
    }

    /// <summary>
    ///   Remove target event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void removeTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _tabInterface.removeTarget(_strProName);
    }

    /// <summary>
    ///   Start target event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void startTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      startTarget();
    }
   
    /// <summary>
    ///   Stop target event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void stopTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      stopTarget();
    }

    private void editTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      _tabInterface.editTarget();
    }

    private void targetList_SelectedIndexChanged(object sender, EventArgs e)
    {
      checkIfSelected();
    }

    private void targetListMenu_Opening(object sender, CancelEventArgs e)
    {
      checkIfSelected();
    }
    
    private void targetList_MouseClick(object sender, MouseEventArgs e)
    {
      checkIfSelected();
    }
    #endregion



   }
}
