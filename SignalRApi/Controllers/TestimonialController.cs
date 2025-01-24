using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService TestimonialService, IMapper mapper)
        {
            _testimonialService = TestimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto var)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Comment = var.Comment,
                ImageUrl = var.ImageUrl,
                Name = var.Name,
                Status = var.Status,
                Title = var.Title,
            });
            return Ok("testimonial eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(value);
            return Ok("testimonial silindi");
        }
        [HttpGet("Get Testimonial")]
        public IActionResult GetTestimonial(int id)
        {
            return Ok(_testimonialService.TGetByID(id));
        }
        [HttpPost("Update")]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto var)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                TestimonialID = var.TestimonialID,
                Comment = var.Comment,
                ImageUrl = var.ImageUrl,
                Name = var.Name,
                Status = var.Status,
                Title = var.Title,
            });
            return Ok("testimonial güncellendi");
        }
    }
}
