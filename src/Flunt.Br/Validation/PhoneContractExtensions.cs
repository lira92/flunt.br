using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Phone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string numberFormat, string property, string message)
        {
            if (!new Phone(numberFormat).Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }


        public static Contract IsCellPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Phone("(99) ?9999-9999").Validate(value))
                if (!new Phone("(99)?9999-9999").Validate(value))
                    contract.AddNotification(property, message);


            return contract;
        }

    }
}