using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class VoterDocument : IValidate
    {
        public bool Validate(string value)
        {
            int d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, DV1, DV2, UltDig;

            value = new Regex(@"['\""&,\\]|\s{2,}").Replace(value, "").Trim();
            if (!new Regex(@"[0-9]+").IsMatch(value)) return false;
            if ((value.Length < 12))
            {
                value = value.PadLeft(12 - value.Length, '0');
            }

            UltDig = value.Length;
            if (value == "000000000000")
            {
                return false;
            }

            d1 = int.Parse(value.Substring(UltDig - 12, 1));
            d2 = int.Parse(value.Substring(UltDig - 11, 1));
            d3 = int.Parse(value.Substring(UltDig - 10, 1));
            d4 = int.Parse(value.Substring(UltDig - 9, 1));
            d5 = int.Parse(value.Substring(UltDig - 8, 1));
            d6 = int.Parse(value.Substring(UltDig - 7, 1));
            d7 = int.Parse(value.Substring(UltDig - 6, 1));
            d8 = int.Parse(value.Substring(UltDig - 5, 1));
            d9 = int.Parse(value.Substring(UltDig - 4, 1));
            d10 = int.Parse(value.Substring(UltDig - 3, 1));
            d11 = int.Parse(value.Substring(UltDig - 2, 1));
            d12 = int.Parse(value.Substring(UltDig - 1, 1));
            DV1 = ((d1 * 2)
                        + ((d2 * 3)
                        + ((d3 * 4)
                        + ((d4 * 5)
                        + ((d5 * 6)
                        + ((d6 * 7)
                        + ((d7 * 8)
                        + (d8 * 9))))))));
            DV1 = (DV1 % 11);

            if ((DV1 == 10))
            {
                DV1 = 0;
            }

            DV2 = ((d9 * 7)
                        + ((d10 * 8)
                        + (DV1 * 9)));
            DV2 = (DV2 % 11);
            // Obtem o resto
            // se o resto for igual a 10 altera pra 0
            if ((DV2 == 10))
            {
                DV2 = 0;
            }

            if ((d11 == DV1) && (d12 == DV2))
            {
                if ((d9 + d10) > 0 && (d9 + d10) < 29)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}