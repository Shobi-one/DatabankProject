using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DatabankProject
{
    class DatabaseHelper
    {
        private string connectionString = "server=localhost;database=moviedatabank;userid=root;password=";

        public List<string> GetMovies()
        {
            List<string> movies = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT title FROM movies", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    movies.Add(reader.GetString("title"));
                }
            }
            return movies;
        }

        public List<string> GetUsers()
        {
            List<string> users = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT username FROM users", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(reader.GetString("username"));
                }
            }
            return users;
        }

        public Dictionary<string, string> GetMovieDetails(string title)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM movies WHERE title = @title", conn);
                cmd.Parameters.AddWithValue("@title", title);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    details["Title"] = reader.GetString("title");
                    details["Genre"] = reader.GetString("genre");
                    details["Director"] = reader.GetString("director");
                    details["Synopsis"] = reader.GetString("synopsis");
                    details["ReleaseDate"] = reader.GetDateTime("release_date").ToString("yyyy-MM-dd");
                    details["Language"] = reader.GetString("language");
                    details["Duration"] = reader.GetInt32("duration").ToString();
                }
            }
            return details;
        }

        public Dictionary<string, string> GetUserDetails(string username)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE username = @username", conn);
                cmd.Parameters.AddWithValue("@username", username);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    details["Username"] = reader.GetString("username");
                    details["Email"] = reader.GetString("email");
                    details["FirstName"] = reader.GetString("first_name");
                    details["LastName"] = reader.GetString("last_name");
                    details["CreatedAt"] = reader.GetDateTime("created_at").ToString("yyyy-MM-dd HH:mm:ss");
                    details["UpdatedAt"] = reader.GetDateTime("updated_at").ToString("yyyy-MM-dd HH:mm:ss");
                    details["IsAdmin"] = reader.GetBoolean("is_admin").ToString();
                }
            }
            return details;
        }
    }
}
