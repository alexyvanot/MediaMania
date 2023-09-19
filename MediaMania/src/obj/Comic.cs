using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.obj
{
    public class Comic : Media
    {
        public Comic(string title, string author, Genre genre) : base(title, author, genre)
        {
        }

        public Comic(string title, string author, List<Genre> genres) : base(title, author, genres)
        {
        }
    }
}
