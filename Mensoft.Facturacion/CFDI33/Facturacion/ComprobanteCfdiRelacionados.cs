namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteCfdiRelacionados
    {

        private ComprobanteCfdiRelacionadosCfdiRelacionado[] cfdiRelacionadoField;

        private string tipoRelacionField;


        [System.Xml.Serialization.XmlElementAttribute("CfdiRelacionado")]
        public ComprobanteCfdiRelacionadosCfdiRelacionado[] CfdiRelacionado
        {
            get
            {
                return cfdiRelacionadoField;
            }
            set
            {
                cfdiRelacionadoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoRelacion
        {
            get
            {
                return tipoRelacionField;
            }
            set
            {
                tipoRelacionField = value;
            }
        }
    }
}