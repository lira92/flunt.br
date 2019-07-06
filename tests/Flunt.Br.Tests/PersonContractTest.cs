using Flunt.Br.Extensions;
using Flunt.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class PersonContractTest
    {
        [TestMethod]
        [DataRow("12345678910")]
        [DataRow("124.835.069-34")]
        [DataRow(null)]
        public void IsCpf_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(false, wrong.Valid);
        }

        [TestMethod]
        [DataRow("08381614996")]
        [DataRow("489.062.735-92")]
        public void IsCpf_Valid(string value)
        {
            var right = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(true, right.Valid);
        }

        [TestMethod]
        [DataRow("123456789101112")]
        [DataRow("655618111115522")]
        [DataRow("00000000000abc")]
        [DataRow("45.448.481/0501-18")]
        [DataRow(null)]
        public void IsCnpj_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("16880249000179")]
        [DataRow("45.448.421/0001-18")]
        public void IsCnpj_Valid(string value)
        {
            var right = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
        }

        [TestMethod]
        [DataRow("668247690132")]
        [DataRow("333438450601")]
        [DataRow("6568351232550")]
        [DataRow(null)]
        public void IsVoterDocument_InValid(string value)
        {
            var wrong = new Contract()
                .IsVoterDocument(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("668247670132")]
        [DataRow("333438450701")]
        [DataRow("656835882550")]
        public void IsVoterDocument_Valid(string value)
        {
            var right = new Contract()
                .IsVoterDocument(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
        }
    }
}