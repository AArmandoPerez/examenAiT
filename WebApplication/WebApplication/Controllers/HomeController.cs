using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Productos()
        {

            if (Session["sUsuario"] == null)
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }

        public ActionResult GetData()
        {

            WsPersonas.Service1Client ws = new WsPersonas.Service1Client();
            var result = ws.ObtenerProductos();
            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;

        }


        [HttpPost]
        public ActionResult Login(Models.User user)
        {

            WsPersonas.Service1Client ws = new WsPersonas.Service1Client();

            var result = ws.ObtenerUsuario(user.UserName, user.Password);

            if (result.password == user.Password)
            {
                Session["sUsuario"] = user.UserName;
                return RedirectToAction("Productos", "Home");

            }
            else
            {
                ModelState.AddModelError("", "El usuario no existe! ");
                return View(user);
            }


        }

    }
}