using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet]
        //public IActionResult UserListWithWorkLocation()
        //{
        //    var values = _userService.TUserListWithWorkLocation();
        //    return Ok(values);
        //}
        [HttpGet]
        public IActionResult UserList()
        {
            Context context= new Context();
			var values = context.Users.Include(x=>x.WorkLocation).Select(y=>new UserWorkLocationViewModel
            {
                Name = y.Name,
                SurName = y.SurName,
                Gender = y.Gender,
                City    = y.City,
                Country= y.Country,
                ImageUrl= y.ImageUrl,
                WorkLocationId= y.WorkLocationId,
                WorkLocationName =y.WorkLocation.WorkLocationName
            }).ToList();
			
            return Ok(values);
        }
    }
}
