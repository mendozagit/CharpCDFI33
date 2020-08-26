namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteCfdiRelacionadosCfdiRelacionado
    {

        private string uUIDField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string UUID
        {
            get
            {
                return uUIDField;
            }
            set
            {
                uUIDField = value;
            }
        }
    }
}