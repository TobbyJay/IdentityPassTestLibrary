using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.Responses.Nin.LookupNinSlip
{

    public class LookUpNinWithFaceResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("face_data")]
        public FaceData FaceData { get; set; }

        [JsonPropertyName("nin_data")]
        public NinData NinData { get; set; }
    }

    public class FaceData
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class NinData
    {
        [JsonPropertyName("birthcountry")]
        public string Birthcountry { get; set; }

        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        [JsonPropertyName("birthlga")]
        public string Birthlga { get; set; }

        [JsonPropertyName("birthstate")]
        public string Birthstate { get; set; }

        [JsonPropertyName("centralID")]
        public string CentralID { get; set; }

        [JsonPropertyName("educationallevel")]
        public string Educationallevel { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("emplymentstatus")]
        public string Emplymentstatus { get; set; }

        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("heigth")]
        public int Heigth { get; set; }

        [JsonPropertyName("maritalstatus")]
        public string Maritalstatus { get; set; }

        [JsonPropertyName("nin")]
        public string Nin { get; set; }

        [JsonPropertyName("nok_address1")]
        public string NokAddress1 { get; set; }

        [JsonPropertyName("nok_address2")]
        public string NokAddress2 { get; set; }

        [JsonPropertyName("nok_firstname")]
        public string NokFirstname { get; set; }

        [JsonPropertyName("nok_lga")]
        public string NokLga { get; set; }

        [JsonPropertyName("nok_middlename")]
        public string NokMiddlename { get; set; }

        [JsonPropertyName("nok_postalcode")]
        public string NokPostalcode { get; set; }

        [JsonPropertyName("nok_state")]
        public string NokState { get; set; }

        [JsonPropertyName("nok_surname")]
        public string NokSurname { get; set; }

        [JsonPropertyName("nok_town")]
        public string NokTown { get; set; }

        [JsonPropertyName("nspokenlang")]
        public string Nspokenlang { get; set; }

        [JsonPropertyName("ospokenlang")]
        public string Ospokenlang { get; set; }

        [JsonPropertyName("pfirstname")]
        public string Pfirstname { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("pmiddlename")]
        public string Pmiddlename { get; set; }

        [JsonPropertyName("profession")]
        public string Profession { get; set; }

        [JsonPropertyName("psurname")]
        public string Psurname { get; set; }

        [JsonPropertyName("religion")]
        public string Religion { get; set; }

        [JsonPropertyName("residence_AdressLine1")]
        public string ResidenceAdressLine1 { get; set; }

        [JsonPropertyName("residence_Town")]
        public string ResidenceTown { get; set; }

        [JsonPropertyName("residence_lga")]
        public string ResidenceLga { get; set; }

        [JsonPropertyName("residence_state")]
        public string ResidenceState { get; set; }

        [JsonPropertyName("residencestatus")]
        public string Residencestatus { get; set; }

        [JsonPropertyName("self_origin_lga")]
        public string SelfOriginLga { get; set; }

        [JsonPropertyName("self_origin_place")]
        public string SelfOriginPlace { get; set; }

        [JsonPropertyName("self_origin_state")]
        public string SelfOriginState { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("telephoneno")]
        public string Telephoneno { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("trackingId")]
        public string TrackingId { get; set; }
    }

}
