using Lap.DTO;
using Lap.Models;
using Lap.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IcategoryRepository icategoryRepository;

        public CategoryController(IcategoryRepository icategoryRepository)
        {
            this.icategoryRepository = icategoryRepository;
        }


        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var CategoryModel = new GetCategoryWIthProductsDOT();

            Category model = icategoryRepository.getById(id);
            if (model != null)
            {
                CategoryModel.categoryName = model.Name;
                CategoryModel.categoryID = model.Id;

                if (model.Products != null)
                {
                    CategoryModel.products = model.Products.Select(p => p.Name).ToList();
                }
                return Ok(CategoryModel);
            }

            return BadRequest();
        }


        [HttpGet]
        public IActionResult getAll()
        {
            List<GetCategoryWIthProductsDOT> Models = new List<GetCategoryWIthProductsDOT>();
            List<Category> categories = icategoryRepository.getAllWithProduct();

            Models = categories.Select(categories => new GetCategoryWIthProductsDOT
            {
                categoryID = categories.Id,
                categoryName = categories.Name,
                products = categories.Products.Select(p => p.Name).ToList()
            }).ToList();

            return Ok(Models);

        }
    }
}
