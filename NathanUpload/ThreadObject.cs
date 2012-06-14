using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanUpload
{
  /// <summary>
  /// Thread object used for testing the targets connections
  /// </summary>
  class ThreadObject
  {
    private string strProName;
    private TargetSettings ts;

    public ThreadObject(string strProName, TargetSettings ts)
    {
      this.strProName = strProName;
      this.ts = ts;
    }

    public string StrProName
    {
      get { return strProName; }
      set { strProName = value; }
    }

    public TargetSettings Ts
    {
      get { return ts; }
      set { ts = value; }
    }
  }
}
