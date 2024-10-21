using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	public class SettingController : Controller
	{ 
		private readonly UserManager<AppUser> _userManager;

		public SettingController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditViewModel userEditViewModel = new UserEditViewModel();
			userEditViewModel.Name = user.Name;
            userEditViewModel.Surname = user.SurName;
            userEditViewModel.Username = user.UserName;
            userEditViewModel.Email = user.Email;
		
			
			return View(userEditViewModel);
		}
		[HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			if(userEditViewModel.Password == userEditViewModel.ConfirmPassword)
			{
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
           
				user.Name = userEditViewModel.Name;
                user.SurName = userEditViewModel.Surname;
                user.Email = userEditViewModel.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel.Password);
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index","Login");
            }
			return View();
		}

    }
}
