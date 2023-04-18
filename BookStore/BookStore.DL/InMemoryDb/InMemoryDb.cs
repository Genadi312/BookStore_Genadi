using BookStore.Models.Models;

namespace BookStore.DL.InMemoryDb
{
    public static class InMemoryDb
    {
        public static List<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Name = "Pesho"
            },
            new Author()
            {
                Name = "Stavri"
            }
        };

        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                
                Title = "Warcraft: Before the Storm",
                //ReleaseDate = 2018,
            },
            new Book()
            {
                
                Title = "Warcraft: Durotan",
               //ReleaseDate = 2016,
            }
        };
    }
}
