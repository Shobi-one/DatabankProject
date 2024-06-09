using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabankProject
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; }
        public int Amount { get; set; }
        public bool IsInactive { get; set; }
        public string ImgPath { get; set; }
    }
}
