using System;
using System.Collections.Generic;
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
            RefreshLists();
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            RefreshLists();

            lbMovies.DoubleClick += LbMovies_DoubleClick;
            lbUsers.DoubleClick += LbUsers_DoubleClick;

            Controls.Add(lbMovies);
            Controls.Add(lbUsers);
        }

        private void LoadData()
        {
            // This method is no longer necessary as RefreshLists is used instead.
        }

        private void RefreshLists()
        {
            // Load data from the database and populate the lists
            List<string> movies = dbHelper.GetMovies();
            List<string> users = dbHelper.GetUsers();

            lbMovies.Items.Clear();
            lbMovies.Items.AddRange(movies.ToArray());

            lbUsers.Items.Clear();
            lbUsers.Items.AddRange(users.ToArray());
        }

        private void LbMovies_DoubleClick(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null)
            {
                string selectedMovie = lbMovies.SelectedItem.ToString();
                ShowDetails("Movie", selectedMovie);
                RefreshLists();
            }
        }

        private void LbUsers_DoubleClick(object sender, EventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                string selectedUser = lbUsers.SelectedItem.ToString();
                ShowDetails("User", selectedUser);
                RefreshLists();
            }
        }

        private void ShowDetails(string type, string name)
        {
            detailsView detailsView = new detailsView(type, name);
            detailsView.ShowDialog();
            RefreshLists();
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            AddMovieView addMovieForm = new AddMovieView();
            addMovieForm.ShowDialog();
            RefreshLists();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserView addUserForm = new AddUserView();
            addUserForm.ShowDialog();
            RefreshLists();
        }

        private void lbMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMovies.SelectedIndex != -1)
            {
                string selectedMovieTitle = lbMovies.SelectedItem.ToString();
                Movie movie = dbHelper.GetMovieByTitle(selectedMovieTitle);
                if (movie != null)
                {
                    EditMovieView EditMovieForm = new EditMovieView(movie);
                    EditMovieForm.ShowDialog();
                    RefreshLists();
                }
            }
        }

        private void lbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbUsers.SelectedIndex != -1)
            {
                string selectedUsername = lbUsers.SelectedItem.ToString();
                User user = dbHelper.GetUserByUsername(selectedUsername);
                if (user != null)
                {
                    EditUserView editUserForm = new EditUserView(user);
                    editUserForm.ShowDialog();
                    RefreshLists();
                }
            }
        }
    }
}
