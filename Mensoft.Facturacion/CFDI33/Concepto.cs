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
        [XmlElement("InformacionAduanera")]
        public List<ConceptoInformacionAduanera> InformacionesAduanera { get; set; }

        //[XmlElement("Impuestos")]
        public ConceptoImpuestos Impuestos { get; set; }


        public Concepto()
        {
            InformacionesAduanera = null;
        }



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
