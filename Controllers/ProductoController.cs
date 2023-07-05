using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]

        public List<Producto> GetProductos()
        {

            return ADO_Producto.DevolverProductos();
        }

        [HttpPost]

        public void Crear([FromBody] Producto prod)
        {
            CrearProducto.AgregarProducto(prod);
        }

        [HttpPut]

        public void Actualizar([FromBody] Producto prod)
        {
            ModificarProducto.ModificarProd(prod);
        }

        [HttpDelete]

        public void Eliminar([FromBody] int id)
        {
            EliminarProducto.EliminarProd(id);
        }
    }
}