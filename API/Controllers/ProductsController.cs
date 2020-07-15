using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructuer.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController :ControllerBase
    {

       private readonly IProductRepository _repo;
       private readonly StoreContext _context;


        public ProductsController(IProductRepository repo , StoreContext context) 
        {
            _repo = repo;
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts() =>  Ok(await  _repo.GetProductsAsync());
       

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id) => Ok(await _context.Products.FindAsync(id));

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() => Ok(await _repo.GetProductBrandsAsync());

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() => Ok(await _repo.GetProductTypesAsync());
        
    }


}