using FINKOK.demo_facturacion;
using Mensoft.Facturacion.CFDI33;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Mensoft.Facturacion.CFDI33.Facturacion;
// ReSharper disable All


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

            try
            {

                var certificado = new Certificate(@"C:\Dympos\FacturaElectronica\Certificados\DGE131017IP1\CSD_DGE131017IP1_20171115.cer");
                var clavePrivada = new PrivateKey(@"C:\Dympos\FacturaElectronica\Certificados\DGE131017IP1\CSD_DGE131017IP1_20171115.key", "DGE131017", "SHA-256withRSA");
                var cadenaO = new OriginalString(@"C:\Dympos\FacturaElectronica\Certificados\cadenaoriginal33\cadenaoriginal33.xslt");
                var cfdiService = new CfdiService();

                var fiel = new Fiel(certificado, clavePrivada);

                //MessageBox.Show("SerialNumber" + certificado.SerialNumber());
                //MessageBox.Show("GetSerialNumberString" + certificado.GetSerialNumberString());
                //MessageBox.Show(" IssuerName" + certificado.IssuerName());
                //MessageBox.Show("NotAfter" + certificado.NotAfter());
                //MessageBox.Show("NotBefore" + certificado.NotBefore());
                //MessageBox.Show("FriendlyName" + certificado.FriendlyName());
                //MessageBox.Show("GetEffectiveDateString" + certificado.GetEffectiveDateString());
                //MessageBox.Show("GetExpirationDateString" + certificado.GetExpirationDateString());
                //MessageBox.Show("GetPublicKeyString" + certificado.GetPublicKeyString());
                //MessageBox.Show("HasPrivateKey" + certificado.HasPrivateKey());
                //MessageBox.Show("Subject" + certificado.Subject());
                //MessageBox.Show("Verify" + certificado.Verify());
                //MessageBox.Show("Version" + certificado.Version());

                //Concepto 1
                var concepto1 = new ComprobanteConcepto();
                var conceptoimpuesotos1 = new ComprobanteConceptoImpuestos();
                var conceptoTraslado1 = new ComprobanteConceptoImpuestosTraslado();
                var conceptoretencion1 = new ComprobanteConceptoImpuestosRetencion();
                var conceptocuentapredial = new ComprobanteConceptoCuentaPredial();

                concepto1.ClaveProdServ = "01010101";
                concepto1.ClaveUnidad = "H87";
                concepto1.NoIdentificacion = "P001";
                concepto1.Unidad = "Tonelada";
                concepto1.Descripcion = "Producto ACERO";
                concepto1.Cantidad = 1.5M;
                concepto1.ValorUnitario = 1500000;
                concepto1.Importe = 2250000;

                conceptoTraslado1.Base = 2250000;
                conceptoTraslado1.Impuesto = "002";
                conceptoTraslado1.TipoFactor = "Tasa";
                conceptoTraslado1.TasaOCuota = 0.160000m;
                conceptoTraslado1.Importe = 360000;

                conceptoretencion1.Base = 2250000;
                conceptoretencion1.Importe = 1192500;
                conceptoretencion1.Impuesto = "003";
                conceptoretencion1.TasaOCuota = 0.530000m;
                conceptoretencion1.TipoFactor = "Tasa";

                conceptocuentapredial.Numero = "51888";
                concepto1.Impuestos = new ComprobanteConceptoImpuestos();
                concepto1.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                concepto1.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
                concepto1.Impuestos.Traslados[0] = conceptoTraslado1;
                concepto1.Impuestos.Retenciones[0] = conceptoretencion1;
                concepto1.CuentaPredial = conceptocuentapredial;



                //Concepto 2
                var concepto2 = new ComprobanteConcepto();
                var conceptoimpuesotos2 = new ComprobanteConceptoImpuestos();
                var conceptoTraslado2 = new ComprobanteConceptoImpuestosTraslado();
                var conceptoretencion2 = new ComprobanteConceptoImpuestosRetencion();
                var conceptoInformacionAdu = new ComprobanteConceptoInformacionAduanera();

                concepto2.ClaveProdServ = "01010101";
                concepto2.ClaveUnidad = "H87";
                concepto2.NoIdentificacion = "P001";
                concepto2.Unidad = "Tonelada";
                concepto2.Descripcion = "Producto ALUMINIO";
                concepto2.Cantidad = 1.6M;
                concepto2.ValorUnitario = 1500;
                concepto2.Importe = 2400;

                conceptoTraslado2.Base = 2400;
                conceptoTraslado2.Impuesto = "002";
                conceptoTraslado2.TipoFactor = "Tasa";
                conceptoTraslado2.TasaOCuota = 0.160000m;
                conceptoTraslado2.Importe = 384;

                conceptoretencion2.Base = 2400;
                conceptoretencion2.Importe = 1272;
                conceptoretencion2.Impuesto = "003";
                conceptoretencion2.TasaOCuota = 0.530000m;
                conceptoretencion2.TipoFactor = "Tasa";

                conceptoInformacionAdu.NumeroPedimento = "15  48  3009  0001234";

                concepto2.Impuestos = new ComprobanteConceptoImpuestos();
                concepto2.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                concepto2.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
                concepto2.InformacionAduanera = new ComprobanteConceptoInformacionAduanera[1];
                concepto2.Impuestos.Traslados[0] = conceptoTraslado2;
                concepto2.Impuestos.Retenciones[0] = conceptoretencion2;
                concepto2.InformacionAduanera[0] = conceptoInformacionAdu;



                //Concepto 3
                var concepto3 = new ComprobanteConcepto();
                var conceptoimpuesotos3 = new ComprobanteConceptoImpuestos();
                var conceptoTraslado3 = new ComprobanteConceptoImpuestosTraslado();
                var conceptoretencion3 = new ComprobanteConceptoImpuestosRetencion();
                var conceptoparte = new ComprobanteConceptoParte();

                concepto3.ClaveProdServ = "01010101";
                concepto3.ClaveUnidad = "H87";
                concepto3.NoIdentificacion = "P003";
                concepto3.Unidad = "Tonelada";
                concepto3.Descripcion = "Producto ZAMAC";
                concepto3.Cantidad = 1.7M;
                concepto3.ValorUnitario = 10000;
                concepto3.Importe = 17000;

                conceptoTraslado3.Base = 17000;
                conceptoTraslado3.Impuesto = "002";
                conceptoTraslado3.TipoFactor = "Tasa";
                conceptoTraslado3.TasaOCuota = 0.160000m;
                conceptoTraslado3.Importe = 2720;

                conceptoretencion3.Base = 17000;
                conceptoretencion3.Importe = 2720;
                conceptoretencion3.Impuesto = "002";
                conceptoretencion3.TasaOCuota = 0.160000m;
                conceptoretencion3.TipoFactor = "Tasa";

                conceptoparte.Cantidad = 1.0m;
                conceptoparte.ClaveProdServ = "01010101";
                conceptoparte.Descripcion = "Parte ejemplo";
                conceptoparte.Importe = 1.00m;
                conceptoparte.NoIdentificacion = "055155";
                conceptoparte.Unidad = "1/2 TONELADA";
                conceptoparte.ValorUnitario = 1m;

                concepto3.Impuestos = new ComprobanteConceptoImpuestos();
                concepto3.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                concepto3.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
                concepto3.Impuestos.Traslados[0] = conceptoTraslado1;
                concepto3.Impuestos.Retenciones[0] = conceptoretencion3;

                concepto3.Parte = new ComprobanteConceptoParte[1];
                //concepto3.Parte = new ComprobanteConceptoParte[1];
                concepto3.Parte[0] = conceptoparte;


                //Emisor
                var emisor = new ComprobanteEmisor();
                emisor.Nombre = "ESCUELA KEMPER URGATE SA DE CV";
                emisor.RegimenFiscal = "601";
                emisor.Rfc = "MEJJ940824C61";


                //Receptor
                var receptor = new ComprobanteReceptor();
                receptor.Rfc = "MEJJ940824C61";
                receptor.Nombre = "JESUS MENDOZA JUAREZ";
                receptor.UsoCFDI = "P01";

                //Comprobante
                var comprobante = new Comprobante();
                var comprobanteImpuestos = new ComprobanteImpuestos();
                var comprobanteTraslado = new ComprobanteImpuestosTraslado();
                var comprobanteRetencion = new ComprobanteImpuestosRetencion();


                comprobante.Fecha = DateTime.Now.ToString("AAAA-MM-DDThh:mm:ss");
                comprobante.Sello = "MiCadenaDeSello";
                comprobante.NoCertificado = certificado.CertificateNumber();
                comprobante.Certificado = certificado.CertificateBase64();
                comprobante.SubTotal = 2269400;
                comprobante.Moneda = "MXN";
                comprobante.Total = 1436012;
                comprobante.TipoDeComprobante = "I";
                comprobante.LugarExpedicion = "38020";
                comprobante.TipoDeComprobante = "I";
                comprobante.Serie = "F";

                comprobante.Emisor = emisor;
                comprobante.Receptor = receptor;

                comprobante.Conceptos = new ComprobanteConcepto[3];
                comprobante.Conceptos[0] = concepto1;
                comprobante.Conceptos[1] = concepto2;
                comprobante.Conceptos[2] = concepto3;

                comprobanteImpuestos = new ComprobanteImpuestos();
                comprobanteImpuestos.Traslados = new ComprobanteImpuestosTraslado[1];
                comprobanteImpuestos.Retenciones = new ComprobanteImpuestosRetencion[1];
                comprobanteImpuestos.Traslados[0] = comprobanteTraslado;
                comprobanteImpuestos.Retenciones[0] = comprobanteRetencion;

                //Sellar 

                comprobante.Sello = fiel.PrivateKey.GenerateSignature(cadenaO.GetOriginalString("FacturaXML.XML"));

                cfdiService.SaveToXml(comprobante, "FacturaXML.XML");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }




            //Instancias del timbrado
            StampSOAP selloSOAP = new StampSOAP();
            stamp oStamp = new stamp();
            stampResponse selloResponse = new stampResponse();

            //Cargas tu archivo xml
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("FacturaXML.XML");

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
