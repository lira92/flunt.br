using Flunt.Br.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flunt.Validations;

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
            Assert.IsFalse(actual.Valid);
        }

        [TestMethod]
        [DataRow("ABC1111")]        
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
            Assert.IsFalse(actual.Valid);
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
            Assert.IsFalse(actual.Valid);
        }

        [TestMethod]        
        [DataRow("ABC1A23")]                
        [DataRow("DLC9Z46")]    
        [DataRow("IVY1X99")]    
        [DataRow("KDA1E18")]    
        [DataRow("LOL8Y11")]    
        [DataRow("LMA0I11")]    
        public void ShouldBeAbleToReturnTrueGivingValidCarLicensePlate(string value)
        {
            //Arrange
            var contract = new Contract();
            
            //Act
            var actual = contract.IsCarLicensePlate(value, CAR_LICENSE_PLATE_PROPERTY, INVALID_CAR_LICENSE_PLATE_ERROR);

            //Assert            
            Assert.IsTrue(actual.Valid);
        }
    }
}