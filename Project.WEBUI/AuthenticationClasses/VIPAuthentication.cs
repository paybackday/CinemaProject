using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    public class VIPAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["vip"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Account/Login");
            return false;
        }
    }
}