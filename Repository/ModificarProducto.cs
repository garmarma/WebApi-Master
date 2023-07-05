using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class ModificarProducto
    {
        public static bool ModificarProd(Producto prod)
        {
            string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                const string query = @"UPDATE Producto SET Id = @Id, Descripciones = @Descripciones, 
                                   Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario
                                   WHERE Id = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                {

                    command.Parameters.AddWithValue("@Id", prod.id);
                    command.Parameters.AddWithValue("@Descripciones", prod.descripciones);
                    command.Parameters.AddWithValue("@Costo", prod.costo);
                    command.Parameters.AddWithValue("@PrecioVenta", prod.precioVenta);
                    command.Parameters.AddWithValue("@Stock", prod.stock);
                    command.Parameters.AddWithValue("@IdUsuario", prod.idUsuario);
                    

                    // Ejecutamos la consulta SQL utilizando ExecuteNonQuery() que retorna la cantidad de filas afectadas por la consulta SQL
                    // En este caso, debería ser 1 si se modificó el usuario correctamente, o 0 si no se encontró el usuario con el Id correspondiente

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}