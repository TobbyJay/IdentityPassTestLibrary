using IdentityPassTestLibrary.V1.Responses.Passport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IPassportVerification
    {
        public Task<PassportVerificationResponse> VerifyInternationalPassport(string number, string first_name, 
            string last_name, string dob, string secretKey, bool environmentType);
    }
}
