using HotelProject.WebUI.Dtos.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _AboutUsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {

            var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5081/api/About"); //istekte bulundugum adress
            if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
                return View(values);
            }
            return View();
        }
    
    }
}
