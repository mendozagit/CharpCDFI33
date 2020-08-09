using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class ComprobanteComplemento
    {
        [XmlAnyElement()]
        public XmlElement Any { get; set; }
      
    }
}
