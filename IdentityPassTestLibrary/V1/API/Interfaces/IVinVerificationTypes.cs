using IdentityPassTestLibrary.V1.Responses.Nin.LookupNin;
using IdentityPassTestLibrary.V1.Responses.Vin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IVinVerificationTypes
    {
        public Task<LookUpVinResponse> LookUpVinWithIdImage(string image, string secretKey, bool environmentType);
        public Task<LookUpVinResponse> LookUpVin(string number,string last_name, string state, string secretKey, bool environmentType);

    }
}
