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
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Se comparan los credenciales del usuario y se crea la sesion
        /// </summary>
        /// <param name="users">Usuarios del sistema</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(AspNetUsers users)
        {
            var usr = db.AspNetUsers.Where(u => u.Email == users.Email && u.PasswordHash == users.PasswordHash).FirstOrDefault();
            if (usr != null)
            {
                try
                {
                    int idRole = db.AspNetUserRoles.Where(u => u.UserId == usr.Id).FirstOrDefault().RoleId;
                    string role = db.AspNetRoles.Where(u => u.Id == idRole).FirstOrDefault().Name;
                    Session["rol"] = role;
                }
                catch (Exception ex)
                {
                    Session["rol"] = null;
                }
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
        /// <summary>
        /// Se cierra la sesion
        /// </summary>
        /// <returns>Redirecciona a la página del login</returns>
        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login");
        }
        
       
    }
}