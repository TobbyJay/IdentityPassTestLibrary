using IdentityPassTestLibrary.V1.Responses.CreditBureau;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface ICreditBureauVerificationType
    {
        public Task<CreditBuerauResponse> VerfifyCreditBureauInfo(string phoneNumber, string firstName, string secretKey, bool environmentType);
    }
}
