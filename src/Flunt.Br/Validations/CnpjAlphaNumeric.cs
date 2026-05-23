using System.Linq;
using System.Text.RegularExpressions;
using Flunt.Br.Document.Interfaces;

namespace Flunt.Br.Validations
{
    internal class CnpjAlphaNumeric : IValidate
    {
        public bool Validate(string value)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            string pattern = @"^[a-zA-Z0-9]{12}\d{2}$";
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "").Replace("/", "");
            if (!Regex.IsMatch(value, pattern))
                return false;
            tempCnpj = value.Substring(0, 12).ToUpper();
            // CNPJ com todos os caracteres iguais é inválido
            if (tempCnpj.All(caractere => caractere == value[0]))
                return false;
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += (tempCnpj[i] - '0') * multiplicador1[i];
            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += (tempCnpj[i] - '0') * multiplicador2[i];
            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto;
            return value.EndsWith(digito);
        }
    }
}