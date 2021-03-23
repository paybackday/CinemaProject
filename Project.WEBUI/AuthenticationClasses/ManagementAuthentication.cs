using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.AuthenticationClasses
{
    public class ManagementAuthentication:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["management"] != null)
            {
                return true;
            }
            httpContext.Response.Redirect("EmployeeLogin",false);
            return false;
        }
        
    }
}