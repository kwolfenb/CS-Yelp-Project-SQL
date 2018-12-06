using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Yelp;

namespace Yelp.Models
{
    public class Restaurant
    {
        private int _id;
        private string _name;
        private string _address;
        private string _phone;
        private int _cuisineId;

        public Restaurant (string name)
        {
            _name = name;
        }

        public Restaurant (string name, string address, string phone, int cuisineId)
        {
            _name = name;
            _address = address;
            _phone = phone;
            _cuisineId = cuisineId;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        //Getters
        public string GetName()
        {
            return _name;
        }

        public int GetCuisineId()
        {
            return _cuisineId;
        }

        public string GetAddress()
        {
            return _address;
        }

        public string GetPhone()
        {
            return _phone;
        }



        public int GetId()
        {
            return _id;
        }

        public override bool Equals(System.Object otherRestaurant)
        {
            if (!(otherRestaurant is Restaurant))
            {
                return false;
            }
            else
            {
                Restaurant newRestaurant = (Restaurant) otherRestaurant;
                bool areIdsEqual = (this.GetId() == newRestaurant.GetId());
                bool areDescriptionsEqual = (this.GetName() == newRestaurant.GetName());
                return (areIdsEqual && areDescriptionsEqual);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static List<Restaurant> GetAll()
        {
            List<Restaurant> allRestaurants = new List<Restaurant>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurant;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int restaurantId = rdr.GetInt32(0);
                string restaurantName = rdr.GetString(1);
                string restaurantAddress = rdr.GetString(2);
                string restaurantPhone = rdr.GetString(3);
                int restaurantCuisineId = rdr.GetInt32(4);
                
                Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhone, restaurantCuisineId);
                newRestaurant.SetId(restaurantId);
                allRestaurants.Add(newRestaurant);
            }
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return allRestaurants;
        }

        public static Restaurant FindById(int restaurantId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurant WHERE id='" + restaurantId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            string restaurantName="";
            string restaurantAddress="";
            string restaurantPhone="";
            int restaurantCuisineId=0;
             
            while(rdr.Read())
            {
                restaurantName = rdr.GetString(1);
                restaurantAddress = rdr.GetString(2);
                restaurantPhone = rdr.GetString(3);
                restaurantCuisineId = rdr.GetInt32(4);
            }

            Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhone, restaurantCuisineId);
            newRestaurant.SetId(restaurantId);
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return newRestaurant;
        }
        public static void DeleteById(int restaurantId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurant WHERE id='" + restaurantId + "';";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
        }

        public static List<Restaurant> FindByCuisineId(int cuisineId)
        {
            List<Restaurant> restaurantsByCuisine = new List<Restaurant>{};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM restaurant WHERE cuisine='" + cuisineId + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            while(rdr.Read())
            {
                string restaurantName = rdr.GetString(1);
                string restaurantAddress = rdr.GetString(2);
                string restaurantPhone = rdr.GetString(3);
                int restaurantCuisineId = rdr.GetInt32(4);
                Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhone, restaurantCuisineId);
                restaurantsByCuisine.Add(newRestaurant);
            }

            conn.Close();
            if (conn != null)
            {
            conn.Dispose();
            }
            return restaurantsByCuisine;
        }

         public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurant (name, address, phone, cuisine) VALUES (@RestaurantName, @RestaurantAddress, @RestaurantPhone, @RestaurantCuisineId);";

            cmd.Parameters.AddWithValue("@RestaurantName", this._name);
            cmd.Parameters.AddWithValue("@RestaurantAddress", this._address);
            cmd.Parameters.AddWithValue("@RestaurantPhone", this._phone);
            cmd.Parameters.AddWithValue("@RestaurantCuisineId", this._cuisineId);

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM restaurant;";
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}
 