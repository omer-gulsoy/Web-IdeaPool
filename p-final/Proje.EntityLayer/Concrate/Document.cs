using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.EntityLayer.Concrate
{
	public class Document
	{
		public int DocumentId { get; set; }
		public bool Status { get; set; }
		public List<Idea> Ideas { get; set; }

	}
}
