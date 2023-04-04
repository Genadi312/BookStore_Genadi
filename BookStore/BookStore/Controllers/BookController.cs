using BookStore.BL.Interfaces;
using BookStore.Models.Models;
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
        public async Task <IEnumerable<Book>> GetAll()
        {
            return await _bookService.GetAll();

        }

        [HttpGet("GetById")]
        public async Task <Book> GetById(int id)
        {
            return await _bookService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task Add([FromBody] Book book)
        {
            await _bookService.Add(book);
        }

        [HttpPost("Update")]
        public async Task Update([FromBody] Book book)
        {
            await _bookService.Update(book);
        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            _bookService.Delete(id);
        }
    }
}
