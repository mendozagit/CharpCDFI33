using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class ParteInformacionAduanera
    {
        [XmlAttribute()]
        public string NumeroPedimento { get; set; }
    }
}
