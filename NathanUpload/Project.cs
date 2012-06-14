/**
 * Project.cs
 * 
 * Holds the details of the project.  Such as the folder to upload, 
 * settings and target IP addresses.  A project object can be saved to file,
 * thus, it is Serializable.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace NathanUpload
{
  [Serializable()]
  public class Project : ISerializable
  {
    private ProjectSettings _proSettings;     //The project's settings        
    private UploadSession _uploadSession;     //Holds the upload session for the project
    private List<TargetSettings> _lstTargets; //List of all target IPs

    ///
    /// <summary>
    /// Constructor.  
    /// Used for creating a new project.
    /// </summary>
    /// <param name="_proSettings"> The settings to be used by the project </param>
    public Project(ProjectSettings proSettings, TabPageInterface tabInt)
    {
      _proSettings = proSettings;
      _lstTargets = new List<TargetSettings>();
      _uploadSession = new UploadSession(proSettings, tabInt);
    }

    ///
    /// <summary>
    /// Constructor.
    /// Used for loading settings from file.
    /// Get the values from 'info' and assign them to the appropriate properties.
    /// Called automatically when used with BinaryFormatter.Serialize().
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public Project(SerializationInfo info, StreamingContext ctxt)
    {
      this._proSettings = (ProjectSettings)info.GetValue("pSettings", typeof(ProjectSettings));
      this._lstTargets = (List<TargetSettings>)info.GetValue("_lstTargets", typeof(List<TargetSettings>));
    }

    ///
    ///<summary>
    /// Adds a target and it's settings to the project.
    ///</summary>
    ///<param name="_tSettings">
    ///  Information concerning the target server/device 
    ///</param>
    public void addTarget(TargetSettings targetInfo)
    {
      if(_lstTargets.Contains(targetInfo) == false)
      {
        _lstTargets.Add(targetInfo);
      }
    }

    ///
    /// <summary>
    /// Used during serialization.  Stores variable values to corresponding string value.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
      info.AddValue("pSettings", this._proSettings);
      info.AddValue("_lstTargets", this._lstTargets);
    }

    ///
    /// <summary>
    /// Returns project's settings.
    /// </summary>
    /// <returns>Project's settings</returns>
    public ProjectSettings getSettings()
    {
      return _proSettings;
    }

    ///
    /// <summary>
    /// Returns project's targets along with their settings
    /// </summary>
    /// <returns>
    /// Returns list of target IPs for the project 
    /// </returns>
    public List<TargetSettings> getTargets()
    {
      return _lstTargets;
    }

    ///
    /// <summary>
    /// Imports IP addresses from file
    /// </summary>
    /// <param name="filePath">File path of IP txt file</param>
    /// <param name="usedTarget">Target that contains the settings that will be used by the imported addresses</param>
    /// <returns></returns>
    public List<TargetSettings> importIPFile(string filePath, string usedTarget)
    {
      TargetSettings tsToUse = new TargetSettings();
      List<string> lstAllIPs = new List<string>();

      foreach(TargetSettings ts in _lstTargets)
      {
        if(ts.TargetServer == usedTarget)
        {
          tsToUse = ts;                                               //Settings that will be used
        }
        lstAllIPs.Add(ts.TargetServer);
      }
      ImportIPs impIPs = new ImportIPs(tsToUse, filePath, lstAllIPs); //Reads file and creates a list of new targets
      List<TargetSettings> newIPs = impIPs.getTargets();             //Retreives new target list

      try
      {
        foreach(TargetSettings ts in newIPs)
        {
          addTarget(ts);
        }
        return newIPs;    //Only want the new targets
      }
      catch
      {
        return null;
      }
    }
  
    ///
    /// <summary>
    /// Checks whether the project is actively uploading.
    /// </summary>
    /// <returns>True if yes</returns>
    public bool isActive()
    {
      return _uploadSession.isActive();
    }

    ///
    /// <summary>
    /// Checks whether a single target is actively uploading.
    /// </summary>
    /// <param name="strTarget"></param>
    /// <returns></returns>
    public bool isActive(string strTarget)
    {
      return _uploadSession.isActive(strTarget);
    }

    ///
    /// <summary>
    /// Removes target from the project.
    /// </summary>
    /// <param name="strTarget">
    /// Target IP to be removed 
    /// </param>
    public void removeTarget(string strTarget)
    {
      foreach(TargetSettings ti in _lstTargets)    //Loops through list to find correct TargetInfo entry
      {
        if(ti.TargetServer == strTarget)
        {
          _lstTargets.Remove(ti);
          return;
        }
      }
    }

    ///
    /// <summary>
    /// Starts either all or single target upload.
    /// </summary>
    /// <param name="strTarget">Target address, if any</param>
    public void startUpload(string strTarget)
    {
      _uploadSession.startUpload(_lstTargets, strTarget);
    }

    ///
    /// <summary>
    /// Stops target(s) from uploading.
    /// </summary>
    /// <param name="strTarget">Desired target, if any</param>
    public void stopUpload(string strTarget)
    {
      if(strTarget != "")
      {
        _uploadSession.stopSingleProcess(strTarget); //Kills desired wput.exe process
      }
      else
      {
        _uploadSession.stopAllProcesses();     //Kills all process in that Project
      }
    }

  }
}
