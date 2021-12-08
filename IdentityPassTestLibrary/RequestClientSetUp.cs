

namespace IdentityPassTestLibrary
{
    public class RequestClientSetUp : IRequestClientSetup
    {
        public async Task<string> GetHttpClientSetup(string url, Dictionary<string, string> value , string secretKey)
        {
            var httpClient = new HttpClient();

            var content = new FormUrlEncodedContent(value);

            content.Headers.Clear();
            content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            content.Headers.Add("x-api-key", secretKey);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);

            string result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
