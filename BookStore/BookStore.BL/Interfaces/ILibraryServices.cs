using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Models.Responses;

namespace BookStore.BL.Interfaces
{
    public interface ILibraryServices
    {
        public Task <GetAllBooksByAuthorResponse> GetAllBooksByAuthorId(Guid authorId);

        public Task <GetAllBooksByReleaseDate> GetAllBooksByReleaseDate(int releaseDate, Guid authorId);
    }
}
