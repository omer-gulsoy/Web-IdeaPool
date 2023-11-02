using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityLayer.Concrate
{
	public class Category
	{
		public int CategoryId { get; set; }
		public bool Status { get; set; }
		public string CategoryName { get; set; }
		public List<Idea> Ideas { get; set; }

	}
}
