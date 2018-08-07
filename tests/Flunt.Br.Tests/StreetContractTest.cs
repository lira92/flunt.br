using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class FluntBrTest
    {
        [TestMethod]
        [DataRow("99999")]
        [DataRow("abcde-999")]
        [DataRow("99999-fgh")]
        [DataRow("abcde-fgh")]
        [DataRow("abcde999")]
        [DataRow("99999fgh")]
        [DataRow("abcdefgh")]
        [DataRow(null)]
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
