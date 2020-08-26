namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoImpuestos
    {

        private ComprobanteConceptoImpuestosTraslado[] trasladosField;

        private ComprobanteConceptoImpuestosRetencion[] retencionesField;


        [System.Xml.Serialization.XmlArrayItemAttribute("Traslado", IsNullable = false)]
        public ComprobanteConceptoImpuestosTraslado[] Traslados
        {
            get
            {
                return trasladosField;
            }
            set
            {
                trasladosField = value;
            }
        }


        [System.Xml.Serialization.XmlArrayItemAttribute("Retencion", IsNullable = false)]
        public ComprobanteConceptoImpuestosRetencion[] Retenciones
        {
            get
            {
                return retencionesField;
            }
            set
            {
                retencionesField = value;
            }
        }
    }
}