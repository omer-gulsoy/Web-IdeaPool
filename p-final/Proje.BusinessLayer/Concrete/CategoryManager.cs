using Proje.DataAccessLayer.Abstract;
using Proje.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryDal
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void Delete(Category t)
		{
			_categoryDal.Delete(t);
		}

		public Category GetByID(int id)
		{
			return _categoryDal.GetByID(id);
		}

		public List<Category> GetList()
		{
			return _categoryDal.GetList();
		}

		public void Insert(Category t)
		{
			_categoryDal.Insert(t);
		}

		public void Update(Category t)
		{
			_categoryDal.Update(t);
		}
	}
}
