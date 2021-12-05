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
        public List<ArrRevisionEntry> LoadRevisions(string filePath)
        {
            // Using XML serializer.
            XmlSerializer ser = new XmlSerializer(typeof(List<ArrRevisionEntry>));

            // List of workplans that will be filled from the file.
            List<ArrRevisionEntry> revisions;

            // Try to load revisions from the file.
            try
            {
                //XmlTextReader xmlReader = new XmlTextReader(filePath);
                //while (xmlReader.Read())
                //{
                //    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "RevisionEntry")) ;
                //    {
                //        if (xmlReader.HasAttributes)
                //            MessageBox.Show(xmlReader.GetAttribute("ElementNumber") + ": " + xmlReader.GetAttribute("ElementType") + ": " + xmlReader.GetAttribute("End") + ": " + xmlReader.GetAttribute("IndicatorNumber") + ": " + xmlReader.GetAttribute("RelativeAdresse") + ": " + xmlReader.GetAttribute("Slave") + ": " + xmlReader.GetAttribute("Start") + ": " + xmlReader.GetAttribute("State") + ": " + xmlReader.GetAttribute("TopAdresse") + ": " + xmlReader.GetAttribute("Typ"));
                //    }
                //}

                //using (XmlReader reader = XmlReader.Create(filePath))
                //{
                //    revisions = (List<ArrRevisionEntry>)ser.Deserialize(reader);
                //}
                //return revisions;

                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    revisions = (List<ArrRevisionEntry>)ser.Deserialize(reader);
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
        public void SaveRevision(List<ArrRevisionEntry> revisionModels, string filePath)
        {
            // Using XML serializer.
            XmlSerializer xs = new XmlSerializer(typeof(List<ArrRevisionEntry>));

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
