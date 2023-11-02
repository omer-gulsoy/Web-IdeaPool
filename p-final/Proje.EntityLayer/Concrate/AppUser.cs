using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityLayer.Concrate
{
	public class AppUser:IdentityUser<int>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
        public string SicilNo { get; set; }
        public bool IsAdmin { get; set; }
        public bool Status { get; set; }
        public List<Idea> Ideas { get; set; }

	}
}
