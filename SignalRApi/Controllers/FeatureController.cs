using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto var)
        {
            _featureService.TAdd(new Feature()
            {
                Title1= var.Title1,
                Title2= var.Title2,
                Description1= var.Description1,
                Description2= var.Description2,
                Title3 = var.Title3,
                Description3 = var.Description3,
            });
            return Ok("kategori eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var value = _featureService.TGetByID(id);
            _featureService.TDelete(value);
            return Ok("Kategori silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            return Ok(_featureService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto var)
        {
            _featureService.TUpdate(new Feature()
            {
                FeatureID = var.FeatureID,
                Title1 = var.Title1,
                Title2 = var.Title2,
                Description1 = var.Description1,
                Description2 = var.Description2,
                Title3 = var.Title3,
                Description3 = var.Description3,
            });
            return Ok("kategori güncellendi");
        }
    }
}
