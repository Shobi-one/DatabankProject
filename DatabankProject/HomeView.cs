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
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashboardView dash = new DashboardView();
            dash.Show();
        }

        private void PopulateMovieList(List<string> movies)
        {
            lbMovies.Items.Clear();
            foreach (string movie in movies)
            {
                lbMovies.Items.Add(movie);
            }
        }

        private void HomeView_Load(object sender, EventArgs e)
        {
            lbMovies.Items.AddRange(dbHelper.GetMovies().Distinct().ToArray());
            lbMovies.DoubleClick += LbMovies_DoubleClick;
            Controls.Add(lbMovies);
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
            if (type == "Movie")
            {
                Dictionary<string, string> details = dbHelper.GetMovieDetails(name);
                if (details.ContainsKey("IsInactive") && details["IsInactive"] == "1")
                {
                    MessageBox.Show("This movie is inactive and cannot be viewed.");
                    return;
                }
            }
            Details detailsView = new Details(type, name);
            detailsView.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            List<string> filteredMovies = dbHelper.SearchMoviesByName(searchQuery);
            PopulateMovieList(filteredMovies);
        }
    }
}
