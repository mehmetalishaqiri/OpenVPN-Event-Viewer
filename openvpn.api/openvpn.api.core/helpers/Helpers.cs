using System.Configuration;
using System.Linq;
using System.Web;

namespace openvpn.api.core.helpers
{
    public static class Helpers
    {
        public static bool IsUserAdmin()
        {
            var currentUser = HttpContext.Current.Session["ExternalLoginModel"] as openvpn.api.core.auth.ExternalLoginModel;
            if (currentUser == null) 
                return false;
            
            var admins = ConfigurationManager.AppSettings["Administrators"].Split(',');
            
            return admins.Any() && admins.Contains(currentUser.Email);
        }

    }
}