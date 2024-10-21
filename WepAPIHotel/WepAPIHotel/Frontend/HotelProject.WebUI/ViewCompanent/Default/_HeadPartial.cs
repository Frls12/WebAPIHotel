using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _HeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
