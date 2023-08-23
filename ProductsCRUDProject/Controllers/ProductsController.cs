using Microsoft.AspNetCore.Mvc;
using ProductsCRUDProject.Models;
using ProductsCRUDProject.Controllers;

using ProductsCRUDProject.Services;

namespace ProductsCRUDProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<List<Products>> Get()
        {
            return productService.Get();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Products> Get(string id)
        {
            var product = productService.Get(id);
            if (product == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            return product;
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Products> Post([FromBody] Products products)
        {
            productService.Create(products);
            return CreatedAtAction(nameof(Get), new { id = products.Id }, products);

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Products products)
        {
            var existingProduct = productService.Get(id);
            if (existingProduct == null)
            {
                return NotFound($"Student with id {id} not found");
            }
            productService.Update(id, products);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var products = productService.Get(id);
            if (products == null) { return NotFound($"Student with id {id} not found"); }
            productService.Remove(products.Id);
            return Ok($"Product with id = {id} deleted");
        }
    }
}

