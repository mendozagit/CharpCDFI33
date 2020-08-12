using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
  
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class ConceptoImpuestos
    {
        [XmlArrayItem("Traslado", IsNullable = false)]
        public List<ConceptoTraslado> Traslados { get; set; }

        [XmlArrayItem("Retencion", IsNullable = false)]
        public List<ConceptoRetencion> Retenciones { get; set; }

        public ConceptoImpuestos()
        {
            Traslados = new List<ConceptoTraslado>();
            Retenciones = null;
        }
    }
}
