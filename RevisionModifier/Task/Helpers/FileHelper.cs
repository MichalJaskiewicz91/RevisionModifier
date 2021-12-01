using System;
using Microsoft.Win32;

namespace Task.Helpers
{
    /// <summary>
    /// A class that helps file handling.
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// Allows the operator to select a file from the disk.
        /// </summary>
        /// <returns></returns>
        public static string SelectXMLFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Please select a XML file with workplans"
            };
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            else return String.Empty;
        }
    }
}
