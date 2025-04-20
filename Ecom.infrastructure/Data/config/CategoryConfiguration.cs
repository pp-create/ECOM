﻿using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Data.config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                      .IsRequired()          
                      .HasMaxLength(100);    

  
            builder.Property(c => c.Id)
                .IsRequired();
            builder.HasData(
                new Category
                {
                 Id=1,
                    Name = "test",
                    Description = "test"
                }
                );
        }
    }
}
