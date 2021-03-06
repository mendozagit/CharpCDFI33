﻿namespace Mensoft.Facturacion.CFDI33.Facturacion
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/3")]
    public partial class ComprobanteConceptoImpuestosRetencion
    {

        private decimal baseField;

        private string impuestoField;

        private string tipoFactorField;

        private decimal tasaOCuotaField;

        private decimal importeField;


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Base
        {
            get
            {
                return baseField;
            }
            set
            {
                baseField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Impuesto
        {
            get
            {
                return impuestoField;
            }
            set
            {
                impuestoField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TipoFactor
        {
            get
            {
                return tipoFactorField;
            }
            set
            {
                tipoFactorField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal TasaOCuota
        {
            get
            {
                return tasaOCuotaField;
            }
            set
            {

                tasaOCuotaField = value;
            }
        }


        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Importe
        {
            get
            {
                return importeField;
            }
            set
            {
                importeField = value;
            }
        }
    }
}