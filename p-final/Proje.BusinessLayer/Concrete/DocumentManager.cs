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
	public class DocumentManager : IDocumentService
	{
		private readonly IDocumentDal _documentDal;

		public DocumentManager(IDocumentDal documentDal)
		{
			_documentDal = documentDal;
		}

		public void TDelete(Document t)
		{
			_documentDal.Delete(t);
		}

		public Document TGetByID(int id)
		{
			return _documentDal.GetByID(id);
		}

		public List<Document> TGetList()
		{
			return _documentDal.GetList();
		}

		public void TInsert(Document t)
		{
			_documentDal.Insert(t);
		}

		public void TUpdate(Document t)
		{
			_documentDal.Update(t);
		}
	}
}
