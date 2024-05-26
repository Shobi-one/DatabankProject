using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabankProject
{
    public partial class Details : Form
    {
        private Label lblDetails;
        private Button btnOrder;
        private DatabaseHelper dbHelper;
        private string itemType;
        private string itemName;

        public Details(string type, string name)
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
    }
}
