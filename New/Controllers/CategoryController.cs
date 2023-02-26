using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using New.Context;
using New.Context.DTO;
using New.Context.EntityModel;

namespace uygulama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
   
    public class CategoryController : ControllerBase
    {
        private readonly NorthWindContext _context;

        public CategoryController(NorthWindContext context)
        {
            _context = context;
        }
        [Route("getall")]
        [HttpGet]
        public async Task<string> GetAllCategories()
        {

         var res=  await _context.Categories.ToListAsync();
             return JsonConvert.SerializeObject(res);

        }
        [Route("addcategory")]
        [HttpPost]
        public  async Task<bool> AddCategory(CategoryDTO category)
        {

            await _context.AddAsync(new Category
            {
                CategoryName = category.CategoryName,
                 Description=category.Descrption,
                 
             
            });
            await _context.SaveChangesAsync();  
         return   await _context.SaveChangesAsync() >0?true:false;
        }

       




    }
}
