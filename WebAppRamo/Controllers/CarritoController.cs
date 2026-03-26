using Datos;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRamo.Controllers
{
    public class CarritoController : Controller
    {
        Consumo consu = new Consumo();
        string msmError = string.Empty;

        // GET: Carrito
        public ActionResult Index()
        {
            msmError = string.Empty;
            cl_CarritoCab ObjCarrito = new cl_CarritoCab();

            ObjCarrito = consu.Carrito(1, ref msmError);
            return View(ObjCarrito);
        }

        // CarritoController.cs
        [ChildActionOnly] // Asegura que solo se pueda llamar desde una vista
        public ActionResult CartSummary()
        {
            int conteo = 0;

            msmError = string.Empty;
            cl_CarritoCab ObjCarrito = new cl_CarritoCab();

            ObjCarrito = consu.Carrito(1, ref msmError);

            if (ObjCarrito != null && ObjCarrito.LstCarritoDet != null)
            {
                conteo = ObjCarrito.LstCarritoDet.Sum(x => x.Cantidad);
            }

            return PartialView("_CartSummary", conteo);
        }

        // GET: Carrito/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
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

        // GET: Carrito/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Carrito/Edit/5
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

        // GET: Carrito/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Carrito/Delete/5
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

        [HttpPost]
        public ActionResult AgregarProducto(int id, string precio)
        {
            try
            {
                msmError = string.Empty;
                List<cl_CarritoDet> LstDetCarrito = new List<cl_CarritoDet>();

                LstDetCarrito.Add(
                    new cl_CarritoDet
                    {
                        IdProd = id,
                        Cantidad = 1,
                        PrecioUnitario = Convert.ToDouble(precio)
                    }
                 );

                cl_CarritoCab ObjCarrito = new cl_CarritoCab
                {
                    IdUsuario = 1,
                    LstCarritoDet = LstDetCarrito
                };

                consu.RegistraCarrito(ObjCarrito, ref msmError);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult PagoCarrito(FormCollection collection)
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


    }
}
