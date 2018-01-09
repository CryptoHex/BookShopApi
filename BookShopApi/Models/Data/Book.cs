using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Models.Data
{
    public class Book
    {
        public int Id { get; set; }  

        [Required]
        public string Title { get; set; }  

        public string Description { get; set; }  

        [Required]
        public decimal Price { get; set; }  

        public int Copies { get; set; }  

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }  

        [Required]
        public int Edition { get; set; }  

    }
}
