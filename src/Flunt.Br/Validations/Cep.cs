using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class Cep : IValidate
    {
        public bool Validate(string value) => Validate(value, null);

        public bool Validate(string value, IValidationOptions options)
        {
            if (value.IndexOf("-") > 0)
            {
                return new Regex(@"^\d{5}-\d{3}$", RegexOptions.Singleline).Match(value).Success;
            }
            return new Regex(@"^\d{8}$", RegexOptions.Singleline).Match(value).Success;
        }
    }
}