﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace Repositories.Extensions
{
    public static class BookRepositoryExtensions
    {
        public static IQueryable<Book> FilterBooks(this  IQueryable<Book> books,
            uint minPrice,
            uint maxPrice) =>
            books.Where(book =>
            book.Price >= minPrice &&
            book.Price <= maxPrice);

        public static IQueryable<Book> Search(this IQueryable<Book> books,string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
                return books;

            var lowerCaseTerm= searchTerm.Trim().ToLower();
            return books
                .Where(b => b.Title
                .ToLower()
                .Contains(lowerCaseTerm));
        }

        public static IQueryable<Book> Sort(this IQueryable<Book>books,string orderByQueryString)
        {
            if(string.IsNullOrEmpty(orderByQueryString))
                return books.OrderBy(b => b.Id);

            var orderQuery=OrderQueryBuilder
                .CreateOrderQuery<Book>(orderByQueryString);

            if (orderQuery is null)
                return books.OrderBy(b => b.Id);


            return books.OrderBy(orderQuery);


        }
        

     
    }
}
