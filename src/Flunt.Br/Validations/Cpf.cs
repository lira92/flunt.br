using System.Linq;
using Flunt.Br.Document.Interfaces;

namespace Flunt.Br.Validations
{
    internal class Cpf : IValidate
    {
        private readonly string[] cpfInvalid =
        {
            "00000000000", "11111111111", "22222222222",
            "33333333333", "44444444444", "55555555555",
            "66666666666", "77777777777", "88888888888", "99999999999"
        };

        public bool Validate(string value)
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "");
            if(!long.TryParse(value, out var parsed))
                return false;
            if (value.Length != 11 || cpfInvalid.Contains(value))
                return false;
            tempCpf = value.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            resto = resto < 2 ? 0 : 11 - resto;
            digito = digito + resto;
            return value.EndsWith(digito);
        }
    }
}
