using Flunt.Br.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flunt.Br.Tests
{
    [TestClass]
    public class CarLicensePlateTest
    {
        private static string INVALID_CAR_LICENSE_PLATE_ERROR = "Invalid Car License Plate";
        private static string CAR_LICENSE_PLATE_PROPERTY = "carlicenseplate";

        [TestMethod]
        [DataRow("ABC1A1")]
        public void ShouldBeAbleToReturnFalseGivingCarLicensePlateWithLessThan7Characters(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsFalse(actual.IsValid);
        }

        [TestMethod]
        [DataRow("1111ABC")]
        [DataRow("AB11ABC")]
        [DataRow("1ABCDEF")]
        [DataRow("A1BCABC")]
        [DataRow("DLCZ946")]
        [DataRow("DLC94Z6")]
        [DataRow("DLC946Z")]
        public void ShouldBeAbleToReturnFalseGivingInvalidPatternCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsFalse(actual.IsValid);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void ShouldBeAbleToReturnFalseGivingEmptyCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsFalse(actual.IsValid);
        }

        [TestMethod]
        [DataRow("GAG1A11")]
        [DataRow("RAR2150")]
        [DataRow("LOL9999")]
        [DataRow("ABC1111")]
        [DataRow("ABC1A23")]
        [DataRow("DLC9Z46")]
        [DataRow("IVY1X99")]
        [DataRow("KDA1E18")]
        [DataRow("LOL8Y11")]
        [DataRow("LMA0I11")]
        [DataRow("LMA-0I11")]
        public void ShouldBeAbleToReturnTrueGivingValidCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsTrue(actual.IsValid);
        }

        [TestMethod]
        [DataRow("GAG1111")]
        [DataRow("RAR2150")]
        [DataRow("LOL9999")]
        [DataRow("ABC1111")]
        [DataRow("ABC1223")]
        [DataRow("DLC9946")]
        [DataRow("IVY1499")]
        [DataRow("KDA1718")]
        [DataRow("LOL8811")]
        [DataRow("LMA0611")]
        [DataRow("LMA-0611")]
        public void ShouldBeAbleToReturnTrueGivingValidOldCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsOldCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsTrue(actual.IsValid);
        }

        [TestMethod]
        [DataRow(" ")]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("ABC1K11")]
        [DataRow("ABC1R23")]
        [DataRow("DLC9E46")]
        [DataRow("IVY19")]
        [DataRow("KDA118")]
        [DataRow("DLC94Z6")]
        [DataRow("LMA0I11")]
        [DataRow("LMA0--11")]        
        [DataRow("LMA--0611")]
        [DataRow("LMA-061")]
        public void ShouldBeAbleToReturnFalseGivingInvalidPatternOldCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsOldCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsFalse(actual.IsValid);
        }

        [TestMethod]
        [DataRow("GAG1A11")]
        [DataRow("RAR2R50")]
        [DataRow("LOL9F99")]
        [DataRow("ABC1Z11")]
        [DataRow("ABC1A23")]
        [DataRow("DLC9Z46")]
        [DataRow("IVY1X99")]
        [DataRow("KDA1E18")]
        [DataRow("LOL8Y11")]
        [DataRow("LMA0I11")]
        [DataRow("LMA-0I11")]
        public void ShouldBeAbleToReturnTrueGivingValidMercosulCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsMercosulCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsTrue(actual.IsValid);
        }

        [TestMethod]
        [DataRow("1111ABC")]
        [DataRow("AB11ABC")]
        [DataRow("1ABCDEF")]
        [DataRow("A1BCABC")]
        [DataRow("DLCZ946")]
        [DataRow("DLC94Z6")]
        [DataRow("DLC946Z")]
        public void ShouldBeAbleToReturnFalseGivingInvalidPatternMercosulCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();

            //Act
            var actual = contract.IsMercosulCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsFalse(actual.IsValid);
        }
    }
}