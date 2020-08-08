using System.Collections.Generic;
using System.Xml.Serialization;

namespace XSDexample.CFDI33
{
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
    public class Comprobante
    {

        [XmlArray("Conceptos")]
        [XmlArrayItem("Concepto", IsNullable = false)]

        public string Version { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public string Fecha { get; set; }
        public string Sello { get; set; }
        public string FormaPago { get; set; }
        public string NoCertificado { get; set; }
        public string Certificado { get; set; }
        public string CondicionPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string Moneda { get; set; }
        public string TipoCambio { get; set; }
        public decimal Total { get; set; }
        public string TipoComprobante { get; set; }
        public string MetodoPago { get; set; }
        public string CodigoPostal { get; set; }
        public string Confirmacion { get; set; }

        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public List<Concepto> Conceptos { get; set; }
        public List<ComprobanteImpuesto> Impuestos { get; set; }
        public List<ComprobanteComplemento> Complementos { get; set; }
        public List<CfdiRelacionado> CfdiRelacionados { get; set; }
        public ComprobanteAdenda Adenda { get; set; }

        public Comprobante()
        {
            Version = "3.3";
            Emisor = null;
            Adenda = null;
            Receptor = null;
            Complementos = new List<ComprobanteComplemento>();
            CfdiRelacionados = new List<CfdiRelacionado>();
            Impuestos = new List<ComprobanteImpuesto>();
            Conceptos = new List<Concepto>();
        }
    }


}
