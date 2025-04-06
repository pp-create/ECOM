using AutoMapper;
using Ecom.Apl.Helper;
using Ecom.core.Dto;
using Ecom.core.Entities.Product;
using Ecom.core.interfaces;
using Ecom.core.Sharing;
using Ecom.infrastructure.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecom.Apl.Controllers
{

    public class ProductsController : BaseController
    {
        public ProductsController(IunitofWork iunitofWork, IMapper mapper) : base(iunitofWork, mapper)
        {
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParam param)
        {
           try
            {
              var Products = await iunitofWork.productRepositry.GetAllAsync(param); ;

                // Return the mapped list
                var totalCount = await iunitofWork.productRepositry.count();
                return Ok(new Pagination<ProductDto>(
                    param.PageNumber,
                    param.PageSize,

                    totalCount,Products.ToList()
                ));


            }
            catch (Exception)
            {

                return BadRequest(new ResponseApi(400));
            }
            
         }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var Product = await iunitofWork.productRepositry.GetIdAsync(id,x=>x.Category, x => x.photo);
           

            if (Product == null)
            {
                return NotFound(new ResponseApi ( 400));
            }
            var data = Mapper.Map<ProductDto>(Product);
            return Ok(data);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromForm]
            AddProductDto ProductDto)
        {
           
            if (ProductDto == null)
            {
                return NotFound(new { message = "Product not found" });
            }

         
            await iunitofWork.productRepositry.Addasync(ProductDto);



            return Ok(new  { message = "Product is  Add" } );
        }  
        [HttpPut("Update_Product")]
        public async Task<IActionResult> Update(UpdateProductDto ProductDto)
        {
           
            if (ProductDto == null)
            {
                return NotFound(new { message = "Product not found" });
            }
            
            await iunitofWork.productRepositry.UpdateProduct(ProductDto);



            return Ok(new { message = "Product is  Updated" } );
        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id )
        {
            try
            {
                var Product = await iunitofWork.productRepositry.GetIdAsync(id, x => x.Category, x => x.photo);

                if (id == null)
                {
                    return NotFound(new { message = "Product not found" });
                }

                await iunitofWork.productRepositry.Deleteasync(Product);



                return Ok(new { message = "Product is  Deleted" });
            }
            catch (Exception)
            {

                return BadRequest(new ResponseApi(400));
            }
            
          
        }
    }
}
