using System;
using System.Text.RegularExpressions;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {     
        public static Contract IsCep(this Contract contract, string value, string property, string message)
        {
            if (!new Cep().Validate(value))
            {
                contract.AddNotification(property, message);
            }

            return contract;

        }
    }
}