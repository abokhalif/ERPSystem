using mvc2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        // connection the model
        MVC_DBEntities1 Emp_DB=new MVC_DBEntities1 ();
        public ActionResult Index()
        {
            return View(Emp_DB.Employees.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Emp_DB.Employees.Add(employee);
                Emp_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        // Edit
        /*[HttpGet]
        public ActionResult Edit(string name)
        {
            Employee employee = Emp_DB.Employees.Find(name);
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Emp_DB.Entry(employee).State = EntityState.Modified;
                Emp_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }*/



        [HttpGet]
 public ActionResult Edit(int id)
        {

            Employee userAccount = Emp_DB.Employees.Find(id);
            return View(userAccount);
        }
        // POST: UserAccounts/Edit/
        [HttpPost]

        public ActionResult Edit(Employee userAccount)
        {
            if (ModelState.IsValid)
            {
                Emp_DB.Entry(userAccount).State = EntityState.Modified;
                Emp_DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userAccount);
        }
    }

}