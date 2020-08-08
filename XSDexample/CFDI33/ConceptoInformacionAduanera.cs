using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XSDexample.CFDI33
{
    public class ConceptoInformacionAduanera
    {

        [XmlAttribute()]
        public string NumeroPedimento { get; set; }
    }
}
