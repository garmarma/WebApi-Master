using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ModificarUsuario
    {
        public static bool ModificarUser(Usuario usuario)
        {
            string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                const string query = @"UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, 
                                   NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail 
                                   WHERE Id = @Id";
                
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                {
                    
                    command.Parameters.AddWithValue("@Nombre", usuario.nombre);
                    command.Parameters.AddWithValue("@Apellido", usuario.apellido);
                    command.Parameters.AddWithValue("@NombreUsuario", usuario.nombreUsuario);
                    command.Parameters.AddWithValue("@Contraseña", usuario.contrasena);
                    command.Parameters.AddWithValue("@Mail", usuario.mail);
                    command.Parameters.AddWithValue("@Id", usuario.id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}