using HotelProject.WebUI.Dtos.WorkLocationDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
	public class WorkLocationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public WorkLocationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()  // list
		{
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/WorkLocation"); //istekte bulundugum adress
			if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
				var values = JsonConvert.DeserializeObject<List<ResultWorkLocalDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddWorkLocation()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddWorkLocation(CreateWorkLocationDto createWorkLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createWorkLocationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5081/api/WorkLocation", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteWorkLocation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessagese = await client.DeleteAsync($"http://localhost:5081/api/WorkLocation/{id}");
			if (responseMessagese.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateWorkLocation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"http://localhost:5081/api/WorkLocation/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateWorkLocationDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateWorkLocation(UpdateWorkLocationDto model)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("http://localhost:5081/api/WorkLocation", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
