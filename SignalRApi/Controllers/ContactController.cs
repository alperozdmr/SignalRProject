using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto var)
        {
            _contactService.TAdd(new Contact()
            {
                Phone=var.Phone,    
                Mail=var.Mail,
                FooterDescription=var.FooterDescription,
                Location=var.Location,
            });
            return Ok("Contact eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetByID(id);
            _contactService.TDelete(value);
            return Ok("Contact silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            return Ok(_contactService.TGetByID(id));
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto var)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactId=var.ContactId,
                Phone = var.Phone,
                Mail = var.Mail,
                FooterDescription = var.FooterDescription,
                Location = var.Location,
            });
            return Ok("Contact güncellendi");
        }
    }
}
