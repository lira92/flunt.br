using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class FluntBrTest
    {
        [TestMethod]
        [DataRow("12345678910")]
        public void IsCpf_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        [DataRow("08381614996")]
        public void IsCpf_Valid(string value)
        {
            var right = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("123456789101112")]
        public void IsCnpj_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        [DataRow("58558674000196")]
        public void IsCnpj_Valid(string value)
        {
            var right = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("123456789")]
        public void IsPhone_InValid(string value)
        {
            var wrong = new Contract()
                .IsPhone(value, "phone", "Invalid phone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
         [DataRow("(45)3222-4520")]
        public void IsPhone_Valid(string value)
        {
            var right = new Contract()
                .IsPhone(value, "phone", "Invalid phone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("456456444456")]
        public void IsCellPhone_InValid(string value)
        {
            var wrong = new Contract()
                .IsCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
         [DataRow("(45)99999-9999")]
        public void IsCellPhone_Valid(string value)
        {
            var right = new Contract()
                .IsCellPhone(value, "cellphone", "Invalid cellphone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("99999")]
        [DataRow("abcde-999")]
        [DataRow("99999-fgh")]
        [DataRow("abcde-fgh")]
        [DataRow("abcde999")]
        [DataRow("99999fgh")]
        [DataRow("abcdefgh")]
        public void IsCep_InValid(string cep)
        {
            var wrong = new Contract().IsCep(cep, "Cep", "Invalid Cep");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("99999-999")]
        [DataRow("99999999")]
        public void IsCep_Valid(string cep)
        {
            var right = new Contract().IsCep(cep, "Cep", "Invalid Cep");
            Assert.IsTrue(right.Valid);
        }
    }
}
