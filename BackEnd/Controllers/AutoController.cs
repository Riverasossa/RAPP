using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private IAutoDAL autoDAL;
        private readonly IWebHostEnvironment _env;

        public AutoController()
        {
            autoDAL = new AutosDALImpl(new rabdContext());
        }

        //public AutoController(IWebHostEnvironment env)
        //{
        //    _env = env;
        //}

        [HttpPost, Route("GuardarArchivo")]
        public Task<bool> UploadFile(string auto)
        {
            try
            {
                //Variable que retorna el valor del resultado del metodo
                //El valor predeterminado es Falso (false)
                bool resultado = false;

                //La variable "file" recibe el archivo en el objeto Request.Form
                //Del POST que realiza la aplicacion a este servicio.
                //Se envia un formulario completo donde uno de los valores es el archivo
                var file = Request.Form.Files[0];

                //Variable donde se coloca la ruta relativa de la carpeta de destino
                //del archivo cargado
                string NombreCarpeta = "/Files/" + auto + "/";

                //Variable donde se coloca la ruta raíz de la aplicacion
                //para esto se emplea la variable "_env" antes de declarada
                string RutaRaiz = "D:\\";

                //Se concatena las variables "RutaRaiz" y "NombreCarpeta"
                //en una otra variable "RutaCompleta"
                string RutaCompleta = RutaRaiz + NombreCarpeta;


                //Se valida con la variable "RutaCompleta" si existe dicha carpeta            
                if (!Directory.Exists(RutaCompleta))
                {
                    //En caso de no existir se crea esa carpeta
                    Directory.CreateDirectory(RutaCompleta);
                }

                //Se valida si la variable "file" tiene algun archivo
                if (file.Length > 0)
                {
                    //Se declara en esta variable el nombre del archivo cargado
                    string NombreArchivo = file.FileName;

                    //Se declara en esta variable la ruta completa con el nombre del archivo
                    string RutaFullCompleta = Path.Combine(RutaCompleta, NombreArchivo);

                    //Se crea una variable FileStream para carlo en la ruta definida
                    using var stream = new FileStream(RutaFullCompleta, FileMode.Create);
                    file.CopyTo(stream);

                    //Como se cargo correctamente el archivo
                    //la variable "resultado" llena el valor "true"
                    resultado = true;

                }

                //Se retorna la variable "resultado" como resultado de una tarea
                return Task.FromResult(resultado);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static AutoModel ConvertirAuto(Auto auto)
        {
            try
            {
                return new AutoModel
                {
                    IdAuto = auto.IdAuto,
                    Marca = auto.Marca,
                    Modelo = auto.Modelo,
                    Anno = auto.Anno,
                    Capacidad = auto.Capacidad,
                    Color = auto.Color,
                    Disponibilidad = auto.Disponibilidad,
                    IdCategoria = auto.IdCategoria,
                    InsertadoPor = auto.InsertadoPor,
                    ModificadorPor = auto.ModificadorPor,
                    Placa = auto.Placa,
                    PrecioDia = auto.PrecioDia,
                    Transmision = auto.Transmision,
                    ImgURL = auto.ImgURL
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static Auto ConvertirAutoModel(AutoModel auto)
        {
            try
            {
                return new Auto
                {
                    IdAuto = auto.IdAuto,
                    Marca = auto.Marca,
                    Modelo = auto.Modelo,
                    Anno = auto.Anno,
                    Capacidad = auto.Capacidad,
                    Color = auto.Color,
                    Disponibilidad = auto.Disponibilidad,
                    IdCategoria = auto.IdCategoria,
                    InsertadoPor = auto.InsertadoPor,
                    ModificadorPor = auto.ModificadorPor,
                    Placa = auto.Placa,
                    PrecioDia = auto.PrecioDia,
                    Transmision = auto.Transmision,
                    ImgURL = auto.ImgURL
                };
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("MostrarAutos")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Auto> listaAutos;
                listaAutos = autoDAL.GetAll();

                List<AutoModel> listaAutosModel = new();
                foreach (var item in listaAutos)
                {
                    listaAutosModel.Add(ConvertirAuto(item));
                }

                return new JsonResult(listaAutosModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarAuto")]
        public JsonResult Get(int id)
        {
            try
            {
                Auto autos;
                autos = autoDAL.Get(id);

                return new JsonResult(ConvertirAuto(autos));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("InsertarAuto")]
        public bool Post([FromBody] AutoModel auto)
        {
            try
            {
                return autoDAL.Add(ConvertirAutoModel(auto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<AutoController>/5
        [HttpPut]
        [Route("ActualizarAuto")]
        public bool Put([FromBody] AutoModel auto)
        {
            try
            {
                return autoDAL.Update(ConvertirAutoModel(auto));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("EliminarAuto")]
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Auto auto = new() { IdAuto = id };
                return autoDAL.Remove(auto);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
