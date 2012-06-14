using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NathanUpload
{
  /// <summary>
  /// ControlExtensions.cs
  /// 
  /// This class is used for cross-thread communication.  Checks to see
  /// if communication between two different threads is safe.
  /// </summary>
  public static class ControlExtensions
  {
    public static void SafeInvoke(this Control control, Action action)
    {
      if(control.InvokeRequired)
      {
        control.Invoke(action);
      }
      else
      {
        action();
      }
    }


    public static void SafeBeginInvoke(this Control control, Action action)
    {
      if(control.InvokeRequired)
      {
        control.BeginInvoke(action);
      }
      else
      {
        action();
      }
    }
  }
}
