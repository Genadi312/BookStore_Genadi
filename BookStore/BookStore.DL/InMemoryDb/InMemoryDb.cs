using System.Net;
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
                Id= 1,
                Name = "Warcraft: Before the Storm",
                AuthorId = 1,
                ReleaseDate = 2018,
            },
            new Book()
            {
                Id= 2,
                Name = "Warcraft: Durotan",
                AuthorId = 2,
                ReleaseDate = 2016,
            }
        };
    }
}
