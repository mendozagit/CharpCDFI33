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
        private readonly XmlSerializerNamespaces namespaces;
        private XmlSerializer xmlSerializer;
        private XmlWriter xmlWriter;
        private XmlReader xmlReader;

        //Comprobante 
        private readonly Comprobante comprobante;
        private List<ComprobanteImpuestosTraslado> comprobanteTraslados;
        private List<ComprobanteImpuestosRetencion> comprobanteRetenciones;

        //Concepto

        private readonly List<ComprobanteConcepto> conceptos;
        private ComprobanteConceptoImpuestosTraslado conceptoTraslado;
        //private List<ComprobanteConceptoImpuestosTraslado> conceptoTraslados;
        private ComprobanteConceptoImpuestosRetencion conceptoRetencion;

        private List<ComprobanteConceptoImpuestosRetencion> conceptoRetenciones;


        #region Constructores

        public CfdiService(string tipoDeComprobante, string version)
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("cfdi", "http://www.sat.gob.mx/cfd/3");
            namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            comprobante = new Comprobante { Version = version, TipoDeComprobante = tipoDeComprobante };

            conceptos = new List<ComprobanteConcepto>();
            conceptoTraslados = new List<ComprobanteConceptoImpuestosTraslado>();
            conceptoRetenciones = new List<ComprobanteConceptoImpuestosRetencion>();
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

        public void CalculaComprobante()
        {

            comprobante.Conceptos = conceptos.ToArray();
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
