using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations.PhoneValidations
{
    internal class Phone : IValidate
    {
        private static readonly Regex _defaultFormat = new Regex(@"^(?:(?:\+?55)?[ .-]*\(?0?[1-9][0-9]\)?)[ .-]?(?:(?:(?:9[ .-]*)?[0-9]{4})[ .-]*[0-9]{4})$");
        public bool Validate(string value) => Validate(value, null);

        public bool Validate(string value, IValidationOptions options)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            var formatToApply = _defaultFormat;
            if (options is PhoneValidationOptions phoneOptions)
            {
                if (phoneOptions.Format != null)
                {
                    formatToApply = HandleCustomFormat(phoneOptions.Format);

                    return formatToApply.IsMatch(value);
                }

                formatToApply = SetFormatBaseOnOptions(phoneOptions);
            }
            return formatToApply.IsMatch(value);
        }

        private static Regex HandleCustomFormat(string customFormat)
        {
            var regex = new Regex(@"[0-9]+");
            var phonePattern = Regex.Replace(customFormat, @"[0-9,?]+", m => {
                var optionalsCount = m.Value.Split(new char[] { '?' }).Length - 1;
                var stringRegex = "";
                if (optionalsCount != 0)
                {
                    stringRegex += (m.Length - optionalsCount);
                    stringRegex += ",";
                    stringRegex += (optionalsCount + (m.Length - optionalsCount));
                }
                else
                {
                    stringRegex = m.Length.ToString();
                }
                return $@"\d{{{stringRegex}}}";
            });
            phonePattern = @"^" + Regex.Replace(phonePattern, @"(?:(?(1)(?!))(\+)|(?(2)(?!))(\()|(?(3)(?!))(\)))+", m => $@"\{m.Value}").Replace("-", @"\-").Replace(" ", @"\s") + "$";
            return new Regex(phonePattern);
        }

        private static Regex SetFormatBaseOnOptions(PhoneValidationOptions phoneOptions)
        {
            if (phoneOptions.CellPhonesOnly && phoneOptions.StrictNineDigit)
            {
                return new Regex(@"^(?:(?:\+?55)?[ .-]*\(?0?[1-9][0-9]\)?)[ .-]?(?:(?:(?:9[ .-]*)[0-9]{4})[ .-]*[0-9]{4})$");
            }

            if (phoneOptions.CellPhonesOnly && !phoneOptions.StrictNineDigit)
            {
                return new Regex(@"^(?:(?:\+?55)?[ .-]*\(?0?[1-9][0-9]\)?)[ .-]?(?:(?:(?:9[ .-]*)[0-9]{4}|[8-9][0-9]{3})[ .-]*[0-9]{4})$");
            }

            if (!phoneOptions.CellPhonesOnly && phoneOptions.StrictNineDigit)
            {
                return new Regex(@"^(?:(?:\+?55)?[ .-]*\(?0?[1-9][0-9]\)?)[ .-]?(?:(?:9[ .-]*[0-9]{4}|[1-7][0-9]{3})[ .-]*[0-9]{4})$");
            }

            return _defaultFormat;
        }
    }
}