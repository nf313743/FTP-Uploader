using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NathanUpload
{
  /// <summary>
  /// Saves project to file.
  /// </summary>
  class SaveProject
  {
    /// 
    /// <summary>
    /// Saves project to file
    /// </summary>
    /// <param name="project">Project object</param>
    /// <param name="strPath">File path to save the project</param>
    public static void SaveToFile(Project project, string strPath)
    {
      try
      {
        Stream stream = File.Open(strPath, FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Serialize(stream, project);
        stream.Close();
      }
      catch(Exception)
      {
        //TODO
      }
    }

  }
}
