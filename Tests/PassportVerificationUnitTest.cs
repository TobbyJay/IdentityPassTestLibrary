using IdentityPassTestLibrary;
using IdentityPassTestLibrary.V1.API.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class PassportVerificationUnitTest
    {
        PassportVerification passportVerification;
        public PassportVerificationUnitTest()
        {
            passportVerification = new PassportVerification();
        }

        [Theory]
        [InlineData("", "", "", "", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberIsReceived_thenRespondWithStatusAndPassportVerification(string number, string first_name, string last_name, DateTime dob, string secretKey, bool environmentType)
        {
            // Arrange
            var verify = passportVerification.VerifyInternationalPassport(number, first_name, last_name, dob, secretKey, environmentType).Result;

            // Assert
            Assert.Equal("Intl. Passport Verification Successful", verify.Detail);
        }
    }
}
