using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Models
{
    public class UtilitiesModel
    {
        public string ConseguirAnioActual()
        {
            int anio = DateTime.Now.Year;
            string anioActual = anio.ToString();
            return anioActual;
        }
    }
}