
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace NathanUpload
{
  /// <summary>
  /// Sets up the wput process and sends the output to other classes.
  /// </summary>
  class TargetUpload
  {
    private int _numProcessID;
    private long _numDirectorySize;
    private long _numTotalUploaded;
    private long _numCurrentFileSize;
    private long _numOldBytesDone;
    private string _strProName;
    private string _strTargetServer;

    private ProjectSettings _proSettings;
    private TargetSettings _tSettings;

    public delegate void WputOutputHandler(object sender, OutputEventArgs e);       //Delegate used for the wput output event
    private WputOutputHandler wputOutput;

    public delegate void ProcessCompleteHandler(object sender, ProcessEventArgs e);
    private ProcessCompleteHandler processComplete;

    public delegate void ProcessExitHandler(object sender, ProcessEventArgs e);     //Delegate used to signal the process upload for a particular project has ended
    private ProcessExitHandler processExit;

    public delegate void ProcessStoppedHandler(object sender, ProcessEventArgs e);
    private ProcessStoppedHandler processStop;

    public delegate void ProcessErrorHandler(object sender, ProcessErrorEventArgs e);
    private ProcessErrorHandler processError;

    /// 
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="proSettings">Project's settings</param>
    /// <param name="ts">Target's settings</param>
    /// <param name="tabInt">Reference to TabPage Interface</param>
    public TargetUpload(ProjectSettings proSettings, TargetSettings ts, TabPageInterface tabInt)
    {
      _proSettings = proSettings;
      _strProName = proSettings.ProjectName;
      _tSettings = ts;
      DirectoryInfo d = new DirectoryInfo(proSettings.SourcePath);
      _numDirectorySize = this.dirSize(d);                        //Finds size of the directory
      WputOutput += new WputOutputHandler(tabInt.OnUpdateProgress);
      ProcessStop += new ProcessStoppedHandler(tabInt.OnProcessStopEvent);
      ProcessError += new ProcessErrorHandler(tabInt.OnProcessErrorEvent);
      _strTargetServer = _tSettings.TargetServer;
    }
    
    /// 
    /// <summary> 
    /// Retreives unique process ID wput upload </summary>
    /// <returns>Process ID</returns>
    public int getProcessID()
    {
      return _numProcessID;
    }

    /// 
    /// <summary>
    /// Starts wput.exe and provides all the command line arguments.
    /// </summary>
    public void startProcess()
    {
      _numTotalUploaded = 0;                                                  //Initialise variable
      _numCurrentFileSize = 0;
      string strArguments = createArgument();
      Process pr = new Process();                                                 //Create a new Process
      pr.StartInfo.FileName = @"wput.exe";                                        //The file wanted to run
      pr.StartInfo.Arguments = strArguments;                                      //Give process command line arguments
      pr.StartInfo.RedirectStandardOutput = true;
      pr.StartInfo.UseShellExecute = false;
      pr.StartInfo.CreateNoWindow = true;                                         //Removes black DOS window
      pr.EnableRaisingEvents = true;                                              //Enables Exit event to be rasied
      pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
      pr.OutputDataReceived += new DataReceivedEventHandler(OnDataReceived);      //Whenever data is received, pass it to method
      pr.ErrorDataReceived += new DataReceivedEventHandler(OnDataReceived);
      pr.Exited += new EventHandler(OnProcessExit);
      pr.Start();                                                                 //Start process
      _numProcessID = pr.Id;                                                  //Adds the target address and Process ID (PID) to list
      pr.BeginOutputReadLine();
      pr.WaitForExit();
      Console.WriteLine("Dir size: " + this._numDirectorySize);
      Console.WriteLine("Upload size: " + this._numTotalUploaded);

    }

    ///
    /// <summary>
    /// Creates a command line argument for the wput.exe using project and target settings.
    /// </summary>
    /// <returns>Command line argument</returns>
    private string createArgument()
    {
      string strQuotes = "\"";

      string strBasename = "--basename=" + strQuotes + this.getBasename(this._proSettings.SourcePath) + strQuotes + "\\";
      string strFoldlerPath = strQuotes + this._proSettings.SourcePath + strQuotes;                        //Folder path surrounded by quotes
      string strTarget = "ftp://" + this._tSettings.UserName + ":" + this._tSettings.UserPassword + "@"
                                  + this._tSettings.TargetServer
                                  + this._tSettings.DestinationFolder;

      if((_proSettings.CommandLine != "") && (_proSettings.CommandLine != null))
      {
        string strArguments = _proSettings.CommandLine + " "
                     + strBasename + " "
                     + strFoldlerPath + " "
                     + strTarget;
        return strArguments;
      }
      else
      {
        string strUploadRate = "";
        string strContinue = "";
        string strProxyName = "";
        string strProxyPass = "";

        if(this._tSettings.UploadRate != 0)
        {
          strUploadRate = "--limit−rate=" + this._tSettings.UploadRate.ToString() + "K ";
        }

        if(this._proSettings.Interrupt == false)
        {
          strContinue = "--dont−continue" + " ";
        }

        if((_proSettings.ProxyName != "") && (_proSettings.ProxyName != null))
        {
          strProxyName = "−−proxy-user=" + _proSettings.ProxyName;
        }

        if((_proSettings.ProxyPass != "") && (_proSettings.ProxyPass != null))
        {
          strProxyPass = "−−proxy-pass=" + _proSettings.ProxyPass;
        }



        string strArguments = strUploadRate     //Prepare command line arguments
                            + strContinue
                            + "--verbose "
                            + strProxyName + " "
                            + strProxyPass + " "
                            + strBasename + " "
                            + strFoldlerPath + " "
                            + strTarget;

        return strArguments;
      }
    }

    /// 
    /// <summary>
    /// Finds the size of the current file being uploaded.
    /// </summary>
    /// <param name="e"></param>
    private void dataContainsLength(DataReceivedEventArgs e)
    {
      int beginBytes = e.Data.IndexOf(":") + 2;           //Beginning of bytes       
      string strBytes = e.Data.Substring(beginBytes);     //Substring with bytes at the beginning                       

      if(strBytes.Contains("["))                          //If resuming to upload file.
      {
        int endBytes = strBytes.IndexOf("[");           //Find index of end of bytes
        strBytes = strBytes.Substring(0, endBytes);     //Extract the bytes
      }

      strBytes = strBytes.Replace(",", "");               //Remove commas
      long numBytes = long.Parse(strBytes);               //Convert string to long
      _numCurrentFileSize = numBytes;                     //Sets current file size
    }

    /// 
    /// <summary>
    /// Finds the size of the folder to be uploaded.
    /// </summary>
    /// <param name="d">Directory information</param>
    /// <returns>Sie of folder/directory</returns>
    private long dirSize(DirectoryInfo d)
    {
      long size = 0;
      FileInfo[] fis = d.GetFiles();              // Add file sizes.

      foreach(FileInfo fi in fis)
      {
        size += fi.Length;
      }

      DirectoryInfo[] dis = d.GetDirectories();   // Add subdirectory sizes.

      foreach(DirectoryInfo di in dis)
      {
        size += dirSize(di);
      }

      return (size);
    }

    /// 
    /// <summary>
    /// Removes any remaining bytes from the total bytes when a file has completed it's
    /// upload.
    /// </summary>
    /// <param name="e">Line of data that contains the complete file size</param>
    private void fileComplete(DataReceivedEventArgs e)
    {
      if(((_numCurrentFileSize - _numOldBytesDone) > 0) && (_numOldBytesDone != 0))  //If there are any remaining bytes from the current file that have yet to be added the total
      {
        long difference = this._numCurrentFileSize - this._numOldBytesDone;               //Remaining differnece, if any
        _numTotalUploaded += difference;                                            //Add difference to total
        long numPercentageDone = getPercentageDone();                                   //Get overall percentage done
        wputOutput(this, new OutputEventArgs(_strProName, _strTargetServer, numPercentageDone, ""));  //Raise event
        _numOldBytesDone = 0;                                                       //Reset Old bytes - because the file is complete i.e. there is no resuming to be done for this file
      }
      else                                                                              //If the file is small and was uploaded in one go.
      {
        int beginIndex = e.Data.IndexOf("[") + 1;
        int endIndex = e.Data.IndexOf("]");
        int length = endIndex - beginIndex;
        string strBytes = e.Data.Substring(beginIndex, length);
        strBytes = strBytes.Replace(",", "");
        _numTotalUploaded += long.Parse(strBytes);
        long numPercentageDone = getPercentageDone();
        wputOutput(this, new OutputEventArgs(_strProName, _strTargetServer, numPercentageDone, ""));
      }
    }

    /// 
    /// <summary>
    /// Finds percentage of total upload
    /// </summary>
    /// <param name="e"></param>
    private void filePercentage(DataReceivedEventArgs e)
    {
      int endIndex = e.Data.IndexOf("%");
      int beginIndex = endIndex - 3;
      string percentDone = e.Data.Substring(beginIndex, endIndex - beginIndex);   //Extract % from string
      percentDone = percentDone.TrimStart();                                      //Remove spaces from string
      long currentFileBytesDone = getBytesDone(percentDone);                      //Number of bytes 
      long difference = currentFileBytesDone - _numOldBytesDone;                   //numOldBytes has already been added to the total.  So, find bytes that has been completed for this file, minus the bytes that have already been added, add the difference to the running total
      _numTotalUploaded += difference;                                        //Adds progress to total upload
      long numPercentageDone = getPercentageDone();                               //Gets overall progress
      _numOldBytesDone = currentFileBytesDone;                                //Sets most recent file percentage reading to numOldProgress
      string speed = findSpeed(e.Data);                                           //Gets current upload speed
      wputOutput(this, new OutputEventArgs(_strProName, _strTargetServer, numPercentageDone, speed));                      //Sends total upload percentage to event subscribers
    }

    /// 
    /// <summary>
    /// When continuing from an interrupted transfer.  Counts all the 
    /// bytes that have already been uploaded
    /// </summary>
    /// <param name="e"></param>
    private void filePrevioulyDone(DataReceivedEventArgs e)
    {
      int beginIndex = e.Data.IndexOf("done (") + 6;              //Index of beginning of bytes
      int endIndex = e.Data.IndexOf("bytes") - 1;                 //Index of end of bytes
      int length = endIndex - beginIndex;                         //Length of string of bytes
      string strBytes = e.Data.Substring(beginIndex, length);     //Extraction of bytes
      strBytes = strBytes.Replace(",", "");                       //Remove, if any, commas
      _numTotalUploaded += long.Parse(strBytes);              //Add bytes to total number done
      _numOldBytesDone = long.Parse(strBytes);                //Set current file size to numOldBytes.  Needed if in the following data the file is to be resumed to be uploaded
      long numPercentageDone = getPercentageDone();               //Get percenetage of complete upload
      wputOutput(this, new OutputEventArgs(_strProName, _strTargetServer, numPercentageDone, ""));               //Raise wputOutput event
    }

    /// 
    /// <summary>
    /// Extracts the upload speed from the wput data output.
    /// </summary>
    /// <param name="strData">Line of data that contains the speed</param>
    /// <returns>Upload speed</returns>
    private string findSpeed(string strData)
    {
      if(strData.Contains("null"))
      {
        return "";
      }

      int beginIndex = strData.LastIndexOf("%") + 2;
      return strData.Substring(beginIndex);
    }

    private string getBasename(string strFolderPath)
    {
      int lastBackSlash = strFolderPath.LastIndexOf(@"\");            //Find the Folder name only
      string strBasename = strFolderPath.Substring(0, lastBackSlash);
      return strBasename;
    }

    /// 
    /// <summary>
    /// Finds number of bytes that have been uploaded
    /// </summary>
    /// <param name="strPercentDone"></param>
    /// <returns>Number of bytes uploaded</returns>
    private long getBytesDone(string strPercentDone)
    {
      decimal percentage = decimal.Parse(strPercentDone);
      decimal total = this._numCurrentFileSize;
      decimal done = (percentage / 100) * total;
      return (long)done;
    }

    ///
    /// <summary>
    /// Finds percentage of total upload
    /// </summary>
    /// <returns>Percentage of completed upload</returns>
    private long getPercentageDone()
    {
      decimal done = this._numTotalUploaded;
      decimal total = this._numDirectorySize;
      decimal percentage = (done / total) * 100;
      return (long)percentage;
    }

    ///
    /// <summary>
    /// Used to print out the cmd data from the wput process.
    /// Sends data to the WputOutputHandler.
    /// </summary>
    private void OnDataReceived(object sender, DataReceivedEventArgs e)
    {
      if(e.Data != null)                                                                      //Check for null condition as this creates an NullReferenceException
      {
        Console.WriteLine(e.Data);
        if(wputOutput != null)
        {
          if(e.Data.Contains("done") && e.Data.Contains("bytes") && e.Data.Contains("SIZE"))  //Extract bytes already completed  //Unfortunately, If the files themselves contain any of these words, won'stopBtnTimer work  
          {
            filePrevioulyDone(e);
          }
          else if(e.Data.Contains("Length:"))   //Finds the file size of the file currently being uploaded
          {
            dataContainsLength(e);
          }
          else if(e.Data.Contains("K") && e.Data.Contains("%"))   //Find percentage done.  Charaters found in wput upload progress bar.  31950K .......... .......... .......... .......... ..........  99%  3.86 MiB/s
          {
            filePercentage(e);
          }
          else if((e.Data.Contains("[") && e.Data.Contains("]")) && (e.Data.Contains("to go") == false) && (e.Data.Contains("skipped") == false))   //The current upload is complete.  Remove any extra bytes from total.  10:33:15 (stopBtnTimer.pdf) - ` 5.16M/s' [86629]
          {
            fileComplete(e);
          }
          else if(e.Data.Contains("FINISHED --"))     //Just to make sure no bytes were missed in the calculations.  FINISHED --10:33:16--
          {
            processComplete(this, new ProcessEventArgs(_strProName, _strTargetServer));
            wputOutput(this, new OutputEventArgs(_strProName, _strTargetServer, 100, ""));
          }
        }
      }
    }

    /// 
    /// <summary>
    /// Used to tell event subscribers that the process has finished.
    /// The information will then be used to remove the object from the
    /// uploadsession list in ProjectInterface.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnProcessExit(object sender, EventArgs e)
    {
      if(processExit != null)
      {
        processExit(this, new ProcessEventArgs(_strProName, _strTargetServer));
      }
    }

    /// 
    /// <summary>
    /// Used to remove the absolute filepath, including drive letter.
    /// Used with the basename argument for wput.
    /// </summary>
    /// <param name="strFolderPath">Folder path</param>
    /// <returns>Folder's relative file path (exclude parent path)</returns>

    /// 
    /// <summary>
    /// Used to tell event subscribers that the process has finished.
    /// The information will then be used to remove the object from the
    /// uploadsession list in ProjectInterface.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnProcessError(object sender, EventArgs e)
    {
      if(processError != null)
      {
        processError(this, new ProcessErrorEventArgs(_strProName, "An Error Has Occurred"));
      }
    }


    public event WputOutputHandler WputOutput
    {
      add
      {
        wputOutput += value;
      }
      remove
      {
        wputOutput -= value;
      }
    }

    public event ProcessErrorHandler ProcessError
    {
      add
      {
        processError += value;
      }
      remove
      {
        processError -= value;
      }
    }

    public event ProcessExitHandler ProcessExit
    {
      add
      {
        processExit += value;
      }
      remove
      {
        processExit -= value;
      }
    }

    public event ProcessCompleteHandler ProcessComplete
    {
      add
      {
        processComplete += value;
      }
      remove
      {
        processComplete -= value;
      }
    }

    public event ProcessStoppedHandler ProcessStop
    {
      add
      {
        processStop += value;
      }
      remove
      {
        processStop -= value;
      }
    }


  }
}
