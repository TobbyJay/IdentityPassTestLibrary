using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn1._0;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn2._0;
using IdentityPassTestLibrary.V1.Responses.Bvn.Bvn2._0_w_face;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IBvnVerficationTypes
    {
        public Task<VerificationLevelOne> VerfifyBvnInfoLevel1(string number,string secretKey, bool environmentType);
        public Task<VerificationLevelTwo> VerfifyBvnInfoLevel2(string number, string secretKey, bool environmentType);
        public Task<VerificationLevelTwoWFace> VerfifyBvnInfoWithFace(string number, string image, string secretKey, bool environmentType);

    }
}
