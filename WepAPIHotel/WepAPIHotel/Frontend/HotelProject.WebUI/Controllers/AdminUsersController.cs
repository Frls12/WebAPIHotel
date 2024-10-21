using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Dtos.UserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HotelProject.WebUI.Controllers
{
	public class AdminUsersController : Controller
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        //private readonly UserManager<AppUser> _userManager;

        //public AdminUsersController(UserManager<AppUser> userManager)
        //{
        //	_userManager = userManager;
        //}

        //public IActionResult Index()
        //{
        //	var values = _userManager.Users.ToList();
        //	return View(values);
        //}
        public async Task<IActionResult> UserList()  // list
        {
            var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5081/api/User"); //istekte bulundugum adress
            if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
                var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
                return View(values);
            }
            return View();
        }
    }
}
