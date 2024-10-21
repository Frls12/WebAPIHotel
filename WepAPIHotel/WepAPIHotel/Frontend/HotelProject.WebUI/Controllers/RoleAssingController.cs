using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HotelProject.WebUI.Controllers
{
	public class RoleAssingController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		public RoleAssingController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			var value = _userManager.Users.ToList();
			return View(value);
		}
		[HttpGet]
		public async Task<IActionResult> AssignRole(int id)
		{
			var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
			TempData["UserId"] = user.Id;
			var roles = _roleManager.Roles.ToList();
			var userRoles = await _userManager.GetRolesAsync(user);
			List<AssingRoleVİewModel> assingRoleVİewModels = new List<AssingRoleVİewModel>();
			foreach (var item in roles)
			{
				AssingRoleVİewModel model = new AssingRoleVİewModel();
				model.RoleId = item.Id;
				model.RoleName = item.Name;
				model.RoleExits = userRoles.Contains(item.Name);
				assingRoleVİewModels.Add(model);

			}
			return View(assingRoleVİewModels);

		}
		[HttpPost]
		public async Task<IActionResult> AssignRole(List<AssingRoleVİewModel> assingRoleVİewModel)
		{
			var userid = (int)TempData["UserId"];
			var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
			foreach (var item in assingRoleVİewModel)
			{
				if (item.RoleExits)
				{
					await _userManager.AddToRoleAsync(user, item.RoleName);
				}
				else
				{
					await _userManager.RemoveFromRoleAsync(user, item.RoleName);

			    }
			}
			return RedirectToAction("Index");
		}

	}
}
