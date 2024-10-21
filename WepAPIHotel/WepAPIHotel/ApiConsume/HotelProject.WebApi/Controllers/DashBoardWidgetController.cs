using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DashBoardWidgetController : ControllerBase
	{
		private readonly IStaffService _staffService;
		private readonly IBookingService _bookingService;
		private readonly IUserService _userService;
		private readonly IRoomService _RoomService;
		public DashBoardWidgetController(IStaffService staffService, IBookingService bookingService, IUserService userService, IRoomService roomService)
		{
			_staffService = staffService;
			_bookingService = bookingService;
			_userService = userService;
			_RoomService = roomService;
		}
		[HttpGet("StaffCount")]
		public IActionResult StaffCount()
		{
			var values = _staffService.TGetStaffCount();
			return Ok(values);
		}

		[HttpGet("BookingCount")]
		public IActionResult BookingCount()
		{
			var values = _bookingService.TGetBookingCount();
			return Ok(values);
		}

		[HttpGet("UserCount")]
		public IActionResult UserCount()
		{
			var values = _userService.TGetUserCount();
			return Ok(values);
		}

		[HttpGet("RoomCount")]
		public IActionResult RoomCount()
		{
			var values = _RoomService.TGetRoomCount();
			return Ok(values);
		}
	}
}

