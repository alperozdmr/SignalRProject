using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet]
        [Route("List")]
        public IActionResult BookingList() {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CreateBooking(CreateBookingDto var)
        {
            Booking booking = new Booking
            {
                Mail = var.Mail,
                Date = var.Date,
                Name = var.Name,
                PersonCount = var.PersonCount,
                Phone = var.Phone,
                Description = var.Description,
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi");
        }
        [HttpPut]
        //[Route("Update")]
        public IActionResult UpdateBooking(UpdateBookingDto var)
        {
            Booking booking = new Booking
            {
                BookingID = var.BookingID,
                Mail = var.Mail,
                Date = var.Date,
                Name = var.Name,
                PersonCount = var.PersonCount,
                Phone = var.Phone,
                Description= var.Description,   
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }
        [HttpGet("{id}")]
        //[Route("Get")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);   
        }
		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_bookingService.BookingStatusApproved(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingService.BookingStatusCancelled(id);
			return Ok("Rezervasyon Açıklaması Değiştirildi");
		}
	}
}
