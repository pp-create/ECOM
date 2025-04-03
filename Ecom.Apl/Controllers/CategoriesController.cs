using AutoMapper;
using Ecom.Apl.Helper;
using Ecom.core.Dto;
using Ecom.core.Entities.Product;
using Ecom.core.interfaces;
using Ecom.infrastructure.Repositries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Ecom.Apl.Controllers
{

    public class CategoriesController : BaseController
    {
        public CategoriesController(IunitofWork iunitofWork, IMapper mapper) : base(iunitofWork, mapper)
        {
        }

        [HttpGet("Get_all")]
        public async Task<IActionResult> GetAllCategories()
        {
           try
            {
                IReadOnlyList<Category> categories = await iunitofWork.categoryRepositry.GetAll();

                return Ok(categories);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category =  iunitofWork.categoryRepositry.GetIdAsync(id);

            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            return Ok(category);
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(CategoryDto CategoryDto)
        {
           
            if (CategoryDto == null)
            {
                return NotFound(new { message = "Category not found" });
            }

            var obj = Mapper.Map<Category>(CategoryDto);
            await iunitofWork.categoryRepositry.Addasync(obj);



            return Ok(new { message = "Category is  Add" } );
        }  
        [HttpPut("Update_Category")]
        public async Task<IActionResult> Update(UpdateCategoryDto CategoryDto)
        {
           
            if (CategoryDto == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            var obj = Mapper.Map<Category>(CategoryDto);
            await iunitofWork.categoryRepositry.Updateasync(obj);



            return Ok(new { message = "Category is  Updated" } );
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id )
        {
            try
            {
                if (id == null)
                {
                    return NotFound(new { message = "Category not found" });
                }

                await iunitofWork.categoryRepositry.Deleteasync(id);



                return Ok(new { message = "Category is  Deleted" });
            }
            catch (Exception)
            {

                return BadRequest(new ResponseApi(400));
            }
            
          
        }
    }
}
