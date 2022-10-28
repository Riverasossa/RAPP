using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class AutoController : Controller
    {

        private readonly AutoHelper autoHelper = new();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var auto = autoHelper.MostrarAutos();
                return View(auto);
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
                var auto = autoHelper.MostrarAuto(id);
                return View(auto);
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
        public ActionResult Create(AutoViewModel auto)
        {
            try
            {
                var creado = autoHelper.CrearAuto(auto);
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
                var auto = autoHelper.MostrarAuto(id);
                return View(auto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(AutoViewModel auto)
        {
            try
            {
                var editado = autoHelper.EditarAuto(auto);
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
                var auto = autoHelper.MostrarAuto(id);
                return View(auto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(AutoViewModel auto)
        {
            try
            {
                var borrado = autoHelper.BorrarAuto(auto);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
