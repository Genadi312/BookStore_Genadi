﻿using BookStore.BL.Interfaces;
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
        public async Task <GetAllBooksByAuthorResponse> GetAllBooksByAuthor(Guid authorId)
        {
            return await _libraryServices.GetAllBooksByAuthorId(authorId);
        }

        [HttpGet("GetAllBooksByReleaseYear")]
        public async Task<GetAllBooksByReleaseYear> GetAllBooksByReleaseYear(int releaseYear, Guid authorId)
        {
            return await _libraryServices.GetAllBooksByReleaseYear(releaseYear, authorId);
        }
    }
}
