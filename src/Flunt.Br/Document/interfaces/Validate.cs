namespace Flunt.Br.Document.interfaces
{
    internal interface IValidate
    {
         bool Validate(string value);
    }

    internal interface IValidateV2
    {
        bool Validate(string value, bool strictNineDigit, bool cellPhonesOnly);
    }
}