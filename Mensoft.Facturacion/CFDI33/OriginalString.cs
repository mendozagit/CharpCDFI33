using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Mensoft.Facturacion.CFDI33
{
    public class OriginalString : IFielFile
    {
        public string Path { get; set; }
        private XslCompiledTransform xslCompiledTransform;
        private StringWriter stringWriter;
        private XmlWriter xmlWriter;

        public OriginalString(string originalStringPath)
        {
            Path = originalStringPath;
            Initialize();
        }

        public bool Exist()
        {
            return File.Exists(Path);
        }

        public byte[] GetFileBytes()
        {
            return File.ReadAllBytes(Path);
        }

        public string GetFileBase64()
        {
            return "Not Implemented";
        }

        public bool Initialize()
        {
            try
            {
                if (!File.Exists(Path)) return false;
                xslCompiledTransform = new XslCompiledTransform(true);
                xslCompiledTransform.Load(Path);
                return xslCompiledTransform != null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public string GetOriginalString(string pathXml)
        {
            using (stringWriter = new StringWriter())
            {
                using (xmlWriter = XmlWriter.Create(stringWriter, xslCompiledTransform.OutputSettings))
                {
                    if (xmlWriter != null)
                        xslCompiledTransform.Transform(pathXml, xmlWriter);
                    else
                        return string.Empty;
                    return stringWriter.ToString();

                }
            }
        }


    }
}
