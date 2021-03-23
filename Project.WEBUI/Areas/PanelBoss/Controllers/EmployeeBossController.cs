using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
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

    public class EmployeeBossController : Controller
    {
        EmployeeRepository _empRep;
        public EmployeeBossController()
        {
            _empRep = new EmployeeRepository();
        }
        // GET: PanelBoss/EmployeeBoss
        public ActionResult EmployeeList()
        {
            EmployeeVM evm = new EmployeeVM()
            {
                Employees = _empRep.GetActives()
            };

            return View(evm);
        }
        
        public ActionResult EmployeeRoleUpdate(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = _empRep.Find(id)
            };
            return View(evm);
               
        }

        [HttpPost]
        public ActionResult EmployeeRoleUpdate(EmployeeVM evm)
        {
            Employee tobeUpdatedEmploye = _empRep.FirstOrDefault(x => x.ID == evm.Employee.ID);
            tobeUpdatedEmploye.EmployeeType = evm.Employee.EmployeeType;
            _empRep.Update(tobeUpdatedEmploye);
            return RedirectToAction("EmployeeList");

        }
    }
}