using System.Net;
using System.Reflection;
using System.Runtime.Serialization;

namespace openvpn.api.core.handlers
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember]
        public string Version { get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); } }

        [DataMember]
        public HttpStatusCode StatusCode { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ErrorMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        public ApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null)
        {
            StatusCode = statusCode;
            Result = result;
            ErrorMessage = errorMessage;
        }
    }
}
