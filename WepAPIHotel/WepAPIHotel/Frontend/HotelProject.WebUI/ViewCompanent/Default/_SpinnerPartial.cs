using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ViewCompanent.Default
{
    public class _SpinnerPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke() { return View(); }
        
    }
}
