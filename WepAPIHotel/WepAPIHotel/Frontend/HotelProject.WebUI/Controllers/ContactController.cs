using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/MessageCategory"); //istekte bulundugum adress

		    var jsonData = await responseMessage.Content.ReadAsStringAsync();  
		    var values = JsonConvert.DeserializeObject<List<ResultMessageCategoryDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.MessageCategoryName,
                                                Value = x.MessageCategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;
            return View();
        }
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {
            createContactDto.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:5081/api/Contact", stringContent);

            return RedirectToAction("Index");
        }
    }
}
