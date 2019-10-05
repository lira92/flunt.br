using System;
using Flunt.Br.Document.Interfaces;

namespace Flunt.Br.Validations
{
    internal class Cnh : IValidate
    {
        public bool Validate(string valor)
        {
            bool isValid = false;

            var Cnh = valor;

            var FirstChar = Cnh[0];

            if (Cnh.Length == 11 && Cnh != new string('1', 11))
            {
                var dsc = 0;
                var v = 0;

                for (int i = 0, j = 9; i < 9; i++, j--)
                {
                    v += (Convert.ToInt32(Cnh[i].ToString()) * j);
                }

                var vl1 = v % 11;

                if (vl1 >= 10)
                {
                    vl1 = 0;
                    dsc = 2;
                }

                v = 0;

                for (int i = 0, j = 1; i < 9; ++i, ++j)
                {
                    v += (Convert.ToInt32(Cnh[i].ToString()) * j);
                }

                var x = v % 11;
                var vl2 = (x >= 10) ? 0 : x - dsc;

                isValid = vl1.ToString() + vl2.ToString() == Cnh.Substring(Cnh.Length - 2, 2);

            }

            return isValid;

        }
    }
}