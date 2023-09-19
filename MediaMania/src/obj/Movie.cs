using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.obj
{
    public class Movie : Media
    {
        public Movie(string title, string director, Genre genre) : base(title, director, genre)
        {
        }

        public Movie(string title, string director, List<Genre> genres) : base(title, director, genres)
        {
        }

        public string GetDirector()
        {
            return GetArtist();
        }

    }
}
