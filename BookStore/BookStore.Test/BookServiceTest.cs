using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.Models.Models;
using Moq;

namespace BookStore.Test
{
    public class BookServiceTest
    {
        private Mock<IBookRepository> _bookRepository;
        private Mock<IAuthorServices> _authorService;

        private IList<Book> Books = new List<Book>()
        {
            new Book()
            {
                Id = new Guid("278c446b-0825-44c5-ba92-e83fb707a40e"),
                AuthorId = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2375c"),
                Title = "Book1",
            },
            new Book()
            {
                Id = new Guid("278c446b-0825-44c5-ba92-e83fb707a41e"),
                AuthorId = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2375c"),
                Title = "Book2",
            }
        };

        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _authorService = new Mock<IAuthorServices>();
        }

        [Fact]
        public async Task Book_GetAll_Count_Check()
        {
            //setup
            var expectedCount = Books.Count();

            _bookRepository.Setup(x => x.GetAll()).Returns(async () => Books.AsEnumerable());

            //inject
            //var service = new BookService(_bookRepository.Object, _authorService.Object);

            //Act
            //var result = await service.GetAll();

            //Assert
           // var books = result.ToList();
            //Assert.NotNull(books);
            //Assert.Equal(expectedCount, books.Count());
            //Assert.Equal(Books, books);

        }

        [Fact]
        public async Task Book_GetById_Check()
        {
            //setup
            var bookId = new Guid("278c446b-0825-44c5-ba92-e83fb707a40e");
            var expectedBook = Books.First(x => x.Id == bookId);
            var expectedTitle = expectedBook.Title;

            _bookRepository.Setup(x => x.GetById(bookId)).Returns(async () => Books.FirstOrDefault(x => x.Id == bookId));

            //inject
            var service = new BookService(_bookRepository.Object);

            //Act
            var result = await service.GetById(bookId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedBook, result);
        }

        [Fact]
        public async Task Book_GetById_NotFound()
        {
            //setup
            var bookId = new Guid("378c446b-0825-44c5-ba92-e83fb707a40e");
            

            _bookRepository.Setup(x => x.GetById(bookId)).Returns(async () => Books.FirstOrDefault(x => x.Id == bookId));

            //inject
            var service = new BookService(_bookRepository.Object);

            //Act
            var result = await service.GetById(bookId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task Book_Add_Ok()
        {
            //setup

            var bookToAdd = new Book
            {
                Id = new Guid("278c446b-0825-44c5-ba92-e83fb707a40e"),
                Title = "New Title",
                AuthorId = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2375c")

            };

            //_bookRepository.Setup(x => x.Add(bookToAdd)).Returns(async () => Books.FirstOrDefault(x => x.Id == bookId));

            //inject
            var service = new BookService(_bookRepository.Object);

            //Act
            //var result = await service.Add(bookToAdd);

            //Assert
            //Assert.Null(result);
        }
    }
}