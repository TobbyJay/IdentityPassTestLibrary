using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.Responses.Vin
{
    public class LookUpVinResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("response_code")]
        public string ResponseCode { get; set; }

        [JsonPropertyName("vc_data")]
        public VcData VcData { get; set; }
    }
    public class VcData
    {
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("vin")]
        public string Vin { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("timeOfRegistration")]
        public string TimeOfRegistration { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("lga")]
        public string Lga { get; set; }

        [JsonPropertyName("registrationAreaWard")]
        public string RegistrationAreaWard { get; set; }

        [JsonPropertyName("pollingUnit")]
        public string PollingUnit { get; set; }

        [JsonPropertyName("pollingUnitCode")]
        public string PollingUnitCode { get; set; }
    }



}
