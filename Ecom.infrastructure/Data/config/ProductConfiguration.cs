using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.infrastructure.Data.config
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
              .IsRequired()          

              .HasMaxLength(200);    


            
            builder.Property(p => p.Newprice)
                .IsRequired()        
                .HasColumnType("decimal(18,2)");

           
            builder.Property(p => p.Description)
                .HasMaxLength(500);
            builder.HasData(
    new Product
    {
        Name = "test",
        categroyid=1,
       
      Id=1,
        Newprice=1000,
        Description = "test"
    }
    );

        }
        
    }
    
}
