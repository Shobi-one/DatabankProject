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
    public partial class DetailsView : Form
    {
        private Label lblDetails;
        private DatabaseHelper dbHelper;

        public DetailsView(string type, string name)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            Dictionary<string, string> details;
            if (type == "Movie")
            {
                details = dbHelper.GetMovieDetails(name);
            }
            else
            {
                details = dbHelper.GetUserDetails(name);
            }

            this.lblDetails = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(13, 13);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(39, 13);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Details";
            // 
            // DetailsView
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblDetails);
            this.Name = "DetailsView";
            this.ResumeLayout(false);
            this.PerformLayout();

            DisplayDetails(details);
        }

        private void DisplayDetails(Dictionary<string, string> details)
        {
            lblDetails.Text = "";
            foreach (var detail in details)
            {
                lblDetails.Text += $"{detail.Key}: {detail.Value}\n";
            }
        }
    }
}
