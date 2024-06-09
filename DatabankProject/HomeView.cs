using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace DatabankProject
{
    public partial class HomeView : Form
    {
        private DatabaseHelper dbHelper;
        private Panel detailsPanel;
        private Button orderButton;
        private Button reviewButton;

        public HomeView()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            UpdateUI();

            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
            detailsPanel = new Panel();
            detailsPanel.Location = new System.Drawing.Point(250, 0);
            detailsPanel.Size = new System.Drawing.Size(400, 300);
            detailsPanel.AutoScroll = true;
            this.Controls.Add(detailsPanel);

            // Initialize order button
            orderButton = new Button();
            orderButton.Text = "Order";
            orderButton.ForeColor = Color.White;
            orderButton.Location = new Point(250, 330);
            orderButton.Click += OrderButton_Click;
            this.Controls.Add(orderButton);

            // Initialize review button
            reviewButton = new Button();
            reviewButton.Text = "Write Review";
            reviewButton.ForeColor = Color.White;
            reviewButton.Location = new Point(350, 330);
            reviewButton.Click += ReviewButton_Click;
            this.Controls.Add(reviewButton);

            orderButton.Visible = false;
            reviewButton.Visible = false;
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            if (lbMovies.SelectedItem != null)
            {
                string selectedMovie = lbMovies.SelectedItem.ToString();
                Dictionary<string, string> details = dbHelper.GetMovieDetails(selectedMovie);
                if (details.ContainsKey("IsInactive") && details["IsInactive"] == "1")
                {
                    MessageBox.Show("This movie is inactive and cannot be ordered.");
                    return;
                }
                if (dbHelper.IsMovieAvailable(selectedMovie))
                {
                    if (dbHelper.CreateOrder(selectedMovie))
                    {
                        // Prompt the user for their email address
                        string email = PromptForEmail();
                        if (!string.IsNullOrEmpty(email))
                        {
                            SendOrderConfirmationEmail(email, selectedMovie);
                        }
                        MessageBox.Show($"Ordered movie: {selectedMovie}");
                    }
                    else
                    {
                        MessageBox.Show("Failed to create order. Check logs for details.");
                    }
                }
                else
                {
                    MessageBox.Show("Movie is out of stock.");
                }
            }
        }

        private string PromptForEmail()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 400;
                prompt.Height = 200;
                prompt.Text = "Enter your email address";

                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Email:" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 300 };
                Button confirmation = new Button() { Text = "Ok", Left = 150, Width = 100, Top = 100, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
            }
        }

        private void SendOrderConfirmationEmail(string toEmail, string movieTitle)
        {
            try
            {
                var fromAddress = new MailAddress("obiverheyen@gmail.com", "obiverheyen@gmail.com");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "lyhm wfhj romr rkgd";
                const string subject = "Order Confirmation";
                string body = $"Thank you for your order. You have successfully ordered the movie: {movieTitle}.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                MessageBox.Show("Order confirmation email sent successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send order confirmation email: {ex.Message}");
            }
        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            // Handle review button click event
            if (lbMovies.SelectedItem != null)
            {
                string selectedMovie = lbMovies.SelectedItem.ToString();
                // Open write review form
                using (WriteReviewForm reviewForm = new WriteReviewForm(selectedMovie))
                {
                    reviewForm.ShowDialog();
                }
            }
        }


        private void UpdateUI()
        {
           
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
            this.Click += HomeView_Click;
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
                DisplayMovieDetails(details);
                orderButton.Visible = true;
                reviewButton.Visible = true;
            }
        }

        private void DisplayMovieDetails(Dictionary<string, string> details)
        {
            detailsPanel.Controls.Clear();
            int y = 0;
            foreach (var detail in details)
            {
                Label label = new Label();
                label.Text = $"{detail.Key}: {detail.Value}";
                label.AutoSize = true;
                label.ForeColor = Color.White;
                label.Location = new System.Drawing.Point(5, y);
                detailsPanel.Controls.Add(label);
                y += 20;
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void HomeView_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = "🔎︎ Search";
            }
        }
    }
}
