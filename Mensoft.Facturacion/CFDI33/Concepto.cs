using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Mensoft.Facturacion.CFDI33
{
    public class Concepto
    {
        public IList<ConceptoInformacionAduanera> InformacionesAduanera { get; set; }
        public IList<ConceptoTraslado> Traslados { get; set; }
        public IList<ConceptoRetencion> Retenciones { get; set; }

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
        public IList<ConceptoParte> Partes { get; set; }

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
