using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using Org.BouncyCastle.Asn1.Misc;

namespace Mensoft.Facturacion.CFDI33
{
    public class PrivateKey : IFielFile
    {
        private Org.BouncyCastle.Crypto.AsymmetricKeyParameter asymmetricKeyParameter;
        private Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters rsaKeyParameters;
        private Org.BouncyCastle.Crypto.ISigner signer;
        private string path;
        private byte[] fileBytes;
        private string algorithm;
        private string password;
        private string originalString;

        public PrivateKey(string path)
        {
            Path = path;
        }

        public PrivateKey(string path, string password, string algorithm)
        {
            this.path = path;
            this.password = password;
            this.algorithm = algorithm;
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

        public string Algorithm
        {
            get => algorithm;
            set => algorithm = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public string OriginalString
        {
            get => originalString;
            set => originalString = value;
        }

        public bool Exist()
        {
            return File.Exists(Path);
        }

        public byte[] GetFileBytes()
        {
            return File.ReadAllBytes(Path);
        }

        public string GetFileBase64()
        {
            return "Not Implemented Yet";
        }
        public bool Initialize()
        {
            try
            {
                if (!File.Exists(Path)) return false;
                fileBytes = File.ReadAllBytes(Path);
                asymmetricKeyParameter = Org.BouncyCastle.Security.PrivateKeyFactory.DecryptKey(password.ToCharArray(), fileBytes);
                rsaKeyParameters = (Org.BouncyCastle.Crypto.Parameters.RsaKeyParameters)asymmetricKeyParameter;
                signer = Org.BouncyCastle.Security.SignerUtilities.GetSigner(algorithm);
                signer.Init(true, rsaKeyParameters);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
        public string GenerateSignature(string originalStringPhrase)
        {
            try
            {
                this.originalString = originalStringPhrase;
                signer.BlockUpdate(Encoding.UTF8.GetBytes(originalStringPhrase), 0, Encoding.UTF8.GetBytes(OriginalString).Length);
                var signedBytes = signer.GenerateSignature();
                return Convert.ToBase64String(signedBytes);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return string.Empty;
            }
        }
    }
}