using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Threading;

namespace NathanUpload
{
  /// <summary>
  /// Acts as an interface between the upload projects and GUI
  /// </summary>
  public class ProjectInterface
  {
    Dictionary<string, Project> _dicProjectList;   //List of upload projects             
    TabPageInterface _tabInterface;                //Reference to the TabPage Interface      

    ///
    /// <summary>
    /// Constructor.
    /// </summary>
    public ProjectInterface()
    {
      this._dicProjectList = new Dictionary<string, Project>();
    }

    ///
    /// <summary>
    /// Assigns Tab Page Interface reference
    /// </summary>
    /// <param name="_tabInterface"></param>
    public void addTabRef(TabPageInterface tabInterface)
    {
      _tabInterface = tabInterface;
    }

    ///
    /// <summary>
    /// Adds upload target to project.
    /// </summary>
    /// <param name="_strProName">Project's name</param>
    /// <param name="ts">Target settings</param>
    public void addTarget(string strProName, TargetSettings ts)
    {
      _dicProjectList[strProName].addTarget(ts);
      _tabInterface.addSingleTarget(strProName, ts);
    }

    ///
    /// <summary>
    /// Checks to see whether any uploads are taking place.
    /// </summary>
    /// <param name="_strProName">Project's name</param>
    /// <returns>True if an upload is in progress</returns>
    public bool checkActiveAll(string strProName)
    {
      if(_dicProjectList[strProName].isActive() == true)  //Check if Project if currently being uploaded
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
    /// Checks to see if a specific target is uploading.
    /// </summary>
    /// <param name="_strProName">Project's name</param>
    /// <param name="strTarget">Target's IP</param>
    /// <returns>True if active</returns>
    public bool checkActiveSingle(string strProName, string strTarget)
    {
      return _dicProjectList[strProName].isActive(strTarget);
    }
    
    ///
    /// <summary>
    /// Removes old project and creates a new one with updated project settings.
    /// </summary>
    /// <param name="strOldName">Project's old name</param>
    /// <param name="ps">New project settings</param>
    public void editProject(string strOldName, ProjectSettings ps)
    {
      List<TargetSettings> lstTargets = _dicProjectList[strOldName].getTargets();
      removeProject(strOldName);
      newPoject(ps);

      foreach(TargetSettings ts in lstTargets)
      {
        addTarget(ps.ProjectName, ts);
      }
    }

    ///
    /// <summary>
    /// Prepares a list of all the project's targets, then
    /// sends them to be written to file.
    /// </summary>
    /// <param name="proName">Project name</param>
    /// <param name="filePath">Save file location</param>
    /// <returns>True if the export was successful</returns>
    public bool exportIPs(string proName, string filePath)
    {
      List<TargetSettings> lstTS = getTargets(proName);
      ExportIPs exIPs = new ExportIPs(filePath, lstTS);
      bool status = exIPs.writeToFile();
      return status;
    }

    ///
    /// <summary>
    /// Retrieves settings for a given project.
    /// </summary>
    /// <param name="_strProName">Name of the project</param>
    /// <returns>The project's settings</returns>
    public ProjectSettings getProSettings(string strProName)
    {
      return _dicProjectList[strProName].getSettings();
    }

    ///
    /// <summary>
    /// Returns list of targets and their settings for a given project. 
    /// </summary>
    /// <param name="_strProName">Name of the project</param>
    ///<returns>List of targets that belong to the project</returns>
    public List<TargetSettings> getTargets(string strProName)
    {
      if(_dicProjectList.ContainsKey(strProName))
      {
        Project tempProject = _dicProjectList[strProName];
        return tempProject.getTargets();
      }
      else
      {
        return null;
      }
    }

    ///
    /// <summary>
    /// Get list of the project names alread in use.
    /// </summary>
    /// <returns>List of the project names alread in use.</returns>
    public List<string> getProNames()
    {
      List<string> lstNames = new List<string>(_dicProjectList.Keys);
      return lstNames;
    }

    ///
    /// <summary>
    /// Imports IP addresses from text file.
    /// </summary>
    /// <param name="filePath">Path of file</param>
    /// <param name="usedTarget">Target whose settings will be used for the import</param>
    /// <param name="proName">Project name</param>
    /// <returns></returns>
    public bool importIPFile(string filePath, string usedTarget, string proName)
    {
      List<TargetSettings> lstTS = _dicProjectList[proName].importIPFile(filePath, usedTarget);

      if(lstTS != null)
      {
        foreach(TargetSettings ts in lstTS)
        {
          this._dicProjectList[proName].addTarget(ts);
        }
        _tabInterface.addMultipleTargets(proName, lstTS);
        return true;
      }
      else
      {
        return false;
      }
    }

    ///
    /// <summary>
    /// Creates a new project and adds it to the project list. 
    /// </summary>
    /// <param name="pSettings"> Project Settings to be used </param>
    public void newPoject(ProjectSettings proSettings)
    {
      string strProName = proSettings.ProjectName;

      if(_dicProjectList.ContainsKey(strProName) == false)
      {
        _dicProjectList.Add(strProName, new Project(proSettings, _tabInterface));     //Adds the project name and object to list
        _tabInterface.addTab(proSettings);
      }
      else
      {
        //Project already exists
        throw new Exception();
      }
    }

    ///
    /// <summary>
    /// Loads project from file.  Including settings and targets.
    /// </summary>
    /// <param name="strFilePath">File path of file to load</param>
    public void openProject(string strFilePath)
    {
      try
      {
        Project loadedPro = OpenProject.loadProject(strFilePath);
        ProjectSettings ps = loadedPro.getSettings();

        if(this._dicProjectList.ContainsKey(ps.ProjectName))
        {
          throw new System.ApplicationException(ps.ProjectName);
        }
        else
        {
          newPoject(ps);
          List<TargetSettings> lstTS = loadedPro.getTargets();

          foreach(TargetSettings ts in lstTS)
          {
            addTarget(ps.ProjectName, ts);
          }
        }
      }
      catch(System.NullReferenceException)
      {
        throw;
      }
    }

    ///
    /// <summary>
    /// Removes project from lists.
    /// </summary>
    /// <param name="_strProName">Project name</param>
    public void removeProject(string strProName)
    {
      if(_dicProjectList.ContainsKey(strProName))
      {
        stopUpload(strProName, "");
        _dicProjectList.Remove(strProName);
      }
      _tabInterface.removeTab(strProName);
    }

    ///
    /// <summary>
    /// Removes target from the project.
    /// Stops upload if active and removes from project's target list.
    /// </summary>
    /// <param name="_strProName">Project name</param>
    public void removeTarget(string strProName)
    {
      string strTarget = _tabInterface.removeSelectedTarget(strProName);

      if(strTarget != "")
      {
        stopUpload(strProName, strTarget);
        _dicProjectList[strProName].removeTarget(strTarget);
      }
    }

    ///
    /// <summary>
    /// Saves current project to file.
    /// </summary>
    /// <param name="strCurProject">Project name</param>
    /// <param name="strFilePath">File path to save the file to</param>
    public void saveProject(string strProName, string strFilePath)
    {
      SaveProject.SaveToFile(_dicProjectList[strProName], strFilePath);
    }

    ///
    /// <summary>
    /// Start single or all uploads.
    /// </summary>
    /// <param name="_strProName">Project name</param>
    /// <param name="strTarget">Target IP address</param>
    public void startUpload(string strProName, string strTarget)
    {
      _tabInterface.startUpload(strProName, strTarget);
      _dicProjectList[strProName].startUpload(strTarget);
    }

    ///
    /// <summary>
    /// Stops all or single upload.
    /// </summary>
    /// <param name="_strProName">Project name</param>
    /// <param name="strTarget">Target IP address</param>
    public void stopUpload(string strProName, string strTarget)
    {
      if(_dicProjectList[strProName].isActive() == true)
      {
        _dicProjectList[strProName].stopUpload(strTarget);
        _tabInterface.OnProcessStop(new ProcessEventArgs(strProName, strTarget));    //Raises Stop Process flags
      }
    }

    ///
    /// <summary>
    /// Method used to start the test connection status Thread.
    /// Makes a series of calls to test the connection on the server.
    /// </summary>
    /// <param name="_ts"> TargetInfo of an individual target </param>
    private void testAllTargets(object targetSettings)
    {
      ThreadObject tObj = (ThreadObject)targetSettings;
      string strProName = tObj.StrProName;
      TargetSettings ts = tObj.Ts;
      string strTarget = ts.TargetServer;
      CheckConnection cc = new CheckConnection(ts);

      if(cc.pingConnections() == true)
      {
        _tabInterface.updateStatus(strProName, strTarget, "Testing FTP Settings");

        if(cc.checkFTP() == true)
        {
          _tabInterface.updateStatus(strProName, strTarget, "Retrieving Site Name");

          if(cc.checkSiteName() == true)
          {
            _tabInterface.updateStatus(strProName, strTarget, "Ready");
          }
          else
          {
            _tabInterface.updateStatus(strProName, strTarget, "Could not retrieve site name");
          }

        }
        else
        {
          _tabInterface.updateStatus(strProName, strTarget, "FTP settings error");
        }
      }
      else
      {
        _tabInterface.updateStatus(strProName, strTarget, "Could not contact server");  //Target IP is not reachable, set status to 'Connection Failed'
      }
    }

    ///
    /// <summary>
    /// Tests the connectivity of a project's targets
    /// </summary>
    /// <param name="_strProName">Project name</param>
    public void testConnections(string strProName)
    {
      List<TargetSettings> targetList = getTargets(strProName);                //Fetches all IP targets from project

      foreach(TargetSettings ts in targetList)
      {
        _tabInterface.updateStatus(strProName, ts.TargetServer, "Testing");         //Sets status to "Testing"
        ThreadObject tObj = new ThreadObject(strProName, ts);
        Thread thread = new Thread(testAllTargets);                               //Creates a Thread for every target
        thread.Start(tObj);
      }
    }

  }
}
