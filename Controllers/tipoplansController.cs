using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunerariaMuertoFeliz.Models;

namespace FunerariaMuertoFeliz.Controllers
{
    public class tipoplansController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: tipoplans
        public ActionResult Index()
        {
            return View(db.tipoplan.ToList());
        }

        // GET: tipoplans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoplan tipoplan = db.tipoplan.Find(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // GET: tipoplans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipoplans/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipoplan,nombre")] tipoplan tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.tipoplan.Add(tipoplan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoplan);
        }

        // GET: tipoplans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoplan tipoplan = db.tipoplan.Find(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // POST: tipoplans/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipoplan,nombre")] tipoplan tipoplan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoplan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoplan);
        }

        // GET: tipoplans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoplan tipoplan = db.tipoplan.Find(id);
            if (tipoplan == null)
            {
                return HttpNotFound();
            }
            return View(tipoplan);
        }

        // POST: tipoplans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoplan tipoplan = db.tipoplan.Find(id);
            db.tipoplan.Remove(tipoplan);
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
