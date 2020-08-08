using FINKOK.demo_facturacion;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace FINKOK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Instancias del timbrado
            StampSOAP selloSOAP = new StampSOAP();
            stamp oStamp = new stamp();
            stampResponse selloResponse = new stampResponse();

            //Cargas tu archivo xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"FacturaXML");

            //Conviertes el archivo en byte
            byte[] byteXmlDocument = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
            //Conviertes el byte resultado en base64
            string stringByteXmlDocument = Convert.ToBase64String(byteXmlDocument);
            //Convirtes el resultado nuevamente a byte
            byteXmlDocument = Convert.FromBase64String(stringByteXmlDocument);

            //Timbras el archivo
            oStamp.xml = byteXmlDocument;
            oStamp.username = "mendoza.git@gmail.com";
            oStamp.password = "Philips@0700";

            //Generamos request
            String usuario;
            usuario = Environment.UserName;
            String url = "C:\\Users\\" + usuario + "\\Documents\\";
            StreamWriter XML = new StreamWriter(url + "SOAP_Request.xml");     //Direccion donde guardaremos el SOAP Envelope
            XmlSerializer soap = new XmlSerializer(oStamp.GetType());    //Obtenemos los datos del objeto oStamp que contiene los parámetros de envió y es de tipo stamp()
            soap.Serialize(XML, oStamp);
            XML.Close();

            //Recibes la respuesta de timbrado
            selloResponse = selloSOAP.stamp(oStamp);

            try
            {
                MessageBox.Show("No se timbro el XML" + "\nCódigo de error: " + selloResponse.stampResult.Incidencias[0].CodigoError.ToString() + "\nMensaje: " + selloResponse.stampResult.Incidencias[0].MensajeIncidencia);
            }
            catch (Exception)
            {
                MessageBox.Show(selloResponse.stampResult.CodEstatus.ToString());
                MessageBox.Show(selloResponse.stampResult.Fecha.ToString());
                MessageBox.Show(selloResponse.stampResult.UUID.ToString());
                MessageBox.Show(selloResponse.stampResult.xml.ToString());
                StreamWriter XMLL = new StreamWriter(url + "responsepruebas.xml");
                XMLL.Write(selloResponse.stampResult.xml);
                XMLL.Close();
            }

        }
    }
}
