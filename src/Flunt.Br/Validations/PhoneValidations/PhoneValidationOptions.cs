using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations.PhoneValidations
{
    internal class PhoneValidationOptions: IValidationOptions
    {
        public bool StrictNineDigit { get; set; }
        public bool CellPhonesOnly { get; set; }
        public string Format { get; set; }
    }
}
