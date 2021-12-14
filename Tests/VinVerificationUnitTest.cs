using IdentityPassTestLibrary.V1.API.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class VinVerificationUnitTest
    {
        VinVerificationTypes vinVerificationTypes;
        public VinVerificationUnitTest()
        {
            vinVerificationTypes = new VinVerificationTypes();
        }

        [Theory]
        [InlineData("987f545AJ67890", "test", "Lagos", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberIsReceived_thenRespondWithStatusAndDataForLookupVin(string number, string last_name, string state, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = vinVerificationTypes.LookUpVin(number, last_name, state, secretKey, environmentType).Result;

            // Assert
            Assert.True("VIN Verification Successful" == actual.Detail);
        }

        [Theory]
        [InlineData("", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenImageIsReceived_thenRespondWithStatusAndDataForLookupVinWithIdImage(string image, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = vinVerificationTypes.LookUpVinWithIdImage(image, secretKey, environmentType).Result;

            // Assert
            Assert.True("VIN Verification Successful" == actual.Detail);
        }
    }
}
