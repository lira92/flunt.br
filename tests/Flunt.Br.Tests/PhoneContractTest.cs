using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class PhoneContractTest
    {
       
        [TestMethod]
        [DataRow("123456789")]
        [DataRow("(1323) 9999-9999")]
        [DataRow("(99) 1199999-9999")]
        [DataRow("(99)911999-9999")]
        [DataRow("(99)9956999-9999")]
        [DataRow("59-9999")]
        [DataRow("999-9999")]
        [DataRow("999999999")]
        [DataRow("9995996666399999")]
        [DataRow("99 922999 9963699")]
        [DataRow("99 9994599 922999")]
        [DataRow("55(99) 9999-992299")]
        [DataRow("55(99) 99999-99959")]
        [DataRow("55(99)9999-999559")]
        [DataRow("55(99)99999-999559")]
        [DataRow("55999999-995299")]
        [DataRow("559999999-995599")]
        [DataRow("559999999996159")]
        [DataRow("559999999999assad9")]
        [DataRow("aa bb cccc-eeee")]
        [DataRow("5599 99999c5 9999")]
        [DataRow("55 (99) 999329-9999")]
        [DataRow("55 (9129) 99999-9999")]
        [DataRow("5522 (99)9999-9999")]
        [DataRow("525 (99)99999-9999")]
        [DataRow("552 999999-9999")]
        [DataRow("552 9999999-9999")]
        [DataRow("551 9999999999")]
        [DataRow("55 9ww9q999999999")]
        [DataRow("55 9955 9999 9999936")]
        [DataRow("55 99 99we999 9999")]
        [DataRow("+55 (92329) 932999-9999")]
        [DataRow("+55 (99) 9999999-9999")]
        [DataRow("+55 (99)2239999-9999")]
        [DataRow("+55 (9329)9992299-9999")]
        [DataRow("+5523 999922399-9999")]
        [DataRow("+55 9232999999-9999")]
        [DataRow("+5523 9999999992329")]
        [DataRow("+5523 232399999999999")]
        [DataRow("+55 99 999923 923999")]
        [DataRow("+55 99 99999 992399")]
        [DataRow(null)]
        public void IsPhone_Invalid(string value)
        {
            var wrong = new Contract()
                .IsPhone(value, "phone", "Invalid phone");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("(99) 3999-9999")]
        [DataRow("(99) 99999-9999")]
        [DataRow("(99)99999-9999")]
        [DataRow("993999-9999")]
        [DataRow("9999999-9999")]
        [DataRow("9939999999")]
        [DataRow("99999999999")]
        [DataRow("99 3999 9999")]
        [DataRow("99 99999 9999")]
        [DataRow("55(99) 3999-9999")]
        [DataRow("55(99) 99999-9999")]
        [DataRow("55(99)3999-9999")]
        [DataRow("55(99)99999-9999")]
        [DataRow("55993999-9999")]
        [DataRow("559999999-9999")]
        [DataRow("559939999999")]
        [DataRow("5599999999999")]
        [DataRow("5599 3999 9999")]
        [DataRow("5599 99999 9999")]
        [DataRow("55 (99) 3999-9999")]
        [DataRow("55 (99) 99999-9999")]
        [DataRow("55 (99)3999-9999")]
        [DataRow("55 (99)99999-9999")]
        [DataRow("55 993999-9999")]
        [DataRow("55 9999999-9999")]
        [DataRow("55 9939999999")]
        [DataRow("55 99999999999")]
        [DataRow("55 99 3999 9999")]
        [DataRow("55 99 99999 9999")]
        [DataRow("+55 (99) 3999-9999")]
        [DataRow("+55 (99) 99999-9999")]
        [DataRow("+55 (99)3999-9999")]
        [DataRow("+55 (99)99999-9999")]
        [DataRow("+55 993999-9999")]
        [DataRow("+55 9999999-9999")]
        [DataRow("+55 9939999999")]
        [DataRow("+55 99999999999")]
        [DataRow("+55 99 3999 9999")]
        [DataRow("+55 99 99999 9999")]
        [DataRow("(99) 9999-9999")]
        [DataRow("999999-9999")]
        [DataRow("9999999999")]
        [DataRow("99 9999 9999")]
        [DataRow("55(99) 9999-9999")]
        [DataRow("55(99)9999-9999")]
        [DataRow("55999999-9999")]
        [DataRow("559999999999")]
        [DataRow("5599 9999 9999")]
        [DataRow("55 (99) 9999-9999")]
        [DataRow("55 (99)9999-9999")]
        [DataRow("(99)9999-9999")]
        [DataRow("55 999999-9999")]
        [DataRow("55 9999999999")]
        [DataRow("55 99 9999 9999")]
        [DataRow("+55 (99) 9999-9999")]
        [DataRow("+55 (99)9999-9999")]
        [DataRow("+55 999999-9999")]
        [DataRow("+55 9999999999")]
        [DataRow("+55 99 9999 9999")]
        public void IsPhone_Valid(string value)
        {
            var right = new Contract()
                .IsPhone(value, "phone", "Invalid phone");
            Assert.IsTrue(right.Valid);
        }

        [TestMethod]
        [DataRow("(99) 9999-9999", "(99) ?9999-9999")]
        [DataRow("(99) 99999-9999", "(99) ?9999-9999")]
        [DataRow("(99) 9999-9999", "(99) 9999-9999")]
        [DataRow("(99) 99999-9999", "(99) 99999-9999")]
        [DataRow("(99)9999-9999", "(99)9999-9999")]
        [DataRow("(99)99999-9999", "(99)99999-9999")]
        [DataRow("999999-9999", "999999-9999")]
        [DataRow("9999999-9999", "9999999-9999")]
        [DataRow("9999999999", "9999999999")]
        [DataRow("99999999999", "99999999999")]
        [DataRow("99 9999 9999", "99 9999 9999")]
        [DataRow("99 99999 9999", "99 99999 9999")]
        [DataRow("55(99) 9999-9999", "55(99) 9999-9999")]
        [DataRow("55(99) 99999-9999", "55(99) 99999-9999")]
        [DataRow("55(99)9999-9999", "55(99)9999-9999")]
        [DataRow("55(99)99999-9999", "55(99)99999-9999")]
        [DataRow("55999999-9999", "55999999-9999")]
        [DataRow("559999999-9999", "559999999-9999")]
        [DataRow("559999999999", "559999999999")]
        [DataRow("5599999999999", "5599999999999")]
        [DataRow("5599 9999 9999", "5599 9999 9999")]
        [DataRow("5599 99999 9999", "5599 99999 9999")]
        [DataRow("55 (99) 9999-9999", "55 (99) 9999-9999")]
        [DataRow("55 (99) 99999-9999", "55 (99) 99999-9999")]
        [DataRow("55 (99)9999-9999", "55 (99)9999-9999")]
        [DataRow("55 (99)99999-9999", "55 (99)99999-9999")]
        [DataRow("55 999999-9999", "55 999999-9999")]
        [DataRow("55 9999999-9999", "55 9999999-9999")]
        [DataRow("55 9999999999", "55 9999999999")]
        [DataRow("55 99999999999", "55 99999999999")]
        [DataRow("55 99 9999 9999", "55 99 9999 9999")]
        [DataRow("55 99 99999 9999", "55 99 99999 9999")]
        [DataRow("+55 (99) 9999-9999", "+55 (99) 9999-9999")]
        [DataRow("+55 (99) 99999-9999", "+55 (99) 99999-9999")]
        [DataRow("+55 (99)9999-9999", "+55 (99)9999-9999")]
        [DataRow("+55 (99)99999-9999", "+55 (99)99999-9999")]
        [DataRow("+55 999999-9999", "+55 999999-9999")]
        [DataRow("+55 9999999-9999", "+55 9999999-9999")]
        [DataRow("+55 9999999999", "+55 9999999999")]
        [DataRow("+55 99999999999", "+55 99999999999")]
        [DataRow("+55 99 9999 9999", "+55 99 9999 9999")]
        [DataRow("+55 99 99999 9999", "+55 99 99999 9999")]
        public void IsPhoneFormat_Valid(string value, string formatNumber)
        {
            var right = new Contract()
                .IsPhone(value, formatNumber, "phone", "Invalid phone");
            Assert.IsTrue(right.Valid);
        }

        [TestMethod]
        [DataRow("(999) 9999-9999", "(99) 9999-9999")]
        [DataRow("(995) 99999-9999", "(99) 99999-9999")]
        [DataRow("(99)995299-9999", "(99)9999-9999")]
        [DataRow("(99)999959-9999", "(99)99999-9999")]
        [DataRow("999999-995299", "999999-9999")]
        [DataRow("9999999-999559", "9999999-9999")]
        [DataRow("9999999999565", "9999999999")]
        [DataRow("999999999995", "99999999999")]
        [DataRow("99 9999 999s9s", "99 9999 9999")]
        [DataRow("99 99999 99969", "99 99999 9999")]
        [DataRow("55(99) 99959-95999", "55(99) 9999-9999")]
        [DataRow("55(99) 9999569-9999", "55(99) 99999-9999")]
        [DataRow("55(9ss9)9999-99699", "55(99)9999-9999")]
        [DataRow("55(99)2199999-9999", "55(99)99999-9999")]
        [DataRow("5599999129-921999", "55999999-9999")]
        [DataRow("55999992399-999129", "559999999-9999")]
        [DataRow("55999999923999", "559999999999")]
        [DataRow("559999999992399", "5599999999999")]
        [DataRow("5599 992399 992399", "5599 9999 9999")]
        [DataRow("5599 9999239 9999", "5599 99999 9999")]
        [DataRow("55 (99) 999239-923999", "55 (99) 9999-9999")]
        [DataRow("55 (99) 9992399-999239", "55 (99) 99999-9999")]
        [DataRow("55 (9912)999219-923999", "55 (99)9999-9999")]
        [DataRow("55 (9912)2199999-9999", "55 (99)99999-9999")]
        [DataRow("55 99999129-912999", "55 999999-9999")]
        [DataRow("55 999999921-93999", "55 9999999-9999")]
        [DataRow("55 999999999129", "55 9999999999")]
        [DataRow("55 9999999", "55 99999999999")]
        [DataRow("55 99 99929 921999", "55 99 9999 9999")]
        [DataRow("55 99 9923999 9999", "55 99 99999 9999")]
        [DataRow("+55 (99) 923999-129999", "+55 (99) 9999-9999")]
        [DataRow("+55 (1299) 99999-9921299", "+55 (99) 99999-9999")]
        [DataRow("+55 (9239)9999-9999", "+55 (99)9999-9999")]
        [DataRow("+55 (3299)2399999-9999", "+55 (99)99999-9999")]
        [DataRow("+55 999999-999239", "+55 999999-9999")]
        [DataRow("+55 9999999-99", "+55 9999999-9999")]
        [DataRow("+55 999999999", "+55 9999999999")]
        [DataRow("+55 99999999", "+55 99999999999")]
        [DataRow("+55 99 9999 99", "+55 99 9999 9999")]
        [DataRow("+55 99 99999 9", "+55 99 99999 9999")]
        [DataRow(null, "+55 99 99999 9999")]
        public void IsPhoneFormat_Invalid(string value, string formatNumber)
        {
            var wrong = new Contract()
                .IsPhone(value, formatNumber, "phone", "Invalid phone");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("456456444456")]
        [DataRow("(45)3333-3333")]
        [DataRow("(99) 8 9999-9999")]
        [DataRow(null)]
        public void IsCellPhone_Invalid(string value)
        {
            var wrong = new Contract().IsCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("(45)99999-9999")]
        [DataRow("+55(99)99999-9999")]
        [DataRow("+55(99)9-9999-9999")]
        [DataRow("+55 (99) 9999-9999")]
        [DataRow("+55 (99) 9999-9999")]
        
        public void IsCellPhone_Valid(string value)
        {
            var right = new Contract().IsCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.IsTrue(right.Valid);
        }

        [TestMethod]
        [DataRow("45999999999")]
        [DataRow("+55(99)99999-9999")]
        [DataRow("+55(99)9.9999-9999")]
        [DataRow("+55 (99) 9-9999-9999")]
        [DataRow("+55 (99) 9 9999-9999")]

        public void IsNewCellPhone_Valid(string value)
        {
            var right = new Contract().IsNewFormatCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.IsTrue(right.Valid);
        }

        [TestMethod]
        [DataRow("4599999999")]
        [DataRow("+55(99)9999-9999")]
        [DataRow("+55(99)9999-9999")]
        [DataRow("+55 (99) 9999-9999")]
        [DataRow("+55 (99) 9999-9999")]
        [DataRow("+55 (99) 3333-4444")]

        public void IsNewCellPhone_Invalid(string value)
        {
            var right = new Contract().IsNewFormatCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.IsTrue(right.Valid);
        }


    }
}