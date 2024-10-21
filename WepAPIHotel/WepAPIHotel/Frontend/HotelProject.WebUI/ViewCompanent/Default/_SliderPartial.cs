using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _SliderPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
