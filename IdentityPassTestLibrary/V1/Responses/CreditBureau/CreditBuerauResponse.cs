using System.Text.Json.Serialization;

namespace IdentityPassTestLibrary.V1.Responses.CreditBureau
{
    public class CreditBuerauResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
    public class PerformanceSummary
    {
        [JsonPropertyName("ACCOUNT_BALANCE")]
        public string ACCOUNTBALANCE { get; set; }

        [JsonPropertyName("APPROVED_AMOUNT")]
        public string APPROVEDAMOUNT { get; set; }

        [JsonPropertyName("DATA_PRDR_ID")]
        public string DATAPRDRID { get; set; }

        [JsonPropertyName("DISHONORED_CHEQUES_COUNT")]
        public string DISHONOREDCHEQUESCOUNT { get; set; }

        [JsonPropertyName("FACILITIES_COUNT")]
        public string FACILITIESCOUNT { get; set; }

        [JsonPropertyName("INSTITUTION_NAME")]
        public string INSTITUTIONNAME { get; set; }

        [JsonPropertyName("NONPERFORMING_FACILITY")]
        public string NONPERFORMINGFACILITY { get; set; }

        [JsonPropertyName("OVERDUE_AMOUNT")]
        public string OVERDUEAMOUNT { get; set; }

        [JsonPropertyName("PERFORMING_FACILITY")]
        public string PERFORMINGFACILITY { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("Bvn")]
        public string Bvn { get; set; }

        [JsonPropertyName("Phonenumber")]
        public string Phonenumber { get; set; }

        [JsonPropertyName("LinkedAccounts")]
        public string LinkedAccounts { get; set; }

        [JsonPropertyName("FullName")]
        public string FullName { get; set; }

        [JsonPropertyName("DateOFBirth")]
        public string DateOFBirth { get; set; }

        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("LinkedEmail")]
        public object LinkedEmail { get; set; }

        [JsonPropertyName("IsLoan")]
        public string IsLoan { get; set; }

        [JsonPropertyName("LoanAmounts")]
        public string LoanAmounts { get; set; }

        [JsonPropertyName("LastUpdatedDate")]
        public string LastUpdatedDate { get; set; }

        [JsonPropertyName("Score")]
        public object Score { get; set; }

        [JsonPropertyName("Delinquency")]
        public string Delinquency { get; set; }

        [JsonPropertyName("PerformanceSummary")]
        public List<PerformanceSummary> PerformanceSummary { get; set; }
    }
}
