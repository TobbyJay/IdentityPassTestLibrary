using IdentityPassTestLibrary.V1.Responses.Nin.LookupNin;
using IdentityPassTestLibrary.V1.Responses.Nin.LookupNinSlip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface INinVerificationTypes
    {
        public Task<LookUpNinResponse> LookUpNin(string number, string secretKey, bool environmentType);
        public Task<LookUpNinResponse> LookUpNinSlip(string slipImage, string secretKey, bool environmentType);
        public Task<LookUpNinWithFaceResponse> LookUpNinWithFace(string faceImage, string number, string secretKey, bool environmentType);
    }
}
