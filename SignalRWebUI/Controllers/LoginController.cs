using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDto;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto var)
		{
			var result = await _signInManager.PasswordSignInAsync(var.Username, var.Password,false,false);
			if (result.Succeeded) {
				return RedirectToAction("Index","Category");
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index","Login");
		}
	}
}
