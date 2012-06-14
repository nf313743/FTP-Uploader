using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace NathanUpload
{
  /// <summary>
  /// Manages a project's uploading operations
  /// </summary>
  class UploadSession
  {
    private bool killAll;                                       //Used to stop errors occurring when removing entries from dicActiveUploads in the stopAllProcesses() and processExitEvent() methods
    private TabPageInterface tabInt;                            //Reference to project's tab page
    private Dictionary<string, TargetUpload> dicActiveUploads;  //Targets that are currently being uploaded
    private List<TargetSettings> lstTargets;                    //List of IP address the project contains
    private List<Thread> lstThreads;                            //A Thread for each Target Server
    private ProjectSettings pSettings;                          //Projects Settings
    private List<string> lstCompleted;    //List of completed upload IPs
    private List<string> lstStopped;      //List of IPs that have been told to stop

    ///
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="ps">Project settings to be uploaded</param>
    /// <param name="tabInt">Reference to project's tab page</param>
    public UploadSession(ProjectSettings ps, TabPageInterface tabInt)
    {
      this.pSettings = ps;
      this.killAll = false;
      this.tabInt = tabInt;
      this.dicActiveUploads = new Dictionary<string, TargetUpload>();
      this.lstCompleted = new List<string>();
      this.lstThreads = new List<Thread>();
      this.lstStopped = new List<string>();
    }

    /// 
    /// <summary>
    /// Checks whether there are any active uploads in the project.
    /// </summary>
    /// <returns>True if active, false if not.</returns>
    public bool isActive()
    {
      if(dicActiveUploads.Count == 0)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    /// 
    /// <summary>
    /// Checks whether a single upload is active.
    /// </summary>
    /// <param name="strTarget">Target IP</param>
    /// <returns>True if an upload is active</returns>
    public bool isActive(string strTarget)
    {
      if(dicActiveUploads.Count == 0)
      {
        return false;
      }
      else
      {
        if(dicActiveUploads.ContainsKey(strTarget) == true)
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    /// 
    /// <summary>
    /// Calls method to begin uploading.
    /// If strTarget is empty, upload all targets.  Else, upload a single target
    /// </summary>
    /// <param name="lstTargets">Project's target list</param>
    /// <param name="strTarget">Target IP</param>
    public void startUpload(List<TargetSettings> lstTargets, string strTarget)
    {
      this.lstTargets = lstTargets;

      if(strTarget == "")
      {
        uploadAll();
      }
      else
      {
        uploadSingle(strTarget);
      }
    }

    /// 
    /// <summary>
    /// Terminates all running wput processes belonging to a 
    /// particular project.
    /// </summary>
    public void stopAllProcesses()
    {
      killAll = true;     //Stops processExitEvent() from removing dicActiveUploads entries before the foreach loop has had time to access each upload

      try
      {
        foreach(KeyValuePair<string, TargetUpload> pair in dicActiveUploads)
        {
          lstStopped.Add(pair.Key);
          int processID = pair.Value.getProcessID();

          foreach(Process process in Process.GetProcessesByName("wput"))  //Close all active wput.exe processes
          {
            if(process.Id == processID)
            {
              process.Kill();
            }
          }
        }
        this.dicActiveUploads.Clear();
        killAll = false;
      }
      catch
      {
      }
    }

    /// 
    /// <summary>
    /// Kills a single process.
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    public void stopSingleProcess(string strTarget)
    {
      if(this.dicActiveUploads.ContainsKey(strTarget))
      {
        lstStopped.Add(strTarget);
        int PID = this.dicActiveUploads[strTarget].getProcessID();

        foreach(Process process in Process.GetProcessesByName("wput"))  //Close all active wput.exe processes
        {
          if(process.Id == PID)
          {
            process.Kill();
          }
        }
      }
    }

    /// 
    /// <summary>
    /// Launches the installation process on the SNMP agent
    /// </summary>
    /// <param name="strTarget">Target IP</param>
    private void launchInstallation(string strTarget)
    {
      TargetSettings ts = null;
      foreach(TargetSettings tSett in lstTargets)
      {
        if(tSett.TargetServer == strTarget)
        {
          ts = tSett;
        }
      }

      if(SNMPFunctions.setExecute(ts, pSettings.SourcePath) == true)
      {
        tabInt.updateStatus(pSettings.ProjectName, ts.TargetServer, "Done - Install In Progress");
      }
      else
      {
        tabInt.updateStatus(pSettings.ProjectName, ts.TargetServer, "Installaion could not be started!");
      }
    }

    /// 
    /// <summary>
    /// Called whenever a process has completed it's upload.
    /// Then IP address is added to the completed list
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void processCompleteEvent(object sender, ProcessEventArgs e)
    {
      if(lstCompleted.Contains(e.strTarget) == false)
      {
        lstCompleted.Add(e.strTarget);
      }
    }

    /// 
    /// <summary>
    /// Called whenever a process wput process terminates.
    /// Removes the object and Thread from their respective lists.
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    private void processExitEvent(object sender, ProcessEventArgs e)
    {
      Thread.Sleep(1000);          //Pauses the method for 1 second.  Without it, processCompleteEvent would not have time to add to lstCompleted
      if(killAll == false)
      {
        if(this.dicActiveUploads.ContainsKey(e.strTarget) == true)
        {
          dicActiveUploads.Remove(e.strTarget);
        }
      }

      foreach(Thread thread in lstThreads)               //Removes finished Thread from list
      {
        if(thread.Name == e.strTarget)
        {
          lstThreads.Remove(thread);
          break;
        }
      }

      if((pSettings.InstallUpdate == true)
          && lstCompleted.Contains(e.strTarget))
      {
        launchInstallation(e.strTarget);   //Call event to begin installation
      }

      if(lstStopped.Contains(e.strTarget) == true)
      {
        lstStopped.Remove(e.strTarget);
        tabInt.OnConnectionFail(pSettings.ProjectName, e.strTarget, "Stopped");
      }
    }

    /// 
    /// <summary>
    /// Creates and starts a Thread for each Target Address.
    /// </summary>
    private void uploadAll()
    {
      try
      {
        foreach(TargetSettings ts in lstTargets)
        {
          if(lstStopped.Contains(ts.TargetServer) != true)
          {
            if(dicActiveUploads.ContainsKey(ts.TargetServer) == false)
            {
              CheckConnection cc = new CheckConnection(ts);
              if(cc.testAll() == true)
              {
                TargetUpload tu = new TargetUpload(this.pSettings, ts, this.tabInt); //New target upload
                tu.ProcessExit += new TargetUpload.ProcessExitHandler(processExitEvent);                     //Subscribes to Process exit event
                tu.ProcessComplete += new TargetUpload.ProcessCompleteHandler(processCompleteEvent);
                dicActiveUploads.Add(ts.TargetServer, tu);
                Thread uploadThread = new Thread(tu.startProcess);      //Creates Thread
                uploadThread.IsBackground = true;                       //The Thread/Process ends when the _Main Thread ends 
                uploadThread.Name = ts.TargetServer;                    //Sets name of Thread
                uploadThread.Start();                                   //Starts Thread
                lstThreads.Add(uploadThread);                           //Adds Thread to list
              }
              else
              {
                tabInt.OnConnectionFail(pSettings.ProjectName, ts.TargetServer, "Connection Failed");
              }
            }
          }
          else
          {
            tabInt.OnConnectionFail(pSettings.ProjectName, ts.TargetServer, "Please Wait");
          }
        }
      }
      catch
      {
      }
    }

    /// 
    /// <summary>
    /// Starts a single upload.  
    /// </summary>
    /// <param name="strTarget">Target IP address</param>
    private void uploadSingle(string strTarget)
    {

      if(this.dicActiveUploads.ContainsKey(strTarget) == false) //Checks to see if target is currently being uploaded 
      {
        TargetSettings targetInfo = null;

        foreach(TargetSettings ti in this.lstTargets)           //Searches for matching target in the list
        {
          if(ti.TargetServer == strTarget)
          {
            targetInfo = ti;
            break;
          }
        }
        CheckConnection cc = new CheckConnection(targetInfo);

        if(cc.testAll() == true)
        {
          TargetUpload tu = new TargetUpload(this.pSettings, targetInfo, this.tabInt);
          tu.ProcessExit += processExitEvent;                 //Subscribes to Process exit event   
          tu.ProcessComplete += processCompleteEvent;
          this.dicActiveUploads.Add(strTarget, tu);
          Thread uploadThread = new Thread(tu.startProcess);  //Creates Thread
          uploadThread.IsBackground = true;                   //The Thread/Process ends when the _Main Thread ends 
          uploadThread.Name = strTarget;                      //Sets name of Thread
          uploadThread.Start();                               //Starts Thread
          this.lstThreads.Add(uploadThread);                  //Adds Thread to list
        }
        else
        {
          tabInt.OnConnectionFail(pSettings.ProjectName, targetInfo.TargetServer, "Connection Failed");
        }
      }
    }
  }
}