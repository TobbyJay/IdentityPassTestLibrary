using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn1._0;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn2._0;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn2._0_w_face;
using System.Text.Json;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class BvnVerficationTypes : IBvnVerficationTypes
    {
        private readonly JsonSerializerOptions _options;
        private readonly IRequestClientSetup _requestClientSetup;
        public BvnVerficationTypes(IRequestClientSetup requestClientSetup)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _requestClientSetup = requestClientSetup;
        }

        /// <summary>
        /// This method is used to verify Bvn, and only used for Bvn1.0
        /// </summary>
        /// <param name="number"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns> The verification status and details. </returns>
        public async Task<VerificationLevelOne> VerfifyBvnInfoLevel1(string number, string secretKey, bool environmentType)
        {
           
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn_validation";

            var result = await _requestClientSetup.GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<VerificationLevelOne>(result, _options);

          
            return verificationDetails;

        }

        /// <summary>
        /// This method is used to verify Bvn, only used for Bvn2.0
        /// </summary>
        /// <param name="number"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns>  The verification status and details. </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<VerificationLevelTwo> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn";

            var result = await _requestClientSetup.GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<VerificationLevelTwo>(result, _options);


            return verificationDetails;
        }

        /// <summary>
        /// This method is used to verify Bvn along with a face.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="image"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns> The verification status and details. </returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<VerificationLevelTwoWFace> VerfifyBvnInfoWithFace(string number, string image, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number},
                {"image", image}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn_w_face";

            var result = await _requestClientSetup.GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<VerificationLevelTwoWFace>(result, _options);


            return verificationDetails;
        }
    }
}
