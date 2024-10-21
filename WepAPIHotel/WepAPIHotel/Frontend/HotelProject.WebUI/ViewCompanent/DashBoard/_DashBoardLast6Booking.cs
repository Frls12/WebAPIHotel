using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.DashBoard
{
	public class _DashBoardLast6Booking : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashBoardLast6Booking(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()  // list
		{
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/Booking/Last6Booking"); //istekte bulundugum adress
			if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
				var values = JsonConvert.DeserializeObject<List<Last6BookingDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
				return View(values);
			}
			return View();
		}
	}
}
