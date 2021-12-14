using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityPassTestLibrary
{
    public interface IRequestClientSetup
    {
        Task<string> GetHttpClientSetup(string url, Dictionary<string,string> value, string secretKey);
    }
}
