using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() {
            var products = await _productRepo.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId) {
            var product = await _productRepo.GetProductByIdAsync(productId);
            return Ok(product);
        }
        
        [HttpGet("Types")]
        public async Task<IActionResult> GetProductTypess() {
            var productTypes = await _productRepo.GetProductTypesAsync();
            return Ok(productTypes);
        }
        
        [HttpGet("Brands")]
        public async Task<IActionResult> GetProductBrands() {
            var productBrands = await _productRepo.GetProductBrandsAsync();
            return Ok(productBrands);
        }
    }
}