using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApi.Models;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{
    public class ADO_Usuario
    {
        static string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static List<Usuario> DevolverUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, nombre, apellido, nombreUsuario, contrasena, mail FROM Usuario";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.id = Convert.ToInt32(reader["id"]);
                    usuario.nombre = (string)reader["nombre"];
                    usuario.apellido = (string)reader["apellido"];
                    usuario.nombreUsuario = (string)reader["nombreUsuario"];
                    usuario.contrasena = (string)reader["contrasena"];
                    usuario.mail = (string)reader["mail"];

                    usuarios.Add(usuario);
                }
                reader.Close();
            }

            return usuarios;
        }
    }

}