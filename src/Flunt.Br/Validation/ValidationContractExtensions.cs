using System;
using System.Text.RegularExpressions;
using Flunt.Br.Document;
using Flunt.Validations;

namespace Flunt.Br.Validation
{
    public static class ContractExtensions
    {
        public static Contract IsCpf(this Contract contract, string value, string property, string message)
        {
            var cpfValidate = new Cpf();
            if (!cpfValidate.Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

       
        public static bool ValidateCnpj(string cnpj)
        {
           return new Cnpj().Validate(cnpj);
        }

        public static Contract IsCnpj(this Contract contract, string value, string property, string message)
        {
            if (!ValidateCnpj(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Phone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static Contract IsCellPhone(this Contract contract, string value, string property, string message)
        {
            if (!new Cellphone().Validate(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static bool ValidateCep(string value)
        {
            return new Cep().Validate(value);           
        }

        public static Contract IsCep(this Contract contract, string value, string property, string message)
        {
            if (!ValidateCep(value))
            {
                contract.AddNotification(property, message);
            }

            return contract;

        }
    }
}