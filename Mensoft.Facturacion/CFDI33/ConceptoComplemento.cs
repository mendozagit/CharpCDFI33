using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class ConceptoComplemento
    {

        [XmlAnyElement()]

        public IList<XmlElement> Any { get; set; }
    }
}
