using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Services.Models.Book
{
    public class BooksPageListingModel
    {
        public IEnumerable<BooksListingModel> Books { get; set; }

        public int Page { get; set; }

        public int TotalPages { get; set; }

    }
}
