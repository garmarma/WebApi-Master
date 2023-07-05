using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;


namespace WebApi.Repository
{
    public class EliminarProducto
    {
        public static bool EliminarProd(int id)
        {
            string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                
                const string query = @"DELETE FROM Producto WHERE Id = @Id";
                
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                {
                    
                    command.Parameters.AddWithValue("@Id", id);

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se eliminó el producto o 0 si no se encontró el producto con el Id correspondiente
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}