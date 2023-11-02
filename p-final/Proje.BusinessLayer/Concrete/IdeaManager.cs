using Proje.BusinessLayer.Abstract;
using Proje.DataAccessLayer.Abstract;
using Proje.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BusinessLayer.Concrete
{
	internal class IdeaManager : IIdeaService
	{
		private readonly IIdeaDal _ideaDal;

		public IdeaManager(IIdeaDal ideaDal)
		{
			_ideaDal = ideaDal;
		}

		public void TDelete(Idea t)
		{
			_ideaDal.Delete(t);
		}

		public Idea TGetByID(int id)
		{
			return _ideaDal.GetByID(id);
		}

		public List<Idea> TGetList()
		{
			return _ideaDal.GetList();
		}

		public void TInsert(Idea t)
		{
			_ideaDal.Insert(t);
		}

		public void TUpdate(Idea t)
		{
			_ideaDal.Update(t);
		}
	}
}
