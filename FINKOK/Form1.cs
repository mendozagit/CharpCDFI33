using FINKOK.demo_facturacion;
using Mensoft.Facturacion.CFDI33;
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
            var comprobante = new Comprobante();
            var emisor = new Emisor();
            var receptor = new Receptor();

            var concepto = new Concepto();
            var conceptoTraslado = new ConceptoTraslado();

            var conceptoImpuestos = new ConceptoImpuestos();
            var conceptotraslado = new ConceptoTraslado();
            var comprobantetraslado = new ComprobanteTraslado();

            emisor.Nombre = "JESUS MENDOZA JUAREZ";
            emisor.RegimenFiscal = "621";
            emisor.Rfc = "MEJJ940824C61";

            receptor.Rfc = "ADA110907QWA";
            receptor.Nombre = "OPERADORA KR, S.A. DE C.V";
            receptor.UsoCFDI = "P01";

            /*llenar concepto*/
            concepto.ClaveProdServ = "01010101";
            concepto.NoIdentificacion = "PROD001";
            concepto.Cantidad = 1;
            concepto.ClaveUnidad = "H87";
            concepto.Unidad = "PZ";
            concepto.Descripcion = "Coca Cola 2.5 Litros";
            concepto.ValorUnitario = 100;
            concepto.Importe = 100;

            /*llenar concepto traslado*/
            conceptoTraslado.Base = 100;
            conceptoTraslado.Impuesto = "002";
            conceptoTraslado.TipoFactor = "Tasa";
            conceptoTraslado.TasaOCuota = 0.160000m;
            conceptotraslado.Importe = 16.000000m;

            conceptoImpuestos.Traslados.Add(conceptoTraslado);

            /*llenar comprobante traslado*/
            comprobantetraslado.Impuesto = "002";
            comprobantetraslado.TipoFactor = "Tasa";
            comprobantetraslado.TasaOCuota = 0.160000m;
            comprobantetraslado.Importe = 16.000000m;


            comprobante.Fecha = DateTime.Now.ToString("AAAA-MM-DDThh:mm:ss");
            comprobante.Sello = "MiCadenaDeSello";
            comprobante.NoCertificado = "MiNoCertificado";
            comprobante.Certificado = "MiCadenadeCertificado";
            comprobante.SubTotal = 100;
            comprobante.Moneda = "MXN";
            comprobante.Total = 116;
            comprobante.TipoDeComprobante = "I";
            comprobante.LugarExpedicion = "38020";
            comprobante.Emisor = emisor;
            comprobante.Receptor = receptor;
            concepto.Impuestos = conceptoImpuestos;

            comprobante.Conceptos.Add(concepto);
            comprobante.Traslados.Add(comprobantetraslado);


            Cfdi33Service.SaveToXml(comprobante, "FacturaXML.XML");

            //Instancias del timbrado
            StampSOAP selloSOAP = new StampSOAP();
            stamp oStamp = new stamp();
            stampResponse selloResponse = new stampResponse();

            //Cargas tu archivo xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("FacturaXML");

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
