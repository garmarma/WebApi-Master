using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApi.Models;
using System.Linq;
using System.Web;

namespace WebApi.Repository
{
    public class ADO_Venta
    {
        static string connectionString = @"Server=MAIA\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";

        public static List<Venta> DevolverVentas()
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id, comentarios FROM Venta";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Venta venta = new Venta();
                    venta.id = Convert.ToInt32(reader["id"]);
                    venta.comentarios = (string)reader["comentarios"];

                    ventas.Add(venta);
                }
                reader.Close();
            }

            return ventas;


        }
    }
}