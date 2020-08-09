using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class ConceptoParte
    {


        public ConceptoParte()
        {
            InformacionAduanera = new List<ParteInformacionAduanera>();
        }

        [XmlElement("InformacionAduanera")]
        public IList<ParteInformacionAduanera> InformacionAduanera { get; set; }

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

        [XmlIgnore()]
        public bool ValorUnitarioSpecified { get; set; }


        [XmlAttribute()]
        public decimal Importe { get; set; }


        [XmlIgnore()]
        public bool ImporteSpecified { get; set; }
    }
}
