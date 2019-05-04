using AdminSystemManagement.Models;
using AdminSystemManagement.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminSystemManagement.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
       
        static ApplicationDbContext ctx = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    EmployeeViewModel evm = new EmployeeViewModel();
        //    evm.departments = ctx.Departments.ToList();
        //    ViewBag.Action = "Add";
        //    return View(evm);
        //}
        public ActionResult List()
        {
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.Employees = ctx.Employees.Include("Department").ToList();
            evm.departments = ctx.Departments.ToList();
           
            return View(evm);
        }
        [HttpPost]
        [Authorize(Roles ="Manager,Admin")]

        public ActionResult Add(EmployeeViewModel evmEmp)
        {
            if (ModelState.IsValid)
            {
                evmEmp.employee.DateProperty = DateTime.Now;
                ctx.Employees.Add(evmEmp.employee);
                ctx.SaveChanges();
                return PartialView("_EmpRowPartial",evmEmp.employee);

            }
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = evmEmp.employee;
            return View("List",evm);

        }

        [HttpGet]
        [Authorize(Roles = "Manager,Admin")]

        public ActionResult Edit(int id)
        {

            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == id);
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = employee;
            ViewBag.Action = "Edit";
            if (employee != null)
            {
                return View("Add", evm);
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        [Authorize(Roles = "Manager,Admin")]

        public ActionResult Edit(EmployeeViewModel em)
        {

            Employee oldEmployee = ctx.Employees.FirstOrDefault(e => e.Id == em.employee.Id);
            if (ModelState.IsValid)
            {

                oldEmployee.Name = em.employee.Name;
                oldEmployee.Age = em.employee.Age;
                oldEmployee.Gender = em.employee.Gender;
                oldEmployee.Email = em.employee.Email;
                oldEmployee.Department.Id = em.employee.Fk_DepartmentId;
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.departments = ctx.Departments.ToList();
            evm.employee = em.employee;
            return View(evm);

        }

        public ActionResult Details(Employee emp)
        {
            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == emp.Id);
            if (employee != null)
            {
                return View("Details", employee);
            }

            return RedirectToAction("List");
        }

        [Authorize(Roles = "Manager,Admin")]

        public ActionResult Delete(int id)
        {
            Employee employee = ctx.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                ctx.Employees.Remove(employee);
                ctx.SaveChanges();
                return RedirectToAction("List");
            }
            return View("List");
        }


    }
}
