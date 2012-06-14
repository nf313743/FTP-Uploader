using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SnmpSharpNet;

namespace NathanUpload
{
  class SNMPFunctions
  {
    ///
    /// <summary>
    /// Finds the site name of the SNMP Agent.  If site name is retreived, then SNMP commands can be issued.
    /// First tries a DVM command, then if it is not DVM, uses a DVMS command to see if it is instead a DVMS device.
    /// </summary>
    /// <param name="strHost">IP address</param>
    /// <param name="strComm">Community String</param>
    /// <returns>SNMP agent's Site Name</returns>
    public static string getSiteName(string strHost, string strComm)
    {
      SimpleSnmp snmp = new SimpleSnmp(strHost, strComm);

      if(!snmp.Valid)
      {
        return null;
      }

      Dictionary<Oid, AsnType> resultDVM = snmp.Get(SnmpVersion.Ver1, new string[] {".1.3.6.1.4.1.2566.127.1.1.157.3.1.1.1.0"});

      if(resultDVM != null)
      {
        foreach(KeyValuePair<Oid, AsnType> kvp in resultDVM)
        {
          return kvp.Value.ToString();
        }
      }

      //Now tries DVMS command
      Dictionary<Oid, AsnType> resultDVMs = snmp.Get(SnmpVersion.Ver1, new string[] { ".1.3.6.1.4.1.2566.127.1.1.152.3.1.1.1.0" });

      if(resultDVMs != null)
      {
        foreach(KeyValuePair<Oid, AsnType> kvp in resultDVMs)
        {
          return kvp.Value.ToString();
        }
      }
      return null;
    }

    /// 
    /// <summary>
    /// Executes the installation process on the SNMP agent.
    /// </summary>
    /// <param name="ts">Target's settings</param>
    /// <param name="uploadFolder">Path of folder with exe update within it</param>
    /// <returns>True if installation was executed successfully</returns>
    public static bool setExecute(TargetSettings ts, string uploadFolder)
    {
      SimpleSnmp snmp = new SimpleSnmp(ts.TargetServer, ts.Community);

      if(!snmp.Valid)
      {
        return false;
      }

      string d = ts.DestinationFolder.Substring(1);
      int i = uploadFolder.LastIndexOf("\\") + 1;
      string relativePath = uploadFolder.Substring(i);
      string destination = d.Replace("/", "\\");
      string batFile = ts.RootPath + destination + relativePath + "\\UpdateVersion.bat";

      Dictionary<Oid, AsnType> result = snmp.Set(SnmpVersion.Ver2,
                                                    new Vb[] { 
                                                    new Vb(new Oid("1.3.6.1.4.1.2566.127.1.1.157.3.1.1.10.0"), 
                                                           new OctetString(batFile))});
      
      if(result != null)
      {
        return true;
      } 
      return false;
    }
  }
}
