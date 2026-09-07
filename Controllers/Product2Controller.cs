using DockerTestProject.Data;
using DockerTestProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerTestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Product2Controller : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public Product2Controller(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/product   
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _dbContext.Products.ToListAsync();

            return Ok(products);
        }

        // GET: api/product/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        // PUT: api/product/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            Product request)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = request.Name;
            product.Price = request.Price;

            await _dbContext.SaveChangesAsync();

            return Ok(product);
        }

        // DELETE: api/product/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}

