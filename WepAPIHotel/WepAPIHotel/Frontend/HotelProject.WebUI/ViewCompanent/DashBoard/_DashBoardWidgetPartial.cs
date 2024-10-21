using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.DashBoard
{
	public class _DashBoardWidgetPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashBoardWidgetPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/DashBoardWidget/StaffCount"); //istekte bulundugum adress
			var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım

			var client2 = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage2 = await client2.GetAsync("http://localhost:5081/api/DashBoardWidget/BookingCount"); //istekte bulundugum adress
			var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım

			var client3 = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage3 = await client3.GetAsync("http://localhost:5081/api/DashBoardWidget/UserCount"); //istekte bulundugum adress
			var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım

			var client4 = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage4 = await client4.GetAsync("http://localhost:5081/api/DashBoardWidget/RoomCount"); //istekte bulundugum adress
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım


			ViewBag.StaffCount = jsonData;
			ViewBag.BookingCount = jsonData2;
			ViewBag.UserCount = jsonData3;
			ViewBag.RoomCount = jsonData4;
			
			return View();
		}
	}
}
