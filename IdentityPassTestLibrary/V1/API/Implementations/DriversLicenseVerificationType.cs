using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses.DriversLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class DriversLicenseVerificationType : IDriversLicenseVerificationType
    {
        private readonly JsonSerializerOptions _options;
        private bool disposedValue;
        private HttpClient _httpClient;
        public DriversLicenseVerificationType()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// This method is used to verify Drivers License
        /// </summary>
        /// <param name="dob"></param>
        /// <param name="number"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns></returns>
        public async Task<DriverseLicenseResponse> VerfifyDriversLicense(string dob,string number, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "dob", dob },
                { "number", number}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/bvn_validation";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<DriverseLicenseResponse>(result, _options);


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
