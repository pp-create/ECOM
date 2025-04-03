using Ecom.core.Dto;
using Ecom.core.Entities.Product;
using Ecom.core.Sharing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.core.interfaces
{
   public interface IproductRepositry:IGenericRepositry<Product>
    {
        Task<bool> Addasync(AddProductDto entity);
        Task<bool> UpdateProduct(UpdateProductDto entity);
        Task Deleteasync(Product entity);
        Task<IEnumerable<ProductDto>> GetAllAsync(ProductParam param);
    }
}
