using System.Text.Json.Serialization;

namespace IdentityPassTestLibrary.V1.Responses
{
    public class Response
    {

        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; } 

    }
}
