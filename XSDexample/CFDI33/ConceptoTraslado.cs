using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSDexample.CFDI33
{
    public class ConceptoTraslado
    {

        [XmlAttribute()]
        public decimal Base { get; set; }

        [XmlAttribute()]
        public string Impuesto { get; set; }

        [XmlAttribute()]
        public string TipoFactor { get; set; }

        [XmlAttribute()]
        public decimal TasaOCuota { get; set; }

        [XmlAttribute()]
        public decimal Importe { get; set; }
        //teste
    }
}
