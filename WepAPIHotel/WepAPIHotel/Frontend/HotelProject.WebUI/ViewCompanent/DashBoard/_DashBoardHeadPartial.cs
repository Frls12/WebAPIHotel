using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.DashBoard
{
	public class _DashBoardHeadPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
