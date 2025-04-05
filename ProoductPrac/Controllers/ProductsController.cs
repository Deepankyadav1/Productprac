using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProoductPrac.Model;
using ProoductPrac.Services;
using System.Reflection.Metadata.Ecma335;

namespace ProoductPrac.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductServices _productService;

        public ProductsController(ProductServices productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        

        [HttpPost]
        public ActionResult<Product> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id },product);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.Id) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!_productService.Update(id, product)) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_productService.Delete(id)) return NotFound();
            return NoContent();
        }

    }
}
