using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;


namespace DigitalniPotpis.Kriptografija
{
    public class GeneratorKljuca
    {
        public static void GenerirajRSAKljuceve(string putDoJavnogKljuca, string putDoPrivatnogKljuca)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;

                File.WriteAllText(putDoJavnogKljuca, rsa.ToXmlString(false));
                File.WriteAllText(putDoPrivatnogKljuca, rsa.ToXmlString(true));
            }
        }

        public static void GenerirajAESKljuc(string putDoTajnogKljuca)
        {
            using (var aes = Aes.Create())
            {
                string kljucBase64 = Convert.ToBase64String(aes.Key);

                File.WriteAllText(putDoTajnogKljuca, kljucBase64);
            }
        }
    }
}
