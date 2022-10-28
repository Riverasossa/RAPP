using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class DevolucionController : Controller
    {
        private readonly DevolucionHelper devolucionHelper = new();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var devoluciones = devolucionHelper.MostrarDevoluciones();
                return View(devoluciones);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                var devolucion = devolucionHelper.MostrarDevolucion(id);
                return View(devolucion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(DevolucionesViewModel devolucion)
        {
            try
            {
                var creado = devolucionHelper.CrearDevolucion(devolucion);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var devolucion = devolucionHelper.MostrarDevolucion(id);
                return View(devolucion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(DevolucionesViewModel devoluciones)
        {
            try
            {
                var editado = devolucionHelper.EditarDevolucion(devoluciones);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
