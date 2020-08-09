using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class ConceptoRetencion
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

        [XmlIgnore()]
        public bool TasaOCuotaSpecified { get; set; }

        [XmlIgnore()]
        public bool ImporteSpecified { get; set; }
    }
}
