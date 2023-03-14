using BookStore.BL.Interfaces;
using BookStore.Models.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryServices _libraryServices;
        public LibraryController(ILibraryServices libraryServices)
        {
            _libraryServices = libraryServices;
        }

        [HttpGet("GetAllBooksByAuthor")]
        public GetAllBooksByAuthorResponse GetAllBooksByAuthor(int authorId)
        {
            return _libraryServices.GetAllBooksByAuthorId(authorId);
        }

        [HttpGet("GetAllBooksByReleaseDate")]
        public GetAllBooksByReleaseDate GetAllBooksByReleaseDate(int releaseDate, int authorId)
        {
            return _libraryServices.GetAllBooksByReleaseDate(releaseDate, authorId);
        }
    }
}
