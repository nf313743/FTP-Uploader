using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace NathanUpload
{
  [Serializable()]
  public class TargetSettings : ICloneable
  {
    private string targetServer;
    private string destinationFolder;
    private string rootPath;
    private string userName;
    private string userPassword;
    private decimal uploadRate;
    private string community;

    /// <summary>
    /// Empty default constructor
    /// </summary>
    public TargetSettings()
    {
    }


    public object Clone()
    {
      return this.MemberwiseClone();
    }

    /// <summary>
    /// Constructor for Serialization.  Used to load an object from file.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public TargetSettings(SerializationInfo info, StreamingContext ctxt)
    {
      this.targetServer = (string)info.GetValue("targetServer", typeof(string));
      this.destinationFolder = (string)info.GetValue("destinationFolder", typeof(string));
      this.rootPath = (string)info.GetValue("rootPath", typeof(string));
      this.userName = (string)info.GetValue("userName", typeof(string));
      this.userPassword = (string)info.GetValue("userPassword", typeof(string));
      this.uploadRate = (decimal)info.GetValue("uploadRate", typeof(decimal));
      this.community = (string)info.GetValue("community", typeof(string));
    }

    /// <summary>
    /// Used during serialization.  Stores variable values to corresponding string value.
    /// </summary>
    /// <param name="info"></param>
    /// <param name="ctxt"></param>
    public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
    {
      info.AddValue("targetServer", this.targetServer);
      info.AddValue("destinationFolder", this.destinationFolder);
      info.AddValue("rootPath", this.rootPath);
      info.AddValue("userName", this.userName);
      info.AddValue("userPassword", this.userPassword);
      info.AddValue("uploadRate", this.uploadRate);
      info.AddValue("community", this.community);
    }

    public string TargetServer
    {
      get { return targetServer; }
      set { targetServer = value; }
    }

    public string DestinationFolder
    {
      get { return destinationFolder; }
      set { destinationFolder = value; }
    }

    public string RootPath
    {
      get { return rootPath; }
      set { rootPath = value; }
    }

    public string UserName
    {
      get { return userName; }
      set { userName = value; }
    }

    public string UserPassword
    {
      get { return userPassword; }
      set { userPassword = value; }
    }

    public decimal UploadRate
    {
      get { return uploadRate; }
      set { uploadRate = value; }
    }

    public string Community
    {
      get { return community; }
      set { community = value; }
    }

  }
}
