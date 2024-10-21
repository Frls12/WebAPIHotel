using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Inbox()  // list
        {
            var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5081/api/Contact"); //istekte bulundugum adress

            var client2 = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage2 = await client2.GetAsync("http://localhost:5081/api/Contact/GetContactCount"); //istekte bulundugum adress

			var client3 = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage3 = await client3.GetAsync("http://localhost:5081/api/SendMessage/GetSendMessageCount"); //istekte bulundugum adress

			if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
                var values = JsonConvert.DeserializeObject<List<ResultContactDtocs>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.ContactCount = jsonData2;

				var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
				ViewBag.SendMessageCount = jsonData3;

				return View(values);
            }
            return View();
        }
		public async Task<IActionResult> Sendbox()  // list
		{
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/SendMessage"); //istekte bulundugum adress
			if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
				var values = JsonConvert.DeserializeObject<List<ResultSendMessageDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult AddSendMessage()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddSendMessage(CreateSendMessageDto model)
		{
            model.SenderName = "Admin";
            model.SenderMail = "Admin@gmail.com";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(model);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("http://localhost:5081/api/SendMessage", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Inbox");
			}
			return View();
		}
		public PartialViewResult SiderBarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SiderBarAdminCategoryPartial()
        {
            return PartialView();
        }
        [HttpGet]
		public async Task<IActionResult> MessageDetailsBySendbox(int id)
		{
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5081/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5081/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
