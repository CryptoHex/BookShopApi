﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Models.Data
{
    public class CategoryBook
    {
        public int CategoryId { get; set; }  
        public Category Category { get; set; }  

        public int BookId { get; set; }  
        public Book Book { get; set; }  

    }
}
