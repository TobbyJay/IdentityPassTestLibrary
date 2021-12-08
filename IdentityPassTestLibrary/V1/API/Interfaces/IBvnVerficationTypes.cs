using IdentityPassTestLibrary.V1.Responses;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IBvnVerficationTypes
    {
        public Task<Response> VerfifyBvnInfoLevel1(string number,string secretKey, bool environmentType);
        public Task<Response> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType);
        public Task<Response> VerfifyBvnInfoWithFace(string number, string secretKey, bool environmentType);

    }
}
