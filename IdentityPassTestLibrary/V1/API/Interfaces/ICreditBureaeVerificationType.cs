using IdentityPassTestLibrary.V1.Responses.CreditBureau;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface ICreditBureaeVerificationType
    {
        public Task<CreditBuerauResponse> VerfifyCreditBureauInfo(string phoneNumber, string firstName, string secretKey, bool environmentType);
    }
}
