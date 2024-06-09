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
    public partial class WriteReviewForm : Form
    {
        private string movieTitle;
        private DatabaseHelper dbHelper;

        public WriteReviewForm(string title)
        {
            InitializeComponent();
            movieTitle = title;
            dbHelper = new DatabaseHelper();

            this.Text = "Write a Review";
            Label lblReview = new Label() { Left = 10, Top = 20, Text = "Review:" };
            TextBox txtReview = new TextBox() { Left = 10, Top = 50, Width = 300, Height = 100, Multiline = true };
            Button btnSubmit = new Button() { Text = "Submit", Left = 110, Width = 100, Top = 160 };

            btnSubmit.Click += (sender, e) => { SubmitReview(txtReview.Text); };

            this.Controls.Add(lblReview);
            this.Controls.Add(txtReview);
            this.Controls.Add(btnSubmit);
            this.ClientSize = new System.Drawing.Size(350, 200);
        }

        private void SubmitReview(string reviewText)
        {
            if (string.IsNullOrWhiteSpace(reviewText))
            {
                MessageBox.Show("Review cannot be empty.");
                return;
            }

            if (dbHelper.AddReview(movieTitle, reviewText))
            {
                MessageBox.Show("Review submitted successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to submit review.");
            }
        }

        private void WriteReviewForm_Load(object sender, EventArgs e)
        {

        }
    }
}
