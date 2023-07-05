using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApi.Models;
using System.Linq;
using System.Web;


namespace WebApi.Repository
{
    public class ADO_ProductoVendido
    {
        static string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static List<ProductoVendido> DevolverProductosVendidos()
        {
            List<ProductoVendido> productosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, stock, idProducto, idVenta FROM ProductoVendido";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductoVendido productoVendido = new ProductoVendido();
                    productoVendido.id = Convert.ToInt32(reader["id"]);
                    productoVendido.stock = Convert.ToInt32(reader["stock"]);
                    productoVendido.idProducto = Convert.ToInt32(reader["idProducto"]);
                    productoVendido.idVenta = Convert.ToInt32(reader["idVenta"]);

                    productosVendidos.Add(productoVendido);
                }
                reader.Close();
            }

            return productosVendidos;


        }
    }
}