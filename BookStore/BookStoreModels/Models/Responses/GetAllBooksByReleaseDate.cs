using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models.Responses
{
    public class GetAllBooksByReleaseDate
    {
        public IEnumerable<Book> Books { get; set; }
        public Author? Author { get; set; }
    }
}
