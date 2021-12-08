using IdentityPassTestLibrary.V1.Responses;
using IdentityPassTestLibrary.V1.Responses.Bvn;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IBvnVerficationTypes
    {
        public Task<VerificationLevelOne> VerfifyBvnInfoLevel1(string number,string secretKey, bool environmentType);
        public Task<Response> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType);
        public Task<Response> VerfifyBvnInfoWithFace(string number, string secretKey, bool environmentType);

    }
}
