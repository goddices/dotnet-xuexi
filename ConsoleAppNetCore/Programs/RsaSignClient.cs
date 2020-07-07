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
        static string cert = @"";
        public static void Run()
        {
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
            var str = SignLicenseContract(toBeEncryptedContract);
            var ddd = "ewAiAE0AYQBjAGgAaQBuAGUASwBlAHkAIgA6ACIANAA1ADAARgBCADUANgA3AC0AMwBEADkAOQAtAEYAOQA0AEYALQBBADIARAAyAC0AMQA1ADMANwBBAEUANAA5AEYAMQA3ADYAIgAsACIATABpAGMAZQBuAHMAZQBJAGQAIgA6ACIANQA3ADkAQgBCADMANABBAEIAQQAwADgANABGADUAMQBBADMAOQA0ADcANgAzAEYARgBFAEYAQQA2ADMAMQA4ACIALAAiAFMAYwBoAGUAbQBhAFYAZQByAHMAaQBvAG4AIgA6ACIAMQAuADAAIgAsACIAUgBlAHEAdQBlAHMAdABlAGQAQgB5ACIAOgAiAGgAdQBhAG4AZwByAHUAaQBAAGUAbgBjAG8AbwB0AGUAYwBoAC4AbwBuAG0AaQBjAHIAbwBzAG8AZgB0AC4AYwBvAG0AIgAsACIAUgBlAHEAdQBlAHMAdABlAGQAQQB0ACIAOgAiADIAMAAyADAALQAwADQALQAwADMAVAAwADEAOgA1ADQAOgAzADEALgA3ADgAOQA5ADAAMgA4ACsAMAAwADoAMAAwACIALAAiAE4AbwB0AEIAZQBmAG8AcgBlACIAOgAiADIAMAAyADAALQAwADQALQAwADIAVAAwADEAOgA1ADMAOgA1ADQALgAwADcAWgAiACwAIgBOAG8AdABBAGYAdABlAHIAIgA6ACIAMgAwADIAOQAtADEAMQAtADMAMABUADAAMQA6ADUAMwA6ADUANAAuADAANwBaACIALAAiAEwAaQBjAGUAbgBzAGUAZABUAG8AIgA6ACIAMAA4AGQANwBkADYAZQAwAC0AMwA3AGIAOAAtADQANwAzADgALQA4ADIAYQAyAC0AYQA5AGMANQA4AGUANABmADgANwBkADUAIgAsACIAUAByAG8AZAB1AGMAdABzACIAOgBbAHsAIgBOAGEAbQBlACIAOgAiAGMAbwBuAHMAbwBsAGUAIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEALAAiAFMAawB1ACIAOgAiAGUAbgB0AGUAcgBwAHIAaQBzAGUAIgB9ACwAewAiAE4AYQBtAGUAIgA6ACIAcgBvAGIAbwB0ACIALAAiAEEAbQBvAHUAbgB0ACIAOgAxADAAMgAsACIAUwBrAHUAIgA6ACIAZQBuAHQAZQByAHAAcgBpAHMAZQBfAGIAYQBzAGkAYwAiAH0ALAB7ACIATgBhAG0AZQAiADoAIgByAG8AYgBvAHQAIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEAMAAzACwAIgBTAGsAdQAiADoAIgBlAG4AdABlAHIAcAByAGkAcwBlAF8AcAByAG8AIgB9ACwAewAiAE4AYQBtAGUAIgA6ACIAcwB0AHUAZABpAG8AIgAsACIAQQBtAG8AdQBuAHQAIgA6ADEAMAAxACwAIgBTAGsAdQAiADoAIgBlAG4AdABlAHIAcAByAGkAcwBlACIAfQBdAH0A";

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





            X509Certificate2 pri = new X509Certificate2(File.ReadAllBytes(@"test._pfx"), "123456");
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
