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
    public class PhotoConfiguration : IEntityTypeConfiguration<photo>
    {
      

        public void Configure(EntityTypeBuilder<photo> builder)
        {
            builder.HasData(
               new photo
               {
                   Id = 1,
                   ImageName = "test",
                   productid = 1
               }
               );
        }
    }
}
