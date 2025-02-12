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
        [HttpGet("ProductCount")]
        public IActionResult ProductCount() { 
            return Ok(_productService.TProductCount());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger() {
            return Ok(_productService.TProductCountByCategoryNameHambuger());
        }
		[HttpGet("ProductCountByDrink")]
		public IActionResult ProductCountByDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}
        [HttpGet("ProductPriceAVG")]
        public IActionResult ProductPriceAVG()
        {
            return Ok(_productService.TProductPriceAVG());
        }
        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductPriceMax() {
            
            return Ok(_productService.TProductNameByMaxPrice());
        }
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductPriceMin()
		{

			return Ok(_productService.TProductNameByMinPrice());
		}
		[HttpGet("ProductPriceAvgByHamburger")]
		public IActionResult ProductPriceAvgByHamburger()
		{

			return Ok(_productService.TProductPriceByHamburger());
		}

		[HttpPost]
        public IActionResult CreateProduct(CreateProductDto var)
        {
            var.ProductStatus = true;
            _productService.TAdd(_mapper.Map<Product>(var));
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
            _productService.TUpdate(_mapper.Map<Product>(var));
            return Ok("ürün güncellendi");
        }
		[HttpGet("GetLast9Products")]
		public IActionResult GetLast9Products()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetLast9Products());
			return Ok(values);
		}
	}
}
