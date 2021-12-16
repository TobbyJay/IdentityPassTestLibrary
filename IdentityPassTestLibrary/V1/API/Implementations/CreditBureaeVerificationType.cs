using IdentityPassTestLibrary.V1.API.Interfaces;
using IdentityPassTestLibrary.V1.Responses.CreditBureau;
using System.Text.Json;

namespace IdentityPassTestLibrary.V1.API.Implementations
{
    public class CreditBureaeVerificationType : ICreditBureauVerificationType
    {
        private readonly JsonSerializerOptions _options;
        private bool disposedValue;
        private HttpClient _httpClient;
        public CreditBureaeVerificationType()
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// This method is used to verify Credit bureau info
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="firstName"></param>
        /// <param name="secretKey"></param>
        /// <param name="environmentType"></param>
        /// <returns></returns>
        public async Task<CreditBuerauResponse> VerfifyCreditBureauInfo(string phoneNumber, string firstName, string secretKey, bool environmentType)
        {
            var environmentUrl = environmentType == false ? "https://sandbox.myidentitypass.com" : "https://api.myidentitypay.com";

            var value = new Dictionary<string, string>
            {
                { "phone_number", phoneNumber },
                { "first_name", firstName}
            };

            var url = $"{environmentUrl}/api/v1/biometrics/merchant/data/verification/credit_bureau";

            var result = await GetHttpClientSetup(url, value, secretKey);

            var verificationDetails = JsonSerializer.Deserialize<CreditBuerauResponse>(result, _options);


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
