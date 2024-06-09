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
    public partial class detailsView : Form
    {
        private Label lblDetails;
        private Button btnOrder;
        private Button btnWriteReview;
        private Button btnViewReviews;
        private DatabaseHelper dbHelper;
        private string itemType;
        private string itemName;

        public detailsView(string type, string name)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            itemType = type;
            itemName = name;

            Dictionary<string, string> details;
            if (type == "Movie")
            {
                details = dbHelper.GetMovieDetails(name);
            }
            else
            {
                details = dbHelper.GetUserDetails(name);
            }

            this.lblDetails = new Label();
            this.btnOrder = new Button();
            this.btnWriteReview = new Button();
            this.btnViewReviews = new Button();
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
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(16, 230);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnWriteReview
            // 
            this.btnWriteReview.Location = new System.Drawing.Point(16, 230);
            this.btnWriteReview.Name = "btnWriteReview";
            this.btnWriteReview.Size = new System.Drawing.Size(100, 23);
            this.btnWriteReview.TabIndex = 2;
            this.btnWriteReview.Text = "Write Review";
            this.btnWriteReview.UseVisualStyleBackColor = true;
            this.btnWriteReview.Click += new System.EventHandler(this.btnWriteReview_Click);
            // 
            // btnViewReviews
            // 
            this.btnViewReviews.Location = new System.Drawing.Point(16, 260);
            this.btnViewReviews.Name = "btnViewReviews";
            this.btnViewReviews.Size = new System.Drawing.Size(100, 23);
            this.btnViewReviews.TabIndex = 3;
            this.btnViewReviews.Text = "View Reviews";
            this.btnViewReviews.UseVisualStyleBackColor = true;
            this.btnViewReviews.Click += new System.EventHandler(this.btnViewReviews_Click);
            // 
            // Details
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnViewReviews);
            // 
            // Details
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lblDetails);
            this.Name = "Details";
            this.ResumeLayout(false);
            this.PerformLayout();

            DisplayDetails(details);
        }

        public void SendOrderConfirmationEmail(string toEmail, string movieTitle)
        {
            try
            {
                var fromAddress = new MailAddress("obiverheyen@gmail.com", "obiverheyen@gmail.com");
                var toAddress = new MailAddress(toEmail);
                const string fromPassword = "";
                const string subject = "Order Confirmation";
                string body = $"Thank you for your order. You have successfully ordered the movie: {movieTitle}.";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com", // Replace with your SMTP server
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

        private void btnViewReviews_Click(object sender, EventArgs e)
        {
            using (ReviewsForm reviewsForm = new ReviewsForm(itemName))
            {
                reviewsForm.ShowDialog();
            }
        }

        private void DisplayDetails(Dictionary<string, string> details)
        {
            lblDetails.Text = "";
            foreach (var detail in details)
            {
                lblDetails.Text += $"{detail.Key}: {detail.Value}\n";
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (itemType == "Movie")
            {
                Dictionary<string, string> details = dbHelper.GetMovieDetails(itemName);
                if (details.ContainsKey("IsInactive") && details["IsInactive"] == "1")
                {
                    MessageBox.Show("This movie is inactive and cannot be ordered.");
                    return;
                }
                if (dbHelper.IsMovieAvailable(itemName))
                {
                    if (dbHelper.CreateOrder(itemName))
                    {
                        // Prompt the user for their email address
                        string email = PromptForEmail();
                        if (!string.IsNullOrEmpty(email))
                        {
                            SendOrderConfirmationEmail(email, itemName);
                        }
                        MessageBox.Show($"Ordered movie: {itemName}");
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

        private void btnWriteReview_Click(object sender, EventArgs e)
        {
            using (WriteReviewForm reviewForm = new WriteReviewForm(itemName))
            {
                reviewForm.ShowDialog();
            }
        }
    }
}