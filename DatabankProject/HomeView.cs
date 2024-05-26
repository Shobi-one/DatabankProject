using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabankProject
{
    public partial class HomeView : Form
    {
        private DatabaseHelper dbHelper;

        public HomeView()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void LoadData()
        {
            List<string> movies = dbHelper.GetMovies();
            PopulateMovieList(movies);
        }

        private void LbMovies_DoubleClick(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null)
            {
                string selectedMovie = lbMovies.SelectedItem.ToString();
                ShowDetails("Movie", selectedMovie);
            }
        }

        private void ShowDetails(string type, string name)
        {
            Details detailsView = new Details(type, name);
            detailsView.ShowDialog();
        }

        private void PopulateMovieList(List<string> movies)
        {
            lbMovies.Items.Clear();
            HashSet<string> uniqueMovies = new HashSet<string>(movies);
            foreach (string movie in uniqueMovies)
            {
                lbMovies.Items.Add(movie);
            }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashboardView dash = new DashboardView();
            dash.Show();
        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            lbMovies.Items.AddRange(dbHelper.GetMovies().Distinct().ToArray());
            lbMovies.DoubleClick += LbMovies_DoubleClick;
            Controls.Add(lbMovies);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            List<string> filteredMovies = dbHelper.SearchMoviesByName(searchQuery);
            PopulateMovieList(filteredMovies);
        }
    }
}
