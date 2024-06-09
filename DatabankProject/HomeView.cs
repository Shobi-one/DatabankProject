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
        private string loggedInUser;

        public HomeView()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            UpdateUI();

            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void UpdateUI()
        {
            if (string.IsNullOrEmpty(loggedInUser))
            {
                // User is not logged in
                lblUser.Text = "Please login!";
            }
            else
            {
                // User is logged in
                lblUser.Text = loggedInUser;
            }
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
            lblUser.Text = "Please login!";
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

        //search functionality
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "🔎︎ Search";
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                string searchQuery = txtSearch.Text;
                List<string> filteredMovies = dbHelper.SearchMoviesByName(searchQuery);
                PopulateMovieList(filteredMovies);
            }
        }

        private void Logo_Click(object sender, EventArgs e)
        {

        }
        private void pnlUser_Click(object sender, EventArgs e)
        {
            
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void lblRegister_Click(object sender, EventArgs e)
        {

        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
