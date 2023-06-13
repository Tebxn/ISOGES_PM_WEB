using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_management_for_ISOGES.Entities
{
    public class UserEnt // Empleado
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Status { get; set; }
    }
}