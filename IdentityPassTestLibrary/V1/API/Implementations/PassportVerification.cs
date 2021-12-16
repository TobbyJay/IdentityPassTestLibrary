using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses.Passport;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class PassportVerification : IPassportVerification, IDisposable
    {
        private readonly JsonSerializerOptions _options;
        private bool disposedValue;
        private HttpClient _httpClient;

        public PassportVerification()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Allows merchant to verify a Nigerian International passport
        /// </summary>
        /// <param name="number"></param>
        /// <param name="first_name"></param>
        /// <param name="last_name"></param>
        /// <param name="dob"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns></returns>
        public async Task<PassportVerificationResponse> VerifyInternationalPassport(string number, string first_name, string last_name, DateTime dob, string secretKey, bool environmentType)
        {
            var _dob = Convert.ToDateTime(dob).ToString("yyyy-MM-dd");

            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "number", number},
                {"first_name", first_name },
                {"last_name", last_name },
                {"dob", _dob },
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/national_passport";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<PassportVerificationResponse>(result, _options);

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

        //public void Dispose()
        //{
        //    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //    Dispose(disposing: true);
        //    GC.SuppressFinalize(this);
        //}

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
