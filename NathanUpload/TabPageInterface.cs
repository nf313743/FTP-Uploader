using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NathanUpload
{
  public class TabPageInterface
  {
    Dictionary<string, cTabPage> _dicTabPages; //Holds references to all active TabPages for a project
    ProjectInterface _proInter;
    Main _Main;

    public TabPageInterface(Main Main)
    {
      _Main = Main;
      _dicTabPages = new Dictionary<string, cTabPage>();
    }

    public void addTab(ProjectSettings ps)
    {   
      string strProName = ps.ProjectName;                                 //Sets currently selected tab to this new tab
      cTabPage tabPage = new cTabPage(strProName, this);
      _dicTabPages.Add(strProName, tabPage);
      _dicTabPages[strProName].updateSettings(ps);                         //Updates/Adds project settings to tab
      List<TargetSettings> lstTargets = _proInter.getTargets(strProName);  //Fetchs, if any, upload target addresses

      if(lstTargets.Count > 0)                                            //If Uploadfolders exist, add to tab display
      {
        _dicTabPages[strProName].addMultipleTargets(lstTargets);
      }
      _Main.addTabPage(tabPage);
    }

    public void addTargetEvent()
    {
      _Main.addTarget();
    }

    public void addProRef(ProjectInterface proInterface)
    {
      _proInter = proInterface;
    }

    public cTabPage getTabPage(string strProName)
    {
      return _dicTabPages[strProName];
    }

    public string getSelectedIP(string strProName)
    {
      return _dicTabPages[strProName].getSelectIP();
    }

    public void addSingleTarget(string proName, TargetSettings ts)
    {
      _dicTabPages[proName].addSingleTarget(ts);     //Updates the Listview dispaly with target list
    }

    public void removeTab(string strProName)
    {
      _dicTabPages.Remove(strProName);
    }

    public void startUpload(string strProName, string strTarget)
    {
      if(strTarget == "")
      {
        _dicTabPages[strProName].resetStatus();                //Resets any stopped process status
        _dicTabPages[strProName].updateStatus("", "Working");  //Set status to 'Working' upload operations are being carried out    
      }
      else
      {
        _dicTabPages[strProName].resetStatus();                      //Resets any stopped process status
        _dicTabPages[strProName].updateStatus(strTarget, "Working"); //Set status to 'Working' upload operations are being carried out    
      }
    }

    public void updateStatus(string strProName, string strTarget, string strMsg)
    {
      _dicTabPages[strProName].updateStatus(strTarget, strMsg);
    }

    public void OnProcessStop(ProcessEventArgs e)
    {
      if(_dicTabPages.ContainsKey(e.strProject))
      {
        _dicTabPages[e.strProject].processStopEvent(e);
      }
    }

    public string removeSelectedTarget(string strProName)
    {
      return _dicTabPages[strProName].removeTarget();
    }

    public void stopProcess(string strProName, string strTarget)
    {
      _proInter.stopUpload(strProName, strTarget); 
    }

    public void startProcess(string strProName, string strTarget)
    {
      _proInter.startUpload(strProName, strTarget);
    }

    public void OnUpdateProgress(object sender, OutputEventArgs e)
    {
      if(_dicTabPages.ContainsKey(e.strProName))
      {
        _dicTabPages[e.strProName].updateProgress(e);
      }
    }

    public void OnProcessStopEvent(object sender, ProcessEventArgs e) 
    {
      if(_dicTabPages.ContainsKey(e.strTarget))
      {
        _dicTabPages[e.strTarget].processStopEvent(e);
      }
    }

    public void OnProcessErrorEvent(object sender, ProcessErrorEventArgs e)
    {
      if(_dicTabPages.ContainsKey(e.strProject))
      {
        _dicTabPages[e.strProject].processErrorEvent(e);
      }
    }

    public void removeTarget(string strProName)
    {
      _proInter.removeTarget(strProName);
      _Main.enableTargetButtons();
    }

    public void OnConnectionFail(string strProName, string strTarget, string msg)
    {
      if(_dicTabPages.ContainsKey(strProName))
      {
        _dicTabPages[strProName].connectionFail(strTarget, msg);
      }
    }


    public void editTarget()
    {
      _Main.editTarget();
    }

    public void enableSelectedTargetButtons(bool p)
    {
      _Main.enableSelectedTargetButtons(p);
    }

    public void addMultipleTargets(string proName, List<TargetSettings> lstTS)
    {
      _dicTabPages[proName].addMultipleTargets(lstTS);
    }

    public bool checkIfActive(string strProName, string strTarget)
    {
      return _proInter.checkActiveSingle(strProName, strTarget);
    }
  }
}
