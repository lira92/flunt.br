using Flunt.Br.Document.interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Document
{
    internal class Cellphone : IValidate
    {
        public bool Validate(string value) => new Regex(@"^\(\d{2}\)\d{4,5}-\d{4}$").Match(value).Success;
        
    }
}