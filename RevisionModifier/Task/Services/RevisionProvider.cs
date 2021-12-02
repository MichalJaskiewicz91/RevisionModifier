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
    /// A class that handles revisions.
    /// </summary>
    public class RevisionProvider : IRevisionProvider
    {
        /// <summary>
        /// A method that provides loading workplans from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<RevisionModel> LoadRevisions(string filePath)
        {
            // Using XML serializer.
            XmlSerializer ser = new XmlSerializer(typeof(List<RevisionModel>));

            // List of workplans that will be filled from the file.
            List<RevisionModel> revisions;

            // Try to load revisions from the file.
            try
            {
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    revisions = (List<RevisionModel>)ser.Deserialize(reader);
                }
                return revisions;

            }
            catch (Exception e)
            { 
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /// <summary>
        /// A method that provides saving revisions to the file.
        /// </summary>
        /// <param name="revisionModels"></param>
        /// <param name="filePath"></param>
        public void SaveRevision(List<RevisionModel> revisionModels, string filePath)
        {
            // Using XML serializer.
            XmlSerializer xs = new XmlSerializer(typeof(List<RevisionModel>));

            // Try to save revisions to the file.
            try
            {
                using (TextWriter txtWriter = new StreamWriter(filePath))
                {
                    xs.Serialize(txtWriter, revisionModels);
                }
                MessageBox.Show("Revisions have been saved properly");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
