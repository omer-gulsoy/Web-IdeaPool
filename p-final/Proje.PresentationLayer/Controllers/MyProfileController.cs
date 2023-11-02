using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.DtoLayer.Dtos.AppUserDtos;
using Proje.EntityLayer.Concrate;

namespace Proje.PresentationLayer.Controllers
{
	[Authorize]
	public class MyProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public MyProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			AppUserEditDto appUserEditDto = new AppUserEditDto();
			appUserEditDto.Name = values.Name;
			appUserEditDto.Surname = values.Surname;
			appUserEditDto.Username = values.UserName;
			appUserEditDto.SicilNo = values.SicilNo;
			appUserEditDto.Email = values.Email;
			appUserEditDto.PhoneNumber = values.PhoneNumber;
			return View(appUserEditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
		{
			if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = appUserEditDto.Name;
				user.Surname = appUserEditDto.Surname;
				user.UserName = appUserEditDto.Username;
				user.SicilNo = appUserEditDto.SicilNo;
				user.Email = appUserEditDto.Email;
				user.PhoneNumber = appUserEditDto.PhoneNumber;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}
