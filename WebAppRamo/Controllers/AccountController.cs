using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebAppRamo.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        /*
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        */

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Producto");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            // Simulación de validación (reemplaza con tu BD)
            if (email == "admin@correo.com" && password == "123")
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return RedirectToAction("Index", "Producto");
            }

            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }

        public ActionResult RegistraUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(cl_Usuario m) // Reemplaza 'TuModelo' por el nombre de tu clase
        {
            if (ModelState.IsValid)
            {
                // Tu lógica para guardar en la base de datos aquí
                return RedirectToAction("Login");
            }



            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut(); // Quita la cookie
            Session.Clear();               // Limpia la sesión actual
            return RedirectToAction("Login", "Account"); // Te manda al login
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
