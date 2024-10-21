using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _FooterPartial : ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
