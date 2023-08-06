using project_management_for_ISOGES.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        public List<string> ConseguirListaAnios()
        {
            List<string> anios = new List<string>();
            var respChartAnual = CargarChartAnualIngreso();

            foreach (var item in respChartAnual)
            {
                anios.Add(item.Anio.ToString());
            }

            //Separar anios
            List<string> aniosIndividuales = new List<string>();
            foreach (var item in anios)
            {
                if (!aniosIndividuales.Contains(item))
                {
                    aniosIndividuales.Add(item);
                }
            }
            return aniosIndividuales;
        }
        public double ConseguirTotalIngresosAnioActual()
        {
            UtilitiesModel util = new UtilitiesModel();
            var anioActual = util.ConseguirAnioActual();
            var respChartAnual = CargarChartAnualIngreso();
            var respTotalIngresosAnioActual = respChartAnual.Where(p => p.Anio.Equals(anioActual));
            double totalIngresosAnioActual = 0;
            foreach (var item in respTotalIngresosAnioActual)
            {
                totalIngresosAnioActual += item.IngresosTotales;
            }
            return totalIngresosAnioActual;
        }

        public List<double> CargarListaMontosPorAnio()
        {
            var respChartAnual = CargarChartAnualIngreso();
            var listaAnios = ConseguirListaAnios();

            //SepararMontosPorAnio
            List<double> montosPorAnio = new List<double>();
            foreach (var item in listaAnios)
            {
                var datos = respChartAnual.Where(p => p.Anio.Equals(item));
                double montoPorAnio = 0;

                foreach (var x in datos)
                {
                    montoPorAnio += x.IngresosTotales;
                }
                montosPorAnio.Add(montoPorAnio);
            }
            return montosPorAnio;
        }

        public double ConseguirIngresoHistorico()
        {
            UtilitiesModel util = new UtilitiesModel();
            string anioActual = util.ConseguirAnioActual();

            return 0;
        }

        public List<double> ListarIngresosMensuales(string anioActual)
        {
            List<double> listaDoubles = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var respChartAnual = CargarChartAnualIngreso();
            foreach (var item in respChartAnual)
            {
                switch (item.Mes)
                {
                    case "01":
                        listaDoubles[0] += item.IngresosTotales;
                        break;
                    case "02":
                        listaDoubles[1] += item.IngresosTotales;
                        break;
                    case "03":
                        listaDoubles[2] += item.IngresosTotales;
                        break;
                    case "04":
                        listaDoubles[3] += item.IngresosTotales;
                        break;
                    case "05":
                        listaDoubles[4] += item.IngresosTotales;
                        break;
                    case "06":
                        listaDoubles[5] += item.IngresosTotales;
                        break;
                    case "07":
                        listaDoubles[6] += item.IngresosTotales;
                        break;
                    case "08":
                        listaDoubles[7] += item.IngresosTotales;
                        break;
                    case "09":
                        listaDoubles[8] += item.IngresosTotales;
                        break;
                    case "10":
                        listaDoubles[9] += item.IngresosTotales;
                        break;
                    case "11":
                        listaDoubles[10] += item.IngresosTotales;
                        break;
                    case "12":
                        listaDoubles[11] += item.IngresosTotales;
                        break;
                    default:
                        break;
                }
            }
            return listaDoubles;
        }
    }
}