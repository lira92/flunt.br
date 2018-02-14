using System.Text.RegularExpressions;
using Flunt.Br.Document.interfaces;

namespace Flunt.Br.Document
{
    internal class Phone : IValidate
    {
        public bool Validate(string value) => new Regex(@"^\(\d{2}\)\d{4}-\d{4}$").Match(value).Success;
    }
}