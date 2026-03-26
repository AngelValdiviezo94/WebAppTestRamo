using Datos;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppRamo.Controllers
{
    public class ClienteController : Controller
    {
        Consumo consu = new Consumo();

        // GET: Cliente
        public ActionResult Index()
        {
            string msmError = string.Empty;
            List<cl_Cliente> LstClientes = new List<cl_Cliente>();

            LstClientes = consu.ListaCliente(ref msmError);

            return View(LstClientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(cl_Cliente collection)
        {
            try
            {
                string msmError = string.Empty;
                List<cl_Cliente> LstCliente = new List<cl_Cliente>();
                collection.IdTipoIdentificacion = 1;
                collection.TendenciaCompra = "1";
                collection.EstadoCivil = "C";
                LstCliente.Add(collection);

                consu.RegistraCliente(LstCliente, ref msmError);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
