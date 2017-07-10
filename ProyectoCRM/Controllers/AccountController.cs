using Microsoft.AspNet.Identity.Owin;
using ProyectoCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoCRM.Controllers
{
    public class AccountController : Controller
    {
        CRMDB db = new CRMDB();
        // GET: Account
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AspNetUsers users)
        {
            var usr = db.AspNetUsers.Where(u => u.Email == users.Email && u.PasswordHash == users.PasswordHash).FirstOrDefault();
            if (usr != null)
            {
                FormsAuthentication.SetAuthCookie(usr.UserName, false);
                await SignInManager.SignInAsync(usr.UserName, isPersistent: false, rememberBrowser: false);
                Session["UserId"] = usr.Id.ToString();
                Session["Email"] = usr.Email.ToString();
                return RedirectToAction("Index", "Home", new { area = "" });

            }
            else
            {
                ModelState.AddModelError("", "Credenciales incorrectos");
            }
            return View();
        }
        
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        
       
    }
}