using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _ScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
