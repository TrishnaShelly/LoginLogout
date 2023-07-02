using LoginLogout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginLogout.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Main_Testing_SpEntities db = new Main_Testing_SpEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u)
        {
            
                var usr = db.users.Where(model => model.usrName == u.usrName &&
                model.UsrPass == u.UsrPass).FirstOrDefault();
                if(usr != null)
                {
                    Session["userName"] = u.usrName.ToString();
                    TempData["LoginStatus"] = "<script>alert('Login successfuly')</script>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage= "<script>alert('Incorrect user Name or Password')</script>";
                    return View();
                }

            
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp( user u)
        {
            if(ModelState.IsValid== true)
            {
                db.users.Add(u);
                int a = db.SaveChanges();
                if(a >0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered successfuly')</script>";
                    ModelState.Clear();
                    return RedirectToAction("Index","Login");
                    
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registeration Failed')</script>";
                }

            }
            return View();
        }
    }
}