using Flunt.Br.Validations.PhoneValidations;
using Flunt.Validations;

namespace Flunt.Br.Extensions
{
    public static partial class ContractExtensions
    {
        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Phone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string numberFormat, string property, string message, bool strictNineDigit = false)
        {
            var result = new Phone(new PhoneValidationOptions { Format = numberFormat, StrictNineDigit = strictNineDigit }).Validate(value);
            if (string.IsNullOrEmpty(value) || !result)
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsCellPhone(this Contract contract, string value, string property, string message, bool strictNineDigit = false)
        {
            var result = new Phone(new PhoneValidationOptions { StrictNineDigit = strictNineDigit, CellPhonesOnly = true }).Validate(value);
            if (string.IsNullOrEmpty(value) || !result)
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsNewFormatCellPhone(this Contract contract, string value, string property, string message)
        {
            var result = new Phone(new PhoneValidationOptions { StrictNineDigit = true, CellPhonesOnly = true }).Validate(value);
            if (string.IsNullOrEmpty(value) || !result)
                contract.AddNotification(property, message);
            return contract;
        }
    }
}