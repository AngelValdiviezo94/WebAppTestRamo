using Datos;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebAppRamo.Controllers
{
    public class ProductoController : Controller
    {
        Consumo consu = new Consumo();
        string msmError = string.Empty;

        // GET: Producto
        public ActionResult Index()
        {
            msmError = string.Empty;
            List<cl_Producto> LstClientes = new List<cl_Producto>();
            
            LstClientes = consu.ListaProducto(ref msmError);
            

            return View(LstClientes.OrderBy(x => x.Id).ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            List<cl_Tipo_Producto> LstTpProd = new List<cl_Tipo_Producto>();
            LstTpProd = consu.ListaTipoProducto(ref msmError);
            
            var listaTipos = LstTpProd
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            ViewBag.TiposProducto = listaTipos;

            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(cl_Producto collection)
        {
            try
            {
                msmError = string.Empty;
                List<cl_Producto> LstCliente = new List<cl_Producto>();                
                collection.UsuarioCreacion = "AngelValdiviezo";
                LstCliente.Add(collection);

                consu.RegistraProducto(LstCliente, ref msmError);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            msmError = string.Empty;
            cl_Producto Cliente = new cl_Producto();

            Cliente = consu.ProductoById(id, ref msmError);

            List<cl_Tipo_Producto> LstTpProd = new List<cl_Tipo_Producto>();
            LstTpProd = consu.ListaTipoProducto(ref msmError);

            var listaTipos = LstTpProd
            .Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Nombre
            }).ToList();

            ViewBag.TiposProducto = listaTipos;

            return View(Cliente);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, cl_Producto collection)
        {
            try
            {
                msmError = string.Empty;
                collection.UsuarioModificacion = "AngelValdiviezo";
                consu.ModificaProducto(collection, ref msmError);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                msmError = string.Empty;
                cl_Producto ObjProducto = new cl_Producto
                {
                    Id = id,
                    UsuarioModificacion = "AngelValdiviezo"
                };

                consu.EliminaProducto(ObjProducto, ref msmError);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
