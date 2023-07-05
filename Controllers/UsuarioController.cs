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
    public class UsuarioController : ApiController
    {
        [HttpGet]

        public List<Usuario> GetUsuarios()
        {

            return ADO_Usuario.DevolverUsuarios();
        }

        [HttpPut]

        public void Actualizar([FromBody] Usuario usuario)
        {
            ModificarUsuario.ModificarUser(usuario);
        }
    }
}