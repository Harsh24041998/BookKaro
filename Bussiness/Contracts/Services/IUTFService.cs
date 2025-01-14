namespace Bussiness.Contracts.Services
{
    public interface IUTFService
    {
        public string Encryptdata(string plainText);
        public string Decryptdata(string cipherText);
    }
}
