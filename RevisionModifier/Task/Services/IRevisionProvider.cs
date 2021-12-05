using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Models;

namespace Task.Services
{
    /// <summary>
    /// An interface that provides an access to the RevisionProvider class.
    /// </summary>
    public interface IRevisionProvider
    {
        /// <summary>
        /// A method that provides loading revisions from the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        List<RevisionEntry> LoadRevisionEntries(string filePath);
        /// <summary>
        /// A method that provides saving revisions to the file.
        /// </summary>
        /// <param name="revisionEntries"></param>
        /// <param name="filePath"></param>
        void SaveRevisionEntries(List<RevisionEntry> revisionEntries, string filePath);




    }
}
