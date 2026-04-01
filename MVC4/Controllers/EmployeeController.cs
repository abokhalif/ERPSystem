using MVC4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Controllers
{
    public class EmployeeController : Controller
    {
        Employee_DBEntities1 db = new Employee_DBEntities1();
        // GET: Employee
        public ActionResult Index()
        {
            return View(db.Employee_Tb.ToList());
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee_Tb emp)
        {
            if(ModelState.IsValid)
            { 
                db.Employee_Tb.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee_Tb emp = db.Employee_Tb.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee_Tb emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State=EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            Employee_Tb emp = db.Employee_Tb.Find(id);
            return View(emp);
        }
        /* public ActionResult Delete(int id)
         {
             Employee_Tb emp = db.Employee_Tb.Find(id);
                 db.Employee_Tb.Remove(emp);
                 db.SaveChanges();
                 return RedirectToAction("Index");

         }*/
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee_Tb emp = db.Employee_Tb.Find(id);
            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Employee_Tb emp = db.Employee_Tb.Find(id);
            db.Employee_Tb.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}