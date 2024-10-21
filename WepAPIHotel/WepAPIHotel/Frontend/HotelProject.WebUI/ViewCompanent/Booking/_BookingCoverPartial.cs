using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.Booking
{
	public class _BookingCoverPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
