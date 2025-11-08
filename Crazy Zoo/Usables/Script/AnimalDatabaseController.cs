using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Crazy_Zoo.Usables.Script
{
    internal class AnimalDatabaseController : IAnimalDatabaseController
    {
        private string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=SchoolDB;Trusted_Connection=True;";

        public AnimalDatabaseController() 
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string table = @"IF OBJECT_ID('Animals') IS NULL
                CREATE TABLE Animals(
                Id INT,
                Name VARCHAR(50),
                Enclosure VARCHAR(50)
                )";
            new SqlCommand(table, conn).ExecuteNonQuery();

            conn.Close();
        }

        public void RemoveAnimalInfo(int index)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string insert = "DELETE FROM Animals WHERE Id=@i";
            using var cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@i", index);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void ExecuteCommand(string command)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            using var cmd = new SqlCommand(command, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void AddAnimalInfo<T>(T animal, Enclosure<T> enclosure = null) where T : BaseAnimal
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string insert = "INSERT INTO Animals (Id ,Name, Enclosure) VALUES (@i ,@n, @e)";
            using var cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@i", animal.GetUnique());
            cmd.Parameters.AddWithValue("@n", animal.GetName());
            if (enclosure != null) { cmd.Parameters.AddWithValue("@e", enclosure.GetName()); }
            else { cmd.Parameters.AddWithValue("@e", null); }
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataTable GetData()
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();


            using var adapter = new SqlDataAdapter("SELECT * FROM Animals", conn);
            var table = new DataTable();
            adapter.Fill(table);

            return table;
        }
    }
}
