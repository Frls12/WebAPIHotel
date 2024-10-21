using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;
        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }
        [HttpGet]
        public IActionResult guestList()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult Addguest(Guest guest)
        {
            _guestService.TInsert(guest);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deleteguest(int id)
        {
            var values = _guestService.TGetById(id);
            _guestService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult Updateguest(Guest guest)
        {
            _guestService.TUpdate(guest);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult Getguest(int id)
        {
            var values = _guestService.TGetById(id);
            return Ok(values);
        }
    }
}
