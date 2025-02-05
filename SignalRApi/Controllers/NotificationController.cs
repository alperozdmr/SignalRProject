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

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotificationList() {
			return Ok(_notificationService.TGetListAll());
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
			Notification Notification = new Notification
			{
				NotificationID = var.NotificationID,
				Icon = var.Icon,
				Status = var.Status,
				Type = var.Type,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Description = var.Description,	
			};
			_notificationService.TUpdate(Notification);
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
