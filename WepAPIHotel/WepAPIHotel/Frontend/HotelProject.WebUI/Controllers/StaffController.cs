using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{

    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        public async Task<IActionResult> Index()  // list
        {
            var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5081/api/Staff"); //istekte bulundugum adress
            if(responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5081/api/Staff",stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessagese = await client.DeleteAsync($"http://localhost:5081/api/Staff/{id}");
            if(responseMessagese.IsSuccessStatusCode) 
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5081/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5081/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
    }

