using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController(ISliderService SliderService, IMapper mapper)
        {
            _sliderService = SliderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(CreateSliderDto var)
        {
            _sliderService.TAdd(new Slider()
            {
                Title1= var.Title1,
                Title2= var.Title2,
                Description1= var.Description1,
                Description2= var.Description2,
                Title3 = var.Title3,
                Description3 = var.Description3,
            });
            return Ok("Slider eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSlider(int id)
        {
            var value = _sliderService.TGetByID(id);
            _sliderService.TDelete(value);
            return Ok("Slider silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSlider(int id)
        {
            return Ok(_sliderService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateSlider(UpdateSliderDto var)
        {
            _sliderService.TUpdate(new Slider()
            {
                SliderID = var.SliderID,
                Title1 = var.Title1,
                Title2 = var.Title2,
                Description1 = var.Description1,
                Description2 = var.Description2,
                Title3 = var.Title3,
                Description3 = var.Description3,
            });
            return Ok("Slider güncellendi");
        }
    }
}
