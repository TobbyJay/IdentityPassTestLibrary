using System.Text.Json.Serialization;

namespace IdentityPassTestLibrary.V1.Responses.Bvn.Bvn1._0
{
    public class VerificationLevelOne
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }

        [JsonPropertyName("response_code")]
        public string? ResponseCode { get; set; }

        [JsonPropertyName("bvn_data")]
        public BvnData? BvnData { get; set; }
    }

    public class BvnData
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string? MiddleName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string? PhoneNumber { get; set; }
    }
}
