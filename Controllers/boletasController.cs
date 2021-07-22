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
    public class boletasController : Controller
    {
        private FunerariaEntities db = new FunerariaEntities();

        // GET: boletas
        public ActionResult Index()
        {
            var boleta = db.boleta.Include(b => b.boleta1).Include(b => b.boleta2).Include(b => b.fallecido).Include(b => b.pago).Include(b => b.parque).Include(b => b.planes).Include(b => b.usuario);
            return View(boleta.ToList());
        }

        // GET: boletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // GET: boletas/Create
        public ActionResult Create()
        {
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta");
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta");
            ViewBag.fallecido_id = new SelectList(db.fallecido, "idfallecido", "rut");
            ViewBag.pago_id = new SelectList(db.pago, "idpago", "nombre");
            ViewBag.parque_id = new SelectList(db.parque, "idparque", "nombre");
            ViewBag.plan_id = new SelectList(db.planes, "idplanes", "nombre");
            ViewBag.usuario_id = new SelectList(db.usuario, "idusuario", "nombre");
            return View();
        }

        // POST: boletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idboleta,plan_id,usuario_id,pago_id,created_at,parque_id,fechaFuneral,fallecido_id")] boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.boleta.Add(boleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.fallecido_id = new SelectList(db.fallecido, "idfallecido", "rut", boleta.fallecido_id);
            ViewBag.pago_id = new SelectList(db.pago, "idpago", "nombre", boleta.pago_id);
            ViewBag.parque_id = new SelectList(db.parque, "idparque", "nombre", boleta.parque_id);
            ViewBag.plan_id = new SelectList(db.planes, "idplanes", "nombre", boleta.plan_id);
            ViewBag.usuario_id = new SelectList(db.usuario, "idusuario", "nombre", boleta.usuario_id);
            return View(boleta);
        }

        // GET: boletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.fallecido_id = new SelectList(db.fallecido, "idfallecido", "rut", boleta.fallecido_id);
            ViewBag.pago_id = new SelectList(db.pago, "idpago", "nombre", boleta.pago_id);
            ViewBag.parque_id = new SelectList(db.parque, "idparque", "nombre", boleta.parque_id);
            ViewBag.plan_id = new SelectList(db.planes, "idplanes", "nombre", boleta.plan_id);
            ViewBag.usuario_id = new SelectList(db.usuario, "idusuario", "nombre", boleta.usuario_id);
            return View(boleta);
        }

        // POST: boletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idboleta,plan_id,usuario_id,pago_id,created_at,parque_id,fechaFuneral,fallecido_id")] boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.idboleta = new SelectList(db.boleta, "idboleta", "idboleta", boleta.idboleta);
            ViewBag.fallecido_id = new SelectList(db.fallecido, "idfallecido", "rut", boleta.fallecido_id);
            ViewBag.pago_id = new SelectList(db.pago, "idpago", "nombre", boleta.pago_id);
            ViewBag.parque_id = new SelectList(db.parque, "idparque", "nombre", boleta.parque_id);
            ViewBag.plan_id = new SelectList(db.planes, "idplanes", "nombre", boleta.plan_id);
            ViewBag.usuario_id = new SelectList(db.usuario, "idusuario", "nombre", boleta.usuario_id);
            return View(boleta);
        }

        // GET: boletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: boletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boleta boleta = db.boleta.Find(id);
            db.boleta.Remove(boleta);
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
