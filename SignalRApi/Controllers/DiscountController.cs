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
            _discountService.TAdd(new Discount()
            {
               Amount = var.Amount, 
               Description = var.Description,
               ImageUrl = var.ImageUrl,
               Title = var.Title,
            });
            return Ok("discount eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountService.TGetByID(id);
            _discountService.TDelete(value);
            return Ok("discount silindi");
        }
        [HttpGet("Get Discount")]
        public IActionResult GetDiscount(int id)
        {
            return Ok(_discountService.TGetByID(id));
        }
        [HttpPost("Update")]
        public IActionResult UpdateDiscount(UpdateDiscountDto var)
        {
            _discountService.TUpdate(new Discount()
            {
                DiscountID = var.DiscountID,
                Amount = var.Amount,
                Description = var.Description,
                ImageUrl = var.ImageUrl,
                Title = var.Title,
            });
            return Ok("discount güncellendi");
        }
    }
}
