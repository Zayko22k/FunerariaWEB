using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
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

        public ActionResult Obituario()
        {
            usuario u = (usuario)Session["usuario"];
            if(u == null)
            {
                return Redirect("~/Login/IndexLogin");
            }

            var linq = from us in db.boleta
                       where us.usuario_id == u.idusuario
                       select us;
         
            return View(linq.ToList());
        }
    /*  public ActionResult ObituarioYear()
     {
         List<boleta> boleta = db.boleta.ToList();
            var result = db.boleta.Include(x => x.parque)
                 .GroupBy(x => new { x.parque.nombre, x.parque.idparque })
                 .Select(x => new { parque = x.Key, Total = x.Count() }).ToList();
            return View(result);
     }*/
        // GET: boletas/Details/5
        public ActionResult Comprar()
        {
            try
            {
                planes p = (planes)Session["planSelect"];
                fallecido f = (fallecido)Session["fallecido"];
                parque pr = (parque)Session["parqueSelect"];
                List<pago> pago = new List<pago>();
                pago= db.pago.ToList(); 
                if (Session["usuario"] == null)
                {
                    return Redirect("~/Home/IndexCliente");
                }
                //var tupleModel = new Tuple<planes,fallecido,parque,List<pago>>(p,f,pr,pg);
                boleta boleta = new boleta();
                boleta.listapago = pago;
                boleta.fallecido = f;
                boleta.parque = pr;
                boleta.planes = p;

                if (p == null)
                {
                    return Redirect("~/Home/IndexCliente");
                }

                return View(boleta);
            }
            catch(Exception e)
            {
                _ = e.StackTrace;
            }

            return View();
        }
    
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
        public ActionResult Comprar([Bind(Include = "plan_id,created_at,pago_id,parque_id,fechaFuneral,fallecido_id")] boleta boleta)
        {
            if (ModelState.IsValid)
            {
                usuario u = (usuario)Session["usuario"];
                boleta.usuario_id = u.idusuario;
             
                db.boleta.Add(boleta);
                db.SaveChanges();
                return Redirect("~/Home/IndexCliente");
            }

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
