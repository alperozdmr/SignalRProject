﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApı.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCaseController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}
		[HttpGet]
		public IActionResult TotalOrderCount() {
			return Ok(_moneyCaseService.TTotalMoneyCaseAmount());
		}
	}
}
