using Flunt.Br.Document.Interfaces;

namespace Flunt.Br.Validations
{
    internal class Cnpj : IValidate
    {
        public bool Validate(string value) => Validate(value, null);

        public bool Validate(string value, IValidationOptions options)
        {
            var multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "").Replace("/", "");
            if (value.Length != 14 || !long.TryParse(value, out var parsed))
                return false;
            tempCnpj = value.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto;
            return value.EndsWith(digito);
        }
    }
}