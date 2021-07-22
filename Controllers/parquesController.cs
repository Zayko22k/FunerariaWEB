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
    public class parquesController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: parques
        public ActionResult Index()
        {
            var parque = db.parque.Include(p => p.region);
            return View(parque.ToList());
        }

        // GET: parques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parque parque = db.parque.Find(id);
            if (parque == null)
            {
                return HttpNotFound();
            }
            return View(parque);
        }

        // GET: parques/Create
        public ActionResult Create()
        {
            ViewBag.region_id = new SelectList(db.region, "idregion", "nombre");
            return View();
        }

        // POST: parques/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idparque,nombre,direccion,horario,telefono,region_id")] parque parque)
        {
            if (ModelState.IsValid)
            {
                db.parque.Add(parque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.region_id = new SelectList(db.region, "idregion", "nombre", parque.region_id);
            return View(parque);
        }

        // GET: parques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parque parque = db.parque.Find(id);
            if (parque == null)
            {
                return HttpNotFound();
            }
            ViewBag.region_id = new SelectList(db.region, "idregion", "nombre", parque.region_id);
            return View(parque);
        }

        // POST: parques/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idparque,nombre,direccion,horario,telefono,region_id")] parque parque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.region_id = new SelectList(db.region, "idregion", "nombre", parque.region_id);
            return View(parque);
        }

        // GET: parques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            parque parque = db.parque.Find(id);
            if (parque == null)
            {
                return HttpNotFound();
            }
            return View(parque);
        }

        // POST: parques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            parque parque = db.parque.Find(id);
            db.parque.Remove(parque);
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
