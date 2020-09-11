using FINKOK.demo_facturacion;
using Mensoft.Facturacion.CFDI33;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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



            var certificado = new Certificate(@"C:\Users\PHILIPS-JESUSMENDOZA\source\repos\CharpCDFI33\FINKOK\bin\Debug\Sellos\cer.cer");
            var clavePrivada = new PrivateKey(@"C:\Users\PHILIPS-JESUSMENDOZA\source\repos\CharpCDFI33\FINKOK\bin\Debug\Sellos\key.key", "12345678a", "SHA-256withRSA");
            var cadenaO = new OriginalString(@"C:\Dympos\FacturaElectronica\Certificados\cadenaoriginal33\cadenaoriginal33.xslt");
            var fiel = new Fiel(certificado, clavePrivada);
            var cfdiService = new CfdiService("I", "3.3");




            cfdiService.Comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            cfdiService.Comprobante.Sello = "MiCadenaDeSello";
            cfdiService.Comprobante.NoCertificado = certificado.CertificateNumber();
            cfdiService.Comprobante.Certificado = certificado.CertificateBase64();
            cfdiService.Comprobante.SubTotal = 2269400;
            cfdiService.Comprobante.Moneda = "MXN";
            cfdiService.Comprobante.Descuento = 30;
            cfdiService.Comprobante.Total = 1436012 - 30;
            cfdiService.Comprobante.TipoDeComprobante = "I";
            cfdiService.Comprobante.LugarExpedicion = "38020";
            cfdiService.Comprobante.TipoDeComprobante = "I";
            cfdiService.Comprobante.Serie = "F";
            cfdiService.Comprobante.FormaPago = "01";
            cfdiService.Comprobante.MetodoPago = "PUE";


            //Concepto 1
            var concepto1 = new ComprobanteConcepto();

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
            concepto1.Descuento = 10; //***********************************************
            concepto1.Importe = 2250000;



            //conceptoTraslado1.Base = 2250000;
            //conceptoTraslado1.Impuesto = "002";
            //conceptoTraslado1.TipoFactor = "Tasa";
            //conceptoTraslado1.TasaOCuota = 0.160000m;
            //conceptoTraslado1.Importe = 360000;

            //conceptoretencion1.Base = 2250000;
            //conceptoretencion1.Importe = 1192500;
            //conceptoretencion1.Impuesto = "003";
            //conceptoretencion1.TasaOCuota = 0.530000m;
            //conceptoretencion1.TipoFactor = "Tasa";


            cfdiService.AddConcepto(concepto1, "002", 0.160000m, 2250000, 360000, "Tasa", "003", 0.530000m, 2250000, 1192500, "Tasa");
            //conceptocuentapredial.Numero = "51888";
            //concepto1.CuentaPredial = conceptocuentapredial;


            //var t1 = new List<ComprobanteConceptoImpuestosTraslado>();
            //var r1 = new List<ComprobanteConceptoImpuestosRetencion>();

            //t1.Add(conceptoTraslado1);
            //r1.Add(conceptoretencion1);
            //cfdiService.AddConcepto(concepto1, t1, r1);
            //cfdiService.AddConcepto(concepto1);




            //concepto1.Impuestos = new ComprobanteConceptoImpuestos();
            //concepto1.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
            //concepto1.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
            //concepto1.Impuestos.Traslados[0] = conceptoTraslado1;
            //concepto1.Impuestos.Retenciones[0] = conceptoretencion1;


            //Concepto 2
            var concepto2 = new ComprobanteConcepto();
            // var conceptoimpuesotos2 = new ComprobanteConceptoImpuestos();
            //var conceptoTraslado2 = new ComprobanteConceptoImpuestosTraslado();
            //var conceptoretencion2 = new ComprobanteConceptoImpuestosRetencion();
            // var conceptoInformacionAdu = new ComprobanteConceptoInformacionAduanera();

            concepto2.ClaveProdServ = "01010101";
            concepto2.ClaveUnidad = "H87";
            concepto2.NoIdentificacion = "P001";
            concepto2.Unidad = "Tonelada";
            concepto2.Descripcion = "Producto ALUMINIO";
            concepto2.Cantidad = 1.6M;
            concepto2.ValorUnitario = 1500;
            concepto2.Descuento = 10; //***********************************************
            concepto2.Importe = 2400;

            //conceptoTraslado2.Base = 2400;
            //conceptoTraslado2.Impuesto = "002";
            //conceptoTraslado2.TipoFactor = "Tasa";
            //conceptoTraslado2.TasaOCuota = 0.160000m;
            //conceptoTraslado2.Importe = 384;

            //conceptoretencion2.Base = 2400;
            //conceptoretencion2.Importe = 1272;
            //conceptoretencion2.Impuesto = "003";
            //conceptoretencion2.TasaOCuota = 0.530000m;
            //conceptoretencion2.TipoFactor = "Tasa";

            // conceptoInformacionAdu.NumeroPedimento = "15  48  3009  0001234";


            //var t2 = new List<ComprobanteConceptoImpuestosTraslado>();
            //var r2 = new List<ComprobanteConceptoImpuestosRetencion>();

            //t2.Add(conceptoTraslado2);
            //r2.Add(conceptoretencion2);
            //cfdiService.AddConcepto(concepto2, t2, r2);
            cfdiService.AddConcepto(concepto2, "002", 0.160000m, 2400, 384, "Tasa", "003", 0.530000m, 2400, 1272, "Tasa");

            //concepto2.Impuestos = new ComprobanteConceptoImpuestos();
            //concepto2.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
            //concepto2.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
            //concepto2.InformacionAduanera = new ComprobanteConceptoInformacionAduanera[1];
            //concepto2.Impuestos.Traslados[0] = conceptoTraslado2;
            //concepto2.Impuestos.Retenciones[0] = conceptoretencion2;
            //concepto2.InformacionAduanera[0] = conceptoInformacionAdu;



            //Concepto 3
            var concepto3 = new ComprobanteConcepto();
            //var conceptoimpuesotos3 = new ComprobanteConceptoImpuestos();
            //var conceptoTraslado3 = new ComprobanteConceptoImpuestosTraslado();
            //var conceptoretencion3 = new ComprobanteConceptoImpuestosRetencion();
            //var conceptoparte = new ComprobanteConceptoParte();

            concepto3.ClaveProdServ = "01010101";
            concepto3.ClaveUnidad = "H87";
            concepto3.NoIdentificacion = "P003";
            concepto3.Unidad = "Tonelada";
            concepto3.Descripcion = "Producto ZAMAC";
            concepto3.Cantidad = 1.7M;
            concepto3.ValorUnitario = 10000;
            concepto3.Descuento = 10; //***********************************************
            concepto3.Importe = 17000;

            //conceptoparte.Cantidad = 1.0m;
            //conceptoparte.ClaveProdServ = "01010101";
            //conceptoparte.Descripcion = "Parte ejemplo";
            //conceptoparte.Importe = 1.00m;
            //conceptoparte.NoIdentificacion = "055155";
            //conceptoparte.Unidad = "1/2 TONELADA";
            //conceptoparte.ValorUnitario = 1m;
            //concepto3.Parte = new ComprobanteConceptoParte[1];

            //concepto3.Parte[0] = conceptoparte;

            //conceptoTraslado3.Base = 17000;
            //conceptoTraslado3.Impuesto = "002";
            //conceptoTraslado3.TipoFactor = "Tasa";
            //conceptoTraslado3.TasaOCuota = 0.160000m;
            //conceptoTraslado3.Importe = 2720;

            //conceptoretencion3.Base = 17000;
            //conceptoretencion3.Importe = 2720;
            //conceptoretencion3.Impuesto = "002";
            //conceptoretencion3.TasaOCuota = 0.160000m;
            //conceptoretencion3.TipoFactor = "Tasa";





            //var t3 = new List<ComprobanteConceptoImpuestosTraslado>();
            //var r3 = new List<ComprobanteConceptoImpuestosRetencion>();

            //t3.Add(conceptoTraslado3);
            //r3.Add(conceptoretencion3);
            //cfdiService.AddConcepto(concepto3, t3, r3);
            cfdiService.AddConcepto(concepto3, "002", 0.160000m, 17000, 2720, "Tasa", "002", 0.160000m, 17000, 2720, "Tasa");


            //Emisor
            cfdiService.AddEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE SA DE CV", "601");

            //var emisor = new ComprobanteEmisor();
            //emisor.Nombre = "ESCUELA KEMPER URGATE SA DE CV";
            //emisor.RegimenFiscal = "601";
            //emisor.Rfc = "EKU9003173C9";

            //cfdiService.AddEmisor(emisor);

            //Receptor
            cfdiService.AddReceptor("MEJJ940824C61", "JESUS MENDOZA JUAREZ", "P01");
            //var receptor = new ComprobanteReceptor();
            //receptor.Rfc = "MEJJ940824C61";
            //receptor.Nombre = "JESUS MENDOZA JUAREZ";
            //receptor.UsoCFDI = "P01";

            //cfdiService.AddReceptor(receptor);




            cfdiService.Comprobante = cfdiService.CalculaComprobante();

            //Sellar  
            cfdiService.SaveToXml(cfdiService.Comprobante, "FacturaXML.XML");
            cfdiService.Comprobante.Sello = fiel.PrivateKey.GenerateSignature(cadenaO.GetOriginalString("FacturaXML.XML"));

            cfdiService.SaveToXml(cfdiService.Comprobante, "FacturaXML.XML");





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

                var x = selloResponse.stampResult.Incidencias.Length;

                if (selloResponse != null)
                {
                    if (selloResponse.stampResult != null)
                    {
                        if (selloResponse.stampResult.Incidencias != null)
                        {
                            if (selloResponse.stampResult.Incidencias.Length == 0)
                            {

                                //MessageBox.Show(selloResponse.stampResult.Fecha.ToString());
                                //MessageBox.Show(selloResponse.stampResult.UUID.ToString());
                                //MessageBox.Show(selloResponse.stampResult.xml.ToString());
                                StreamWriter XMLL = new StreamWriter(url + "responsepruebas.xml");
                                XMLL.Write(selloResponse.stampResult.xml);
                                File.WriteAllText("FacturaXML.XML", selloResponse.stampResult.xml);

                                XMLL.Close();
                                MessageBox.Show(selloResponse.stampResult.CodEstatus.ToString());
                            }
                            else
                            {
                                MessageBox.Show("No se timbro el XML" + "\nCódigo de error: " + selloResponse.stampResult.Incidencias[0].CodigoError.ToString() + "\nMensaje: " + selloResponse.stampResult.Incidencias[0].MensajeIncidencia);

                            }
                        }
                    }
                }



            }
            catch (Exception)
            {

            }

        }
    }
}
