using IdentityPassTestLibrary.V1.API.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class DriversLicenseVerificationUnitTest
    {
        DriversLicenseVerificationType driversLicenseVerificationType;
        public DriversLicenseVerificationUnitTest()
        {
            driversLicenseVerificationType = new DriversLicenseVerificationType();
        }

        [Theory]
        [InlineData("AAD23208212298", "1999-12-21", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberAndDobIsReceived_thenRespondWithStatus(string number, string dob, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = driversLicenseVerificationType.VerfifyDriversLicense(number,dob, secretKey, environmentType).Result;

            // Assert
            Assert.Equal("DL Verification Successful", actual.Detail);
        }
    }
}
