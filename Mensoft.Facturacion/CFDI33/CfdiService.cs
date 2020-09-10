using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Mensoft.Facturacion.CFDI33.Facturacion;
using Mensoft.Facturacion.CFDI33.Helper;

namespace Mensoft.Facturacion.CFDI33
{
    public class CfdiService
    {

        //Serializacion
        private XmlSerializerNamespaces namespaces;
        private XmlSerializer xmlSerializer;
        private XmlWriter xmlWriter;
        private XmlReader xmlReader;

        //Comprobante 
        private Comprobante comprobante;
        private List<ComprobanteImpuestosTraslado> comprobanteTraslados;
        private List<ComprobanteImpuestosRetencion> comprobanteRetenciones;

        //Concepto
        private List<ComprobanteConcepto> conceptos;
        private ComprobanteConceptoImpuestosTraslado conceptoTraslado;






        #region Constructores

        public CfdiService(string tipoDeComprobante, string version)
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            comprobante = new Comprobante { Version = version, TipoDeComprobante = tipoDeComprobante };

            conceptos = new List<ComprobanteConcepto>();


            comprobanteTraslados = new List<ComprobanteImpuestosTraslado>();
            comprobanteRetenciones = new List<ComprobanteImpuestosRetencion>();
        }


        #endregion





        public void AddEmisor(ComprobanteEmisor pEmisor)
        {
            if (pEmisor != null)
            {
                comprobante.Emisor = pEmisor;
            }
        }
        public void AddReceptor(ComprobanteReceptor pReceptor)
        {
            if (pReceptor != null)
            {
                comprobante.Receptor = pReceptor;
            }
        }

        public void AddConcepto(ComprobanteConcepto pconcepto, List<ComprobanteConceptoImpuestosTraslado> traslados = null, List<ComprobanteConceptoImpuestosRetencion> retenciones = null)
        {
            if (traslados == null)
            {
                // Concepto excento
                conceptoTraslado = new ComprobanteConceptoImpuestosTraslado
                {
                    Base = pconcepto.Cantidad * pconcepto.ValorUnitario,
                    Impuesto = CfdiHelper.ImpuestoEstandar,
                    TipoFactor = CfdiHelper.TipoFactorEstandar
                };
                pconcepto.Impuestos.Traslados = new ComprobanteConceptoImpuestosTraslado[1];
                pconcepto.Impuestos.Traslados[0] = conceptoTraslado;
                conceptos.Add(pconcepto);
            }
            else
            {
                /*Uno o varios impuestos*/
                pconcepto.Impuestos.Traslados = traslados.ToArray();
                conceptos.Add(pconcepto);
            }

            if (retenciones == null) return;
            pconcepto.Impuestos.Retenciones = retenciones.ToArray();
            conceptos.Add(pconcepto);

        }

        public Comprobante CalculaComprobante(Comprobante pComprobante)
        {
            this.comprobante = pComprobante;


            #region Agrupacion de traslados
            //Agrupacion de traslados
            var traslados = new List<ComprobanteConceptoImpuestosTraslado>();

            //Obtener todos los traslados de todos los conceptos
            foreach (var c in pComprobante.Conceptos)
            {
                foreach (var t in c.Impuestos.Traslados.ToList())
                {
                    traslados.Add(t);
                }
            }

            //Agrupar traslados por:  Impuesto, TasaOCuota, TipoFactor
            var trasladosAgrupados = from item in traslados
                                     group item by new { item.Impuesto, item.TasaOCuota, item.TipoFactor }
                into g
                                     select new ComprobanteConceptoImpuestosTraslado()
                                     {
                                         Impuesto = g.Key.Impuesto,
                                         TasaOCuota = g.Key.TasaOCuota,
                                         TipoFactor = g.Key.TipoFactor,
                                         Base = g.Sum(x => x.Base),
                                         Importe = g.Sum(x => x.Importe)
                                     };


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

            pComprobante.Impuestos.Traslados = comprobanteTraslados.ToArray();
            pComprobante.Impuestos.TotalImpuestosTrasladados = agrupados.Sum(x => x.Importe);

            if (comprobanteTraslados.Count == 0)
                pComprobante.Impuestos.TotalImpuestosTrasladadosSpecified = false;
            #endregion


            #region Agrupacion de retenciones




            //Agrupacion de retenciones
            var retenciones = new List<ComprobanteConceptoImpuestosRetencion>();

            //Obtener todos los traslados de todos los conceptos
            foreach (var c in pComprobante.Conceptos)
            {
                foreach (var t in c.Impuestos.Retenciones.ToList())
                {
                    retenciones.Add(t);
                }
            }

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

            pComprobante.Impuestos.Retenciones = comprobanteRetenciones.ToArray();
            pComprobante.Impuestos.TotalImpuestosRetenidos = retencionesagrupadas.Sum(x => x.Importe);

            if (comprobanteRetenciones.Count == 0)
                pComprobante.Impuestos.TotalImpuestosRetenidosSpecified = false;
            #endregion

            return pComprobante;
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

        public T LoadFromXml<T>(string path) where T : class
        {
            xmlSerializer = new XmlSerializer(typeof(T));

            using (xmlReader = XmlReader.Create(path))
            {
                return xmlSerializer.Deserialize(xmlReader) as T;
            }
        }

        #endregion


    }
}
