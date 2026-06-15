using System.Security.Cryptography;
using System.Text;

namespace Redbox_MQTT
{
    class CertificatePasswordGenerator
    {

        private async Task<string> GetSaltOfTheCertificatePassword(string kioskId)
        {
            int num = 0;
            char c = kioskId[kioskId.Length - 1];
            foreach (char c2 in kioskId + kioskId)
            {
                num *= (int)(c2 * c);
            }
            return num.ToString();
        }

        public async Task<string> GetCertificatePassword(string kioskId)
        {
            SHA512 sha = new SHA512Managed();
            byte[] array = sha.ComputeHash(Encoding.UTF8.GetBytes(kioskId));
            string text = Convert.ToBase64String(array);
            Task<string> saltOfTheCertificatePassword = this.GetSaltOfTheCertificatePassword(kioskId);
            array = sha.ComputeHash(Encoding.UTF8.GetBytes(text + saltOfTheCertificatePassword));
            return Convert.ToBase64String(array);
        }


        static async Task Maina(string[] args)
        {
            Console.Write("Enter Your Kiosk ID: ");
            string kioskidnum = Console.ReadLine();
            CertificatePasswordGenerator creator = new CertificatePasswordGenerator(); // Create an instance
            string result = await creator.GetCertificatePassword(kioskidnum);
            Console.WriteLine(result); // Optionally, print the result
        }
    }
}
