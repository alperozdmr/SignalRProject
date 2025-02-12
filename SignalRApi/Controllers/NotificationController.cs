using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer;
using SignalR.EntityLayer.Entities;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult NotificationList() {
			var values = _notificationService.TGetListAll();
			return Ok(_mapper.Map<List<ResultNotificationDto>>(values));
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse() {
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}
		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationsByFalse());
		}
		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto var)
		{
			Notification notification = new Notification()
			{
				Description = var.Description,
				Icon = var.Icon,
				Status = false,
				Type = var.Type,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
			};
			_notificationService.TAdd(notification);
			return Ok("Ekleme işi başarıyla yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id) {
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim başarıyla silindi");
		}
		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto var)
		{
			var.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			var value = _mapper.Map<Notification>(var);
			_notificationService.TUpdate(value);
			return Ok("Bildirim alanı güncellendi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(value);
		}
		[HttpGet("NotificationChangeToFalse/{id}")]
		public IActionResult NotificationChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);
			return Ok("güncellendi");
		}
        [HttpGet("NotificationChangeToTrue/{id}")]
        public IActionResult NotificationChangeToTrue(int id)
        {
            _notificationService.TNotificationChangeToTrue(id);
            return Ok("güncellendi");
        }
    }
}
