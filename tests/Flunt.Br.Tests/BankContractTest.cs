using Flunt.Br.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class BankContractTest
    {
        [TestMethod]
        [DataRow("403401714056921341")]
        [DataRow("521586453135936245")]
        [DataRow("601138410090657947")]
        [DataRow("3559716521958")]
        [DataRow(null)]
        public void IsCreditCard_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCreditCard(value, "document", "Invalid document");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        [DataRow("4024007140542043")]
        [DataRow("5215804531352362")]
        [DataRow("6011364100907579")]
        [DataRow("3559714521955133")]
        public void IsCreditCard_Valid(string value)
        {
            var right = new Contract()
                .IsCreditCard(value, "document", "Invalid document");
            Assert.IsTrue(right.Valid);
        }
    }
}