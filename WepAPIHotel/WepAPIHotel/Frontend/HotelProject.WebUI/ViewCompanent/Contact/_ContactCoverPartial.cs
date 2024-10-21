using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewCompanent.Contact
{
    public class _ContactCoverPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
