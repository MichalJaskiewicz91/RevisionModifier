using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using Task.Models;

namespace Task.Services
{
    /// <summary>
    /// A class that handles workplans.
    /// </summary>
    public class WorkplanProvider : IWorkplanProvider
    {
        /// <summary>
        /// A method that provides loading workplans from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<WorkplanModel> LoadWorkplans(string filePath)
        {
            // Using XML serializer.
            XmlSerializer ser = new XmlSerializer(typeof(List<WorkplanModel>));

            // List of workplans that will be filled from the file.
            List<WorkplanModel> workplans;

            // Try to load workplans from the file.
            try
            {
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    workplans = (List<WorkplanModel>)ser.Deserialize(reader);
                }
                return workplans;

            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /// <summary>
        /// A method that provides saving workplans to the file.
        /// </summary>
        /// <param name="workplanModels"></param>
        /// <param name="filePath"></param>
        public void SaveWorkplan(List<WorkplanModel> workplanModels, string filePath)
        {
            // Using XML serializer.
            XmlSerializer xs = new XmlSerializer(typeof(List<WorkplanModel>));

            // Try to save workplans to the file.
            try
            {
                using (TextWriter txtWriter = new StreamWriter(filePath))
                {
                    xs.Serialize(txtWriter, workplanModels);
                }
                MessageBox.Show("Workplans have been saved properly");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
