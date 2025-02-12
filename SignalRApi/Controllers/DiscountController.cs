using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto var)
        {
            _discountService.TAdd(_mapper.Map<Discount>(var));
            return Ok("discount eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("discount silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            return Ok(_discountService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto var)
        {
            var.Status = false;
            _discountService.TUpdate(_mapper.Map<Discount>(var));
            return Ok("discount güncellendi");
        }
        [HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
        {
            _discountService.TChangeStatusToTrue(id);
            return Ok("durrum değiştirildi");
        }
        [HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
        {
            _discountService.TChangeStatusToFalse(id);
			return Ok("durrum değiştirildi");
		}
	}
}
