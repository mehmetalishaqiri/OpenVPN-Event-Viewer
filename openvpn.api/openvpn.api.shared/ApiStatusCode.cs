using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openvpn.api.shared
{
    public enum ApiStatusCode
    {
        Saved = 1,

        Exists = 2,
        
        Deleted = 3,

        Error = 4
    }
}
