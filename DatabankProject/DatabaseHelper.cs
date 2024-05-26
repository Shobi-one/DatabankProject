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
            List<string> movieTitles = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT title FROM tblmovies", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movieTitles.Add(reader.GetString(0));
                    }
                }
            }
            return movieTitles;
        }

        // Method to fetch user usernames as a list of strings
        public List<string> GetUsers()
        {
            List<string> userUsernames = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT username FROM tblusers", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userUsernames.Add(reader.GetString(0));
                    }
                }
            }
            return userUsernames;
        }

        public Dictionary<string, string> GetMovieDetails(string title)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM movies WHERE tbltitle = @title", conn);
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
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE tblusername = @username", conn);
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
        public void AddUser(string username, string email, string firstName, string lastName, bool isAdmin)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblusers (username, email, first_name, last_name, is_admin, created_at, updated_at) VALUES (@username, @Email, @FirstName, @LastName, @IsAdmin, @CreatedAt, @UpdatedAt)", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@IsAdmin", isAdmin);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddMovie(string title, string genre, string director, string synopsis, DateTime releaseDate, string language, int duration)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO tblmovies (title, genre, director, synopsis, release_date, language, duration, created_at, updated_at) VALUES (@Title, @Genre, @Director, @Synopsis, @ReleaseDate, @Language, @Duration, @CreatedAt, @UpdatedAt)", conn);
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Genre", genre);
                cmd.Parameters.AddWithValue("@Director", director);
                cmd.Parameters.AddWithValue("@Synopsis", synopsis);
                cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                cmd.Parameters.AddWithValue("@Language", language);
                cmd.Parameters.AddWithValue("@Duration", duration);
                cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
