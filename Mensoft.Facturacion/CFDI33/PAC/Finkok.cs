using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Mensoft.Facturacion.com.finkok.demo.facturacion;

namespace Mensoft.Facturacion.CFDI33.PAC
{
    public class Finkok
    {

        private StampSOAP webService;
        private quick_stamp quickStamp;
        private StreamWriter streamWriter;
        private XmlSerializer xmlSerializer;

        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Prodution { get; set; }
        public string SoapRequestDirectory { get; set; }


        public Finkok(string userName, string password, bool prodution, string soapRequestDirectory)
        {
            webService = new StampSOAP();
            quickStamp = new quick_stamp();
            UserName = userName;
            Password = password;
            Prodution = prodution;

            quickStamp.password = password;
            quickStamp.username = userName;
            SoapRequestDirectory = soapRequestDirectory;
        }
        public quick_stampResponse Timbrar(byte[] comprobanteEnBytes)
        {
            quickStamp.xml = comprobanteEnBytes;
            return webService.quick_stamp(quickStamp);
        }

        private void CreateSoapRequest(string soapRequestDirectory)
        {
            //Direccion donde guardaremos el SOAP Envelope
            streamWriter = new StreamWriter(soapRequestDirectory + "SOAP_Request.xml");
            //Serializamos el request
            xmlSerializer = new XmlSerializer(quickStamp.GetType());
            xmlSerializer.Serialize(streamWriter, quickStamp);
            streamWriter.Close();
        }
    }
}
