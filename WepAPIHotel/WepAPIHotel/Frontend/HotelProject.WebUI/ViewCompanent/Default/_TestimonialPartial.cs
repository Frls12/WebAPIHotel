using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _TestimonialPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient(); // istemci oluşturdum
            var responseMessage = await client.GetAsync("http://localhost:5081/api/Testimonial"); //istekte bulundugum adress
            if (responseMessage.IsSuccessStatusCode) // adress ten başarılı bir durum kodu dönerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//gelen veriyi jesondata diye bir degişkene atadım
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);// json türündeki veriyide deserialize ederek tabloda gösterilecek formata dönüştürüm.
                return View(values);
            }
            return View();
        }
    }
}
