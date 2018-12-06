using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Yelp;

namespace Yelp.Models
{
    public class Cuisine
    {
        private int _id;
        private string _name;

        public Cuisine (string name)
        {
          _name = name;  
        }

         public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }
        public int GetId()
        {
            return _id;
        }

         public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO cuisine (name) VALUES (@CuisineName);";

            cmd.Parameters.AddWithValue("@CuisineName", this._name);

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

         public static List<Cuisine> GetAll()
        {
            List<Cuisine> allCuisines = new List<Cuisine>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int cuisineId = rdr.GetInt32(0);
                string cuisineName = rdr.GetString(1);
                
                Cuisine newCuisine = new Cuisine(cuisineName);
                newCuisine.SetId(cuisineId);
                allCuisines.Add(newCuisine);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return allCuisines;
        }

          public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM cuisine;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Cuisine FindById(int cuisineId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM cuisine WHERE id='" + cuisineId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string cuisineName="";
             
            while(rdr.Read())
            {
                cuisineName = rdr.GetString(1);
            }

            Cuisine newCuisine = new Cuisine(cuisineName);
            newCuisine.SetId(cuisineId);
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return newCuisine;
        }

        public override bool Equals(System.Object otherCuisine)
        {
            if (!(otherCuisine is Cuisine))
            {
                return false;
            }
            else
            {
                Cuisine newCuisine = (Cuisine) otherCuisine;
                bool areIdsEqual = (this.GetId() == newCuisine.GetId());
                bool areDescriptionsEqual = (this.GetName() == newCuisine.GetName());
                return (areIdsEqual && areDescriptionsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

    }     
}      