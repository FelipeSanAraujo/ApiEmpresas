using System.Text;
using System.Security.Cryptography;

namespace EmpresasApi.Infra.Data.Utils
{
    public class Criptografia
    {
        public string GetMD5(string valor)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(valor));

            var result = string.Empty;
            foreach (var item in hash)
                result += item.ToString("X2");

            return result;
        }
    }
}



