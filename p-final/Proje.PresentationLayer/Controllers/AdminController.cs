using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using Proje.DataAccessLayer.Concrete;
using Proje.EntityLayer.Concrate;

namespace Proje.PresentationLayer.Controllers
{
	[Authorize]
	public class AdminController : Controller
	{
		private readonly Context _context;

		public AdminController(Context context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ListUsers()
		{
			return View(_context.Users);
		}
		[HttpPost]
		public IActionResult ListUsers(AppUser appUser)
		{
			return RedirectToAction("Index", "Admin");
		}


		[HttpPost]
		public IActionResult Delete(int id)
		{
			var a = _context.Users.Find(id);
			_context.Users.Remove(a);
			_context.SaveChanges();
			return RedirectToAction("ListUsers", "Admin");
		}

		[HttpGet]
		public IActionResult UpdateUser(int id)
		{
			var guncellenecek = _context.Users.Find(id);
			return View(guncellenecek);
		}

		[HttpPost]
		public IActionResult UpdateUser(AppUser appUser)
		{
			var guncellenecek = _context.Users.Find(appUser.Id);
			guncellenecek.Status = appUser.Status;
			guncellenecek.IsAdmin = appUser.IsAdmin;
			_context.Users.Update(guncellenecek);
			_context.SaveChanges();
			return RedirectToAction("ListUsers", "Admin");
		}
	}
}
