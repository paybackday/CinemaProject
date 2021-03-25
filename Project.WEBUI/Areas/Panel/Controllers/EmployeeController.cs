using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
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
    [AllRolePassedAuthentication]
  
    public class EmployeeController : Controller
    {
        // GET: Panel/Employee
        EmployeeRepository _empRep;
        public EmployeeController()
        {
            _empRep = new EmployeeRepository();
        }
        public ActionResult EmployeeList()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employees = _empRep.GetActives()
            };
            return View(evm);
        }

        public ActionResult DeleteEmployee(int id)
        {
            _empRep.Delete(_empRep.Find(id));
         



            return RedirectToAction("EmployeeList", "Employee", new { Area = "Panel" });
        }

        public ActionResult UpdateEmployee(int id)
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = _empRep.Find(id),
                
            };
            return View(evm);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM apvm)
        {
          
            if (!ModelState.IsValid)
            {
                return View();
            }



            Employee tobeUpdatedEmploye = _empRep.FirstOrDefault(x => x.ID == apvm.Employee.ID);
            tobeUpdatedEmploye.FirstName = apvm.Employee.FirstName;
            tobeUpdatedEmploye.LastName = apvm.Employee.LastName;
            tobeUpdatedEmploye.MobilePhone = apvm.Employee.MobilePhone;
            tobeUpdatedEmploye.Password = apvm.Employee.Password;
            tobeUpdatedEmploye.ConfirmPassword = apvm.Employee.ConfirmPassword;
            tobeUpdatedEmploye.TCNO = apvm.Employee.TCNO;
         
            tobeUpdatedEmploye.Sallary = apvm.Employee.Sallary;
            tobeUpdatedEmploye.EmployeeType = apvm.Employee.EmployeeType;
            tobeUpdatedEmploye.Email = apvm.Employee.Email;



            _empRep.Update(tobeUpdatedEmploye);

            



            TempData["updateEmployee"] = $"{tobeUpdatedEmploye.FirstName} {tobeUpdatedEmploye.LastName} kişisi başarıyla güncellenmiştir";


            return RedirectToAction("EmployeeList", "Employee", new { Area = "Panel" });
        }

       public ActionResult AddEmployee()
        {
            EmployeeVM evm = new EmployeeVM
            {
                Employee = new Employee(),
                

            };
            return View(evm);
        }
        [HttpPost]
        public ActionResult AddEmployee([Bind(Prefix ="Employee")] Employee evm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _empRep.Add(evm);
            TempData["employeeSuccess"] = $"{evm.FirstName} {evm.LastName} Çalışan başarı ile eklenmiştir";
            return RedirectToAction("EmployeeList");
        }

       
    }
}