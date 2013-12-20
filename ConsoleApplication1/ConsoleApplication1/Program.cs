using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using Npgsql;

namespace ConsoleApplication1
{


    class MySQLParser
    {
        public void Execute()
        {
            string connectionString = "DSN=PostgreSQL;Server=localhost;" +
               "Port=5432;Database=dsourcesbase;" +
               "Uid=dsourcesclient;Pwd=dsourcesclient";

            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.Password = "dsourcesclient";
            builder.UserName="dsourcesclient";
            builder.Port = 5432;
            builder.Database = "dsourcesbase";
            builder.Host = "localhost";

            
            string sql = "select * from sampledata";
            NpgsqlConnection con = null;
            NpgsqlDataReader reader = null;
            try
            {
                con = new NpgsqlConnection(builder.ConnectionString);
                con.Open();
                // Execute the query
                NpgsqlCommand cmd = new NpgsqlCommand(sql, con);
                reader = cmd.ExecuteReader();
                int Columns = reader.FieldCount;
                for (int i = 0; i < Columns; ++i)
                {
                    Console.WriteLine(reader.GetName(i));
                }
                
                while (reader.Read())
                {
                    for (int i = 0; i < Columns; ++i)
                    {
                        Console.Write(Convert.ToString(reader.GetValue(i)) +" ? ");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con != null)
                {
                    con.Close();
                }
            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new MySQLParser().Execute();
            Console.ReadKey();
        }
    }
}
