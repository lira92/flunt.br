using System;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static partial class ContractExtensions
    {
        public static Contract IsCpf(this Contract contract, string value, string property, string message)
        {
            if (!new Cpf().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        [Obsolete("Use IsCnpj(contract, value, property, message)")]
        public static bool ValidateCnpj(string cnpj) => new Cnpj().Validate(cnpj);

        public static Contract IsCnpj(this Contract contract, string value, string property, string message)
        {
            if (!new Cnpj().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsVoterDocument(this Contract contract, string value, string property, string message)
        {
            if (!new VoterDocument().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }
    }
}