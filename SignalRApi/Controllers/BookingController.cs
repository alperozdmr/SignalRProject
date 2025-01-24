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
        [HttpPost]
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
            };
            _bookingService.TAdd(booking);
            return Ok("Rezervasyon yapıldı");
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok("Rezervasyon silindi");
        }
        [HttpPost]
        [Route("Update")]
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
            };
            _bookingService.TUpdate(booking);
            return Ok("Rezervasyon güncellendi");
        }
        [HttpPost]
        [Route("Get")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);   
        }
    }
}
