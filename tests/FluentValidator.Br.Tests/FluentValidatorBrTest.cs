using FluentValidator.Validation;
using FluentValidator.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentValidator.Br.Tests
{
    [TestClass]
    public class FluentValidatorBrTest
    {
        [TestMethod]
        public void IsCpf_Invalid()
        {
            var wrong = new ValidationContract()
                .IsCpf("12345678910", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCpf_Valid()
        {
            var right = new ValidationContract()
                .IsCpf("08381614996", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsCnpj_InValid()
        {
            var wrong = new ValidationContract()
                .IsCnpj("123456789101112", "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCnpj_Valid()
        {
            var right = new ValidationContract()
                .IsCnpj("58558674000196", "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsPhone_InValid()
        {
            var wrong = new ValidationContract()
                .IsPhone("123456789", "phone", "Invalid phone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsPhone_Valid()
        {
            var right = new ValidationContract()
                .IsPhone("(45)3222-4520", "phone", "Invalid phone");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        public void IsCellPhone_InValid()
        {
            var wrong = new ValidationContract()
                .IsCellPhone("456456444456", "cellphone", "Invalid cellphone");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        public void IsCellPhone_Valid()
        {
            var right = new ValidationContract()
                .IsCellPhone("(45)99999-9999", "cellphone", "Invalid cellphone");
            Assert.AreEqual(true, right.Valid);
        }
    }
}
