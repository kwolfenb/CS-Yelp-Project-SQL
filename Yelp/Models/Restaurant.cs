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
        private string _cuisine;

        public Restaurant (string name)
        {
            _name = name;
        }

        public Restaurant (string name, string address, string phone, string cuisine)
        {
            _name = name;
            _address = address;
            _phone = phone;
            _cuisine = cuisine;
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
                string restaurantCuisine = rdr.GetString(4);
                
                Restaurant newRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhone, restaurantCuisine);
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

         public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO restaurant (name, address, phone, cuisine) VALUES (@RestaurantName, @RestaurantAddress, @RestaurantPhone, @RestaurantCuisine);";

            cmd.Parameters.AddWithValue("@RestaurantName", this._name);
            cmd.Parameters.AddWithValue("@RestaurantAddress", this._address);
            cmd.Parameters.AddWithValue("@RestaurantPhone", this._phone);
            cmd.Parameters.AddWithValue("@RestaurantCuisine", this._cuisine);

            cmd.ExecuteNonQuery();   
            _id = (int) cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static void DeleteAll()
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
