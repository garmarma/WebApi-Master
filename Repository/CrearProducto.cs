using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repository
{
    public class CrearProducto
    {
        public static int AgregarProducto(Producto prod)
        {
            string connectionString = "Server=localhost;Database=SistemaGestion;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                
                const string query = @"INSERT INTO Producto (Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario) 
                                   VALUES (@Id, @Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);
                                   SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                {

                    command.Parameters.AddWithValue("@Id", prod.id);
                    command.Parameters.AddWithValue("@Descripciones", prod.descripciones);
                    command.Parameters.AddWithValue("@Costo", prod.costo);
                    command.Parameters.AddWithValue("@PrecioVenta", prod.precioVenta);
                    command.Parameters.AddWithValue("@Stock", prod.stock);
                    command.Parameters.AddWithValue("@IdUsuario", prod.idUsuario);

                    // Ejecutamos la consulta SQL utilizando ExecuteScalar() que retorna el id generado para nuevo registro insertado
                    return (int)(decimal)command.ExecuteScalar();
                }
            }
        }
    }
}