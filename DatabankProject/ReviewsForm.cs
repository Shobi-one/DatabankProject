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
    public partial class ReviewsForm : Form
    {
        private ListBox lstReviews;
        private TextBox txtReviewDetails;
        private DatabaseHelper dbHelper;
        private string movieTitle;

        public ReviewsForm(string title)
        {
            movieTitle = title;
            dbHelper = new DatabaseHelper();
            InitializeComponent();
            LoadReviews();

            this.lstReviews = new ListBox();
            this.txtReviewDetails = new TextBox();
            this.SuspendLayout();
            // 
            // lstReviews
            // 
            this.lstReviews.FormattingEnabled = true;
            this.lstReviews.Location = new System.Drawing.Point(12, 12);
            this.lstReviews.Name = "lstReviews";
            this.lstReviews.Size = new System.Drawing.Size(260, 150);
            this.lstReviews.TabIndex = 0;
            this.lstReviews.SelectedIndexChanged += new System.EventHandler(this.lstReviews_SelectedIndexChanged);
            // 
            // txtReviewDetails
            // 
            this.txtReviewDetails.Location = new System.Drawing.Point(12, 168);
            this.txtReviewDetails.Multiline = true;
            this.txtReviewDetails.Name = "txtReviewDetails";
            this.txtReviewDetails.Size = new System.Drawing.Size(260, 80);
            this.txtReviewDetails.TabIndex = 1;
            // 
            // ReviewsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtReviewDetails);
            this.Controls.Add(this.lstReviews);
            this.Name = "ReviewsForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadReviews()
        {
            List<string> reviews = dbHelper.GetReviews(movieTitle);
            lstReviews.DataSource = reviews;
        }

        private void lstReviews_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedReview = lstReviews.SelectedItem as string;
            if (selectedReview != null)
            {
                txtReviewDetails.Text = dbHelper.GetReviewText(movieTitle, selectedReview);
            }
        }
    }
}
