using Flunt.Br.Document.Interfaces;

namespace Flunt.Br.Validations
{
    internal class Cnh : IValidate
    {
        public bool Validate(string value)
        {
            int[] multiplicador = { 9, 10 };
            string dvRecebido, cnhSemDv, dvCalculado = "";
            int soma = 0;

            value = value.Trim().Replace(",", "").Replace(".", "").Replace("-", "").Replace("_", "");

            if (value.Length == 11 && value != "00000000000")
            {
                dvRecebido = value.Substring(9, 2);
                cnhSemDv = value.Substring(0, 9);

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        soma += int.Parse(cnhSemDv[j].ToString()) * multiplicador[i];
                        multiplicador[i]--;
                    }
                    var temp = soma % 11;
                    if (temp >= 10)
                        dvCalculado += 1;
                    else
                    {
                        dvCalculado += temp;
                    }
                    soma = 0;
                }

                return dvRecebido == dvCalculado;
            }
            else
                return false;
        }
    }
}