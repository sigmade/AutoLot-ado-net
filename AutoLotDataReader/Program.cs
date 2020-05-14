using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Data Reader ADO.NET * ****");
            using(SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = @"Data Source=.\SQLEXPRESS; Integrated Security=true; Initial Catalog=AutoLot";
                connection.Open();

                //Create object command SQL
                string sql = "SELECT * FROM Inventory";
                SqlCommand myCommand = new SqlCommand(sql, connection);

                //Get object 
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    while (myDataReader.Read())
                    {
                        Console.WriteLine($"*- Make: {myDataReader["Make"]}, PetName: {myDataReader["PetName"]}, Color: {myDataReader["Color"]}.");
                    }
                }
            }
            Console.ReadLine();


        }
    }
}
