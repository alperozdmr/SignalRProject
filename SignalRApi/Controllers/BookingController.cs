using AutoMapper;
using FluentValidation;
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
        private readonly IMapper _mapper;
        private readonly IValidator<CreateBookingDto> _validator;


        public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
        {
            _bookingService = bookingService;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        [Route("List")]
        public IActionResult BookingList() {
            var values = _bookingService.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult CreateBooking(CreateBookingDto var)
        {
            var validationResult = _validator.Validate(var);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var value = _mapper.Map<Booking>(var);
            _bookingService.TAdd(value);
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
