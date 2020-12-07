using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsoleAppNetCore.Programs
{
    class RsaSignClient
    {
        public static void Run()
        {
            string cert = File.ReadAllText("Programs/test._cert");

            var toBeEncryptedContract = new LicenseContract
            {
                NotAfter = DateTimeOffset.UtcNow.AddMinutes(5),
                NotBefore = DateTimeOffset.UtcNow,
                LicensedTo = Guid.Empty.ToString("N"),
                SchemaVersion = "1.0",
                LicenseId = Guid.NewGuid(),
                Products = new List<object>
                {
                    new
                    {
                        Amount=10,
                        Name= "rrr",
                        Sku= "aaa"
                    }
                }
            };
            //var str = SignLicenseContract(toBeEncryptedContract);
            var str = "BA72650B45704ED9848647833B33A41D-ewAiAE0AYQBjAGgAaQBuAGUASwBlAHkAIgA6ACIANAA1ADAARgBCADUANgA3AC0AMwBEADkAOQAtAEYAOQA0AEYALQBBADIARAAyAC0AMQA1ADMANwBBAEUANAA5AEYAMQA3ADYAIgAsACIATABpAGMAZQBuAHMAZQBJAGQAIgA6ACIAQgBBADcAMgA2ADUAMABCADQANQA3ADAANABFAEQAOQA4ADQAOAA2ADQANwA4ADMAMwBCADMAMwBBADQAMQBEACIALAAiAFMAYwBoAGUAbQBhAFYAZQByAHMAaQBvAG4AIgA6ACIAMQAuADAAIgAsACIAUgBlAHEAdQBlAHMAdABlAGQAQgB5ACIAOgAiAGgAdQBhAG4AZwByAHUAaQBAAGUAbgBjAG8AbwB0AGUAYwBoAC4AbwBuAG0AaQBjAHIAbwBzAG8AZgB0AC4AYwBvAG0AIgAsACIAUgBlAHEAdQBlAHMAdABlAGQAQQB0ACIAOgAiADIAMAAyADAALQAwADcALQAwADcAVAAwADMAOgA0ADkAOgAzADkALgAxADQAMAAxADEAMwAyACsAMAAwADoAMAAwACIALAAiAE4AbwB0AEIAZQBmAG8AcgBlACIAOgAiADIAMAAyADAALQAwADcALQAwADcAVAAwADMAOgAyADAAOgAwADkALgA3ADgANABaACIALAAiAE4AbwB0AEEAZgB0AGUAcgAiADoAIgAyADAAMgA2AC0AMAA4AC0AMwAxAFQAMAAzADoAMgAwADoAMAA5AC4ANwA4ADQAWgAiACwAIgBMAGkAYwBlAG4AcwBlAGQAVABvACIAOgAiACAAMAA4AGQANwBkADYAZQAwAC0AMwA3AGIAOAAtADQANwAzADgALQA4ADIAYQAyAC0AYQA5AGMANQA4AGUANABmADgANwBkADUAIgAsACIAUAByAG8AZAB1AGMAdABzACIAOgBbAHsAIgBOAGEAbQBlACIAOgAiAGMAbwBuAHMAbwBsAGUAIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEALAAiAFMAawB1ACIAOgAiAGUAbgB0AGUAcgBwAHIAaQBzAGUAIgB9ACwAewAiAE4AYQBtAGUAIgA6ACIAcgBvAGIAbwB0ACIALAAiAEEAbQBvAHUAbgB0ACIAOgAxADAAMAAsACIAUwBrAHUAIgA6ACIAZQBuAHQAZQByAHAAcgBpAHMAZQBfAGIAYQBzAGkAYwAiAH0ALAB7ACIATgBhAG0AZQAiADoAIgByAG8AYgBvAHQAIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEAMAAwACwAIgBTAGsAdQAiADoAIgBlAG4AdABlAHIAcAByAGkAcwBlAF8AcAByAG8AIgB9ACwAewAiAE4AYQBtAGUAIgA6ACIAcwB0AHUAZABpAG8AIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEAMAAwACwAIgBTAGsAdQAiADoAIgBlAG4AdABlAHIAcAByAGkAcwBlACIAfQBdAH0A-DdlASX+udVCSLCQyIWz/ssbLkTNfdeh0DHTxfhrf3g+SzA3Ota7Iua1ryupTCM6OXHiwVRfhnZlp9QU7Gnl4DUJ3pOcUUfFhSHii+2ObIjYatGQLeik6iSwIyCiROJ+ZnBjCIlQOtiPlMbYzH/MW0muNqTNVMjWV+rLa3dLCOxfj5cwXcQH87ijSIMgyUXoMi+YCG+bA0T0//n57LNK8qKW3kJFX1pElKHHDgcukRGwVKb2hOv5L97R25hUuMiwgFwxZDE67PJkb2f53ut7sQlqcoyIN+h+fBjVpFtOwbK2eCQMMly8K8uSqhq3iZ8DebJE6vaTJY1R4r04QrE6aBA==";

            //
            var licenseParts = str.Split('-');
            string id = licenseParts[0];
            string payload = licenseParts[1];
            var data = Encoding.Unicode.GetString(Convert.FromBase64String(payload));
            string signature = licenseParts[2];


            X509Certificate2 certificate = new X509Certificate2(Encoding.UTF8.GetBytes(cert));
            byte[] buffer = Encoding.Unicode.GetBytes(payload);

            using (RSA rsa = certificate.GetRSAPublicKey())//验证签名
            {
                var hash2 = Convert.FromBase64String(signature);
                var result = rsa.VerifyData(buffer, hash2, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                if (result)
                {
                    string strData = Encoding.Unicode.GetString(Convert.FromBase64String(payload));

                }
            }





            X509Certificate2 pri = new X509Certificate2(File.ReadAllBytes(@"Programs/test._pfx"), "123456");
            X509Certificate2 pub = new X509Certificate2(Encoding.UTF8.GetBytes(cert));

            RSA RSAPrivate = pri.GetRSAPrivateKey();
            RSA RSAPublic = pub.GetRSAPublicKey();
            byte[] dataToEncrypt = Encoding.Unicode.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(toBeEncryptedContract));
            string licenseText = Convert.ToBase64String(dataToEncrypt);
            byte[] hash = RSAPrivate.SignData(dataToEncrypt, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var signature2 = Convert.ToBase64String(hash);
            bool a = RSAPublic.VerifyData(dataToEncrypt, hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            Console.ReadLine();
        }

        private static string SignLicenseContract(LicenseContract licenseContract)
        {
            Guid licenseId = licenseContract.LicenseId;
            byte[] liceseBytes = Encoding.Unicode.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(licenseContract));
            string licenseText = Convert.ToBase64String(liceseBytes);
            X509Certificate2 pri = new X509Certificate2(File.ReadAllBytes(@"test.pfx"), "123456");
            var privateKey = pri.GetRSAPrivateKey();
            byte[] hash = privateKey.SignData(Encoding.Unicode.GetBytes(licenseText), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            string signature = Convert.ToBase64String(hash);
            return $"{licenseId.ToString("N")}-{licenseText}-{signature}";
        }
    }

    public class LicenseContract
    {
        /// <summary>
        /// license id
        /// </summary>
        public Guid LicenseId { get; set; }

        /// <summary>
        /// machine info from the server device
        /// </summary>
        public string MachineKey { get; set; }

        /// <summary>
        /// 1.0 by default
        /// </summary>
        public string SchemaVersion { get; set; }

        /// <summary>
        /// who request this license
        /// </summary>
        public string RequestedBy { get; set; }

        /// <summary>
        /// request date time
        /// </summary>
        public DateTimeOffset RequestedAt { get; set; }

        /// <summary>
        /// date time that license starts to activate,
        /// </summary>
        public DateTimeOffset NotBefore { get; set; }

        /// <summary>
        /// date time that license ends
        /// </summary>
        public DateTimeOffset NotAfter { get; set; }

        /// <summary>
        /// authorize the license to whom.it could be a tenant id who owns the license
        /// </summary>
        public string LicensedTo { get; set; }

        /// <summary>
        /// list that contains products, quantity could be used
        /// </summary>
        public virtual List<Object> Products { get; set; }
    }
}
