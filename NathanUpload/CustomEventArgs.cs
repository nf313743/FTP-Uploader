using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanUpload
{
  public class OutputEventArgs : EventArgs
  {
    public readonly string strProName;
    public readonly string strTarget;
    public readonly long percent;
    public readonly string strSpeed;

    public OutputEventArgs(string strProName, string strTarget, long percent, string strSpeed)
    {
      this.strProName = strProName;
      this.strTarget = strTarget;
      this.percent = percent;
      this.strSpeed = strSpeed;
    }
  }

  public class ProcessEventArgs : EventArgs
  {
    public readonly string strTarget;
    public readonly string strProject;
    private string _strProName;

    public ProcessEventArgs(string strProject, string strTarget)
    {
      this.strProject = strProject;
      this.strTarget = strTarget;
    }

    public ProcessEventArgs(string _strProName)
    {
      // TODO: Complete member initialization
      this._strProName = _strProName;
    }
  }

  public class ProcessErrorEventArgs : EventArgs
  {
 
    public readonly string strProject;
    public readonly string msg;

    public ProcessErrorEventArgs(string strProject, string msg)
    {
      this.strProject = strProject;
      this.msg = msg;
    }
  }


  public class ConnectionEventArgs : EventArgs
  {
    public readonly string strTarget;
    public readonly string strMsg;

    public ConnectionEventArgs(string strTarget, string strMsg)
    {
      this.strTarget = strTarget;
      this.strMsg = strMsg;
    }
  }

}

