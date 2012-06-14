using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace NathanUpload
{
  class ExportIPs
  {
    private string filePath;
    private List<TargetSettings> lstTsettings;

    ///
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="fPath">File path to save to</param>
    /// <param name="lstTs">List of project's targets</param>
    public ExportIPs(string fPath, List<TargetSettings> lstTs)
    {
      this.filePath = fPath;
      this.lstTsettings = lstTs;
    }

    ///
    /// <summary>
    /// Writes the IP addresses to file.
    /// </summary>
    /// <returns>
    /// True if the write was successful.  False if there
    /// was and error.
    /// </returns>
    public bool writeToFile()
    {
      try
      {
        StreamWriter file = new StreamWriter(filePath);
        
        foreach(TargetSettings ts in lstTsettings)
        {
          file.WriteLine(ts.TargetServer);
        }
        file.Close();
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}
