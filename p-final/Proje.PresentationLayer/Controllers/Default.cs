using Microsoft.AspNetCore.Mvc;

namespace Proje.PresentationLayer.Controllers
{
	public class Default : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
