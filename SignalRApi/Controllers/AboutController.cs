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

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CreateAbout(CreateAboutDto var)
        {
            About about = new About
            {
                Title = var.Title,
                Description = var.Description,
                ImageUrl = var.ImageUrl,
            };
            _aboutService.TAdd(about);
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
            About about = new About
            {
                AboutID = var.AboutID,
                Title = var.Title,
                Description = var.Description,
                ImageUrl = var.ImageUrl,
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkında alanı güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var value = _aboutService.TGetByID(id);
            return Ok(value);
        }
    }
}
