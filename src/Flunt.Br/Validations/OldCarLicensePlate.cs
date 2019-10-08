using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class OldCarLicensePlate : IValidate
    {
        public bool Validate(string value)
        {
            return (value.Length == 7 || value.Length == 8) && new Regex(@"[A-Z]{3}\-?[0-9]{4}", RegexOptions.Singleline).Match(value).Success;
        }
    }
}
