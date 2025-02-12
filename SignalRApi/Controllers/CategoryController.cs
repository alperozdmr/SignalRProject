using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList() {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount() { 
            return Ok(_categoryService.TCategoryCount());
        }
		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}
		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			return Ok(_categoryService.TPassiveCategoryCount());
		}
		[HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto var)
        {
            var.Status = true;
            _categoryService.TAdd(_mapper.Map<Category>(var));
            return Ok("kategori eklendi");
        }
        //Buraya id yazmamın nedeni webUI dan istek atılınca parametre olarak id yi görmesi 
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) {
            return Ok(_categoryService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto var) {
            _categoryService.TUpdate(_mapper.Map<Category>(var));
            return Ok("kategori güncellendi");
        }  
    }
}
