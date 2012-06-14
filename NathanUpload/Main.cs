 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Threading;
using System.Timers;
namespace NathanUpload
{
  public partial class Main : Form
  {
    private ProjectInterface _proInter;           //An object that is used to communicate Between the user interface the the project classes
    private TabPageInterface _tabInter;           //Used to communicate between the project's TabPage
    private string _strTabIndex = "";             //Holds the name of the currently selected (TabPage) project
    private System.Timers.Timer stopBtnTimer = new System.Timers.Timer(800);  //Used for enabling disabling the start button
    private System.Timers.Timer startBtnTimer = new System.Timers.Timer(800); //Used for enabling disabling the start button
    private System.Timers.Timer editBtnTimer = new System.Timers.Timer(1000); //Used for enabling disabling the edit button

    ///
    /// <summary>
    /// Constructor.
    /// Starts the edit button checking timer.
    /// </summary>
    public Main()
    {
      checkWput();
      InitializeComponent();
      _proInter = new ProjectInterface();   //Creates Project Interface.  Passes its own reference 
      _tabInter = new TabPageInterface(this);
      _proInter.addTabRef(_tabInter);
      _tabInter.addProRef(_proInter);
      editBtnCheck();
      
    }

    /// 
    /// <summary>
    /// If wput.exe is not in the same directory as the application's .exe the
    /// application will close.
    /// </summary>
    private void checkWput()
    {
      if(File.Exists(@"wput.exe") != true)
      {
        MessageBox.Show("wput.exe could not be located.  wput.exe must be in the same directory" +
                        " as the application's .exe." +
                        "\nPlease reinstall the application" +
                        "\nApplication will now terminate.",
                        "wput.exe Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
        Process.GetCurrentProcess().Kill();
      }
    }

    ///
    /// <summary>
    /// Adds a new TabPage to the TabControl
    /// </summary>
    /// <param name="tabPage"></param>
    public void addTabPage(cTabPage tabPage)
    {
      mainTabControl.Visible = true;
      _strTabIndex = tabPage.Name;
      mainTabControl.Controls.Add(tabPage);         //Adds TabPage to TabContol
      mainTabControl.SelectedTab = tabPage;         //Makes new Tab the selected tab
    }

    ///
    /// <summary>
    /// Adds a new target to the project
    /// </summary>
    public void addTarget()
    {
      if(_strTabIndex != "")     //Check if there is a project open
      {
        try
        {
          List<TargetSettings> targetList = _proInter.getTargets(_strTabIndex);       //List of targets in the current project, passed to addTargetDialog to prevent duplicate targets
          frmAddTarget addTargetDialog = new frmAddTarget(targetList);                //Opens as new addTargetDialog

          if(addTargetDialog.ShowDialog() == DialogResult.OK)
          {
            TargetSettings ts = addTargetDialog.getTargetSettings();  //Fetches target settings from addTargetDialog
            _proInter.addTarget(_strTabIndex, ts);                    //Adds target to project
          }
          enableTargetButtons();
        }
        catch(Exception ex)
        {
          MessageBox.Show("There has been an error: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    ///
    /// <summary>
    /// Allows the user to edit the current project's settings.
    /// </summary>
    private void editProject()
    {
      if((_strTabIndex != "") && (_proInter.checkActiveAll(_strTabIndex) == false))   //Checks it the project is currently uploading
      {
        List<string> lstNames = _proInter.getProNames();
        ProjectSettings oldProSettings = _proInter.getProSettings(_strTabIndex);       //Get the current project settings
        frmProjectSettings frmNewProject = new frmProjectSettings(lstNames, oldProSettings);    //Use them to fill form

        if(frmNewProject.ShowDialog() == DialogResult.OK)
        {
          TabPage oldTabPage = mainTabControl.SelectedTab;                    //Old TabPage
          this.mainTabControl.TabPages.Remove(oldTabPage);                    //Removes old tab page from Tab Control
          ProjectSettings newSettings = frmNewProject.getSettings();          //Fetch the new settings
          _proInter.editProject(oldProSettings.ProjectName, newSettings);
        }
      }
      enableProButtons();
      enableTargetButtons();
    }

    ///
    /// <summary>
    /// Enables and disables Toolbar target buttons
    /// </summary>
    /// <param name="p"></param>
    public void enableSelectedTargetButtons(bool p)
    {
      editSelectedTargetToolStripMenuItem.Enabled = p;
      deleteSelectedToolStripMenuItem.Enabled = p;
    }

    ///
    /// <summary>
    /// Edit's selected target's settings.
    /// </summary>
    public void editTarget()
    {
      if(_strTabIndex == "")
      {
        return;
      }

      string strTarget = _tabInter.getSelectedIP(_strTabIndex);

      if((strTarget == "") || (_proInter.checkActiveSingle(_strTabIndex, strTarget) == true))
      {
        return;
      }
      else
      {
        List<TargetSettings> lstTSettings = _proInter.getTargets(_strTabIndex);
        TargetSettings oldTs = null;

        foreach(TargetSettings ts in lstTSettings)
        {
          if(ts.TargetServer == strTarget)
          {
            oldTs = ts;
            break;
          }
        }
        frmAddTarget targetDialog = new frmAddTarget(lstTSettings, oldTs);

        if(targetDialog.ShowDialog() == DialogResult.OK)
        {
          _proInter.removeTarget(_strTabIndex);
          TargetSettings ts = targetDialog.getTargetSettings();     //Fetches target settings from addTargetDialog
          _proInter.addTarget(_strTabIndex, ts);                    //Adds target to project
        }
      }
    }

    ///
    /// <summary>
    /// Enables and disables target related buttons
    /// </summary>
    public void enableTargetButtons()
    {
      try
      {
        List<TargetSettings> lstTs = _proInter.getTargets(_strTabIndex);

        if(lstTs.Count > 0)
        {
          btnConnections.Enabled = true;
          btnStart.Enabled = true;
          btnStop.Enabled = true;
        }
        else
        {
          btnConnections.Enabled = false;
          btnStart.Enabled = false;
          btnStop.Enabled = false;

          editSelectedTargetToolStripMenuItem.Enabled = false;
          deleteSelectedToolStripMenuItem.Enabled = false;
        }
      }
      catch
      {
        //No projects loaded
        btnConnections.Enabled = false;
        btnStart.Enabled = false;
        btnStop.Enabled = false;
        btnEdit.Enabled = false;

        
        editProjectToolStripMenuItem1.Enabled = false;
        addTargetToProjectToolStripMenuItem.Enabled = false;
        deleteSelectedToolStripMenuItem.Enabled = false;
        saveProjectToolStripMenuItem.Enabled = false;
        editSelectedTargetToolStripMenuItem.Enabled = false;
        importExportToolStripMenuItem.Enabled = false;
        closeProjectToolStripMenuItem.Enabled = false;
      }
    }

    ///
    /// <summary>
    /// Closes the selected tab.
    /// Asks the user whether they want to save the tab they are closing.
    /// </summary>
    private void closeTab()
    {
      DialogResult saveDialog = MessageBox.Show("Would you like to save the current project?.", "Save Project", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

      if(saveDialog == DialogResult.Yes)
      {
        saveProject();     //Calls save event      
      }
      else if(saveDialog == DialogResult.Cancel)
      {
        return;
      }
      removeProject(_strTabIndex);
      mainTabControl.Controls.Remove(mainTabControl.SelectedTab);             //Removes the tab from the tab control

      if(mainTabControl.TabCount == 0)                                        //If there are no more tabs, hide Tab Control
      {
        this.mainTabControl.Visible = false;                                //Hide blank TabControl
        _strTabIndex = "";                                //Set current project as blank
      }
      else
      {
        _strTabIndex = mainTabControl.SelectedTab.Text;   //Set current project to the next tab
      }
      enableTargetButtons();
      enableProButtons();
    }

    ///
    /// <summary>
    /// Enables the edit button timer.
    /// </summary>
    private void editBtnCheck()
    {
      editBtnTimer.Elapsed += new ElapsedEventHandler(OnEditCheckEvent);
      editBtnTimer.SynchronizingObject = this;
      editBtnTimer.Enabled = true;
    }

    ///
    /// <summary>
    /// Enables and disables project related buttons
    /// </summary>
    private void enableProButtons()
    {
      if(_strTabIndex != null && _strTabIndex != "")
      {
        btnEdit.Enabled = true;
        editProjectToolStripMenuItem1.Enabled = true;
        saveProjectToolStripMenuItem.Enabled = true;
        importExportToolStripMenuItem.Enabled = true;
        addTargetToProjectToolStripMenuItem.Enabled = true;
        closeProjectToolStripMenuItem.Enabled = true;
      }
      else
      {
        btnEdit.Enabled = false;
        editProjectToolStripMenuItem1.Enabled = false;
        saveProjectToolStripMenuItem.Enabled = false;
        importExportToolStripMenuItem.Enabled = false;
        addTargetToProjectToolStripMenuItem.Enabled = false;
        closeProjectToolStripMenuItem.Enabled = false;
      }
    }

    ///
    /// <summary>
    /// Exports IP addresses of a project to file.
    /// </summary>
    private void exportIPFile()
    {
      if(_strTabIndex != "")
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();   //Creates SaveFileDialog
        saveFileDialog.Title = "Export IP Addresses";
        saveFileDialog.Filter = ".txt|*.txt";                   //Only allows the user to save the file type as .sav    
        saveFileDialog.ShowDialog();                            //Displays dialog

        if(saveFileDialog.FileName != "")
        {
          bool saveStatus = _proInter.exportIPs(_strTabIndex, saveFileDialog.FileName);

          if(saveStatus == false)
          {
            MessageBox.Show("An error has occurred during the export process.",
                        "Export Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
        }
      }
    }

    ///
    /// <summary>
    /// Gets file path of the import file.
    /// </summary>
    /// <returns>File path</returns>
    private string getImportFilePath()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Open Import File";
      openFileDialog.Filter = ".txt|*.txt";   //Only displays .sav files
      openFileDialog.ShowDialog();

      if(openFileDialog.FileName != "")
      {
        return openFileDialog.FileName;
      }
      else
      {
        return "";
      }
    }

    ///
    /// <summary>
    /// Imports IP addresses from file.
    /// </summary>
    private void importFile()
    {
      if(_strTabIndex != "")
      {
        string strTarget = _tabInter.getSelectedIP(_strTabIndex);

        if(strTarget == "")
        {
          MessageBox.Show("You must select and existing target before proceeding\nThe imported IPs will use these existing settings.",
                          "No Selected Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
          string strPath = getImportFilePath();

          if(strPath != "")
          {
            if(_proInter.importIPFile(strPath, strTarget, _strTabIndex) == false)
            {
              MessageBox.Show("There was an error during the import procedure." +
                              "\nThe file may be corrupt of incorrectly formatted.",
                              "No Selected Target", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          }
        }
      }
    }

    ///
    /// <summary>
    /// Terminates all running wput.exe processes.
    /// </summary>
    private void killProcessess()
    {
      foreach(Process process in Process.GetProcessesByName("wput"))  //Close all active wput.exe processes
      {
        process.Kill();
      }
    }

    ///
    /// <summary>
    /// Creates a new project.
    /// </summary>
    private void newProject()
    {
      List<string> lstNames = _proInter.getProNames();
      frmProjectSettings frmNewProject = new frmProjectSettings(lstNames); //Creates and displays frmProjectSettings dialog

      if(frmNewProject.ShowDialog() == DialogResult.OK)
      {
        ProjectSettings ps = frmNewProject.getSettings(); //Fetches settings from the dialog
        _proInter.newPoject(ps);                          //Creates new project
        enableProButtons();
      }
      enableTargetButtons();
    }

    ///
    /// <summary>
    /// Check to see at every interval if the current project is available to edit.
    /// I.e. is not uploading.  If it is available edit button is enabled.  Else, 
    /// it is disabled.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void OnEditCheckEvent(object source, ElapsedEventArgs e)
    {
      if(!(_strTabIndex != null) || (_strTabIndex != ""))
      {
        if(_proInter.checkActiveAll(_strTabIndex) == true)
        {
          btnEdit.Enabled = false;
          editProjectToolStripMenuItem1.Enabled = false;
        }
        else
        {
          btnEdit.Enabled = true;
          editProjectToolStripMenuItem1.Enabled = true;
        }
      }
    }

    ///
    /// <summary>
    /// Start button timer tick event.
    /// Enables the start button after interval.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void OnStartEvent(object source, ElapsedEventArgs e)
    {
      if(!(_strTabIndex != null) || (_strTabIndex != ""))
      {
        btnStart.Enabled = true;
        startBtnTimer.Enabled = false;
        startBtnTimer.Elapsed -= new ElapsedEventHandler(OnStartEvent);
      }
    }

    ///
    /// <summary>
    /// Start button timer tick event.
    /// Enables the start button after interval.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void OnStopEvent(object source, ElapsedEventArgs e)
    {
      if((_strTabIndex != null) && (_strTabIndex != ""))
      {
        btnStart.Enabled = true;
        stopBtnTimer.Enabled = false;
        stopBtnTimer.Elapsed -= new ElapsedEventHandler(OnStopEvent);
      }
    }

    ///
    /// <summary>
    /// Opens project from file.
    /// </summary>
    private void openProject()
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Title = "Open Project";
      openFileDialog.Filter = ".ulp|*.ulp";   //Only displays .ulp files
      openFileDialog.ShowDialog();

      if(openFileDialog.FileName != "")
      {
        try
        {
          _proInter.openProject(openFileDialog.FileName); //Deserializes object
          enableProButtons();
        }
        catch(System.ApplicationException ex)           //Project name already in use
        {
          MessageBox.Show("Project '" + ex.Message + "' already in use. Cannot load project.",
                          "Project Name Already In Use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        catch(System.NullReferenceException)             //File cannot be opened
        {
          MessageBox.Show("The file is corrupt and cannot be opened", "Corrupt File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
      enableTargetButtons();

    }

    ///
    /// <summary>
    /// Removes a project along with it's TabPage.
    /// </summary>
    /// <param name="_strProName">Name of the project</param>
    private void removeProject(string strProName)
    {
      _proInter.removeProject(strProName);
      enableTargetButtons();
      enableProButtons();
    }

    ///
    /// <summary>
    /// Removes selected target from it's project.
    /// </summary>
    private void removeTarget()
    {
      if(_strTabIndex != "")
      {
        _proInter.removeTarget(_strTabIndex);
        enableTargetButtons();
      }
    }

    ///
    /// <summary>
    /// Used to select tab using right mouse button click.  This is required for closing
    /// the tab using right-click context menu strip.
    /// </summary>
    /// <param name="e"> Mouse Event Object </param>
    private void rightButtonClick(MouseEventArgs e)
    {
      if(e.Button == MouseButtons.Right)     
      {
        for(int i = 0; i < this.mainTabControl.TabCount; i++)                       //Loop through all tabs
        {
          if(this.mainTabControl.GetTabRect(i).Contains(new Point(e.X, e.Y)))     //Checks to see if mouse click's location is same as tab's
          {
            this.mainTabControl.SelectedIndex = i;
            _strTabIndex = mainTabControl.SelectedTab.Text;
            break;
          }
        }
      }
    }

    ///
    /// <summary>
    /// Saves currently selected project to file.
    /// </summary>
    private void saveProject()
    {
      if(_strTabIndex != "")
      {
        SaveFileDialog saveFileDialog = new SaveFileDialog();   //Creates SaveFileDialog
        saveFileDialog.Title = "Save Project";
        saveFileDialog.Filter = ".ulp|*.ulp";                   //Only allows the user to save the file type as .ulp
        saveFileDialog.FileName = _strTabIndex;
        saveFileDialog.ShowDialog();                            //Displays dialog
        

        if(saveFileDialog.FileName != "")
        {
          _proInter.saveProject(_strTabIndex, saveFileDialog.FileName); //Call to save object to file
        }
      }
    }

    ///
    /// <summary>
    /// Can start the uploading of a single target, or all targets in a project.
    /// </summary>
    /// <param name="_strProName"> Project name </param>
    /// <param name="strTarget"> Target IP to start.  If "", start all processes/uploads </param>
    private void startUpload(string strProName, string strTarget)
    {
      if(_strTabIndex != "")                                        //Checks if there is a Project open
      {
        if(btnStart.Enabled == false)
        {
          return;
        }

        btnStart.Enabled = false;

        if(startBtnTimer.Enabled == false)
        {
          startBtnTimer.Elapsed += new ElapsedEventHandler(OnStartEvent);
          startBtnTimer.SynchronizingObject = this;
          startBtnTimer.Enabled = true;
        }
        _proInter.startUpload(strProName, strTarget);
      }
    }

    ///
    /// <summary>
    /// Stops all targets within a project
    /// </summary>
    /// <param name="_strProName"> Project Name </param>
    private void stopUpload(string strProName)
    {
      btnStart.Enabled = false;

      if(stopBtnTimer.Enabled == false)
      {
        stopBtnTimer.Elapsed += new ElapsedEventHandler(OnStopEvent);
        stopBtnTimer.SynchronizingObject = this;
        stopBtnTimer.Enabled = true;
      }
      _proInter.stopUpload(strProName, "");                                  //Stops upload/Process
    }

    ///
    /// <summary>
    /// Changes _strTabIndex to the current tab index
    /// </summary>
    private void tabIndexChanged()
    {
      if(mainTabControl.SelectedTab != null)
      {
        _strTabIndex = mainTabControl.SelectedTab.Text;   //Uses the name of the header to identify what project is selected
      }
      else
      {
        _strTabIndex = "";
      }
      enableTargetButtons();
      enableSelectedTargetButtons(false);
    }

    ///
    /// <summary>
    /// Tests the availability of all target servers
    /// </summary>
    private void testConnections()
    {
      if(_strTabIndex != "")
      {
        _proInter.testConnections(_strTabIndex);
      }
    }

    #region Events
    /// <summary>
    ///   Add new target event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void addTargetToProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      addTarget();
    }

    /// <summary>
    /// Edit button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnEdit_Click(object sender, EventArgs e)
    {
      editProject();
    }

    /// <summary>
    /// Starts all processes/uploads.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnStart_Click(object sender, EventArgs e)
    {
      startUpload(_strTabIndex, "");
    }

    /// <summary>
    ///   Stop event. 
    ///   Stops all process/uploads for current project.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnStop_Click(object sender, EventArgs e)
    {
      if(_strTabIndex != "")           //If a project is active
      {
        stopUpload(_strTabIndex); //Stops all wput processes that belong to that project
      }
    }

    /// <summary>
    /// Close Tab event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      closeTab();
    }

    /// <summary>
    ///   Remove tab event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      removeTarget();
    }

    /// <summary>
    /// Form close event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Main_FormClosed(object sender, FormClosedEventArgs e)
    {
      killProcessess();
    }

    /// <summary>
    ///   Open project event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mainMenuStripOpenProject_Click(object sender, EventArgs e)
    {
      openProject();
    }

    /// <summary>
    ///   New project event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mainMenuStripNewProject_Click(object sender, EventArgs e)
    {
      newProject();
    }

    /// <summary>
    ///   Whenever the user changes between tab the string variable this.strCurrentSelectedProjects kept updated.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mainTabControl_SelectedIndexChanged_1(object sender, EventArgs e)
    {
      tabIndexChanged();
    }

    /// <summary>
    /// Test connections event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnConnections_Click(object sender, EventArgs e)
    {
      testConnections();
    }

    /// <summary>
    /// Right/Middle button click event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void mainTabControl_MouseDown_1(object sender, MouseEventArgs e)
    {
      rightButtonClick(e);
    }

    /// <summary>
    ///   Save project event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      saveProject();
    }

    private void importIPsToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      importFile();
    }

    private void exportIPsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      exportIPFile();
    }

    private void exittToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void editSelectedTargetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      editTarget();
    }

    private void editProjectToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      editProject();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AboutBox aBox = new AboutBox();
      aBox.ShowDialog();
    }
    
    private void editProjectToolStripMenuItem11_Click(object sender, EventArgs e)
    {
      editProject();
    }

    private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
    {
      closeTab();
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
      DialogResult exitDialog = MessageBox.Show("Are you sure you want to exit the application?.", "Exit Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3);

      if(exitDialog == DialogResult.Yes)
      {
        e.Cancel = false;
      }
      else
      {
        e.Cancel = true;
      }
    }

    #endregion


  }
}
