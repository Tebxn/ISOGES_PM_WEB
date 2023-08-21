﻿using project_management_for_ISOGES.Entities;
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
    public class CobroModel
    {
        public List<CobroEnt> ConsultarCobrosPorProyecto(long q)
        {
            using (var client = new HttpClient())
            {
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarCobrosPorProyecto?q=" + q;
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CobroEnt>>().Result;
                }

                return null;

            }
        }
        public List<CobroEnt> ListadoCobros()
        {
            using (var client = new HttpClient())
            {
                string token = HttpContext.Current.Session["Token"].ToString();
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ListadoCobros";
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