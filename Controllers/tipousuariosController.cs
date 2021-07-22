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
    public class tipousuariosController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: tipousuarios
        public ActionResult Index()
        {
            return View(db.tipousuario.ToList());
        }

        // GET: tipousuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = db.tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // GET: tipousuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tipousuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idtipousuario,tipo")] tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.tipousuario.Add(tipousuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipousuario);
        }

        // GET: tipousuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = db.tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: tipousuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idtipousuario,tipo")] tipousuario tipousuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipousuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipousuario);
        }

        // GET: tipousuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipousuario tipousuario = db.tipousuario.Find(id);
            if (tipousuario == null)
            {
                return HttpNotFound();
            }
            return View(tipousuario);
        }

        // POST: tipousuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipousuario tipousuario = db.tipousuario.Find(id);
            db.tipousuario.Remove(tipousuario);
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
