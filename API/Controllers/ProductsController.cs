using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productRepo,
            IGenericRepository<ProductType> productTypeRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productTypeRepo = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() {
            var specs = new ProductsWithTypeAndBrandSpecification();
            var products = await _productRepo.ListAll(specs);
            var productsToReturn = _mapper.Map<IList<ProductToReturnDto>>(products);
            return Ok(productsToReturn);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(int productId) {
            var spec = new ProductsWithTypeAndBrandSpecification(productId);
            var product = await _productRepo.GetEntityWithSpec(spec);
            var productToReturn = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productToReturn);
        }
        
        [HttpGet("Types")]
        public async Task<IActionResult> GetProductTypess() {
            var productTypes = await _productTypeRepo.ListAllAsync();
            return Ok(productTypes);
        }
        
        [HttpGet("Brands")]
        public async Task<IActionResult> GetProductBrands() {
            var productBrands = await _productBrandRepo.ListAllAsync();
            return Ok(productBrands);
        }
    }
}