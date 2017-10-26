using System;
using System.Text.RegularExpressions;
using FluentValidator.Validation;

namespace FluentValidator.Br.Validation
{
    public static class ValidationContractExtensions
    {
        private static bool ValidateCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for(int i=0; i<9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if ( resto < 2 )
                resto = 0;
            else
            resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for(int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static ValidationContract IsCpf(this ValidationContract contract, string value, string property, string message)
        {
            if(!ValidateCpf(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static bool ValidateCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
            int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for(int i=0; i<12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if ( resto < 2)
            resto = 0;
            else
            resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
            resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

        public static ValidationContract IsCnpj(this ValidationContract contract, string value, string property, string message)
        {
            if(!ValidateCnpj(value))
                contract.AddNotification(property, message);
            return contract;
        }

        public static ValidationContract IsPhone(this ValidationContract contract, string value, string property, string message)
        {
            if(!new Regex(@"^\(\d{2}\)\d{4}-\d{4}$").Match(value).Success)
                contract.AddNotification(property, message);
            return contract;
        }

        public static ValidationContract IsCellPhone(this ValidationContract contract, string value, string property, string message)
        {
            if(!new Regex(@"^\(\d{2}\)\d{4,5}-\d{4}$").Match(value).Success)
                contract.AddNotification(property, message);
            return contract;
        }
    }
}