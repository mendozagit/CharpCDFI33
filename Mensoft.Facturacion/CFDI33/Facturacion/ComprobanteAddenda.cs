namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteAddenda
    {
        private System.Xml.XmlElement[] anyField;
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return anyField;
            }
            set
            {
                anyField = value;
            }
        }
    }
}