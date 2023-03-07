using System.Net;
using BookStore.Models.Base;

namespace BookStore.DL.InMemoryDb
{
    public static class InMemoryDb
    {
        public static List<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id= 1,
                Name = "Pesho"
            },
            new Author()
            {
                Id= 2,
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
            },
            new Book()
            {
                Id= 2,
                Name = "Warcraft: Durotan",
                AuthorId = 2,
            }
        };
    }
}
