using FuzzySharp;
using IdentityPassTestLibrary.V1.API.Implementations;
using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class BvnVerificationUnitTest
    {
        BvnVerficationTypes _bvnVerficationTypes;
        public BvnVerificationUnitTest()
        {
            _bvnVerficationTypes = new BvnVerficationTypes();
        }

        [Theory]
        [InlineData("54651333604", "test_231qza7t1kxejz21eg26e5:m1YlNf4sqfSQ0GEKnC8j2oZ-dyc", false)]
        // test method naming convention: givenX_whenY_thenZ
        public void _whenNumberIsReceived_thenRespondWithStatusAndDataForLevelOne(string number, string secretKey, bool environmentType)
        {
            // Arrange
            var verify = _bvnVerficationTypes.VerfifyBvnInfoLevel1(number, secretKey, environmentType).Result;


            // Act
            var data = new Data
            {
                VerificationType = "bvn"
            };

            var expected = new Response
            {
                Status = true,
                Message = "verification successful",
                Data = data
            };

            if (expected == verify)
            {
                //
            }


            // Assert
            Assert.Equal<Response>(expected, verify);
        }
    }
}
