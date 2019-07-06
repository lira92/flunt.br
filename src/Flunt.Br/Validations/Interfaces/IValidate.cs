namespace Flunt.Br.Document.Interfaces
{
    internal interface IValidate
    {
         bool Validate(string value);
         bool Validate(string value, IValidationOptions options);
    }

    internal interface IValidateV2
    {
        bool Validate(string value, bool strictNineDigit, bool cellPhonesOnly);
    }
}