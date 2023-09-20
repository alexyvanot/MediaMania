using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaMania.src.obj;
using MediaMania.src.utils;

namespace MediaMania.src
{
    public class main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Library library = new Library("Alexy's lib");
            Media m0 = new Book("Programmer pour l'intelligence collective", "Toby Segaran", Genre.EDUCATION);
            Media m1 = new Book("Le meilleur des mondes", "Aldous Huxley", Genre.SCIENCE_FICTION);
            Media m2 = new Comic("Zaï Zaï Zaï Zaï", "Fabcaro", Genre.ABSURD);
            Media m3 = new Movie("Parasite", "Bong Joon-ho", new List<Genre> { Genre.THRILLER, Genre.DRAMA });

            library.AddMedia(new List<Media> { m0, m1, m2, m3 });

            Console.WriteLine(library.GetName());
            library.GetPersonalMedias().ForEach(m => Console.WriteLine(m.GetTitle()));

            StorageService.Save(library, "library.json");


            Library library2 = StorageService.Load("library.json");
            Media m4 = new Movie("Pathema et le monde inversé", "Je sais plus qui", Genre.ROMANCE);
            library2.AddMedia(m4);
            library2.SetName("Célivé's lib");
            Console.WriteLine(library2.GetName());
            library2.GetPersonalMedias().ForEach(m => Console.WriteLine(m.GetTitle()));

        }
    }
}
