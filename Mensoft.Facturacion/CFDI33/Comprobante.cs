using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [XmlRoot(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
    public class Comprobante
    {
        public Comprobante()
        {
            Version = "3.3";
            Complementos = new List<ComprobanteComplemento>();
            CfdiRelacionados = new List<CfdiRelacionado>();
            Traslados = new List<ComprobanteTraslado>();
            Retenciones = new List<ComprobanteRetencion>();
            Conceptos = new List<Concepto>();

        }


        public List<CfdiRelacionado> CfdiRelacionados { get; set; }

        public List<ComprobanteTraslado> Traslados { get; set; }

        public List<ComprobanteRetencion> Retenciones { get; set; }

        [XmlArrayItem("Concepto", IsNullable = false)]
        public List<Concepto> Conceptos { get; set; }

        [XmlElement("Complemento")]
        public List<ComprobanteComplemento> Complementos { get; set; }

        public Emisor Emisor { get; set; }


        public Receptor Receptor { get; set; }




        public ComprobanteAddenda Addenda { get; set; }


        [XmlAttribute()]
        public string Version { get; set; }


        [XmlAttribute()]
        public string Serie { get; set; }


        [XmlAttribute()]
        public string Folio { get; set; }


        [XmlAttribute()]
        public string Fecha { get; set; }


        [XmlAttribute()]
        public string Sello { get; set; }


        [XmlAttribute()]
        public string FormaPago { get; set; }




        [XmlAttribute()]
        public string NoCertificado { get; set; }


        [XmlAttribute()]
        public string Certificado { get; set; }


        [XmlAttribute()]
        public string CondicionesDePago { get; set; }


        [XmlAttribute()]
        public decimal SubTotal { get; set; }


        [XmlAttribute()]
        public decimal Descuento { get; set; }




        [XmlAttribute()]
        public string Moneda { get; set; }


        [XmlAttribute()]
        public decimal TipoCambio { get; set; }




        [XmlAttribute()]
        public decimal Total { get; set; }


        [XmlAttribute()]
        public string TipoDeComprobante { get; set; }


        [XmlAttribute()]
        public string MetodoPago { get; set; }




        [XmlAttribute()]
        public string LugarExpedicion { get; set; }


        [XmlAttribute()]
        public string Confirmacion { get; set; }

       
    }
}
