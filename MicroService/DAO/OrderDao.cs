using MicroService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MicroService.DAO
{
    public class OrderDao
    {

        public static Order ReadRow(SqlDataReader reader, string table = "order")
        {
            Order returnOrder = null;

            returnOrder.Id = (int)reader[$"{table}_Id"];
            returnOrder.Note = (string)reader[$"{table}_Note"];
            returnOrder.DeliveryAddress = (string)reader[$"{table}_DeliveryAddress"];
            returnOrder.DeliveryCity = (string)reader[$"{table}_DeliveryCity"];
            returnOrder.DeliveryCountry = (string)reader[$"{table}_DeliveryCountry"];
            returnOrder.DeliveryDate = (DateTime)reader[$"{table}_DeliveryDate"];
            //dodati ostalo
            return returnOrder;
        }
        public static Order GetOrder(int id)
        {
            try
            {
                Order result = null;

                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = $@" Select  * FROM  [order].[Order] where Id = @Id";
                    command.Parameters.Add("@Id", SqlDbType.Int);
                    command.Parameters["Id"].Value = id;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result = ReadRow(reader);
                        }
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
            
        }

        public static List<Order> GetOrders ()
        {
            try
            {
                List<Order> retOrder = null;
                using (SqlConnection connection = new SqlConnection(DBFunctions.ConnectionString))
                {
                    SqlCommand command = connection.CreateCommand();

                    command.CommandText = $@"SELECT * FROM [order].[Order]";
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retOrder.Add(ReadRow(reader));
                        }
                    }
                }
                return retOrder;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            return null;
        }
    }
}