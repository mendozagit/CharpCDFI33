using System.Xml.Schema;
using System.Xml.Serialization;
using Facturacion;

namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.sat.gob.mx/cfd/3", IsNullable = false)]
    public class Comprobante
    {
        private ComprobanteCfdiRelacionados cfdiRelacionadosField;

        private ComprobanteEmisor emisorField;

        private ComprobanteReceptor receptorField;

        private ComprobanteConcepto[] conceptosField;

        private ComprobanteImpuestos impuestosField;

        private ComprobanteComplemento[] complementoField;

        private ComprobanteAddenda addendaField;

        private string versionField;

        private string serieField;

        private string folioField;

        private string fechaField;

        private string selloField;

        private string formaPagoField;

        private bool formaPagoFieldSpecified;

        private string noCertificadoField;

        private string certificadoField;

        private string condicionesDePagoField;

        private decimal subTotalField;

        private decimal descuentoField;

        private bool descuentoFieldSpecified;

        private string monedaField;

        private decimal tipoCambioField;

        private bool tipoCambioFieldSpecified;

        private decimal totalField;

        private string tipoDeComprobanteField;

        private string metodoPagoField;

        private bool metodoPagoFieldSpecified;

        private string lugarExpedicionField;

        private string confirmacionField;


        [XmlAttribute("schemaLocation", Namespace = XmlSchema.InstanceNamespace)]
        public string XsiSchemaLocation = "http://www.sat.gob.mx/cfd/3 http://www.sat.gob.mx/sitio_internet/cfd/3/cfdv33.xsd";
        public Comprobante()
        {
            versionField = "3.3";
        }


        public ComprobanteCfdiRelacionados CfdiRelacionados
        {
            get
            {
                return cfdiRelacionadosField;
            }
            set
            {
                cfdiRelacionadosField = value;
            }
        }


        public ComprobanteEmisor Emisor
        {
            get
            {
                return emisorField;
            }
            set
            {
                emisorField = value;
            }
        }


        public ComprobanteReceptor Receptor
        {
            get
            {
                return receptorField;
            }
            set
            {
                receptorField = value;
            }
        }


        [System.Xml.Serialization.XmlArrayItemAttribute("Concepto", IsNullable = false)]
        public ComprobanteConcepto[] Conceptos
        {
            get
            {
                return conceptosField;
            }
            set
            {
                conceptosField = value;
            }
        }


        public ComprobanteImpuestos Impuestos
        {
            get
            {
                return impuestosField;
            }
            set
            {
                impuestosField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Complemento")]
        public ComprobanteComplemento[] Complemento
        {
            get
            {
                return complementoField;
            }
            set
            {
                complementoField = value;
            }
        }


        public ComprobanteAddenda Addenda
        {
            get
            {
                return addendaField;
            }
            set
            {
                addendaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Version
        {
            get
            {
                return versionField;
            }
            set
            {
                versionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Serie
        {
            get
            {
                return serieField;
            }
            set
            {
                serieField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Folio
        {
            get
            {
                return folioField;
            }
            set
            {
                folioField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Fecha
        {
            get
            {
                return fechaField;
            }
            set
            {
                fechaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Sello
        {
            get
            {
                return selloField;
            }
            set
            {
                selloField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FormaPago
        {
            get
            {
                return formaPagoField;
            }
            set
            {
                formaPagoFieldSpecified = true;
                formaPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FormaPagoSpecified
        {
            get
            {
                return formaPagoFieldSpecified;
            }
            set
            {
                formaPagoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NoCertificado
        {
            get
            {
                return noCertificadoField;
            }
            set
            {
                noCertificadoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Certificado
        {
            get
            {
                return certificadoField;
            }
            set
            {
                certificadoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CondicionesDePago
        {
            get
            {
                return condicionesDePagoField;
            }
            set
            {
                condicionesDePagoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal SubTotal
        {
            get
            {
                return subTotalField;
            }
            set
            {
                subTotalField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Descuento
        {
            get
            {
                return descuentoField;
            }
            set
            {
                descuentoFieldSpecified = true;
                descuentoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DescuentoSpecified
        {
            get
            {
                return descuentoFieldSpecified;
            }
            set
            {
                descuentoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Moneda
        {
            get
            {
                return monedaField;
            }
            set
            {
                monedaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TipoCambio
        {
            get
            {
                return tipoCambioField;
            }
            set
            {
                tipoCambioFieldSpecified = true;
                tipoCambioField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TipoCambioSpecified
        {
            get
            {
                return tipoCambioFieldSpecified;
            }
            set
            {
                tipoCambioFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Total
        {
            get
            {
                return totalField;
            }
            set
            {
                totalField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoDeComprobante
        {
            get
            {
                return tipoDeComprobanteField;
            }
            set
            {
                tipoDeComprobanteField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MetodoPago
        {
            get
            {
                return metodoPagoField;
            }
            set
            {
                metodoPagoFieldSpecified = true;
                metodoPagoField = value;
            }
        }


        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MetodoPagoSpecified
        {
            get
            {
                return metodoPagoFieldSpecified;
            }
            set
            {
                metodoPagoFieldSpecified = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LugarExpedicion
        {
            get
            {
                return lugarExpedicionField;
            }
            set
            {
                lugarExpedicionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Confirmacion
        {
            get
            {
                return confirmacionField;
            }
            set
            {
                confirmacionField = value;
            }
        }
    }
}