using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using System.Security.Cryptography;

namespace DigitalniPotpis.Kriptografija
{
    public class Kriptiranje
    {
        // Simetrično kriptiranje (AES)
        public static void KriptirajSimetricno(string ulaznaDatoteka, string kriptiranaDatoteka, string tajniKljucDatoteka)
        {
            byte[] kljuc = Convert.FromBase64String(File.ReadAllText(tajniKljucDatoteka));

            using (Aes aes = Aes.Create())
            {
                aes.Key = kljuc;
                aes.GenerateIV(); 
                File.WriteAllBytes(kriptiranaDatoteka + ".iv", aes.IV); 

                using (FileStream ulazniTok = new FileStream(ulaznaDatoteka, FileMode.Open))
                using (MemoryStream kriptiraniTok = new MemoryStream())
                using (CryptoStream kriptoTok = new CryptoStream(kriptiraniTok, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    ulazniTok.CopyTo(kriptoTok);
                    kriptoTok.FlushFinalBlock();

                    string kriptiraniBase64 = Convert.ToBase64String(kriptiraniTok.ToArray());
                    File.WriteAllText(kriptiranaDatoteka, kriptiraniBase64);
                }
            }
        }

        public static void DekriptirajSimetricno(string kriptiranaDatoteka, string dekriptiranaDatoteka, string tajniKljucDatoteka)
        {
            byte[] kljuc = Convert.FromBase64String(File.ReadAllText(tajniKljucDatoteka));
            byte[] iv = File.ReadAllBytes(kriptiranaDatoteka + ".iv");

            using (Aes aes = Aes.Create())
            {
                aes.Key = kljuc;
                aes.IV = iv;

                string kriptiraniBase64 = File.ReadAllText(kriptiranaDatoteka);
                byte[] kriptiraniBytes = Convert.FromBase64String(kriptiraniBase64);

                using (MemoryStream kriptiraniTok = new MemoryStream(kriptiraniBytes))
                using (FileStream dekriptiraniTok = new FileStream(dekriptiranaDatoteka, FileMode.Create))
                using (CryptoStream kriptoTok = new CryptoStream(kriptiraniTok, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    kriptoTok.CopyTo(dekriptiraniTok);
                }
            }
        }

        // Asimetrično kriptiranje (RSA)
        public static string KriptirajAsimetricno(string podaci, string putDoJavnogKljuca)
        {
            string javniKljuc = File.ReadAllText(putDoJavnogKljuca);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(javniKljuc);

                byte[] podaciBytes = System.Text.Encoding.UTF8.GetBytes(podaci);

                byte[] kriptiranoBytes = rsa.Encrypt(podaciBytes, false);

                return Convert.ToBase64String(kriptiranoBytes);
            }
        }

        public static string DekriptirajAsimetricno(string kriptiraniPodaci, string putDoPrivatnogKljuca)
        {
            string privatniKljuc = File.ReadAllText(putDoPrivatnogKljuca);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privatniKljuc);

                byte[] kriptiraniBytes = Convert.FromBase64String(kriptiraniPodaci);

                byte[] dekriptiranoBytes = rsa.Decrypt(kriptiraniBytes, false);

                return System.Text.Encoding.UTF8.GetString(dekriptiranoBytes);
            }
        }

        public static void IzracunajSazetak(string ulaznaDatoteka, string sazetakDatoteka)
        {
            using (FileStream fs = new FileStream(ulaznaDatoteka, FileMode.Open))
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(fs);
                string hash = Convert.ToBase64String(hashBytes);

                File.WriteAllText(sazetakDatoteka, hash);
            }
        }

        public static void PotpisiSazetak(string sazetakDatoteka, string potpisDatoteka, string privatniKljucDatoteka)
        {
            string sazetak = File.ReadAllText(sazetakDatoteka);
            byte[] sazetakBytes = Convert.FromBase64String(sazetak);

            string privatniKljuc = File.ReadAllText(privatniKljucDatoteka);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privatniKljuc);

                byte[] potpisBytes = rsa.SignData(sazetakBytes, CryptoConfig.MapNameToOID("SHA256"));
                string potpis = Convert.ToBase64String(potpisBytes);

                File.WriteAllText(potpisDatoteka, potpis);
            }
        }

        public static bool ProvjeriPotpis(string sazetakDatoteka, string potpisDatoteka, string javniKljucDatoteka)
        {
            string sazetak = File.ReadAllText(sazetakDatoteka);
            byte[] sazetakBytes = Convert.FromBase64String(sazetak);

            string potpis = File.ReadAllText(potpisDatoteka);
            byte[] potpisBytes = Convert.FromBase64String(potpis);

            string javniKljuc = File.ReadAllText(javniKljucDatoteka);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(javniKljuc);

                return rsa.VerifyData(sazetakBytes, CryptoConfig.MapNameToOID("SHA256"), potpisBytes);
            }
        }

    }

}
