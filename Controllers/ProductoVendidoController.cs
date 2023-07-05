using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class ProductoVendidoController : Controller
    {
        [HttpGet]

        public List<ProductoVendido> GetProductosVendidos()
        {

            return ADO_ProductoVendido.DevolverProductosVendidos();
        }

    }
}