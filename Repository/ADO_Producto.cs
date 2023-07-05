using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApi.Models;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{
    public class ADO_Producto
    {
        static string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
        public static List<Producto> DevolverProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, descripciones, costo, precioVenta, stock, idUsuario FROM Producto";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();
                    producto.id = Convert.ToInt32(reader["id"]);
                    producto.descripciones = (string)reader["descripciones"];
                    producto.costo = Convert.ToInt32(reader["costo"]);
                    producto.precioVenta = Convert.ToInt32(reader["precioVenta"]);
                    producto.stock = Convert.ToInt32(reader["stock"]);
                    producto.idUsuario = Convert.ToInt32(reader["idUsuario"]);

                    productos.Add(producto);
                }
                reader.Close();
            }

            return productos;
        }
    }

}