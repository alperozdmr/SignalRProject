using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto var)
        {
            _socialMediaService.TAdd(_mapper.Map<SocialMedia>(var));
            return Ok("sosyal medya eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(value);
            return Ok("Sosyal Medya silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            return Ok(_socialMediaService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto var)
        {
            _socialMediaService.TUpdate(_mapper.Map<SocialMedia>(var));
            return Ok("Sosyal medya güncellendi");
        }
    }
}
