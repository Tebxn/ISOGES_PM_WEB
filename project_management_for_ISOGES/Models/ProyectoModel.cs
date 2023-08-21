using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CrearProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarProyectos";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarClientes";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarEstadosProyecto";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarProyectoPorId?q=" + q;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
            using (var client = new HttpClient())
            {
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/EditarProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

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
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/InactivarProyecto";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public List<Requerimiento_ProyectoEnt> ConsultaRequerimientosPorProyecto(long q)
        {
            using (var client = new HttpClient())
            {
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultaRequerimientosPorProyecto?q=" + q;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<Requerimiento_ProyectoEnt>>().Result;
                }

                return null;
            }
        }

        public List<CobroEnt> ConsultaCobrosProyectoPorId(long q)
        {
            using (var client = new HttpClient())
            {
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultaCobrosProyectoPorId?q=" + q;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CobroEnt>>().Result;
                }

                return null;
            }
        }
    }
}