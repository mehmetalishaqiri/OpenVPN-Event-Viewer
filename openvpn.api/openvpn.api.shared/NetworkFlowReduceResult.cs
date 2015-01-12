using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace openvpn.api.shared
{
    public class NetworkFlowReduceResult
    {
        public string CommonName { get; set; }

        public decimal BytesReceived { get; set; }

        public decimal BytesSent { get; set; }
    }
}
