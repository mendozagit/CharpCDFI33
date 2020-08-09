using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Receptor
    {
        [XmlAttribute()]
        public string Rfc { get; set; }

       
        [XmlAttribute()]
        public string Nombre { get; set; }

      
        [XmlAttribute()]
        public string ResidenciaFiscal { get; set; }


        [XmlAttribute()]
        public string NumRegIdTrib { get; set; }

        
        [XmlAttribute()]
        public string UsoCFDI { get; set; }
    }
}
