using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaMania.src.obj
{
    public class User
    {
        private string name;
        private Library library;

        public User(string name, Library library)
        {
            this.name = name;
            this.library = library;
        }

        public Library GetLibrary()
        {
            return library;
        }

        public bool IsAvailable(Media media)
        {
            return library.IsAvailable(media);
        }

        public bool IsOwned(Media media)
        {
            return library.GetPersonalMedias().Contains(media);
        }

        public bool IsShared(Media media)
        {
            return library.GetSharedMedias().Contains(media);
        }

        public void Share(Media media, User user)
        {
            if (!IsAvailable(media))
            {
                throw new NotAvailableException("Media is not available");
            }
            if (!IsOwned(media))
            {
                throw new NotOwnedException("Media is not owned");
            }
            library.AddSharedMedia(media);
            user.GetLibrary().AddSharedMedia(media);
        }

    }
}
