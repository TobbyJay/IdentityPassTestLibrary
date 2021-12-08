using System.Text.Json.Serialization;

namespace IdentityPassTestLibrary.V1.Responses
{
    public class Data
    {
        [JsonPropertyName("verificationType")]
        public string VerificationType { get; set; }

        // talk with the team about types of info to return
    }
}