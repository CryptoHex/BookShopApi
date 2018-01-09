using System.ComponentModel.DataAnnotations;

namespace BookShopApi.Services.Models.Book
{
    public class BookModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Copies { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int Edition { get; set; }
    }
}
