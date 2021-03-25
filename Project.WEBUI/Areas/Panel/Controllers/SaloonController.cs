﻿using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.Panel.Controllers
{
    //[AllRolePassedAuthentication]
  
    public class SaloonController : Controller
    {
        SaloonRepository _salRep;
    
        public SaloonController()
        {
            _salRep = new SaloonRepository();
         
        }
        // GET: Panel/Saloon
        public ActionResult SaloonList()
        {
            SaloonVM svm = new SaloonVM
            {
                Saloons = _salRep.GetActives()
            };

            return View(svm);
        }

        public ActionResult DeleteSaloon(int id)
        {
            _salRep.Delete(_salRep.Find(id));
            return RedirectToAction("SaloonList");
        }
        public ActionResult UpdateSaloon(int id)
        {
            SaloonVM svm = new SaloonVM
            {
                Saloon = _salRep.Find(id),
            };
            return View(svm);
        }
        [HttpPost]
        public ActionResult UpdateSaloon([Bind(Prefix ="Saloon")] Saloon item)
        {
            //TODO : SaleSeat ekleme yapılacak.
            //TODO : CSS'ler fotolar halledilecek..
            //TODO : Sevim Update Description
            //Saloon tobeUpdated = _salRep.FirstOrDefault(x => x.ID == item.Saloon.ID);
            //tobeUpdated.SaloonNo = item.Saloon.SaloonNo;
            //TODO : tobeUpdated.Capacity = item.Saloon.Capacity;// readonly set'i kapalı..
            _salRep.Update(item);
            return RedirectToAction("SaloonList");

        }
     
      
        
    }
}
