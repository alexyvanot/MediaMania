namespace MediaMania.src.obj
{
    public class Book : Media
    {
        public Book(string title, string author, Genre genre) : base(title, author, genre)
        {
        }

        public Book(string title, string author, List<Genre> genres) : base(title, author, genres)
        {
        }

        public string GetAuthor()
        {
            return GetArtist();
        }
        
    }
}