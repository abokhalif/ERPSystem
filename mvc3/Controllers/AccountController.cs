using mvc3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc3.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        // connection to data base
        NewAccountEntities1 db = new NewAccountEntities1();
        // shw the data in a list
        public ActionResult Index()
        {
            return View(db.NewUsers.ToList());
        }
        // SignUp 
        [HttpGet]
        public ActionResult SignUp()
        {
           return View();   
        }
        [HttpPost]  
        public ActionResult SignUp(NewUser user)
        {
            if(ModelState.IsValid)
            {
                db.NewUsers.Add(user);  
                db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();  

        }

        // Log In 
        [HttpGet]
        public ActionResult LogIn() 
        {
            return View();
        
        }
        [HttpPost]
        public ActionResult LogIn(NewUser user)
        {
            var result = db.NewUsers.Where(a => a.Name == user.Name && a.password == user.password).FirstOrDefault();
            if (result != null)
            {
                Session["x"] = "Hello" + " " + user.Name;
                return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "Invalid");
            return View();
        }
        // Edit /modify
        [HttpGet]
        public ActionResult Edit (int id) 
        {
            NewUser user=db.NewUsers.Find(id);
            return View(user);
        
        }
        [HttpPost]
        public ActionResult Edit(NewUser user)
        {
            if(ModelState.IsValid)
            {
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        // Delete 
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            NewUser user = db.NewUsers.Find(id);
            return View(user);

        }
        [HttpPost,ActionName("Delete")]
        public ActionResult ConfirmDelete (int id)
        {
            if (ModelState.IsValid)
            {
                NewUser user = db.NewUsers.Find(id);
                db.NewUsers.Remove(user);
                db.SaveChanges();   
                return RedirectToAction("Index");
            }
            return View();  
        }


    }
}