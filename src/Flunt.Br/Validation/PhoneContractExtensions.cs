using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Phone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string numberFormat, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Phone(numberFormat).Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }


        public static Contract IsCellPhone(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Phone("(99) ?9999-9999").Validate(value))
                if (string.IsNullOrEmpty(value) || !new Phone("(99)?9999-9999").Validate(value))
                    contract.AddNotification(property, message);

            return contract;
        }

    }
}