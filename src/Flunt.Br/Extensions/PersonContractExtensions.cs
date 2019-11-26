using Flunt.Br.Validations;
using Flunt.Validations;
using System;

namespace Flunt.Br.Extensions
{
    public static partial class ContractExtensions
    {
        public static Contract IsCpf(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Cpf().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        [Obsolete("Use IsCnpj(contract, value, property, message)")]
        public static bool ValidateCnpj(string cnpj) => new Cnpj().Validate(cnpj);

        public static Contract IsCnpj(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new Cnpj().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsVoterDocument(this Contract contract, string value, string property, string message)
        {
            if (string.IsNullOrEmpty(value) || !new VoterDocument().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsCnh(this Contract contract, string value, string property, string message)
        {
            if(string.IsNullOrEmpty(value) || !new Cnh().Validate(value))
                contract.AddNotification(property,message);
            return contract;
        }
    }
}