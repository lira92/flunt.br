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
        [DataRow("000.000.000-00")]
        [DataRow("111.111.111-11")]
        [DataRow("222.222.222-22")]
        [DataRow("333.333.333-33")]
        [DataRow("444-444.444-44")]
        [DataRow("555.555.555-55")]
        [DataRow("666.666.666-66")]
        [DataRow("777.777.777-77")]
        [DataRow("888.888.888-88")]
        [DataRow("999.999.999-99")]
        [DataRow("999.999.abc-99")]
        [DataRow(null)]
        public void IsCpf_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(false, wrong.IsValid);
        }

        [TestMethod]
        [DataRow("08381614996")]
        [DataRow("489.062.735-92")]
        public void IsCpf_Valid(string value)
        {
            var right = new Contract()
                .IsCpf(value, "document", "Invalid document");
            Assert.AreEqual(true, right.IsValid);
        }
        
        [TestMethod]
        [DataRow("12345678910")]
        [DataRow("124.835.069-34")]
        [DataRow("000.000.000-00")]
        [DataRow("111.111.111-11")]
        [DataRow("222.222.222-22")]
        [DataRow("333.333.333-33")]
        [DataRow("444-444.444-44")]
        [DataRow("555.555.555-55")]
        [DataRow("666.666.666-66")]
        [DataRow("777.777.777-77")]
        [DataRow("888.888.888-88")]
        [DataRow("999.999.999-99")]
        [DataRow("123456789101112")]
        [DataRow("655618111115522")]
        [DataRow("00000000000abc")]
        [DataRow("45.448.481/0501-18")]
        [DataRow("00.000.000/0000-00")]
        [DataRow("11.111.111/1111-11")]
        [DataRow("22.222.222/2222-22")]
        [DataRow("33.333.333/3333-33")]
        [DataRow("44.444.444/4444-44")]
        [DataRow("55.555.555/5555-55")]
        [DataRow("66.666.666/6666-66")]
        [DataRow("77.777.777/7777-77")]
        [DataRow("88.888.888/8888-88")]
        [DataRow("99.999.999/9999-99")]
        [DataRow(null)]
        public void IsCnpjOrCpf_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpjOrCPF(value, "document", "Invalid document");
            Assert.IsFalse(wrong.IsValid);
        }

        [TestMethod]
        [DataRow("16880249000179")]
        [DataRow("45.448.421/0001-18")]
        [DataRow("08381614996")]
        [DataRow("489.062.735-92")]
        public void IsCnpjOrCpf_Valid(string value)
        {
            var right = new Contract()
                .IsCnpjOrCPF(value, "document", "Invalid document");
            Assert.IsTrue(right.IsValid);
        }


        [TestMethod]
        [DataRow("123456789101112")]
        [DataRow("655618111115522")]
        [DataRow("00000000000abc")]
        [DataRow("45.448.481/0501-18")]
        [DataRow("00.000.000/0000-00")]
        [DataRow("11.111.111/1111-11")]
        [DataRow("22.222.222/2222-22")]
        [DataRow("33.333.333/3333-33")]
        [DataRow("44.444.444/4444-44")]
        [DataRow("55.555.555/5555-55")]
        [DataRow("66.666.666/6666-66")]
        [DataRow("77.777.777/7777-77")]
        [DataRow("88.888.888/8888-88")]
        [DataRow("99.999.999/9999-99")]
        [DataRow(null)]
        public void IsCnpj_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsFalse(wrong.IsValid);
        }

        [TestMethod]
        [DataRow("123456789101112")]
        [DataRow("655618111115522")]
        [DataRow("00000000000abc")]
        [DataRow("45.448.481/0501-18")]
        [DataRow("00.000.000/0000-00")]
        [DataRow("11.111.111/1111-11")]
        [DataRow("22.222.222/2222-22")]
        [DataRow("33.333.333/3333-33")]
        [DataRow("44.444.444/4444-44")]
        [DataRow("55.555.555/5555-55")]
        [DataRow("66.666.666/6666-66")]
        [DataRow("77.777.777/7777-77")]
        [DataRow("88.888.888/8888-88")]
        [DataRow("99.999.999/9999-99")]
        [DataRow("AA.AAA.AAA/AAAA-99")]
        [DataRow("ZZ.ZZZ.ZZZ/ZZZZ-99")]
        [DataRow("00.D5H.PL9/AONL-48")]
        [DataRow("4O.X01.0AO/7DD9-38")]
        [DataRow("50.WXI.YTL/4O33-08")]
        [DataRow("61.HXL.XIY/33TQ-48")]
        [DataRow("A8.9Y4.JB9/VLHE-88")]
        [DataRow(null)]
        public void IsCnpjAlphaNumeric_InValid(string value)
        {
            var wrong = new Contract()
                .IsCnpjAlphaNumeric(value, "document", "Invalid document");
            Assert.IsFalse(wrong.IsValid);
        }

        [TestMethod]
        [DataRow("16880249000179")]
        [DataRow("45.448.421/0001-18")]
        public void IsCnpj_Valid(string value)
        {
            var right = new Contract()
                .IsCnpj(value, "document", "Invalid document");
            Assert.IsTrue(right.IsValid);
        }

        [TestMethod]
        [DataRow("16880249000179")]
        [DataRow("45.448.421/0001-18")]
        [DataRow("00.D5H.PL9/AONL-84")]
        [DataRow("4O.X01.0AO/7DD9-03")]
        [DataRow("50.WXI.YTL/4O33-00")]
        [DataRow("61.HXL.XIY/33TQ-64")]
        [DataRow("A8.9Y4.JB9/VLHE-18")]
        [DataRow("B0.8JJ.D0M/FJ3M-84")]
        [DataRow("D2.108.T5M/R2IQ-20")]
        [DataRow("EW.WXK.YC8/HTB2-84")]
        [DataRow("GL.SPN.P58/EQC7-74")]
        [DataRow("IU.BYB.2WV/GJKT-39")]
        [DataRow("LN.L4L.VPN/LDIU-24")]
        [DataRow("QE.V53.HE5/NY08-13")]
        [DataRow("00D5HPL9AONL84")]
        [DataRow("4OX010AO7DD903")]
        [DataRow("50WXIYTL4O3300")]
        [DataRow("61HXLXIY33TQ64")]
        [DataRow("A89Y4JB9VLHE18")]
        [DataRow("B08JJD0MFJ3M84")]
        [DataRow("D2108T5MR2IQ20")]
        [DataRow("EWWXKYC8HTB284")]
        [DataRow("GLSPNP58EQC774")]
        [DataRow("IUBYB2WVGJKT39")]
        [DataRow("LNL4LVPNLDIU24")]
        [DataRow("QEV53HE5NY0813")]

        public void IsCnpjAlphaNumeric_Valid(string value)
        {
            var right = new Contract()
                .IsCnpjAlphaNumeric(value, "document", "Invalid document");
            Assert.IsTrue(right.IsValid);
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
            Assert.IsFalse(wrong.IsValid);
        }

        [TestMethod]
        [DataRow("668247670132")]
        [DataRow("333438450701")]
        [DataRow("656835882550")]
        public void IsVoterDocument_Valid(string value)
        {
            var right = new Contract()
                .IsVoterDocument(value, "document", "Invalid document");
            Assert.IsTrue(right.IsValid);
        }


        [TestMethod]
        [DataRow("668247690132")]
        [DataRow("333438450601")]
        [DataRow("6568351232550")]
        [DataRow(null)]
        public void IsCnh_Invalid(string value)
        {
            var wrong = new Contract()
                .IsCnh(value, "document", "Invalid document");
            Assert.IsFalse(wrong.IsValid);
        }

        [TestMethod]
        [DataRow("09974348506")]
        [DataRow("32983022807")]
        [DataRow("93642298453")]
        public void IsCnh_Valid(string value)
        {
            var right = new Contract()
                .IsCnh(value, "document", "Invalid document");
            Assert.IsTrue(right.IsValid);
        }
    }
}
