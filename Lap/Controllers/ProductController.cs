using Lap.Models;
using Lap.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Lap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IproductRepository productRepository;

        public ProductController(IproductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            Product product = productRepository.getByID(id);
            return Ok(product);
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<Product> products = productRepository.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(product);
                productRepository.Save();
                return CreatedAtAction("getById", new { id = product.Id }, product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.updateProduct(id, product);
                productRepository.Save();
                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            if (ModelState.IsValid)
            {
                productRepository.deleteProduct(id);
                productRepository.Save();
                return NoContent();
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpGet("{id:int}/{name}")]
        public IActionResult getByIdAndName(int id, string name)
        {
            if (ModelState.IsValid)
            {
                Product p = productRepository.getByID(id);

                if (p != null && p.Name == name)
                {

                    return Ok(p);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
