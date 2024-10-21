using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	public class RoleController : Controller
	{
		private readonly RoleManager<AppRole> _roleManager;
		public RoleController(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}
		public IActionResult Index()
		{
			var values = _roleManager.Roles.ToList();
			return View(values);
		}
		[HttpGet]
        public IActionResult RoleAdd()
        {
            return View();
        }
		[HttpPost]
        public async Task<IActionResult> RoleAdd(CreateRoleViewModel createRoleDtoViewModel)
        {
			AppRole appRole = new AppRole()
			{
				Name = createRoleDtoViewModel.RoleName
			};
			var result = await _roleManager.CreateAsync(appRole);
			if(result.Succeeded)
			{
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RoleDelete(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
			await _roleManager.DeleteAsync(value);
            return RedirectToAction("Index");
        }
		[HttpGet]
        public async Task<IActionResult> RoleUpdate(int id)
		{
			var value = _roleManager.Roles.FirstOrDefault(x=>x.Id == id);
			UpdateRoleViewModel updateRoleViewModel = new UpdateRoleViewModel()
			{
				RoleId = value.Id,
				RoleName = value.Name
			};
			return View(updateRoleViewModel);

		}
		[HttpPost]
        public async Task<IActionResult> RoleUpdate(UpdateRoleViewModel updateRoleViewModel)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleViewModel.RoleId);
			value.Name = updateRoleViewModel.RoleName;
			var result = await _roleManager.UpdateAsync(value);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
          

        }

    }
}
