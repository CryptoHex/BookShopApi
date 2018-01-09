using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopApi.Tests
{
    using AutoMapper;
    using BookShopApi.Infrastructure.Mapper;

    public class Tests
    {
        private static bool testsInitialized = false;

        public static void Initialize()
        {
            if (!testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<BookShopApiProfile>());
                testsInitialized = true;
            }
        }
    }
}
