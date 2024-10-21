using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}
		[HttpGet]
		public IActionResult bookingList()
		{
			var values = _bookingService.TGetList();
			return Ok(values);
		}
        [HttpGet("{id}")]
        public IActionResult Getbooking(int id)
        {
            var values = _bookingService.TGetById(id);
            return Ok(values);
        }
        [HttpPost]
		public IActionResult Addbooking(Booking booking)
		{
			_bookingService.TInsert(booking);
			return Ok();
		}
		[HttpDelete]
		public IActionResult Deletebooking(int id)
		{
			var values = _bookingService.TGetById(id);
			_bookingService.TDelete(values);
			return Ok();
		}
		[HttpPut("Updatebooking")]
		public IActionResult Updatebooking(Booking booking)
		{
			_bookingService.TUpdate(booking);
			return Ok();
		}
		[HttpGet("status")]
		public IActionResult status(int id)
		{
			_bookingService.TBookingStatusChangeApproved(id);
			return Ok();
		}
        [HttpGet("statusCancel")]
        public IActionResult statusCancel(int id)
        {
            _bookingService.TBookingStatusChangeCancel(id);
            return Ok();
        }
        [HttpGet("statusWait")]
        public IActionResult statusWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok();
        }
        [HttpGet("Last6Booking")]
		public IActionResult Last6Booking()
		{
			var values = _bookingService.TLast6Booking();
			return Ok(values);
		}
	}
}
