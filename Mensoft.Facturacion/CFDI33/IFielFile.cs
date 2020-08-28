namespace Mensoft.Facturacion.CFDI33
{
    public interface IFielFile
    {
        string Path
        {
            get;
            set;
        }

        bool Initialize();
        bool Exist();
        byte[] GetFileBytes();
        string GetFileBase64();

    }
}