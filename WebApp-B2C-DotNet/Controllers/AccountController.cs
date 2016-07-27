using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// The following using statements were added for this sample.
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;

namespace WebApp_OpenIDConnect_DotNet_B2C.Controllers
{
    public class AccountController : Controller
    {
        public void Login()
        {
            // TODO: Execute the SUSI policy
        }

        public void ResetPassword()
        {
            // TODO: Execute the password reset policy
        }

        public void Logout()
        {
            // TODO: Sign the user out of the app
        }
	}
}