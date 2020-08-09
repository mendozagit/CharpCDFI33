using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class CfdiRelacionado
    {
        [XmlAttribute()]
        public string UUID { get; set; }
    }
}
