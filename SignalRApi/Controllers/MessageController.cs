using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

		private readonly IMessageService _messageService;
		private readonly IMapper _mapper;
		public MessageController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			var values = _messageService.TGetListAll();
			return Ok(_mapper.Map<List<ResultMessageDto>>(values));
		}
		[HttpPost]
		public IActionResult CreateMessage(CreateMessageDto var)
		{
			var.Status = false;
			var.SendDate = DateTime.Now;
			var value = _mapper.Map<Message>(var);
			_messageService.TAdd(value);
			return Ok("Mesaj Başarılı Bir Şekilde Gönderildi");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			_messageService.TDelete(value);
			return Ok("Mesaj Silindi");
		}
		[HttpPut]
		public IActionResult UpdateMessage(UpdateMessageDto var)
		{
			var value = _mapper.Map<Message>(var);
			_messageService.TUpdate(value);
			return Ok("Mesaj Bilgisi Güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetMessage(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(_mapper.Map<GetByIdMessageDto>(value));
		}
	}
}
