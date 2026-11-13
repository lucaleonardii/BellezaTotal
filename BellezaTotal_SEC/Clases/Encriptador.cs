using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BellezaTotal_SEC.Clases
{
    public class Encriptador
    {
        public string Encriptar(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha.ComputeHash(bytes);

                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public Encriptador() { }
    }
}
