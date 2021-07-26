
using FunerariaMuertoFeliz.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunerariaMuertoFeliz.Controllers
{
  
    public class HomeController : Controller
    {


        public ActionResult IndexAdmin()
        {
            usuario u = (usuario)Session["admin"];
            if(u == null)
            {
                return Redirect("~/Login/IndexLogin");
            }
            return View();
        }
   
        public ActionResult IndexCliente()
        {
            usuario u = (usuario)Session["usuario"];
          
            if (u== null)
            {
                return Redirect("~/Login/IndexLogin");
            }

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}