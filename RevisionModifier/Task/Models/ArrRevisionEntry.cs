using System;
using System.Collections.Generic;

namespace Task.Models
{
    /// <summary>
    /// Class holding revision information
    /// </summary>
    [Serializable]
    public class ArrRevisionEntry
    {
        [System.Xml.Serialization.XmlElementAttribute("RevisionEntry")]
        public List<RevisionEntry> RevisionEntry;

    }
}
