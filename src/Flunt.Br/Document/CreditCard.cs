using Flunt.Br.Document.interfaces;
using System.Linq;
using System.Text.RegularExpressions;

namespace Flunt.Br.Document
{
    internal class CreditCard : IValidate
    {
        public bool Validate(string value)
        {
            value = new Regex(@"['\""&,\\]|\s{2,}").Replace(value, "").Trim();
            if (!new Regex(@"[0-9]+").IsMatch(value)) return false;
        
            if (value.All(char.IsDigit) == false)
            {
                return false;
            }
            if (12 > value.Length || value.Length > 19)
            {
                return false;
            }
          
            return IsValidLuhnn(value);
        }

        private bool IsValidLuhnn(string val)
        {
            int currentDigit;
            int valSum = 0;
            int currentProcNum = 0;

            for (int i = val.Length - 1; i >= 0; i--)
            {
                if (!int.TryParse(val.Substring(i, 1), out currentDigit))
                    return false;

                currentProcNum = currentDigit << (1 + i & 1);
                valSum += (currentProcNum > 9 ? currentProcNum - 9 : currentProcNum);

            }

            return (valSum > 0 && valSum % 10 == 0);
        }
    }
}