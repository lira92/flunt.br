using Flunt.Br.Document.Interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class CreditCard : IValidate
    {
        public bool Validate(string value) => Validate(value, null);

        private static bool IsValidLuhnn(string val)
        {
            var valSum = 0;
            var currentProcNum = 0;

            for (int i = val.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(val.Substring(i, 1), out int currentDigit))
                    return false;

                currentProcNum = currentDigit << (1 + i & 1);
                valSum += (currentProcNum > 9 ? currentProcNum - 9 : currentProcNum);
            }

            return (valSum > 0 && valSum % 10 == 0);
        }

        public bool Validate(string value, IValidationOptions options)
        {
            value = new Regex(@"['\""&,\\]|\s{2,}").Replace(value, "").Trim();
            if (!new Regex(@"[0-9]+").IsMatch(value)) return false;

            if (!value.All(char.IsDigit))
            {
                return false;
            }
            if (12 > value.Length || value.Length > 19)
            {
                return false;
            }

            return IsValidLuhnn(value);
        }
    }
}