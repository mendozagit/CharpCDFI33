using System.Xml;
using System.Xml.Serialization;
using Mensoft.Facturacion.CFDI33.Facturacion;

namespace Mensoft.Facturacion.CFDI33
{
    public class CfdiService
    {
        private XmlSerializer xmlSerializer;
        private XmlWriter xmlWriter;
        private XmlReader xmlReader;
        public Comprobante cfdi;


        public CfdiService()
        {
            cfdi = new Comprobante();

        }
        public void SaveToXml<T>(T comprobante, string path)
        {
            xmlSerializer = new XmlSerializer(typeof(T));
            using (xmlWriter = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
            {
                if (xmlWriter != null) xmlSerializer.Serialize(xmlWriter, comprobante);
            }
        }

        public T LoadFromXml<T>(string path) where T : class
        {
            xmlSerializer = new XmlSerializer(typeof(T));

            using (xmlReader = XmlReader.Create(path))
            {
                return xmlSerializer.Deserialize(xmlReader) as T;
            }


        }
    }
}
