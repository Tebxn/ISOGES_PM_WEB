using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace project_management_for_ISOGES.Models
{
    public class ProyectoModel
    {
        public int CrearProyecto(ProyectoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CrearProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public List<ProyectoEnt> ConsultarProyectos()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarProyectos";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ProyectoEnt>>().Result;
                }

                return new List<ProyectoEnt>();
            }
        }

        public List<ClienteEnt> ConsultarClientes()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarClientes";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ClienteEnt>>().Result;
                }

                return new List<ClienteEnt>();
            }
        }

        public List<Estado_ProyectoEnt> ConsultarEstadosProyecto()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarEstadosProyecto";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<Estado_ProyectoEnt>>().Result;
                }

                return new List<Estado_ProyectoEnt>();
            }
        }

        public ProyectoEnt ConsultarProyectoPorId(long q)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarProyectoPorId?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<ProyectoEnt>().Result;
                }

                return null;
            }
        }

        public int EditarProyecto(ProyectoEnt entidad)
        {
            using (var proyecto = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/EditarProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = proyecto.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public int InactivarProyecto(ProyectoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/InactivarProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }






    }
}