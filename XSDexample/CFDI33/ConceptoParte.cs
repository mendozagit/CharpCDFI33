using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSDexample.CFDI33
{
    public class ConceptoParte
    {
        [XmlElement("InformacionAduanera")]
        public List<ConceptoInformacionAduanera> InformacionAduanera { get; set; }


        [XmlAttribute()]
        public string ClaveProdServ { get; set; }


        [XmlAttribute()]
        public string NoIdentificacion { get; set; }

        [XmlAttribute()]
        public decimal Cantidad { get; set; }


        [XmlAttribute()]
        public string Unidad { get; set; }

        [XmlAttribute()]
        public string Descripcion { get; set; }


        [XmlAttribute()]
        public decimal ValorUnitario { get; set; }

        [XmlAttribute()]
        public decimal Importe { get; set; }

    }
}
