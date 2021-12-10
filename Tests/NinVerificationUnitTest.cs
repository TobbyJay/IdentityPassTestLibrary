using IdentityPassTestLibrary.V1.API.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class NinVerificationUnitTest
    {
        NinVerificationTypes ninVerificationTypes;
        public NinVerificationUnitTest()
        {
            ninVerificationTypes = new NinVerificationTypes();
        }

        [Theory]
        [InlineData("12345678909", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberIsReceived_thenRespondWithStatusAndDataForLookupNin(string number, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = ninVerificationTypes.LookUpNin(number, secretKey, environmentType).Result;

            // Assert
            Assert.True("Verification Successfull" == actual.Detail);
        }

        [Theory]
        [InlineData("https://d5nunyagcicgy.cloudfront.net/external_assets/hero_examples/hair_beach_v391182663/original.jpeg", "12345678909", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberIsReceived_thenRespondWithStatusAndDataForLookUpNinWithFace(string faceImage, string number, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = ninVerificationTypes.LookUpNinWithFace(faceImage, number, secretKey, environmentType).Result;

            // Assert
            Assert.True("Verification Successfull" == actual.Detail);
        }

        [Theory]
        [InlineData("https://d5nunyagcicgy.cloudfront.net/external_assets/hero_examples/hair_beach_v391182663/original.jpeg", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenSlipIsReceived_thenRespondWithStatusAndDataForLookUpNinSlip(string slipImage, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = ninVerificationTypes.LookUpNinSlip(slipImage, secretKey, environmentType).Result;

            // Assert
            Assert.True("Verification Successfull" == actual.Detail);
        }
    }
}
