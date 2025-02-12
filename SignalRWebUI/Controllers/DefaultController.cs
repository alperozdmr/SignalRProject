using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.MessageDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index() { 


		// BU KODU YORUM SATIRINDAN ÇIKARICAKSAN ÖNCE CONTACTTAKİ LOCATION DEĞERİNİ İNDEXTEKİ İFRAME
		// İÇİNDEKİ LOCATİONI KULLAN . ŞUANKİ HALİ STATİK ÇALIŞIYOR.
		//	HttpClient client = new HttpClient();
		//	HttpResponseMessage response = await client.GetAsync("https://localhost:7110/api/Contact");
		//	response.EnsureSuccessStatusCode();
		//	string responseBody = await response.Content.ReadAsStringAsync();
		//	JArray item = JArray.Parse(responseBody);
		//	string value = item[0]["location"].ToString();  BU KODUN ÖNEMLİ KISMI BU SATIR 
		//	ViewBag.location = value;
			return View();
		}
		[HttpGet]
		public PartialViewResult SendMessage()
		{
			return PartialView();
		}
		[HttpPost]
		public async Task<IActionResult> SendMessage(CreateMessageDto var)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(var);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7110/api/Message", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
