using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Proje.DataAccessLayer.Concrete;
using Proje.EntityLayer.Concrate;

namespace Proje.PresentationLayer.Controllers
{
	[Authorize]
	public class IdeaController : Controller
	{
		private readonly Context _context;

		public IdeaController(Context context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Idea idea)
		{
			idea.OlusturmaTarihi = DateTime.Now;
			idea.AppUserId = 8;/*değişmeli*/
			idea.DocumentId = 1;/*değişmeli*/
			idea.YoneticiDegerlendirme = "-";
			_context.Add(idea);
			_context.SaveChanges();

			return RedirectToAction("Index", "User");
		}

		public IActionResult List(string ara)
		{
			var model = _context.Ideas.ToList();
			if (!string.IsNullOrEmpty(ara))
			{
				model = model.Where(x => x.Baslik.Contains(ara)).ToList();
			}
			return View(model);
		}


		[HttpGet]
		public IActionResult UpdateIdea(int id)
		{
			var guncellenecek2 = _context.Ideas.Find(id);
			return View(guncellenecek2);
		}

		[HttpPost]
		public IActionResult UpdateIdea(Idea idea)
		{
			var guncellenecek2 = _context.Ideas.Find(idea.IdeaId);
			guncellenecek2.Status = idea.Status;
			guncellenecek2.Puan = idea.Puan;
			guncellenecek2.Karar= idea.Karar;
			guncellenecek2.YoneticiDegerlendirme = idea.YoneticiDegerlendirme;
			_context.Ideas.Update(guncellenecek2);
			_context.SaveChanges();
			return RedirectToAction("List", "Idea");
		}
        public IActionResult Doc() 
		{
			return View();
		}

        [HttpPost("FileUpload")]
        public async Task<ActionResult> Doc(List<IFormFile>files)
		{
			var size = files.Sum(f => f.Length);
			var filePaths=new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length>0)
                {
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), formFile.FileName);
					filePaths.Add(filePath);
					using (var stream = new FileStream(filePath, FileMode.Create))
					{
						await formFile.CopyToAsync(stream);
					}
                }
            }
			return Ok(new { files.Count, size, filePaths });
        }
    }
}
