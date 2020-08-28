using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensoft.Facturacion.CFDI33
{
    public class Fiel
    {
        public Certificate Certificate { get; set; }
        public PrivateKey PrivateKey { get; set; }


        public Fiel(Certificate certificate, PrivateKey privateKey)
        {
            Certificate = certificate;
            PrivateKey = privateKey;
        }

    }
}
