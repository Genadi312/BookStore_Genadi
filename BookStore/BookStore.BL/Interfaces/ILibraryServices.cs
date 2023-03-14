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
        GetAllBooksByAuthorResponse GetAllBooksByAuthorId(int authorId);

        GetAllBooksByReleaseDate GetAllBooksByReleaseDate(int releaseDate, int authorId);
    }
}
