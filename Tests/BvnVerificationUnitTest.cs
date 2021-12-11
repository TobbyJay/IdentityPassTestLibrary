using FuzzySharp;
using IdentityPassTestLibrary;
using IdentityPassTestLibrary.V1.API.Implementations;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn1._0;
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
          
            // Assert
            Assert.Equal("Verification Successfull", verify.Detail);
        }
    }
}
