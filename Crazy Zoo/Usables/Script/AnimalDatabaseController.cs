using Crazy_Zoo.Classes;
using Crazy_Zoo.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Media.Animation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Crazy_Zoo.Usables.Script
{
    internal class AnimalDatabaseController : IAnimalDatabaseController
    {
        private string connStr = @"Server=(localdb)\MSSQLLocalDB;Database=CrazyDb;Trusted_Connection=True;";

        public AnimalDatabaseController() 
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            //Id ,Name, Age, Specie, Introduction, Voice, Origin, Enclosure
            string table = @"IF OBJECT_ID('Animals') IS NULL
                CREATE TABLE Animals(
                Name VARCHAR(50) PRIMARY KEY,
                Age INT,
                Specie VARCHAR(50),
                Introduction VARCHAR(100),
                Voice VARCHAR(100),
                Origin VARCHAR(50),
                Enclosure VARCHAR(50)
                )";
            new SqlCommand(table, conn).ExecuteNonQuery();

            table = @"IF OBJECT_ID('Enclosures') IS NULL
                CREATE TABLE Enclosures(
                Name VARCHAR(50) PRIMARY KEY
                )";
            new SqlCommand(table, conn).ExecuteNonQuery();
            conn.Close();
        }

        public void RemoveAnimalInfo(string name)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string insert = "DELETE FROM Animals WHERE Name=@n";
            using var cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@n", name);
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

        //????????
        public bool IsUniqueAnimal(BaseAnimal animal)
        {
            var unique = animal.GetUnique();
            using var conn = new SqlConnection(connStr);
            conn.Open();

            using var adapter = new SqlDataAdapter("SELECT Name FROM Animals", conn);
            var table = new DataTable();
            adapter.Fill(table);
            conn.Close();

            List<string> items = new List<string>();
            foreach (DataRow item in table.Rows) { items.Add((string)item["Name"]); }

            return !items.Contains(animal.GetUnique());
        }

        public void AddAnimalInfo<T>(T animal, Enclosure<T> enclosure = null) where T : BaseAnimal
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            if (IsUniqueAnimal(animal) == false) { return; }
            string insert = "INSERT INTO Animals (Name, Age, Specie, Introduction, Voice, Origin, Enclosure) VALUES (@n, @a, @s, @in, @v, @o, @e)";
            using var cmd = new SqlCommand(insert, conn);

            cmd.Parameters.AddWithValue("@n", animal.GetName());

            cmd.Parameters.AddWithValue("@a", animal.GetAge());
            cmd.Parameters.AddWithValue("@s", animal.GetSpecies());
            cmd.Parameters.AddWithValue("@in", animal.GetIntroduction());
            cmd.Parameters.AddWithValue("@v", animal.GetVoice());
            cmd.Parameters.AddWithValue("@o", animal.GetOrigin());

            if (enclosure != null) { cmd.Parameters.AddWithValue("@e", enclosure.GetName()); }
            else { cmd.Parameters.AddWithValue("@e", null); }

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataTable GetAnimalData()
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();


            using var adapter = new SqlDataAdapter("SELECT * FROM Animals", conn);
            var table = new DataTable();
            adapter.Fill(table);

            conn.Close();

            return table;
        }



        public DataTable GetEnclosureData()
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();


            using var adapter = new SqlDataAdapter("SELECT * FROM Enclosures", conn);
            var table = new DataTable();
            adapter.Fill(table);

            conn.Close();

            return table;
        }

        public bool IsUniqueEnclosure<T>(Enclosure<T> enclosure) where T : BaseAnimal
        {
            var unique = enclosure.GetName();
            using var conn = new SqlConnection(connStr);
            conn.Open();

            using var adapter = new SqlDataAdapter("SELECT Name FROM Enclosures", conn);
            var table = new DataTable();
            adapter.Fill(table);

            conn.Close();

            List<string> items = new List<string>();
            foreach (DataRow item in table.Rows) { items.Add((string)item["Name"]); }

            return !items.Contains(enclosure.GetName());
        }

        public void AddEnclosureInfo<T>(Enclosure<T> enclosure = null) where T : BaseAnimal
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            if (IsUniqueEnclosure(enclosure) == false) { return; }
            string insert = "INSERT INTO Enclosures (Name) VALUES (@n)";
            using var cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@n", enclosure.GetName());
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public void RemoveEnclosureInfo(string name)
        {
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string insert = "DELETE FROM Enclosures WHERE Name=@n";
            using var cmd = new SqlCommand(insert, conn);
            cmd.Parameters.AddWithValue("@n", name);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
