﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig :IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Araba Sevdası", Price = 50 },
                new Book { Id = 2, Title = "İnsan Neyle Yaşar", Price = 250 },
                new Book { Id = 3, Title = "Yaban", Price = 350 }
                );
        }
    }
}
