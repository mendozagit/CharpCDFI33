namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoCuentaPredial
    {

        private string numeroField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Numero
        {
            get
            {
                return numeroField;
            }
            set
            {
                numeroField = value;
            }
        }
    }
}