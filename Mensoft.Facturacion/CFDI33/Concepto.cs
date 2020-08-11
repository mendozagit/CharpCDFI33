using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Concepto
    {
        public List<ConceptoInformacionAduanera> InformacionesAduanera { get; set; }
        public List<ConceptoTraslado> Traslados { get; set; }
        public List<ConceptoRetencion> Retenciones { get; set; }

        public Concepto()
        {
            InformacionesAduanera = new List<ConceptoInformacionAduanera>();
            Traslados = new List<ConceptoTraslado>();
            Retenciones = new List<ConceptoRetencion>();

        }
        [XmlElement("InformacionAduanera")]


        public ConceptoCuentaPredial CuentaPredial { get; set; }

        public ConceptoComplemento ComplementoConcepto { get; set; }

        [XmlElement("Parte")]
        public List<ConceptoParte> Partes { get; set; }

        [XmlAttribute()]
        public string ClaveProdServ { get; set; }

        [XmlAttribute()]
        public string NoIdentificacion { get; set; }


        [XmlAttribute()]
        public decimal Cantidad { get; set; }


        [XmlAttribute()]
        public string ClaveUnidad { get; set; }


        [XmlAttribute()]
        public string Unidad { get; set; }


        [XmlAttribute()]
        public string Descripcion { get; set; }


        [XmlAttribute()]
        public decimal ValorUnitario { get; set; }


        [XmlAttribute()]
        public decimal Importe { get; set; }


        [XmlAttribute()]
        public decimal Descuento { get; set; }


    }
}
