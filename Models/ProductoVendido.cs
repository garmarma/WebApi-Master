﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApi.Models
{
    public class ProductoVendido
    {
        public int id { get; set; }
        public int stock { get; set; }
        public int idProducto { get; set; }
        public int idVenta { get; set; }

        public ProductoVendido()
        {
            id = 0;
            idProducto = 0;
            stock = 0;
            idVenta = 0;
        }
    }
}