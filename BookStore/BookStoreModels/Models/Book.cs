using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Guid AuthorId { get; set; }

        public int ReleaseDate { get; set; }
    }
}
