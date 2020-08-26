namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConcepto
    {
        public ComprobanteConcepto()
        {

        }
        private ComprobanteConceptoImpuestos impuestosField;

        private ComprobanteConceptoInformacionAduanera[] informacionAduaneraField;

        private ComprobanteConceptoCuentaPredial cuentaPredialField;

        private ComprobanteConceptoComplementoConcepto complementoConceptoField;

        private ComprobanteConceptoParte[] parteField;

        private string claveProdServField;

        private string noIdentificacionField;

        private decimal cantidadField;

        private string claveUnidadField;

        private string unidadField;

        private string descripcionField;

        private decimal valorUnitarioField;

        private decimal importeField;

        private decimal descuentoField;

        private bool descuentoFieldSpecified;


        public ComprobanteConceptoImpuestos Impuestos
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


        [System.Xml.Serialization.XmlElementAttribute("InformacionAduanera")]
        public ComprobanteConceptoInformacionAduanera[] InformacionAduanera
        {
            get
            {
                return informacionAduaneraField;
            }
            set
            {
                informacionAduaneraField = value;
            }
        }


        public ComprobanteConceptoCuentaPredial CuentaPredial
        {
            get
            {
                return cuentaPredialField;
            }
            set
            {
                cuentaPredialField = value;
            }
        }


        public ComprobanteConceptoComplementoConcepto ComplementoConcepto
        {
            get
            {
                return complementoConceptoField;
            }
            set
            {
                complementoConceptoField = value;
            }
        }


        [System.Xml.Serialization.XmlElementAttribute("Parte")]
        public ComprobanteConceptoParte[] Parte
        {
            get
            {
                return parteField;
            }
            set
            {
                parteField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ClaveProdServ
        {
            get
            {
                return claveProdServField;
            }
            set
            {
                claveProdServField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NoIdentificacion
        {
            get
            {
                return noIdentificacionField;
            }
            set
            {
                noIdentificacionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Cantidad
        {
            get
            {
                return cantidadField;
            }
            set
            {
                cantidadField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ClaveUnidad
        {
            get
            {
                return claveUnidadField;
            }
            set
            {
                claveUnidadField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Unidad
        {
            get
            {
                return unidadField;
            }
            set
            {
                unidadField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Descripcion
        {
            get
            {
                return descripcionField;
            }
            set
            {
                descripcionField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal ValorUnitario
        {
            get
            {
                return valorUnitarioField;
            }
            set
            {
                valorUnitarioField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Importe
        {
            get
            {
                return importeField;
            }
            set
            {
                importeField = value;
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
    }
}