using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Repository;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        private readonly IProductRepository productRepositoryService;
        public ProductController( ProductRepository _productRepository, IProductRepository _productRepositoryService) {
            this.productRepository = _productRepository;
            this.productRepositoryService = _productRepositoryService;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDTO product)
        {
                var result = await this.productRepository.AddProductAsync<ProductDTO>(async () => await this.productRepositoryService.AddProducts(product));
                return Ok(result);
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.productRepository.GetAllProductAsync(this.productRepositoryService.GetItems);
            return Ok(result);
        }
      
    }
}
