
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace NathanUpload
{
  /// <summary>
  /// Class contains a static method to open project objects from file.
  /// </summary>
  class OpenProject
  {
    ///
    /// <summary>
    /// Loads the Prjoect object, along with settings and upload folders, from file.
    /// </summary>
    /// <param name="strFilePath">File path of the saved file</param>
    /// <returns>Loaded Project object</returns>
    public static Project loadProject(string strFilePath)
    {
      try
      {
        Stream stream = File.Open(strFilePath, FileMode.Open);              //Open stream
        BinaryFormatter bformatter = new BinaryFormatter();                 //Create new binary formatter
        Project loadedProject = (Project)bformatter.Deserialize(stream);    //Deserialize stream to Project object
        stream.Close();                                                     //Close stream
        return loadedProject;
      }
      catch(Exception ex)
      {
        Console.Write(ex.ToString());
        return null;
      }
    }
  }
}
