using FunerariaMuertoFeliz.Controllers;
using FunerariaMuertoFeliz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunerariaMuertoFeliz.Filters
{
    public class VerifySession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var usr = (usuario)HttpContext.Current.Session["usuario"];
         
            if(usr == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/IndexCliente");
                
                }
            }
            base.OnActionExecuting(filterContext);
        }

    }
}