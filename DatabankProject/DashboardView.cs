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
            Load += DashboardView_Load;
        }

        private void DashboardView_Load(object sender, EventArgs e)
        {
            // Load data from the database
            lbMovies.Items.AddRange(dbHelper.GetMovies().ToArray());
            lbUsers.Items.AddRange(dbHelper.GetUsers().ToArray());

            // Event Handler
            lbMovies.DoubleClick += LbMovies_DoubleClick;
            lbUsers.DoubleClick += LbUsers_DoubleClick;

            // Add ListBoxes
            Controls.Add(lbMovies);
            Controls.Add(lbUsers);
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
            DetailsView detailsView = new DetailsView(type, name);
            detailsView.ShowDialog();
        }
    }
}
