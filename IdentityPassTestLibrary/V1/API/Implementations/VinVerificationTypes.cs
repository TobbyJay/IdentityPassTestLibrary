using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses.Nin.LookupNin;
using IdentityPassTestLibrary.V1.Responses.Vin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class VinVerificationTypes : IVinVerificationTypes, IDisposable
    {
        private readonly JsonSerializerOptions _options;
        private bool disposedValue;
        private HttpClient _httpClient;
        public VinVerificationTypes()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
        }
        /// <summary>
        /// This method allows you to verify voter's card number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="last_name"></param>
        /// <param name="state"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns></returns>
        public async Task<LookUpVinResponse> LookUpVin(string number, string last_name, string state, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number},
                { "last_name", last_name},
                { "state", state}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/voters_card";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<LookUpVinResponse>(result, _options);


            return verificationDetails;
        }

        /// <summary>
        /// This method allows you to verify a voters card ID image
        /// </summary>
        /// <param name="image"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns></returns>
        public async Task<LookUpVinResponse> LookUpVinWithIdImage(string image, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "image", image}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/voters_card/image";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<LookUpVinResponse>(result, _options);


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
