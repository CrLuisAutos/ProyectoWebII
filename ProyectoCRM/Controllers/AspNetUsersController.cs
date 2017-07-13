using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoCRM.Models;

namespace ProyectoCRM.Controllers
{
    
    public class AspNetUsersController : Controller
    {


        private CRMDB db = new CRMDB();
        /// <summary>
        /// Lista de usuarios del sistema
        /// </summary>
        /// <returns></returns>
        // GET: AspNetUsers
        public ActionResult Index()
        {
            return View(db.AspNetUsers.ToList());
        }
        /// <summary>
        /// Muestra las caracteristicas del usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        // GET: AspNetUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }
        /// <summary>
        /// Permite crear el usuario
        /// </summary>
        /// <returns></returns>
        // GET: AspNetUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PasswordHash,UserName,Nombre,Apellido")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                aspNetUsers.Email = aspNetUsers.UserName;
                db.AspNetUsers.Add(aspNetUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aspNetUsers);
        }
      

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }

        /// <summary>
        /// Permite editar un usuario
        /// </summary>
        /// <param name="id">Id del usuario</param>
        /// <returns></returns>
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PasswordHash,UserName,Nombre,Apellido")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                aspNetUsers.Email = aspNetUsers.UserName;
                db.Entry(aspNetUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            if (aspNetUsers == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUsers);
        }
        /// <summary>
        /// Permite eliminar un usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: AspNetUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AspNetUsers aspNetUsers = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUsers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        
    }
}
