using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Net;

namespace NathanUpload
{
  /// <summary>
  /// Performs three different connections checks:
  /// 1. Ping
  /// 2. FTP
  /// 3. Site name
  /// 
  /// Program will only upload files if the sitename for a 
  /// target server has been successfully retreived.
  /// </summary>
  class CheckConnection
  {
    private TargetSettings ts;

    ///
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="_ts">Target Settings to test</param>
    public CheckConnection(TargetSettings ts)
    {
      this.ts = ts;
    }

    ///
    /// <summary>
    /// Checks if server address is available.
    /// </summary>
    /// <returns> 
    ///  True if IP adress is successfully pinged.  
    ///  False otherwise.
    /// </returns>
    public bool pingConnections()
    {
      try
      {
        Ping pingSender = new Ping();
        PingReply reply = pingSender.Send(ts.TargetServer, 4); //Ping address

        if(reply.Status == IPStatus.Success)                  //Check if address is available
        {
          return true;
        }
        else
        {
          return false;
        }
      }
      catch(Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex);
        return false;
      }
    }

    ///
    /// <summary>
    ///  Checks to see if FTP credentials are valid.
    /// </summary>
    /// <returns>
    ///  True if FTP credentials are valid.
    ///  False otherwise.
    /// </returns>
    public bool checkFTP()
    {
      try
      {
        string ftp = "ftp://" + ts.TargetServer + "/";
        FtpWebRequest requestDir = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftp));
        requestDir.Credentials = new NetworkCredential(ts.UserName, ts.UserPassword);
        requestDir.Method = WebRequestMethods.Ftp.ListDirectory;
        requestDir.Timeout = 6000;

        FtpWebResponse response = (FtpWebResponse)requestDir.GetResponse();
        response.Close();
        return true;
      }
      catch(Exception ex)
      {
        System.Diagnostics.Debug.WriteLine(ex);
        return false;
      }
    }

    ///
    /// <summary>
    /// Retreives the sitename of the SNMP agent.
    /// </summary>
    /// <returns>
    /// True if the site name can be retreived.
    /// False otherwise.
    /// </returns>
    public bool checkSiteName()
    {
      string strSiteName = SNMPFunctions.getSiteName(ts.TargetServer, ts.Community);

      if(strSiteName != null)
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
    /// Calls of the connection testings methods.
    /// </summary>
    /// <returns>
    /// True if all of the connection test were successful.
    /// Otherwise, False.
    /// </returns>
    public bool testAll()
    {
      string strTarget = ts.TargetServer;
      if(pingConnections() == true)
      {
        if(checkFTP() == true)
        {
          if(checkSiteName() == true)
          {
            return true;
          }
        }
      }
      return false;
    }

  }
}
