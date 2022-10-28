using BackEnd.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturacionController : ControllerBase
    {
        private IFacturacionDAL facturacionDAL;

        public FacturacionController()
        {
            facturacionDAL = new FacturacionDALImpl(new rabdContext());
        }

        private FacturacionModel ConvertirFacturacion(Facturacion facturacion)
        {
            try
            {
                return new FacturacionModel
                {
                    FechaFactura = facturacion.FechaFactura,
                    FechaUltActu = facturacion.FechaUltActu,
                    IdAlquiler = facturacion.IdAlquiler,
                    IdEnvio = facturacion.IdEnvio,
                    IdFactura = facturacion.IdFactura,
                    MontoAlquiler = facturacion.MontoAlquiler,
                    MontoMulta = facturacion.MontoMulta,
                    PrimerPago = facturacion.PrimerPago,
                    SegundoPago = facturacion.SegundoPago,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarFacturaciones")]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Facturacion> listaFacturacion;
                listaFacturacion = facturacionDAL.GetAll();

                List<FacturacionModel> listaFacturacionModel = new();
                foreach (var item in listaFacturacion)
                {
                    listaFacturacionModel.Add(ConvertirFacturacion(item));
                }

                return new JsonResult(listaFacturacionModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("MostrarFacturacion")]
        public JsonResult Get(int id)
        {
            try
            {
                Facturacion facturacion;
                facturacion = facturacionDAL.Get(id);

                return new JsonResult(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public bool Post([FromBody] Facturacion facturacion)
        {
            try
            {
                return facturacionDAL.Add(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<FacturacionController>/5
        [HttpPut]
        public bool Put([FromBody] Facturacion facturacion)
        {
            try
            {
                return facturacionDAL.Update(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                Facturacion facturacion = new Facturacion { IdFactura = id };
                return facturacionDAL.Remove(facturacion);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
