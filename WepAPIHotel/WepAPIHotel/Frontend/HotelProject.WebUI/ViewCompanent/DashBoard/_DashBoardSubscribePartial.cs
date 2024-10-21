using HotelProject.WebUI.Dtos.DashBoardSubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewCompanent.DashBoard
{
	public class _DashBoardSubscribePartial : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{

			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofile/kemalsnr_12"),
				Headers =
			{
			{ "X-RapidAPI-Key", "2acc8fe388mshd5e46c39451d126p144d15jsn0b3783db0173" },
			{ "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
			},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				ResultSubscribeInstagramDto resultSubscribeInstagramDtos = JsonConvert.DeserializeObject<ResultSubscribeInstagramDto>(body);
				ViewBag.instagram1 = resultSubscribeInstagramDtos.followers;
				ViewBag.instagram2 = resultSubscribeInstagramDtos.following;

			}


			var client2 = new HttpClient();
			var request2 = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://twitter32.p.rapidapi.com/getProfile?username=kemalsnr12"),
				Headers =
	        {
		    { "X-RapidAPI-Key", "2acc8fe388mshd5e46c39451d126p144d15jsn0b3783db0173" },
		    { "X-RapidAPI-Host", "twitter32.p.rapidapi.com" },
	        },
			};
			using (var response2 = await client2.SendAsync(request2))
			{
				response2.EnsureSuccessStatusCode();
				var body = await response2.Content.ReadAsStringAsync();
				ResultSubscribeTwitterDto resultSubscribeTwitterDto = JsonConvert.DeserializeObject<ResultSubscribeTwitterDto>(body);
				ViewBag.Twitter1 = resultSubscribeTwitterDto.data.user_info.followers_count;
				ViewBag.Twitter2 = resultSubscribeTwitterDto.data.user_info.friends_count;
			}
			return View();
		}
	}
}
