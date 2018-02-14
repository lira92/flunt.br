using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class FluntBrTest
    {
        [TestMethod]
        public void IsCpf_Invalid()
        {
            var wrong = new Contract()
                .IsCpf("12345678910", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCpf_Valid()
        {
            var right = new Contract()
                .IsCpf("08381614996", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsCnpj_InValid()
        {
            var wrong = new Contract()
                .IsCnpj("123456789101112", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCnpj_Valid()
        {
            var right = new Contract()
                .IsCnpj("58558674000196", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsPhone_InValid()
        {
            var wrong = new Contract()
                .IsPhone("123456789", "phone", "Invalid phone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsPhone_Valid()
        {
            var right = new Contract()
                .IsPhone("(45)3222-4520", "phone", "Invalid phone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsCellPhone_InValid()
        {
            var wrong = new Contract()
                .IsCellPhone("456456444456", "cellphone", "Invalid cellphone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCellPhone_Valid()
        {
            var right = new Contract()
                .IsCellPhone("(45)99999-9999", "cellphone", "Invalid cellphone");
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
