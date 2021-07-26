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
        public ActionResult IndexLogin(string email, string pass)
        {

            if (email.Equals("") || pass.Equals(""))
            {
                ViewBag.ErrorSession = "Rellene los campos necesarios";
                
            }
            else
            {
                using (var db = new FunerariaEntities())
                {
                    var linq = from u in db.usuario
                               where u.correo == email && u.pass == pass && u.tipousuario_id == 1
                               select u;
                    if (linq.Count() > 0)
                    {
                        Session["usuario"] = linq.First();
                        return Redirect("~/Home/IndexCliente");
                    }
                    var linq2 = from u in db.usuario
                                where u.correo == email && u.pass == pass && u.tipousuario_id == 2
                                select u;

                    if (linq2.Count() > 0)
                    {
                        Session["admin"] = linq2.First();
                        return Redirect("~/Home/IndexAdmin");
                    }
                  ViewBag.ErrorSession = "Usuario y/o contraseña incorrecto(s)";

                }
            }
                return View();
            }
        public ActionResult Logout()
        {
            Session["usuario"] = null;
            Session.Abandon();
            return Redirect("~/Login/IndexLogin");
        }
    }
}