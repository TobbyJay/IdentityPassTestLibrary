using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.Endpoints
{
    public class BvnEndPoints
    {
        public const string bvn1_0 = "/api/v1/biometrics/merchant/data/verification/bvn_validation";
        public const string bvn2_0 = "/api/v1/biometrics/merchant/data/verification/bvn";
        public const string bvn2_0AndFaceValidation = "/api/v1/biometrics/merchant/data/verification/bvn_w_face";
    }
}
