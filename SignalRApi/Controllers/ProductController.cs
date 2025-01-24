using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("ListWithCategory")]
        public IActionResult ProductListWithCategory() {
            var values = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }
        
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto var)
        {
            _productService.TAdd(new Product()
            {
               Price = var.Price,
               ProductName = var.ProductName,
               ProductStatus = true,
               Description = var.Description,
               ImageUrl = var.ImageUrl,
               CategoryID = var.CategoryID,
            });
            return Ok("ürüm eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("ürün silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(_productService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto var)
        {
            _productService.TUpdate(new Product()
            {
                ProductID = var.ProductID,
                Price = var.Price,
                ProductName = var.ProductName,
                ProductStatus = var.ProductStatus,
                Description = var.Description,
                ImageUrl = var.ImageUrl,
                CategoryID = var.CategoryID,
            });
            return Ok("ürün güncellendi");
        }
    }
}
