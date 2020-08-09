using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class ComprobanteRetencion
    {
       
        [XmlAttribute()]
        public decimal Base{ get; set; }

        
        [XmlAttribute()]
        public string Impuesto { get; set; }

       
        [XmlAttribute()]
        public string TipoFactor { get; set; }

     
        [XmlAttribute()]
        public decimal TasaOCuota{ get; set; }

      
        [XmlAttribute()]
        public decimal Importe{ get; set; }
    }
}
