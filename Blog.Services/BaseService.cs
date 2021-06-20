using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Blog.Services
{
	public class BaseService : IDisposable
	{
		private EFDataContext eFDataContext = new EFDataContext();

		public void Dispose()
		{
			if (eFDataContext != null)
			{
				eFDataContext.Dispose();
			}
		}

		public T Find<T>(int id) where T : class
		{
			return eFDataContext.Set<T>().Find(id);
		}

		public IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return eFDataContext.Set<T>().Where(expression);
		}

		public IEnumerable<T> Query<T>(Expression<Func<T, bool>> expression) where T : class
		{
			return eFDataContext.Set<T>().Where(expression);
		}
	}

}
