using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;

namespace project_management_for_ISOGES.Models
{
        public class ChartModel
        {
            public List<ChartAnualIngresoEnt> CargarChartAnualIngreso()
            {
                using (var client = new HttpClient())
                {
                    string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CargarChartAnualIngreso";
                    HttpResponseMessage resp = client.GetAsync(url).Result;

                    if (resp.IsSuccessStatusCode)
                    {
                        return resp.Content.ReadFromJsonAsync<List<ChartAnualIngresoEnt>>().Result;
                    }
                    return new List<ChartAnualIngresoEnt>();
                }
            }
        }
}