using System.Text.RegularExpressions;
using Flunt.Br.Document.interfaces;

namespace Flunt.Br.Document
{
    internal class Cep : IValidate
    {
        public bool Validate(string value)
        {
             if (value.IndexOf("-") > 0)
                return new Regex(@"^\d{5}-\d{3}$", RegexOptions.Singleline).Match(value).Success;
            else
                return new Regex(@"^\d{8}$", RegexOptions.Singleline).Match(value).Success;
        }
    }
}