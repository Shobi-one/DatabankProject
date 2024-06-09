
namespace DatabankProject
{
    partial class HomeView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblUser = new System.Windows.Forms.Label();
            this.pbUser = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lbMovies = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.pnlUser);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.pbLogo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 55);
            this.panel1.TabIndex = 0;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.lblUser);
            this.pnlUser.Controls.Add(this.pbUser);
            this.pnlUser.Location = new System.Drawing.Point(854, 3);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(112, 48);
            this.pnlUser.TabIndex = 2;
            this.pnlUser.Click += new System.EventHandler(this.pnlUser_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.ForeColor = System.Drawing.Color.White;
            this.lblUser.Location = new System.Drawing.Point(36, 17);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(67, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Sample User";
            // 
            // pbUser
            // 
            this.pbUser.BackColor = System.Drawing.Color.Transparent;
            this.pbUser.Image = global::DatabankProject.Properties.Resources.userico;
            this.pbUser.Location = new System.Drawing.Point(3, 7);
            this.pbUser.Name = "pbUser";
            this.pbUser.Size = new System.Drawing.Size(32, 32);
            this.pbUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUser.TabIndex = 2;
            this.pbUser.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.BackColor = System.Drawing.Color.Black;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(707, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(141, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TabStop = false;
            this.txtSearch.Text = "🔎︎ Search";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Image = global::DatabankProject.Properties.Resources.img;
            this.pbLogo.Location = new System.Drawing.Point(8, 7);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(120, 38);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;
            this.pbLogo.Click += new System.EventHandler(this.Logo_Click);
            // 
            // lbMovies
            // 
            this.lbMovies.FormattingEnabled = true;
            this.lbMovies.Location = new System.Drawing.Point(8, 61);
            this.lbMovies.Name = "lbMovies";
            this.lbMovies.Size = new System.Drawing.Size(120, 95);
            this.lbMovies.TabIndex = 1;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(978, 508);
            this.Controls.Add(this.lbMovies);
            this.Controls.Add(this.panel1);
            this.Name = "HomeView";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lbMovies;
        private System.Windows.Forms.PictureBox pbUser;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUser;
    }
}

