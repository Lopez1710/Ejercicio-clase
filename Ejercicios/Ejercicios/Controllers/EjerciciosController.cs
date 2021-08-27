using Ejercicios.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejercicios.Controllers
{
    public class EjerciciosController : Controller
    {
        // GET: Ejercicios
        public ActionResult Index()
        {
            return View();
        }

        Accesos users = new Accesos();
        [HttpPost]
        public ActionResult Login(string User, int dui)
        {
            

            for (int i = 0; i < users.Users.Length; i++)
                if (User.Equals(users.Users[i]) && dui.Equals(users.Dui[i]))
                {
                    return Redirect("/Ejercicios/obtDatos");
                }
                
                ViewBag.Error = "Usuario o password incorrecta";
               
                return RedirectToAction("Index");
        }

        

       

        public ActionResult obtDatos(string nombre, float valorhr=0, float hrstrab=0, float antiguedad=0 )
        {
            ViewBag.nombre = nombre;
            ViewBag.valorhoras = valorhr;
            ViewBag.horastrab = hrstrab;
            ViewBag.antiguedad = antiguedad;
            ViewBag.cobro = (valorhr * hrstrab + antiguedad + 30);
            ViewBag.descuento = ((valorhr * hrstrab + antiguedad * 30) * 0.13);
            ViewBag.condescuento = ((valorhr * hrstrab + antiguedad * 30) - (valorhr * hrstrab + antiguedad * 30) * 0.13);
            return View();
        }
    }
}