using System.Text.RegularExpressions;

namespace BellezaTotal_BLL.Clases
{
    public static class ValidadorCuit
    {
        
        private static readonly Regex Formato = new Regex(@"^[0-9]{2}-[0-9]{8}-[0-9]\z", RegexOptions.Compiled);

        
        private static readonly int[] Pesos = { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };

        public static bool TieneFormatoValido(string cuit)
        {
            return cuit != null && Formato.IsMatch(cuit);
        }

        
        public static bool EsValido(string cuit)
        {
            if (!TieneFormatoValido(cuit)) return false;

            string digitos = cuit.Replace("-", string.Empty);

            int suma = 0;

            for (int i = 0; i < Pesos.Length; i++)
                suma += (digitos[i] - '0') * Pesos[i];

            int verificador = 11 - (suma % 11);

            if (verificador == 11) verificador = 0;


            if (verificador == 10) return false;

            return verificador == digitos[10] - '0';
        }
    }
}