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
        string msmError = string.Empty;

        public ActionResult Index()
        {
            msmError = string.Empty;
            List<cl_Cliente> LstClientes = new List<cl_Cliente>();

            LstClientes = consu.ListaCliente(ref msmError);

            return View(LstClientes.OrderBy(x => x.Id).ToList());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            List<cl_EstadoCivil> LstEstCivil = consu.ListaEstadoCivil(ref msmError);
            List<cl_Tipo_Identificacion> LstTpProd = consu.ListaTipoIdenticacion(ref msmError);

            var listaTipos = LstTpProd
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            var listaEstadoCivil = LstEstCivil
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            ViewBag.EstadoCivilLst = listaEstadoCivil;
            ViewBag.TiposIdentificacion = listaTipos;
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(cl_Cliente collection)
        {
            try
            {
                msmError = string.Empty;
                List<cl_Cliente> LstCliente = new List<cl_Cliente>();
                
                collection.TendenciaCompra = 1;                
                collection.UsuarioCreacion = "AngelValdiviezo";
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
            msmError = string.Empty;
            cl_Cliente Cliente = new cl_Cliente();

            Cliente = consu.ClienteById(id, ref msmError);

            List<cl_Tipo_Identificacion> LstTpProd = consu.ListaTipoIdenticacion(ref msmError);
            List<cl_EstadoCivil> LstEstCivil = consu.ListaEstadoCivil(ref msmError);

            var listaTipos = LstTpProd
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            var listaEstadoCivil = LstEstCivil
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            ViewBag.TiposIdentificacion = listaTipos;
            ViewBag.EstadoCivilLst = listaEstadoCivil;

            return View(Cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, cl_Cliente Cliente)
        {
            try
            {
                msmError = string.Empty;
                Cliente.UsuarioModificacion = "AngelValdiviezo";
                consu.ModificaCliente(Cliente, ref msmError);

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
                msmError = string.Empty;
                consu.EliminaCliente(id, ref msmError);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
