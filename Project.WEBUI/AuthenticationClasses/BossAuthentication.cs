using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    public class BossAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if(httpContext.Session["boss"]!=null)
            {
                return true;
            }
            httpContext.Response.Redirect("/Account/Login");
            return false;
        }
    }
}