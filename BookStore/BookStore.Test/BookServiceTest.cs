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
        private Mock<IAuthorServices> _authorServices;

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
        private IList<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2375c"),
                Name = "Author Name",
                Bio = "Author Bio"
            },
        };
        public BookServiceTest()
        {
            _bookRepository = new Mock<IBookRepository>();
            _authorServices = new Mock<IAuthorServices>();
        }

        [Fact]
        public async Task Book_GetAll_Count_Check()
        {
            //setup
            var expectedCount = Books.Count();

            _bookRepository.Setup(x => x.GetAll()).Returns(async () => Books.AsEnumerable());
            //inject
            var service = new BookService(_authorServices.Object, _bookRepository.Object);

            //Act
            var result = await service.GetAll();

            //Assert
            var books = result.ToList();
            Assert.NotNull(books);
            Assert.Equal(expectedCount, books.Count());
            Assert.Equal(Books, books);

        }

        [Fact]
        public async Task Book_GetById_Ok()
        {
            //setup
            var bookId = new Guid("278c446b-0825-44c5-ba92-e83fb707a41e");
            var expectedBook = Books.First(x => x.Id == bookId);
            var expectedTitle = expectedBook.Title;

            _bookRepository.Setup(x => x.GetById(bookId)).Returns(async () => Books.FirstOrDefault(x => x.Id == bookId));

            //inject
            var service = new BookService(_authorServices.Object, _bookRepository.Object);

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
            var bookId = new Guid("278c446b-0825-44c5-ba92-e83fb707a42e");


            _bookRepository.Setup(
                    x => x.GetById(bookId))
                .Returns(async () =>
                    Books.FirstOrDefault(x => x.Id == bookId));
            //inject
            var service = new BookService(_authorServices.Object, _bookRepository.Object);

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

            var expectedBookCount = 3;

            _authorServices.Setup(a => a.GetById(bookToAdd.AuthorId)).Returns(() => Task.FromResult(Authors.FirstOrDefault()));

            _bookRepository.Setup(x => x.GetAllByAuthorId(bookToAdd.AuthorId)).Returns(() => Task.FromResult(Books.Where(x => x.AuthorId == bookToAdd.AuthorId)));

            _bookRepository.Setup(x => x.Add(It.IsAny<Book>())).Callback(() =>
                {
                    Books.Add(bookToAdd);
                }).Returns(Task.CompletedTask);

            //inject
            var service = new BookService(_authorServices.Object, _bookRepository.Object);

            //Act
            await service.Add(bookToAdd);

            //Assert
            Assert.Equal(expectedBookCount, Books.Count);
            Assert.Equal(bookToAdd, Books.LastOrDefault());
        }
        [Fact]
        public async Task Book_Add_Author_Not_Found()
        {
            //setup

            var bookToAdd = new Book
            {
                Id = new Guid("278c446b-0825-44c5-ba92-e83fb707a40e"),
                Title = "New Title",
                AuthorId = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2373a"),
            };

            var expectedBookCount = 2;

            _authorServices.Setup(a =>
                a.GetById(bookToAdd.AuthorId)).Returns(() =>
                Task.FromResult(Authors.FirstOrDefault(x => x.Id == bookToAdd.AuthorId)));

            _bookRepository.Setup(
                    x => x.GetAllByAuthorId(bookToAdd.AuthorId))
                .Returns(() =>
                    Task.FromResult(Books.Where(x => x.AuthorId == bookToAdd.AuthorId)));

            _bookRepository.Setup(x =>
                x.Add(It.IsAny<Book>()));

            //inject
            var service = new BookService(_authorServices.Object, _bookRepository.Object);

            //Act
            var result = await service.Add(bookToAdd);

            //Assert
            Assert.Equal(expectedBookCount, Books.Count);
            Assert.Null(result);
        }
    }
}