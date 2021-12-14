using IdentityPassTestLibrary.V1.API.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CreditBureauverificationUnitTest
    {
        CreditBureaeVerificationType creditBureaeVerificationType;
        public CreditBureauverificationUnitTest()
        {
            creditBureaeVerificationType = new CreditBureaeVerificationType();
        }

        [Theory]
        [InlineData("07056507458", "Umoh", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberAndDobIsReceived_thenRespondWithStatus(string phoneNumber, string firstName, string secretKey, bool environmentType)
        {
            // Arrange
            var actual = creditBureaeVerificationType.VerfifyCreditBureauInfo(phoneNumber, firstName, secretKey, environmentType).Result;

            // Assert
            Assert.Equal("Verification Successful", actual.Detail);
        }
    }
}
