using IdentityPassTestLibrary.V1.Responses.DriversLicense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary.V1.API.Interfaces
{
    public interface IDriversLicenseVerificationType
    {
        public Task<DriverseLicenseResponse> VerfifyDriversLicense(string dob, string number, string secretKey, bool environmentType);
    }
}
