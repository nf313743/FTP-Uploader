using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NathanUpload
{
  /// <summary>
  /// Holds the upload project's settings.
  /// </summary>
  [Serializable()]
  public class ProjectSettings
  {
    private string projectName;             //Name of the project
    private string sourcePath;              //Folder path to be uploaded to server/device
    private string proxyName;
    private string proxyPass;
    private bool interrupt;                 //Continue upload after interrupt
    private string commandLine;             //Additional command line options
    private bool advancedEnabled;           //Advanced options selected
    private bool installUpdate;             //Install update automatically after upload

    ///
    /// <summary>
    /// Constructor
    /// </summary>
    public ProjectSettings()
    {

      //Empty
    }

    ///
    /// <summary>
    /// Constructor.  Used for loading a project from file.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public ProjectSettings(SerializationInfo info, StreamingContext ctxt)
    {
      this.projectName = (string)info.GetValue("projectName", typeof(string));
      this.sourcePath = (string)info.GetValue("sourcePath", typeof(string));
      this.interrupt = (bool)info.GetValue("interrupt", typeof(bool));
      this.commandLine = (string)info.GetValue("commandLine", typeof(string));
      this.advancedEnabled = (bool)info.GetValue("advancedEnabled", typeof(bool));
    }
    
    /// 
    /// <summary>
    ///  Used during serialization.  Stores variable values to corresponding string value.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
      info.AddValue("projectName", this.projectName);
      info.AddValue("projectName", this.sourcePath);
      info.AddValue("interrupt", this.interrupt);
      info.AddValue("commandLine", this.commandLine);
      info.AddValue("advancedEnabled", this.advancedEnabled);
    }

    public string ProjectName
    {
      get { return projectName; }
      set { projectName = value; }
    }

    public string SourcePath
    {
      get { return sourcePath; }
      set { sourcePath = value; }
    }

    public string ProxyName
    {
      get { return proxyName; }
      set { proxyName = value; }
    }

    public string ProxyPass
    {
      get { return proxyPass; }
      set { proxyPass = value; }
    }

    public bool Interrupt
    {
      get { return interrupt; }
      set { interrupt = value; }
    }

    public string CommandLine
    {
      get { return commandLine; }
      set { commandLine = value; }
    }

    public bool AdvancedEnabled
    {
      get { return advancedEnabled; }
      set { advancedEnabled = value; }
    }

    public bool InstallUpdate
    {
      get { return installUpdate; }
      set { installUpdate = value; }
    }
  }
}
