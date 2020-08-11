using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class Cfdi33Service
    {
        public static void SaveToXml<T>(T comprobante, string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var writer = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
            {
                xmlSerializer.Serialize(writer, comprobante);
            }
        }

        public static T LoadFromXml<T>(string path) where T : class
        {
            var xmlSerializer = new XmlSerializer(typeof(T));

            using (var reader = XmlReader.Create(path))
            {
                return xmlSerializer.Deserialize(reader) as T;
            }
        }
    }
}
