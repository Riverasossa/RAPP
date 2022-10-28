using DAL.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL.Implementations
{
    public class AlquilerDALImpl : IAlquilerDAL
    {
        rabdContext rabdContext;

        public AlquilerDALImpl()
        {
            rabdContext = new rabdContext();
        }

        public AlquilerDALImpl(rabdContext rabdContext)
        {
            this.rabdContext = rabdContext;
        }

        public bool Add(Alquiler entity)
        {
            throw new NotImplementedException();
        }

        public bool AddAlquilerEnvio(AlquilerEnvio entity)
        {
            try
            {
                string SQL = "[dbo].[SP_Agregar_Alquiler_Envio_Facturacion] @IDUsuario, @AlquilerEnvioXML";
                var param = new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName="@IDUsuario",
                            SqlDbType = System.Data.SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value= entity.alquiler.IdUsuario
                        },
                        new SqlParameter("@AlquilerEnvioXML", SqlDbType.Xml)
                        {
                             Value = new SqlXml(new XmlTextReader(CrearXMLAlquier(entity).InnerXml,XmlNodeType.Document, null))
                        }

                };
                rabdContext.Database.ExecuteSqlRaw(SQL, param);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void AddRange(IEnumerable<Alquiler> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Alquiler> Find(Expression<Func<Alquiler, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Alquiler Get(int id)
        {
            try
            {
                Alquiler alquiler;
                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquiler = unidad.genericoDAL.Get(id);
                }

                return alquiler;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Alquiler> Get()
        {
            try
            {
                IEnumerable<Alquiler> alquileres;

                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquileres = unidad.genericoDAL.GetAll();
                }
                return alquileres.ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Alquiler> GetAll()
        {
            try
            {
                IEnumerable<Alquiler> alquileres;

                using (var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext))
                {
                    alquileres = unidad.genericoDAL.GetAll();
                }

                return alquileres;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Alquiler entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext);
                unidad.genericoDAL.Remove(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void RemoveRange(IEnumerable<Alquiler> entities)
        {
            throw new NotImplementedException();
        }

        public Alquiler SingleOrDefault(Expression<Func<Alquiler, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Alquiler entity)
        {
            try
            {
                using var unidad = new UnidadDeTrabajo<Alquiler>(rabdContext);
                unidad.genericoDAL.Update(entity);
                return unidad.Complete();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private XmlDocument CrearXMLAlquier(AlquilerEnvio? model)
        {
            XmlDocument xmlDocument = new XmlDocument();
            try
            {
                using (XmlWriter writer = xmlDocument.CreateNavigator().AppendChild())
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Alquileres");
                    writer.WriteStartElement("Alquiler");
                    writer.WriteElementString("FechaAlquiler", model.alquiler.FechaAlquiler.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteElementString("FechaDevolucion", model.alquiler.FechaDevolucion.ToString("yyyy-MM-dd HH:mm:ss"));
                    writer.WriteElementString("IdAuto", model.alquiler.IdAuto.ToString());
                    writer.WriteElementString("DetalleDireccion", model.envio.DetalleDireccion.ToString());
                    writer.WriteElementString("PrecioBase", model.envio.PrecioBase.ToString());
                    writer.WriteElementString("IdConductor", model.envio.IdConductor.ToString());
                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return xmlDocument;
        }
    }
}
