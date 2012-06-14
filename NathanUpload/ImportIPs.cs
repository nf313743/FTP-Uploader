using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace NathanUpload
{
  /// <summary>
  /// Imports IP addresses from a text file.  An existing target must be selected before
  /// import as it's settings are used for the imported IP's settings.
  /// </summary>
  class ImportIPs
  {
    private string _strFilePath;                 //File path
    private List<string> _lstAllIPs;             //IP address already used by the project
    private List<TargetSettings> _lstTargets;    //List of new targets
    private TargetSettings _ts;                  //Settings to be copied to every new IP

    ///
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="tsettings">Settings to be copied to every new IP</param>
    /// <param name="strFilePath">File path</param>
    /// <param name="lstAllIPs">IP address already used by the project</param>
    public ImportIPs(TargetSettings tsettings, string strFilePath, List<string> lstAllIPs)
    {
      _ts = tsettings;
      _strFilePath = strFilePath;
      _lstAllIPs = lstAllIPs;
      _lstTargets = new List<TargetSettings>();
    }

    ///
    /// <summary>
    /// Returns list of imported IPs and their settings
    /// </summary>
    /// <returns>Imported IPs and their settings</returns>
    public List<TargetSettings> getTargets()
    {
      try
      {
        importFile(this._strFilePath);
        return this._lstTargets;
      }
      catch
      {
        return null;
      }
    }

    ///
    /// <summary>
    /// Checks to see if the IP address is valid and in the correct format.
    /// </summary>
    /// <param name="strLine">IP address</param>
    /// <returns>True if IP address is valid</returns>
    private bool checkValidity(string strLine)
    {
      Regex ipAddress = new Regex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");   //IP address regular expression
      
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
    /// Reads the text file, creates new targets from IP address
    /// and adds them to the list.
    /// </summary>
    /// <param name="strFpath">File path</param>
    private void importFile(string strFpath)
    {
      try
      {
        StreamReader stream = new StreamReader(strFpath);
        string strLine;

        while((strLine = stream.ReadLine()) != null)              //Read line from file
        {
          bool result = checkValidity(strLine);

          if(result == true)
          {
            if(_lstAllIPs.Contains(strLine) == false)              //Checks to see if imported IP is already in use
            {
              TargetSettings temp = new TargetSettings();
              temp.TargetServer = strLine;
              temp.Community = _ts.Community;
              temp.DestinationFolder = _ts.DestinationFolder;
              temp.RootPath = _ts.RootPath;
              temp.UploadRate = _ts.UploadRate;
              temp.UserName = _ts.UserName;
              temp.UserPassword = _ts.UserPassword;
              this._lstTargets.Add(temp);                          //Add to target list
              this._lstAllIPs.Add(strLine);                        //Add to 'IP in use' list
            }
          }
        }
        stream.Close();
      }
      catch
      {
        throw new Exception();
      }
    }

  }
}
