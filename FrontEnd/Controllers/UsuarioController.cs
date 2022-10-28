using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly UsuarioHelper usuarioHelper = new();
        private readonly RolHelper rolHelper = new();
        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var usuarios = usuarioHelper.MostrarUsuarios();
                return View(usuarios);
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
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
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
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                var creado = usuarioHelper.CrearUsuario(usuario);
                return RedirectToAction("Index", "Home");
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
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                var editado = usuarioHelper.EditarUsuario(usuario);
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
                var usuario = usuarioHelper.MostrarUsuario(id);
                usuario.rols = rolHelper.MostrarRoles();
                return View(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                var borrar = usuarioHelper.BorrarUsuario(usuario);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Login() 
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
        public ActionResult Login(UsuarioViewModel usuario)
        {
            try
            {
                var login = usuarioHelper.Login(usuario);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult ChangePassword()
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
        public ActionResult ChangePassword(UsuarioViewModel usuario)
        {
            try
            {
                var changed = usuarioHelper.ChangedPassword(usuario);
                return RedirectToAction("Login");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
