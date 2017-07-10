﻿using System;
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
    public class SupportsController : Controller
    {
        private CRMDB db = new CRMDB();

        // GET: Supports
        public ActionResult Index()
        {
            var support = db.Support.Include(s => s.AspNetUsers).Include(s => s.Cliente);
            return View(support.ToList());
        }

        // GET: Supports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // GET: Supports/Create
        public ActionResult Create()
        {
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre");
            return View();
        }

        // POST: Supports/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_cliente,titulo,detalle,estado,id_user")] Support support)
        {
            if (ModelState.IsValid)
            {
                db.Support.Add(support);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", support.id_user);
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", support.id_cliente);
            return View(support);
        }

        // GET: Supports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", support.id_user);
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", support.id_cliente);
            return View(support);
        }

        // POST: Supports/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_cliente,titulo,detalle,estado,id_user")] Support support)
        {
            if (ModelState.IsValid)
            {
                db.Entry(support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_user = new SelectList(db.AspNetUsers, "Id", "Email", support.id_user);
            ViewBag.id_cliente = new SelectList(db.Cliente, "id", "nombre", support.id_cliente);
            return View(support);
        }

        // GET: Supports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Support support = db.Support.Find(id);
            if (support == null)
            {
                return HttpNotFound();
            }
            return View(support);
        }

        // POST: Supports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Support support = db.Support.Find(id);
            db.Support.Remove(support);
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
