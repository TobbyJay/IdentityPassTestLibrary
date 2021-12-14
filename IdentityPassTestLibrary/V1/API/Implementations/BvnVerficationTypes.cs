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
        private bool disposedValue;
        private HttpClient _httpClient;
        public BvnVerficationTypes()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
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

            var result = await GetHttpClientSetup(url, value, secretKey);

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
        public async Task<VerificationLevelTwo> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn";

            var result = await GetHttpClientSetup(url, value, secretKey);

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
        public async Task<VerificationLevelTwoWFace> VerfifyBvnInfoWithFace(string number, string image, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number},
                {"image", image}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn_w_face";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<VerificationLevelTwoWFace>(result, _options);


            return verificationDetails;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _httpClient.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private async Task<string> GetHttpClientSetup(string url, Dictionary<string, string> value, string secretKey)
        {

            var content = new FormUrlEncodedContent(value);

            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            content.Headers.Add("x-api-key", secretKey);

            HttpResponseMessage response = await _httpClient.PostAsync(new Uri(url), content);

            string result = await response.Content.ReadAsStringAsync();
            _httpClient.Dispose();
            return result;
        }

    }
}
