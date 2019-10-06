using Flunt.Br.Validations;
using Flunt.Validations;

namespace Flunt.Br.Extensions
{
    public static partial class ContractExtensions
    {
        public static Contract IsCarLicensePlate(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new CarLicensePlate().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsMercosulCarLicensePlate(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new MercosulCarLicensePlate().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsOldCarLicensePlate(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new OldCarLicensePlate().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}