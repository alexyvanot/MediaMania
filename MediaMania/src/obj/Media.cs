using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.obj
{
    public class Media
    {
        private string title;
        private string artist;
        private List<Genre> genres;

        public Media(string title, string artist, List<Genre> genres)
        {
            this.title = title;
            this.artist = artist;
            this.genres = genres;
        }

        public Media(string title, string artist, Genre genre) : this(title, artist, new List<Genre> { genre })
        {
        }

        public string GetTitle()
        {
            return title;
        }

        public List<Genre> GetGenres()
        {
            return genres;
        }

        public string GetArtist()
        {
            return artist;
        }

        
    }
}
