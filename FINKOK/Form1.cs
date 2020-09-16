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
using Mensoft.Facturacion.CFDI33.PAC;

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


            var finkok = new FinkokTest("mendoza.git@gmail.com", "Philips@0700", false, @"C:\Users\" + Environment.UserName + "\\Documents\\");
            var certificado = new Certificate(@"C:\Users\PHILIPS-JESUSMENDOZA\source\repos\CharpCDFI33\FINKOK\bin\Debug\Sellos\cer.cer");
            var clavePrivada = new PrivateKey(@"C:\Users\PHILIPS-JESUSMENDOZA\source\repos\CharpCDFI33\FINKOK\bin\Debug\Sellos\key.key", "12345678a", "SHA-256withRSA");
            var cadenaO = new OriginalString(@"C:\Dympos\FacturaElectronica\Certificados\cadenaoriginal33\cadenaoriginal33.xslt");
            var fiel = new Fiel(certificado, clavePrivada);
            var cfdiService = new CfdiService("I", "3.3");




            cfdiService.Comprobante.Fecha = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            cfdiService.Comprobante.Sello = "MiCadenaDeSello";
            cfdiService.Comprobante.NoCertificado = certificado.CertificateNumber();
            cfdiService.Comprobante.Certificado = certificado.CertificateBase64();
            //cfdiService.Comprobante.SubTotal = 2269400;
            cfdiService.Comprobante.Moneda = "MXN";
            //cfdiService.Comprobante.Descuento = 30;
            //cfdiService.Comprobante.Total = 1436012 - 30;
            cfdiService.Comprobante.TipoDeComprobante = "I";
            cfdiService.Comprobante.LugarExpedicion = "38020";
            cfdiService.Comprobante.TipoDeComprobante = "I";
            cfdiService.Comprobante.Serie = "F";
            cfdiService.Comprobante.FormaPago = "01";
            cfdiService.Comprobante.MetodoPago = "PUE";


            //Concepto 1
            var concepto1 = new ComprobanteConcepto();
            concepto1.ClaveProdServ = "01010101";
            concepto1.ClaveUnidad = "H87";
            concepto1.NoIdentificacion = "P001";
            concepto1.Unidad = "Tonelada";
            concepto1.Descripcion = "Producto ACERO";
            concepto1.Cantidad = 1.5M;
            concepto1.ValorUnitario = 1500000;
            concepto1.Descuento = 10;
            concepto1.Importe = 2250000;
            cfdiService.AddConcepto(concepto1, "002", 0.160000m, 2250000, 360000, "Tasa", "003", 0.530000m, 2250000, 1192500, "Tasa");



            //Concepto 2
            var concepto2 = new ComprobanteConcepto();
            concepto2.ClaveProdServ = "01010101";
            concepto2.ClaveUnidad = "H87";
            concepto2.NoIdentificacion = "P001";
            concepto2.Unidad = "Tonelada";
            concepto2.Descripcion = "Producto ALUMINIO";
            concepto2.Cantidad = 1.6M;
            concepto2.ValorUnitario = 1500;
            concepto2.Descuento = 10;
            concepto2.Importe = 2400;
            cfdiService.AddConcepto(concepto2, "002", 0.160000m, 2400, 384, "Tasa", "003", 0.530000m, 2400, 1272, "Tasa");

            //Concepto 3
            var concepto3 = new ComprobanteConcepto();
            concepto3.ClaveProdServ = "01010101";
            concepto3.ClaveUnidad = "H87";
            concepto3.NoIdentificacion = "P003";
            concepto3.Unidad = "Tonelada";
            concepto3.Descripcion = "Producto ZAMAC";
            concepto3.Cantidad = 1.7M;
            concepto3.ValorUnitario = 10000;
            concepto3.Descuento = 10;
            concepto3.Importe = 17000;
            cfdiService.AddConcepto(concepto3, "002", 0.160000m, 17000, 2720, "Tasa", "002", 0.160000m, 17000, 2720, "Tasa");



            //Emisor
            cfdiService.AddEmisor("EKU9003173C9", "ESCUELA KEMPER URGATE SA DE CV", "601");

            //Receptor
            cfdiService.AddReceptor("MEJJ940824C61", "JESUS MENDOZA JUAREZ", "P01");


            cfdiService.Comprobante = cfdiService.CalculaComprobante();

            //Sellar y guardar  
            cfdiService.SaveToXml(cfdiService.Comprobante, "FacturaXML.XML");
            cfdiService.Comprobante.Sello = fiel.PrivateKey.GenerateSignature(cadenaO.GetOriginalString("FacturaXML.XML"));
            cfdiService.SaveToXml(cfdiService.Comprobante, "FacturaXML.XML");


            var selloResponse = finkok.Timbrar(cfdiService.ComprobanteToBytes());


            try
            {

                var x = selloResponse.quick_stampResult.Incidencias.Length;

                if (selloResponse != null)
                {
                    if (selloResponse.quick_stampResult != null)
                    {
                        if (selloResponse.quick_stampResult.Incidencias != null)
                        {
                            if (selloResponse.quick_stampResult.Incidencias.Length == 0)
                            {


                                File.WriteAllText("FacturaXML.XML", selloResponse.quick_stampResult.xml);

                                MessageBox.Show(selloResponse.quick_stampResult.CodEstatus.ToString());
                            }
                            else
                            {
                                MessageBox.Show("No se timbro el XML" + "\nCódigo de error: " + selloResponse.quick_stampResult.Incidencias[0].CodigoError.ToString() + "\nMensaje: " + selloResponse.quick_stampResult.Incidencias[0].MensajeIncidencia);

                            }
                        }
                    }
                }



            }
            catch (Exception)
            {

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ValidationSOAP validationSoap = new ValidationSOAP();
            //com.finkok.validations.validate validate = new validate();
            //var cfdiService = new CfdiService();
            //cfdiService.Comprobante = cfdiService.LoadFromXml<Comprobante>("FacturaXML.XML");
            //validate.xml = cfdiService.ComprobanteToBytes();
            //validate.username = "mendoza.git@gmail.com";
            //validate.password = "Philips@0700";
            //var response = validationSoap.validate(validate);

            //MessageBox.Show("Test");
        }
    }
}
