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
    public partial class AddUserView : Form
    {
        private DatabaseHelper dbHelper;

        public AddUserView()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            this.Text = "Add User";
            this.ClientSize = new System.Drawing.Size(300, 900);

            var lblUsername = new Label { Text = "Username:", Left = 0, Top = 20 };
            var txtUsername = new TextBox { Left = 100, Top = 20, Width = 150 };

            var lblPassword = new Label { Text = "Password:", Left = 0, Top = 60 };
            var txtPassword = new TextBox { Left = 100, Top = 60, Width = 150 };

            var lblEmail = new Label { Text = "Email:", Left = 0, Top = 100 };
            var txtEmail = new TextBox { Left = 100, Top = 100, Width = 150 };

            var lblFirstName = new Label { Text = "First Name:", Left = 0, Top = 140 };
            var txtFirstName = new TextBox { Left = 100, Top = 140, Width = 150 };

            var lblLastName = new Label { Text = "Last Name:", Left = 0, Top = 180 };
            var txtLastName = new TextBox { Left = 100, Top = 180, Width = 150 };

            var chkIsAdmin = new CheckBox { Text = "Is Admin", Left = 100, Top = 220 };

            var btnAdd = new Button { Text = "Add", Left = 100, Top = 260, Width = 80 };
            btnAdd.Click += (sender, e) =>
            {
                // Code to add the user to the database
                dbHelper.AddUser(txtUsername.Text, txtPassword.Text, txtEmail.Text, txtFirstName.Text, txtLastName.Text, chkIsAdmin.Checked);
                MessageBox.Show($"User {txtUsername.Text} added");
                this.Close();
            };

            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(chkIsAdmin);
            this.Controls.Add(btnAdd);
        }
    }
}
