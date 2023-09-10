using System;
using Xunit;
using System.Collections.Generic;
using TestMediaMania.src.obj;

namespace TestMediaMania.src
{
    public class TestMediaMania
    {
        Library library;
        Media m0;
        Media m1;
        Media m2;
        Media m3;
        Media m4;
        Media m5;
        Media m6;
        Media m7;
        Media m8;
        Media m9;
        Media m10;

        public TestMediaMania()
        {
            library = new Library("INTECH Sharing");

            m0 = new Book("Programmer pour l'intelligence collective", "Toby Segaran", Genre.EDUCATION);
            m1 = new Book("La horde du Contrevent", "Alain Damasio", Genre.SCIENCE_FANTASY);
            m2 = new Book("Le mythe de Sisyphe", "Albert Camus", new List<Genre> { Genre.PHILOSOPHY, Genre.ESSAY });
            m3 = new Book("L'œcumène d'or", "John C. Wright", Genre.SCIENCE_FICTION);
            m4 = new Comic("Zaï Zaï Zaï Zaï", "Fabcaro", Genre.ABSURD);
            m5 = new Comic("Les damnés de la Commune", "Raphaël Meyssan", new List<Genre> { Genre.HISTORY, Genre.GRAPHIC_NOVEL });
            m6 = new Movie("Parasite", "Bong Joon-ho", new List<Genre> { Genre.THRILLER, Genre.DRAMA });
            m7 = new Movie("Le Silence des agneaux", "Jonathan Demme", Genre.THRILLER);
            m8 = new Movie("Bienvenue à Gattaca", "Andrew Niccol", new List<Genre> { Genre.SCIENCE_FICTION, Genre.DRAMA, Genre.THRILLER });
            m9 = new Movie("The Island", "Michael Bay", new List<Genre> { Genre.SCIENCE_FICTION, Genre.ACTION });
            m10 = new Movie("Harry Potter à l'école des sorciers", "Chris Columbus", Genre.FANTASY);

            library.AddMedia(new List<Media> { m0, m1, m2, m3, m4, m5, m6, m7 });
        }

        [Fact]
        public void GetName()
        {
            Assert.Equal("INTECH Sharing", library.GetName());
        }

        [Fact]
        public void SetName()
        {
            string newName = "Sharing is caring";
            library.SetName(newName);
            Assert.Equal(newName, library.GetName());
        }

        [Fact]
        public void Size()
        {
            Assert.Equal(8, library.Size());
        }

        [Fact]
        public void CountBooks()
        {
            Assert.Equal(4, library.CountBooks());
        }

        [Fact]
        public void CountComics()
        {
            Assert.Equal(2, library.CountComics());
        }

        [Fact]
        public void CountMovies()
        {
            Assert.Equal(2, library.CountMovies());
        }

        [Fact]
        public void Media()
        {
            Assert.Equal("Programmer pour l'intelligence collective", m0.GetTitle());
            List<Genre> l = m0.GetGenres();
            Assert.Single(l);
            Assert.Contains(Genre.EDUCATION, l);

            l = m8.GetGenres();
            Assert.Equal(3, l.Count);
            Assert.DoesNotContain(Genre.EDUCATION, l);
            Assert.Contains(Genre.DRAMA, l);
        }

        [Fact]
        public void Book()
        {
            Assert.Equal("Toby Segaran", ((Book)m0).GetAuthor());
        }

        [Fact]
        public void Movie()
        {
            Assert.Equal("Michael Bay", ((Movie)m9).GetDirector());
        }

        [Fact]
        public void DuplicateException()
        {
            string message = "Le titre existe déjà !";
            string title = "Example de titre";
            try
            {
                throw new DuplicateException(message, title);
            }
            catch (DuplicateException e)
            {
                Assert.IsType<Exception>(e);
                Assert.Equal(title, e.GetDuplicateTitle());
            }
        }

        [Fact]
        public void AddMedia()
        {
            Assert.Equal(8, library.Size());
            library.AddMedia(m8);
            Assert.Equal(9, library.Size());
            Assert.Equal(3, library.CountMovies());
            library.AddMedia(m9);
            Assert.Equal(10, library.Size());
            Assert.Equal(4, library.CountMovies());
        }

        [Fact]
        public void LibraryContains()
        {
            Assert.True(library.Contains(m0));
            Assert.True(library.Contains(m7));
            Assert.False(library.Contains(m8));
            Assert.False(library.Contains(m9));
            library.AddMedia(m8);
            Assert.True(library.Contains(m8));
        }

        [Fact]
        public void AddMediaDuplicate()
        {
            library.AddMedia(m8);
            Assert.Equal(9, library.Size());
            Assert.Equal(3, library.CountMovies());
            try
            {
                library.AddMedia(m8);
                Assert.True(false, "AddMedia should throw an exception when title already exists");
            }
            catch (DuplicateException e)
            {
                Assert.Equal(m8.GetTitle(), e.GetDuplicateTitle());
                Assert.Equal(9, library.Size());
                Assert.Equal(3, library.CountMovies());
            }
        }

        [Fact]
        public void AddMultipleMediaDuplicate()
        {
            try
            {
                library.AddMedia(new List<Media> { m8, m9, m7 });
                Assert.True(false, "AddMedia should throw an exception when title already exists");
            }
            catch (DuplicateException e)
            {
                Assert.Equal(m7.GetTitle(), e.GetDuplicateTitle());
                Assert.Equal(8, library.Size());
                Assert.False(library.Contains(m8));
                Assert.False(library.Contains(m9));
            }
        }

        [Fact]
        public void RemoveMedia()
        {
            Assert.Equal(8, library.Size());
            library.RemoveMedia(m1);
            Assert.Equal(7, library.Size());
            Assert.Equal(3, library.CountBooks());
            library.RemoveMedia(new List<Media> { m2, m6 });
            Assert.Equal(5, library.Size());
            Assert.Equal(2, library.CountBooks());
            Assert.Equal(1, library.CountMovies());
        }

        [Fact]
        public void FindByGenre()
        {
            List<Media> m = library.FindByGenre(Genre.ROMANCE);
            Assert.Empty(m);

            m = library.FindByGenre(Genre.SCIENCE_FICTION);
            Assert.Single(m);
            Assert.Contains(m3, m);

            library.AddMedia(new List<Media> { m8, m9 });

            m = library.FindByGenre(Genre.SCIENCE_FICTION);
            Assert.Equal(3, m.Count);
            Assert.Contains(m8, m);
            Assert.Contains(m9, m);

            library.RemoveMedia(m3);
            m = library.FindByGenre(Genre.SCIENCE_FICTION);
            Assert.Equal(2, m.Count);
            Assert.DoesNotContain(m3, m);
            Assert.Contains(m9, m);
        }

        [Fact]
        public void FindByTitle()
        {
            library.AddMedia(new List<Media> { m8, m9 });

            List<Media> m = library.FindByTitle("Pouet Pouet Camember");
            Assert.Empty(m);

            m = library.FindByTitle("Programmer pour l'intelligence collective");
            Assert.Single(m);
            Assert.Contains(m0, m);

            m = library.FindByTitle("Le ");
            Assert.Equal(2, m.Count);
            Assert.Contains(m2, m);
            Assert.Contains(m7, m);

            library.RemoveMedia(m2);
            m = library.FindByTitle("Le ");
            Assert.Single(m);
            Assert.DoesNotContain(m2, m);
            Assert.Contains(m7, m);
        }

        [Fact]
        public void UserSharing()
        {
            library.SetName("Collection Raphael");
            User raphael = new User("Raphael", library);
            User thomas = new User("Thomas", new Library("Collection Thomas"));
            thomas.GetLibrary().AddMedia(m10);

            Assert.False(raphael.IsShared(m0));
            Assert.True(raphael.IsAvailable(m0));
            Assert.True(raphael.IsOwned(m0));
            raphael.Share(m0, thomas);
            Assert.True(raphael.IsShared(m0));
            Assert.False(raphael.IsAvailable(m0));
            Assert.True(raphael.IsOwned(m0));

            Assert.True(thomas.IsShared(m0));
            Assert.True(thomas.IsAvailable(m0));
            Assert.False(thomas.IsOwned(m0));
        }

        [Fact]
        public void UserSharingErrors()
        {
            library.SetName("Collection Raphael");
            User raphael = new User("Raphael", library);
            User thomas = new User("Thomas", new Library("Collection Thomas"));
            User david = new User("David", new Library("Collection David"));
            thomas.GetLibrary().AddMedia(m10);

            Assert.Throws<NotAvailableException>(() => raphael.Share(m8, thomas));

            Assert.Throws<NotOwnedException>(() =>
            {
                raphael.Share(m10, david);
                thomas.Share(m10, raphael);
            });
        }
    }
}

