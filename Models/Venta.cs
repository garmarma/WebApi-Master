using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Venta
    {
        public int id { get; set; }
        public string comentarios { get; set; }

        public Venta()
        {
            id = 0;
            comentarios = string.Empty;
        }
    }
}