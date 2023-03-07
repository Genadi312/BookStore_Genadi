using BookStore.BL.Interfaces;
using BookStore.Models.Base;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookServices _bookService;

        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAll()
        {
            return _bookService.GetAll();

        }

        [HttpGet("GetById")]
        public Book GetById(int id)
        {
            return _bookService.GetById(id);
        }

        [HttpPost("Add")]
        public void Add([FromBody] Book book)
        {
            _bookService.Add(book);
        }

        [HttpPost("Update")]
        public void Update([FromBody] Book book)
        {
            _bookService.Update(book);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }
    }
}
