using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Services.Models.Book
{
    public class BookDetailsModel
    {
        public int Id { get; set; }  

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public int AuthorId { get; set; }

        public int Edition { get; set; }
    }
}
