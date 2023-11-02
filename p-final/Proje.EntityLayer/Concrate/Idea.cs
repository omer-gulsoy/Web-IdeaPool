using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityLayer.Concrate
{
	public class Idea
	{
		public int IdeaId { get; set; }
		public int AppUserId { get; set; }
		public AppUser AppUser { get; set; }
		public string Baslik { get; set; }
		public string Icerik { get; set; }
		public string Fayda { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int DocumentId { get; set; }
		public Document Document { get; set; }
		public DateTime OlusturmaTarihi { get; set; }
		public bool Status { get; set; }
        public bool Karar { get; set; }
        public string YoneticiDegerlendirme { get; set; }
		[NotMapped]
        public IFormFile Doc { get; set; }
        public int Puan { get; set; }
    }
}
