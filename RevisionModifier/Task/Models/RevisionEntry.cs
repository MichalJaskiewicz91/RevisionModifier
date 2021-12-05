using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task.Models
{
    [Serializable]
    public class RevisionEntry
    {
        [XmlAttribute]
        public string ElementNumber { get; set; }
        [XmlAttribute]
        public string ElementType { get; set; }
        [XmlAttribute]
        public string End { get; set; }
        [XmlAttribute]
        public string IndicatorNumber { get; set; }
        [XmlAttribute]
        public string RelativeAdresse { get; set; }
        [XmlAttribute]
        public string Slave { get; set; }
        [XmlAttribute]
        public string Start { get; set; }
        [XmlAttribute]
        public string State { get; set; }
        [XmlAttribute]
        public string TopAdresse { get; set; }
        [XmlAttribute]
        public string Typ { get; set; }

    }
}
