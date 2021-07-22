using FunerariaMuertoFeliz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunerariaMuertoFeliz.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult IndexLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            using (var db = new FunerariaEntities())
            {
                var linq = from u in db.usuario
                           where u.correo == email && u.pass == pass && u.tipousuario_id== 1
                           select u;
                if (linq.Count() > 0)
                {
                    Session["usuario"] = linq.First();
                }
            }
            return View();
        }

    }
}