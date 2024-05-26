
namespace DatabankProject
{
    partial class DashboardView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnAddMovie = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbMovies
            // 
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.Location = new System.Drawing.Point(12, 12);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(476, 381);
            this.lbMovies.TabIndex = 0;
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(521, 12);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(476, 381);
            this.lbUsers.TabIndex = 1;
            // 
            // btnAddMovie
            // 
            this.btnAddMovie.Location = new System.Drawing.Point(12, 408);
            this.btnAddMovie.Name = "btnAddMovie";
            this.btnAddMovie.Size = new System.Drawing.Size(214, 23);
            this.btnAddMovie.TabIndex = 2;
            this.btnAddMovie.Text = "Add movie";
            this.btnAddMovie.UseVisualStyleBackColor = true;
            this.btnAddMovie.Click += new System.EventHandler(this.btnAddMovie_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(12, 437);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(214, 23);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // DashboardView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 610);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnAddMovie);
            this.Controls.Add(this.lbUsers);
            this.Controls.Add(this.lbMovies);
            this.Name = "DashboardView";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Button btnAddMovie;
        private System.Windows.Forms.Button btnAddUser;
    }
}