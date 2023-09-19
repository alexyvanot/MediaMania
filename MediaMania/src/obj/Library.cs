using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaMania.src.exceptions;

namespace MediaMania.src.obj
{
    public class Library : ILibrary
    {
        private string name;
        private List<Media> personalMedias;
        private List<Media> sharedMedias;

        public Library(string name)
        {
            this.name = name;
            this.personalMedias = new List<Media>();
            this.sharedMedias = new List<Media>();
        }

        public void AddMedia(List<Media> medias)
        {
            foreach (Media media in medias)
            {
                foreach (Media m in this.personalMedias)
                {
                    if (m.GetTitle().Equals(media.GetTitle()))
                    {
                        throw new DuplicateException("Media already exists", media.GetTitle());
                    }
                }
            }
            this.personalMedias.AddRange(medias);
        }

        public void AddMedia(Media media)
        {
            foreach (Media m in this.personalMedias)
            {
                if (m.GetTitle().Equals(media.GetTitle()))
                {
                    throw new DuplicateException("Media already exists", media.GetTitle());
                }
            }
            this.personalMedias.Add(media);
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public int Size()
        {
            return this.personalMedias.Count;
        }

        public int CountBooks()
        {
            int count = 0;
            foreach (Media media in this.personalMedias)
            {
                if (media is Book)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountComics()
        {
            int count = 0;
            foreach (Media media in this.personalMedias)
            {
                if (media is Comic)
                {
                    count++;
                }
            }
            return count;
        }

        public int CountMovies()
        {
            int count = 0;
            foreach (Media media in this.personalMedias)
            {
                if (media is Movie)
                {
                    count++;
                }
            }
            return count;
        }

        public bool Contains(Media media)
        {
            return this.personalMedias.Contains(media);
        }

        public void RemoveMedia(Media media)
        {
            this.personalMedias.Remove(media);
        }

        public void RemoveMedia(List<Media> medias)
        {
            this.personalMedias.RemoveAll(medias.Contains);
        }

        public List<Media> FindByGenre(Genre romance)
        {
            List<Media> medias = new List<Media>();
            foreach (Media media in this.personalMedias)
            {
                if (media.GetGenres().Contains(romance))
                {
                    medias.Add(media);
                }
            }
            return medias;
        }

        public List<Media> FindByTitle(string title)
        {
            List<Media> medias = new List<Media>();
            foreach (Media media in this.personalMedias)
            {
                if (media.GetTitle().Contains(title))
                {
                    medias.Add(media);
                }
            }
            return medias;
        }

        public List<Media> GetSharedMedias()
        {
            return this.sharedMedias;
        }

        public void AddSharedMedia(Media media)
        {
            this.sharedMedias.Add(media); 
        }

        public List<Media> GetPersonalMedias()
        {
            return this.personalMedias;
        }

        internal bool IsAvailable(Media media)
        {
            if (this.personalMedias.Contains(media))
            {
                if (!this.sharedMedias.Contains(media))
                {
                    return true;
                }
            }
            else
            {
                if (this.sharedMedias.Contains(media))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
