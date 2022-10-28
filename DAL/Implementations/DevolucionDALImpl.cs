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
    public class DevolucionDALImpl : IDevolucionDAL
    {
        rabdContext rabdContext;

        public DevolucionDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public DevolucionDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
                unidad.genericoDAL.Add(entity);

                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Devolucion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Devolucion> Find(Expression<Func<Devolucion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Devolucion Get(int id)
        {
            try
            {
                Devolucion devolucion;
                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devolucion = unidad.genericoDAL.Get(id);
                }

                return devolucion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Devolucion> Get()
        {
            try
            {
                IEnumerable<Devolucion> devoluciones;

                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devoluciones = unidad.genericoDAL.GetAll();
                }
                return devoluciones.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Devolucion> GetAll()
        {
            try
            {
                IEnumerable<Devolucion> devoluciones;

                using (var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext))
                {
                    devoluciones = unidad.genericoDAL.GetAll();
                }

                return devoluciones;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Devolucion> entities)
        {
            throw new NotImplementedException();
        }

        public Devolucion SingleOrDefault(Expression<Func<Devolucion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Devolucion entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Devolucion>(rabdContext);
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
