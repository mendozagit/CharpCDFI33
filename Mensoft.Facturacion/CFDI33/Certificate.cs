using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.Crmf;

namespace Mensoft.Facturacion.CFDI33
{
    public class Certificate : IFielFile
    {
        private string path;
        private byte[] fileBytes;
        private X509Certificate2 certificado;

        public Certificate(string path)
        {
            this.path = path;
            Initialize();
        }
        public string Path
        {
            get => path;
            set => path = value;
        }

        public byte[] FileBytes
        {
            get => fileBytes;
            set => fileBytes = value;
        }

        public X509Certificate2 Certificado
        {
            get => certificado;
            set => certificado = value;
        }

        public bool Exist()
        {
            return File.Exists(path);
        }

        public byte[] GetFileBytes()
        {
            return File.ReadAllBytes(path);
        }

        public string GetFileBase64()
        {
            return Convert.ToBase64String(fileBytes);
        }


        public string GetEffectiveDateString()
        {
            return certificado.GetEffectiveDateString();
        }


        public string FriendlyName()
        {
            return certificado.FriendlyName;
        }
        public string Thumbprint()
        {
            return certificado.Thumbprint;
        }
        public string Issuer()
        {
            return certificado.Issuer;
        }
        public string Subject()
        {
            return certificado.Subject;
        }
        public string GetSerialNumberString()
        {
            return certificado.GetSerialNumberString();
        }
        public string GetExpirationDateString()
        {
            return certificado.GetExpirationDateString();
        }
        public string GetPublicKeyString()
        {
            return certificado.GetPublicKeyString();
        }
        public bool HasPrivateKey()
        {
            return certificado.HasPrivateKey;
        }
        public string IssuerName()
        {
            return certificado.IssuerName.Name;

        }
        public DateTime NotBefore()
        {
            return certificado.NotBefore.Date;

        }
        public DateTime NotAfter()
        {
            return certificado.NotAfter.Date;
        }
        public bool Verify()
        {
            return certificado.Verify();
        }
        public int Version()
        {
            return certificado.Version;
        }


        public string CertificateNumber()
        {
            //return certificado.GetSerialNumberString();

            return Encoding.ASCII.GetString(certificado.GetSerialNumber().Reverse().ToArray());
        }
        public string CertificateBase64()
        {
            return Convert.ToBase64String(certificado.Export(X509ContentType.Cert));
            // return Convert.ToBase64String(fileBytes);
        }
        public bool Initialize()
        {
            try
            {
                if (!File.Exists(path)) return false;
                fileBytes = File.ReadAllBytes(path);
                certificado = new X509Certificate2(fileBytes);
                return certificado != null;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}
