﻿using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class AutoHelper
    {
        public List<AutoViewModel> MostrarAutos()
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Auto/MostrarAutos");
                response.EnsureSuccessStatusCode();
                var content = response.Content.ReadAsStringAsync().Result;
                List<AutoViewModel> Autos = JsonConvert.DeserializeObject<List<AutoViewModel>>(content);

                return Autos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AutoViewModel MostrarAuto(int id)
        {
            try
            {
                ServiceRepository serviceObj = new();
                HttpResponseMessage response = serviceObj.GetResponse("api/Auto/MostrarAuto?id=" + id);
                response.EnsureSuccessStatusCode();
                AutoViewModel AutoViewModel = response.Content.ReadAsAsync<AutoViewModel>().Result;
                return AutoViewModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool CrearAuto(AutoViewModel auto)
        {
            try
            {
                ServiceRepository serviceObj = new();
                HttpResponseMessage response = serviceObj.PostResponse("api/Auto/InsertarAuto", auto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditarAuto(AutoViewModel auto)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Auto/MostrarAuto?id=" + auto);
                response.EnsureSuccessStatusCode();
                AutoViewModel AutoViewModel = response.Content.ReadAsAsync<AutoViewModel>().Result;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool BorrarAuto(AutoViewModel auto)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Auto/EliminarAuto?id=" + auto.IdAuto);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
