using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn1._0;
using System.Text.Json;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class BvnVerficationTypes : IBvnVerficationTypes
    {
        private readonly JsonSerializerOptions _options;
        public BvnVerficationTypes()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        /// <summary>
        /// This method is used to verify Bvn, and only used for Bvn1.0
        /// </summary>
        /// <param name="number"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns> The verification status and details</returns>
        public async Task<VerificationLevelOne> VerfifyBvnInfoLevel1(string number, string secretKey, bool environmentType)
        {
           
            var environmentUrl = "";

            if (environmentType == false) environmentUrl = "https://sandbox.myidentitypass.com";

            var value = new Dictionary<string, string>
            {
                { "number", number}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn_validation";

            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(value);

            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            content.Headers.Add("x-api-key", secretKey);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();

            var verificationDetails = JsonSerializer.Deserialize<VerificationLevelOne>(result, _options);

          
            return verificationDetails;

        }

        public async Task<Response> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> VerfifyBvnInfoWithFace(string number, string secretKey, bool environmentType)
        {
            throw new NotImplementedException();
        }
    }
}
