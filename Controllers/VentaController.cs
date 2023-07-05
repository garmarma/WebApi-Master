using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class VentaController : Controller
    {
        [HttpGet]

        public List<Venta> GetProductos()
        {

            return ADO_Venta.DevolverVentas();
        }

    }
}