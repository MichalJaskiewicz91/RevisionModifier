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
        public Revision Revisions { get; set; }
        public RevisionProvider()
        {
            Revisions = new Revision();
        }
        /// <summary>
        /// A method that provides loading workplans from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<RevisionEntry> LoadRevisionEntries(string filePath)
        {
            {
                // Using XML serializer.
                XmlSerializer serr = new XmlSerializer(typeof(Revision));

                List<RevisionEntry> revisionEntry;

                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    Revisions = (Revision)serr.Deserialize(reader);
                }

                revisionEntry = Revisions.ArrRevisionEntry.RevisionEntry;
                return revisionEntry;
            }


        }

        /// <summary>
        /// A method that provides saving revisions to the file.
        /// </summary>
        /// <param name="revisionEntries"></param>
        /// <param name="filePath"></param>
        public void SaveRevisionEntries(List<RevisionEntry> revisionEntries, string filePath)
        {
            // Using XML serializer.
            XmlSerializer xs = new XmlSerializer(typeof(Revision));

            Revisions.ArrRevisionEntry.RevisionEntry = revisionEntries;

            // Try to save revisions to the file.
            try
            {
                using (TextWriter txtWriter = new StreamWriter(filePath))
                {
                    xs.Serialize(txtWriter, Revisions);
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
