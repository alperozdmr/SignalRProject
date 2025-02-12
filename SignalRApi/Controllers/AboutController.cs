using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

		public AboutController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(_mapper.Map<List<ResultAboutDto>>(values));
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CreateAbout(CreateAboutDto var)
        {
            var value = _mapper.Map<About>(var);
            _aboutService.TAdd(value);
            return Ok("Hakkında kısmı başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            _aboutService.TDelete(value);
            return Ok("Hakkında alanı silindi");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto var)
        {
            var value = _mapper.Map<About>(var);
            _aboutService.TUpdate(value);
            return Ok("Hakkında alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(_mapper.Map<GetAboutDto>(value));
        }
    }
}
