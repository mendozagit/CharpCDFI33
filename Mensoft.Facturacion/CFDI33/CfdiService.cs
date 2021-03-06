﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using Mensoft.Facturacion.CFDI33.Facturacion;
using Mensoft.Facturacion.CFDI33.Helper;

namespace Mensoft.Facturacion.CFDI33
{
    public class CfdiService
    {
        private readonly int decimalesConcepto;
        private readonly int decimalesComprobante;

        //Serializacion
        private XmlSerializerNamespaces namespaces;
        private XPathNavigator xPathNavigator;
        private XmlSerializer xmlSerializer;
        private XmlDocument document;
        private XmlWriter xmlWriter;
        private XmlReader xmlReader;
        private XmlDocument xmlDocument;
        private StreamWriter streamWriter;
        private byte[] byteXmlDocument;
        private string stringByteXmlDocument;

        //Comprobante 
        public Comprobante Comprobante;
        private List<ComprobanteImpuestosTraslado> comprobanteTraslados;
        private List<ComprobanteImpuestosRetencion> comprobanteRetenciones;

        //Concepto
        private List<ComprobanteConcepto> conceptos;
        private ComprobanteConceptoImpuestosTraslado conceptoTraslado;
        private ComprobanteConceptoImpuestosRetencion conceptoRetencion;

        //Fiel
        public Certificate Certificate;
        public PrivateKey PrivateKey;
        public OriginalString OriginalString;



        #region Constructores

        public CfdiService(string tipoDeComprobante, string version, int decimalesConcepto = 6, int decimalesComprobante = 2)
        {
            this.decimalesConcepto = decimalesConcepto;
            this.decimalesComprobante = decimalesComprobante;
            comprobanteTraslados = new List<ComprobanteImpuestosTraslado>();
            comprobanteRetenciones = new List<ComprobanteImpuestosRetencion>();
            namespaces = new XmlSerializerNamespaces();
            conceptos = new List<ComprobanteConcepto>();
            document = new XmlDocument();
            xPathNavigator = document.CreateNavigator();
            namespaces.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            Comprobante = new Comprobante { Version = version, TipoDeComprobante = tipoDeComprobante };
        }

        public CfdiService()
        {
            document = new XmlDocument();
            xPathNavigator = document.CreateNavigator();

        }
        #endregion




        /// <summary>
        /// Emisor del comprobante
        /// </summary>
        /// <param name="pEmisor"></param>
        public void AddEmisor(ComprobanteEmisor pEmisor)
        {
            if (pEmisor != null)
            {
                Comprobante.Emisor = pEmisor;
            }
        }
        /// <summary>
        /// Emisor del comprobante
        /// </summary>
        /// <param name="rfc"></param>
        /// <param name="razonSocial"></param>
        /// <param name="claveRegimenFiscal"></param>
        public void AddEmisor(string rfc, string razonSocial, string claveRegimenFiscal)
        {
            Comprobante.Emisor = new ComprobanteEmisor();
            Comprobante.Emisor.Rfc = rfc;
            Comprobante.Emisor.Nombre = razonSocial;
            Comprobante.Emisor.RegimenFiscal = claveRegimenFiscal;

        }



        /// <summary>
        /// Receptor del comprobante
        /// </summary>
        /// <param name="pReceptor"></param>
        public void AddReceptor(ComprobanteReceptor pReceptor)
        {
            if (pReceptor != null)
            {
                Comprobante.Receptor = pReceptor;
            }
        }
        /// <summary>
        /// Receptor del comprobante
        /// </summary>
        /// <param name="rfc"></param>
        /// <param name="razonSocial"></param>
        /// <param name="claveUsoCfdi"></param>
        public void AddReceptor(string rfc, string razonSocial, string claveUsoCfdi)
        {

            Comprobante.Receptor = new ComprobanteReceptor();
            Comprobante.Receptor.Rfc = rfc;
            Comprobante.Receptor.Nombre = razonSocial;
            Comprobante.Receptor.UsoCFDI = claveUsoCfdi;
        }

        /// <summary>
        /// Agrega el concepto con sus respectivas colecciones de impuestos
        /// cuando ambas colecciones toman valor null por defecto, entonces
        /// el concepto se grava excento
        /// </summary>
        /// <param name="pconcepto"> Concepto</param>
        /// <param name="traslados"> Impuestos trasladados</param>
        /// <param name="retenciones">Impuestos retenidos </param>
        public void AddConcepto(ComprobanteConcepto pconcepto,
            List<ComprobanteConceptoImpuestosTraslado> traslados = null,
            List<ComprobanteConceptoImpuestosRetencion> retenciones = null)
        {
            pconcepto.Impuestos = new ComprobanteConceptoImpuestos();

            if (traslados == null)
            {
                if (retenciones == null)
                {
                    // Concepto excento
                    conceptoTraslado = new ComprobanteConceptoImpuestosTraslado
                    {
                        Base = pconcepto.Cantidad * pconcepto.ValorUnitario,
                        Impuesto = CfdiHelper.ImpuestoEstandar,
                        TipoFactor = CfdiHelper.TipoFactorEstandar
                    };
                    pconcepto.Importe = Math.Round(pconcepto.Cantidad * pconcepto.ValorUnitario, decimalesConcepto, MidpointRounding.AwayFromZero);
                    pconcepto.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                    pconcepto.Impuestos.Traslados[0] = conceptoTraslado;
                    conceptos.Add(pconcepto);
                }
                else
                {
                    //Una o varias retenciones
                    pconcepto.Impuestos.Retenciones = retenciones.ToArray();
                    conceptos.Add(pconcepto);
                }
            }
            else
            {
                if (retenciones == null)
                {
                    //Uno o varios traslados
                    pconcepto.Impuestos.Traslados = traslados.ToArray();
                    conceptos.Add(pconcepto);
                }
                else
                {
                    //Una o varias retenciones y Uno o varios traslados
                    pconcepto.Impuestos.Retenciones = retenciones.ToArray();
                    pconcepto.Impuestos.Traslados = traslados.ToArray();
                    conceptos.Add(pconcepto);
                }
            }
        }

        /// <summary>
        /// Agrega el concepto y su respectivo impuesto trasladado
        /// Este metodo solo debe ser llamado cuendo el concepto tenga
        /// Uno y solo un impuesto por trasladar o retener (No excento)
        /// </summary>
        /// <param name="nConcepto"></param>
        /// <param name="nImpuesto"></param>
        /// <param name="nTasaOCuota"></param>
        /// <param name="nBase"></param>
        /// <param name="nImporte"></param>
        /// <param name="nTipoFactor"></param>
        /// <param name="isTraslado"></param>
        public void AddConcepto(ComprobanteConcepto nConcepto, string nImpuesto, decimal nTasaOCuota, decimal nBase,
            decimal nImporte, string nTipoFactor, bool isTraslado = true)
        {
            nConcepto.Impuestos = new ComprobanteConceptoImpuestos();

            if (isTraslado)
            {
                //Solo Un traslado
                conceptoTraslado = new ComprobanteConceptoImpuestosTraslado();
                conceptoTraslado.Impuesto = nImpuesto;
                conceptoTraslado.TasaOCuota = nTasaOCuota;
                conceptoTraslado.Base = nBase;
                conceptoTraslado.Importe = nImporte;
                conceptoTraslado.TipoFactor = nTipoFactor;
                nConcepto.Importe = Math.Round(nConcepto.Cantidad * nConcepto.ValorUnitario, decimalesConcepto, MidpointRounding.AwayFromZero);
                nConcepto.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                nConcepto.Impuestos.Traslados[0] = conceptoTraslado;
                conceptos.Add(nConcepto);
            }
            else
            {
                //Solo Un traslado
                conceptoRetencion = new ComprobanteConceptoImpuestosRetencion();
                conceptoRetencion.Impuesto = nImpuesto;
                conceptoRetencion.TasaOCuota = nTasaOCuota;
                conceptoRetencion.Base = nBase;
                conceptoRetencion.Importe = nImporte;
                conceptoRetencion.TipoFactor = nTipoFactor;
                nConcepto.Importe = Math.Round(nConcepto.Cantidad * nConcepto.ValorUnitario, decimalesConcepto, MidpointRounding.AwayFromZero);
                nConcepto.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
                nConcepto.Impuestos.Retenciones[0] = conceptoRetencion;
                conceptos.Add(nConcepto);
            }
        }

        /// <summary>
        /// Agrega el concepto y su respectivo impuesto trasladado y retencion
        /// Solo debe ser llamado cuando el concepto tenga un impuesto y una
        /// retencion.
        /// </summary>
        /// <param name="nConcepto"></param>
        /// <param name="trasladoImpuesto"></param>
        /// <param name="trasladoTasaOCuota"></param>
        /// <param name="trasladoBase"></param>
        /// <param name="trasladoImporte"></param>
        /// <param name="trasladoTipoFactor"></param>
        /// <param name="retencionImpuesto"></param>
        /// <param name="retencionTasaOCuota"></param>
        /// <param name="retencionBase"></param>
        /// <param name="retencionImporte"></param>
        /// <param name="retencionTipoFactor"></param>
        public void AddConcepto(ComprobanteConcepto nConcepto, string trasladoImpuesto, decimal trasladoTasaOCuota,
            decimal trasladoBase, decimal trasladoImporte, string trasladoTipoFactor, string retencionImpuesto,
            decimal retencionTasaOCuota, decimal retencionBase, decimal retencionImporte, string retencionTipoFactor)
        {
            nConcepto.Impuestos = new ComprobanteConceptoImpuestos();
            nConcepto.Importe = Math.Round(nConcepto.Cantidad * nConcepto.ValorUnitario, decimalesConcepto, MidpointRounding.AwayFromZero);

            //Solo Un traslado
            conceptoTraslado = new ComprobanteConceptoImpuestosTraslado();
            conceptoTraslado.Impuesto = trasladoImpuesto;
            conceptoTraslado.TasaOCuota = trasladoTasaOCuota;
            conceptoTraslado.Base = trasladoBase;
            conceptoTraslado.Importe = trasladoImporte;
            conceptoTraslado.TipoFactor = trasladoTipoFactor;
            nConcepto.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
            nConcepto.Impuestos.Traslados[0] = conceptoTraslado;

            //Solo una retencion
            conceptoRetencion = new ComprobanteConceptoImpuestosRetencion();
            conceptoRetencion.Impuesto = retencionImpuesto;
            conceptoRetencion.TasaOCuota = retencionTasaOCuota;
            conceptoRetencion.Base = retencionBase;
            conceptoRetencion.Importe = retencionImporte;
            conceptoRetencion.TipoFactor = retencionTipoFactor;
            nConcepto.Impuestos.Retenciones = new ComprobanteConceptoImpuestosRetencion[1];
            nConcepto.Impuestos.Retenciones[0] = conceptoRetencion;

            conceptos.Add(nConcepto);
        }

        public Comprobante CalculaComprobante()
        {
            Comprobante.Conceptos = conceptos.ToArray();
            AgrupaTraslados();
            AgrupaRetenciones();
            RedondeaComprobante();
            return Comprobante;
        }

        private void RedondeaComprobante()
        {
            conceptos = Comprobante.Conceptos.ToList();
            Comprobante.SubTotal = Math.Round(conceptos.Sum(x => x.Cantidad * x.ValorUnitario), decimalesComprobante, MidpointRounding.AwayFromZero);
            Comprobante.Descuento = Math.Round(conceptos.Sum(x => x.Descuento), decimalesComprobante, MidpointRounding.AwayFromZero);
            Comprobante.Total = Math.Round(Comprobante.SubTotal - Comprobante.Descuento +
                Comprobante.Impuestos.TotalImpuestosTrasladados - Comprobante.Impuestos.TotalImpuestosRetenidos,
                decimalesComprobante, MidpointRounding.AwayFromZero);
            if (Comprobante.Descuento <= 0) return;
            Comprobante.DescuentoSpecified = true;
        }


        private void AgrupaTraslados()
        {
            //Obtener todos los traslados de todos los conceptos
            var traslados = Comprobante.Conceptos.SelectMany(c => c.Impuestos.Traslados.ToList()).ToList();


            //Agrupar traslados por:  Impuesto, TasaOCuota, TipoFactor
            var trasladosAgrupados = traslados.GroupBy(item => new { item.Impuesto, item.TasaOCuota, item.TipoFactor })
                .Select(g => new ComprobanteConceptoImpuestosTraslado()
                {
                    Impuesto = g.Key.Impuesto,
                    TasaOCuota = g.Key.TasaOCuota,
                    TipoFactor = g.Key.TipoFactor,
                    Base = g.Sum(x => x.Base),
                    Importe = g.Sum(x => x.Importe)
                });


            var agrupados = trasladosAgrupados.ToList();
            foreach (var trasladosAgrupado in agrupados)
            {
                comprobanteTraslados.Add(new ComprobanteImpuestosTraslado
                {
                    Impuesto = trasladosAgrupado.Impuesto,
                    TipoFactor = trasladosAgrupado.TipoFactor,
                    TasaOCuota = trasladosAgrupado.TasaOCuota,
                    Importe = trasladosAgrupado.Importe
                });
            }

            Comprobante.Impuestos = new ComprobanteImpuestos();
            Comprobante.Impuestos.Traslados = comprobanteTraslados.ToArray();
            Comprobante.Impuestos.TotalImpuestosTrasladados = Math.Round(agrupados.Sum(x => x.Importe), decimalesComprobante, MidpointRounding.AwayFromZero);

            if (comprobanteTraslados.Any())
                Comprobante.Impuestos.TotalImpuestosTrasladadosSpecified = true;
        }
        private void AgrupaRetenciones()
        {
            //Obtener todos las retenciones de todos los conceptos
            var retenciones = Comprobante.Conceptos.SelectMany(c => c.Impuestos.Retenciones.ToList()).ToList();


            //Agrupar traslados por:  Impuesto, TasaOCuota, TipoFactor
            var retencionesAgrupados = from item in retenciones
                                       group item by new { item.Impuesto, item.TasaOCuota, item.TipoFactor }
                into g
                                       select new ComprobanteConceptoImpuestosRetencion()
                                       {
                                           Impuesto = g.Key.Impuesto,
                                           TasaOCuota = g.Key.TasaOCuota,
                                           TipoFactor = g.Key.TipoFactor,
                                           Base = g.Sum(x => x.Base),
                                           Importe = g.Sum(x => x.Importe)
                                       };


            var retencionesagrupadas = retencionesAgrupados.ToList();
            foreach (var retencionAgrupada in retencionesagrupadas)
            {
                comprobanteRetenciones.Add(new ComprobanteImpuestosRetencion
                {
                    Impuesto = retencionAgrupada.Impuesto,
                    Importe = retencionAgrupada.Importe
                });
            }

            Comprobante.Impuestos.Retenciones = comprobanteRetenciones.ToArray();
            Comprobante.Impuestos.TotalImpuestosRetenidos = Math.Round(retencionesagrupadas.Sum(x => x.Importe), decimalesComprobante, MidpointRounding.AwayFromZero);


            if (comprobanteRetenciones.Any())
                Comprobante.Impuestos.TotalImpuestosRetenidosSpecified = true;
        }

        #region Serializar - Deserializar


        public void SaveToXml<T>(T pComprobante, string path)
        {
            xmlSerializer = new XmlSerializer(typeof(T));

            using (xmlWriter = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
            {

                if (xmlWriter != null) xmlSerializer.Serialize(xmlWriter, pComprobante, namespaces);
            }
        }

        public XmlDocument ComprobanteToXmlDocument()
        {
            using (var w = xPathNavigator.AppendChild())
            {
                xmlSerializer.Serialize(w, Comprobante, namespaces);
            }
            return document;
        }

        public T LoadFromXml<T>(string path) where T : class
        {
            xmlSerializer = new XmlSerializer(typeof(T));

            using (xmlReader = XmlReader.Create(path))
            {
                return xmlSerializer.Deserialize(xmlReader) as T;
            }
        }

        public StreamWriter CreateSoapRequest(string directoryPath = "")
        {
            return streamWriter = directoryPath.Equals("")
                   ? new StreamWriter(@"C:\\Users\\" + Environment.UserName + "\\Documents\\" + "SOAP_Request.xml")
                   : new StreamWriter(directoryPath + "SOAP_Request.xml");


        }

        public byte[] ComprobanteToBytes()
        {
            try
            {
                xmlDocument = ComprobanteToXmlDocument();
                //Conviertes el archivo en byte
                byteXmlDocument = Encoding.UTF8.GetBytes(xmlDocument.OuterXml);
                //Conviertes el byte resultado en base64
                stringByteXmlDocument = Convert.ToBase64String(byteXmlDocument);
                //Convirtes el resultado nuevamente a byte
                byteXmlDocument = Convert.FromBase64String(stringByteXmlDocument);
                return byteXmlDocument;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }

        }

        #endregion


    }
}
