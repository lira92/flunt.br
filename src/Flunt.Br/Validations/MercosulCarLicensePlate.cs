using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class MercosulCarLicensePlate : IValidate
    {
        public bool Validate(string value)
        {
            return (value.Length == 7 || value.Length == 8) && new Regex(@"[A-Z]{3}\-?[0-9][A-Z][0-9]{2}", RegexOptions.Singleline).Match(value).Success;
        }
    }
}
