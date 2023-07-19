using Newtonsoft.Json;
using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using System.Web.Security;

namespace project_management_for_ISOGES.Models
{
    public class UsuarioModel
    {
        public UsuarioEnt IniciarSesion(Entities.UsuarioEnt entidad) {

            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/IniciarSesion";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
                }

                return null;
            }
        }
        public int CrearUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CrearUsuario";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public List<UsuarioEnt> ConsultarUsuarios()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarUsuarios";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
                }

                return new List<UsuarioEnt>();
            }
        }

        public int InactivarUsuario(UsuarioEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/InactivarUsuario";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public List<TipoUsuarioEnt> ConsultarTiposUsuarios()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarTiposUsuarios";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<TipoUsuarioEnt>>().Result;
                }

                return new List<TipoUsuarioEnt>();
            }
        }
    }
}