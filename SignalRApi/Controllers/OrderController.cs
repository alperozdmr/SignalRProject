using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderSevice;

		public OrderController(IOrderService orderSevice)
		{
			_orderSevice = orderSevice;
		}

		[HttpGet("TotalOrderCount")]
		public IActionResult TotalOrderCount() {
			return Ok(_orderSevice.TTotalOrderCount());
		}

		[HttpGet("ActiveOrderCount")]
		public IActionResult ActiveOrderCount()
		{
			return Ok(_orderSevice.TActiveOrderCount());
		}
		[HttpGet("ActiveOrderCountByStatus")]
		public IActionResult ActiveOrderCountByStatus()
		{
			return Ok(_orderSevice.TActiveOrderCountByStatus());
		}
		[HttpGet("LastOrderPrice")]
		public IActionResult LastOrderPrice()
		{
			return Ok(_orderSevice.TLastOrderPrice());
		}
		[HttpGet("TodayTotalPrice")]
		public IActionResult TodayTotalPrice ()
		{
			return Ok(_orderSevice.TTodayTotalPrice());
		}
	}
}
