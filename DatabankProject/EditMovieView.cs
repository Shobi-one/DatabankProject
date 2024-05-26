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
    public partial class EditMovieView : Form
    {
        private DatabaseHelper dbHelper;

        public EditMovieView(Movie movie)
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();

            this.Text = "Edit Movie";
            this.ClientSize = new System.Drawing.Size(300, 300);


            var lblTitle = new Label { Text = "Title:", Left = 10, Top = 20 };
            var txtTitle = new TextBox { Left = 100, Top = 20, Width = 150 };

            var lblGenre = new Label { Text = "Genre:", Left = 10, Top = 60 };
            var txtGenre = new TextBox { Left = 100, Top = 60, Width = 150 };

            var lblDirector = new Label { Text = "Director:", Left = 10, Top = 100 };
            var txtDirector = new TextBox { Left = 100, Top = 100, Width = 150 };

            var lblSynopsis = new Label { Text = "Synopsis:", Left = 10, Top = 140 };
            var txtSynopsis = new TextBox { Left = 100, Top = 140, Width = 150, Height = 60, Multiline = true };

            var lblReleaseDate = new Label { Text = "Release Date:", Left = 10, Top = 220 };
            var dtpReleaseDate = new DateTimePicker { Left = 100, Top = 220, Width = 150 };

            var lblLanguage = new Label { Text = "Language:", Left = 10, Top = 260 };
            var txtLanguage = new TextBox { Left = 100, Top = 260, Width = 150 };

            var lblAmount = new Label { Text = "Amount:", Left = 10, Top = 260 };
            var txtAmount = new TextBox { Left = 100, Top = 300, Width = 150 };

            var lblDuration = new Label { Text = "Duration:", Left = 10, Top = 300 };
            var numDuration = new NumericUpDown { Left = 100, Top = 340, Width = 150, Minimum = 1, Maximum = 600 };

            var btnAdd = new Button { Text = "Add", Left = 100, Top = 380, Width = 80 };
            btnAdd.Click += (sender, e) =>
            {
                if (txtTitle == null || txtGenre == null || txtDirector == null || txtSynopsis == null || dtpReleaseDate == null || txtLanguage == null || numDuration == null)
                {
                    MessageBox.Show("One or more controls are not properly initialized.");
                    return;
                }

                dbHelper.AddMovie(txtTitle.Text, txtGenre.Text, txtDirector.Text, txtSynopsis.Text, dtpReleaseDate.Value, txtLanguage.Text, (int)numDuration.Value, txtAmount.Text);
                MessageBox.Show($"Movie {txtTitle.Text} added");
                this.Close();
            };

            this.Controls.Add(lblTitle);
            this.Controls.Add(txtTitle);
            this.Controls.Add(lblGenre);
            this.Controls.Add(txtGenre);
            this.Controls.Add(lblDirector);
            this.Controls.Add(txtDirector);
            this.Controls.Add(lblSynopsis);
            this.Controls.Add(txtSynopsis);
            this.Controls.Add(lblReleaseDate);
            this.Controls.Add(dtpReleaseDate);
            this.Controls.Add(lblLanguage);
            this.Controls.Add(txtLanguage);
            this.Controls.Add(lblDuration);
            this.Controls.Add(numDuration);
            this.Controls.Add(btnAdd);
            this.Controls.Add(lblAmount);
            this.Controls.Add(txtAmount);

            txtTitle.Text = movie.Title;
            txtGenre.Text = movie.Genre;
            txtDirector.Text = movie.Director;
            txtSynopsis.Text = movie.Synopsis;
            dtpReleaseDate.Value = movie.ReleaseDate;
            txtLanguage.Text = movie.Language;
            numDuration.Value = movie.Duration;
            txtAmount.Text = movie.Amount.ToString();
        }
    }
}
