using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.DashBoard
{
	public class _DashBoardLast4Staff : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashBoardLast4Staff(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()  // list
		{
			var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
			var responseMessage = await client.GetAsync("http://localhost:5081/api/Staff/Last4StaffList"); //istekte bulundugum adress
			if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
				var values = JsonConvert.DeserializeObject<List<StaffLast4List>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
				return View(values);
			}
			return View();
		}
	}
}
