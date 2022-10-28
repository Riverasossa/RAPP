using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class FacturacionDALImpl : IFacturacionDAL
    {
        rabdContext rabdContext;

        public FacturacionDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public FacturacionDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Facturacion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Facturacion> Find(Expression<Func<Facturacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Facturacion Get(int id)
        {
            try
            {
                Facturacion facturacion;
                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturacion = unidad.genericoDAL.Get(id);
                }

                return facturacion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Facturacion> Get()
        {
            try
            {
                IEnumerable<Facturacion> facturaciones;

                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturaciones = unidad.genericoDAL.GetAll();
                }
                return facturaciones.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Facturacion> GetAll()
        {
            try
            {
                IEnumerable<Facturacion> facturaciones;

                using (var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext))
                {
                    facturaciones = unidad.genericoDAL.GetAll();
                }

                return facturaciones;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Facturacion> entities)
        {
            throw new NotImplementedException();
        }

        public Facturacion SingleOrDefault(Expression<Func<Facturacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Facturacion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Facturacion>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
