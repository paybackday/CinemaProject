﻿using Project.WEBUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    //[BoxOfficeSupervisorAuthentication]
    //[ManagementAuthentication]
    //[BookingClerkAuthentication]
    public class MainController : Controller
    {
        // GET: Panel/Main
        public ActionResult Index()
        {
            return View();
        }
    }
}