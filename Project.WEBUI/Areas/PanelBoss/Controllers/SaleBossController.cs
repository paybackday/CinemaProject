using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.WEBUI.AuthenticationClasses;
using Project.WEBUI.Models.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Areas.PanelBoss.Controllers
{
    [BossAuthentication]
    public class SaleBossController : Controller
    {
        SaleRepository _saleRep;
       
        public SaleBossController()
        {
            _saleRep = new SaleRepository();
     
        }
        // GET: PanelBoss/SaleBoss
        public ActionResult SaleList()
        {
            SaleVM svm = new SaleVM
            {
                Sales = _saleRep.GetActives(),

            };
            
            return View(svm);
        }
    }
}