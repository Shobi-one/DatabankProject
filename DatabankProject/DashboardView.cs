using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace DatabankProject
{
    public partial class DashboardView : Form
    {
        private DatabaseHelper dbHelper;

        public DashboardView()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadData();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            // Load data from the database
            lbMovies.Items.AddRange(dbHelper.GetMovies().ToArray());
            lbUsers.Items.AddRange(dbHelper.GetUsers().ToArray());

            lbMovies.DoubleClick += LbMovies_DoubleClick;
            lbUsers.DoubleClick += LbUsers_DoubleClick;

            Controls.Add(lbMovies);
            Controls.Add(lbUsers);
        }

        private void LoadData()
        {
            // Load data from the database and populate the lists
            List<string> movies = dbHelper.GetMovies();
            List<string> users = dbHelper.GetUsers();

            // Populate lists
            lbMovies.Items.Clear();
            foreach (string movie in movies)
            {
                lbMovies.Items.Add(movie);
            }

            lbUsers.Items.Clear();
            foreach (string user in users)
            {
                lbUsers.Items.Add(user);
            }
        }

        private void LbMovies_DoubleClick(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null)
            {
                string selectedMovie = lbMovies.SelectedItem.ToString();
                ShowDetails("Movie", selectedMovie);
            }
        }

        private void LbUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                string selectedUser = lbUsers.SelectedItem.ToString();
                ShowDetails("User", selectedUser);
            }
        }

        private void ShowDetails(string type, string name)
        {
            Details detailsView = new Details(type, name);
            detailsView.ShowDialog();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovieView addMovieForm = new AddMovieView();
            addMovieForm.ShowDialog();
            LoadData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserView addUserForm = new AddUserView();
            addUserForm.ShowDialog();
            LoadData();
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1) // Ensure an item is selected
            {
                string selectedMovieTitle = lbMovies.SelectedItem.ToString();
                Movie movie = dbHelper.GetMovieByTitle(selectedMovieTitle);
                if (movie != null)
                {
                    // Show the AddMovieForm with pre-filled data
                    EditMovieView EditMovieForm = new EditMovieView(movie);
                    EditMovieForm.ShowDialog();
                }
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex != -1) // Ensure an item is selected
            {
                string selectedUsername = lbUsers.SelectedItem.ToString();
                User user = dbHelper.GetUserByUsername(selectedUsername);
                if (user != null)
                {
                    // Show the AddUserForm with pre-filled data
                    EditUserView editUserForm = new EditUserView(user);
                    editUserForm.ShowDialog();
                }
            }
        }
    }
}
