using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proje.EntityLayer.Concrate;
using Proje.PresentationLayer.Models;

namespace Proje.PresentationLayer.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, false);
			if (result.Succeeded)
			{
				var user=await _userManager.FindByNameAsync(loginViewModel.Username);
				if(user.Status==true)
				{

					if (user.IsAdmin == true)
					{
						return RedirectToAction("Index", "Admin");
					}
					return RedirectToAction("Index", "User");
				}
                else
				{
					return RedirectToAction("Index", "Login");
				}
            }
			return View();
		}
	}
}
