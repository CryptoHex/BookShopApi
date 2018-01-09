using AutoMapper;
using BookShopApi.Models.Data;
using BookShopApi.Services.Models.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShopApi.Infrastructure.Mapper
{
    public  class BookShopApiProfile : Profile
    {


        public  BookShopApiProfile()
        {

            CreateMap<BookModel, Book>()
                .ForMember(dest => dest.Author, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Book, BooksListingModel>();

            CreateMap<Book, BookDetailsModel>();

        }
    }
}
