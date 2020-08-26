namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoInformacionAduanera
    {

        private string numeroPedimentoField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string NumeroPedimento
        {
            get
            {
                return numeroPedimentoField;
            }
            set
            {
                numeroPedimentoField = value;
            }
        }
    }
}