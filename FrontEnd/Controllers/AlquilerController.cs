using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Newtonsoft.Json;
using System.Text.Json;

namespace FrontEnd.Controllers
{
    public class AlquilerController : Controller
    {
        private readonly AlquilerHelper alquilerHelper = new();
        public IActionResult Index()
        {
            try
            {
                var alquileres = alquilerHelper.MostrarAlquileres();
                return View(alquileres);
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
                var alquiler = alquilerHelper.MostrarAlquiler(id);
                return View(alquiler);
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
                AlquilerEnvioViewModel model = new();
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(AlquilerEnvioViewModel model)
        {
            try
            {
                var creado = alquilerHelper.CrearAlquiler(model);
                return RedirectToAction("Index", "Envio");
            }
            catch (Exception ex)
            {

                throw new Exception("" + ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var alquiler = alquilerHelper.MostrarAlquiler(id);
                return View(alquiler);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AlquilerViewModel alquiler)
        {
            try
            {
                var editado = alquilerHelper.EditarAlquiler(alquiler);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var borrado = alquilerHelper.MostrarAlquiler(id);
                return View(borrado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(AlquilerViewModel alquiler)
        {
            try
            {
                var borrado = alquilerHelper.BorrarAlquiler(alquiler);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
