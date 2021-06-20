using Blog.Interface;
using Blog.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Services
{
	public class BlogService : IBlog
	{
		public M_Blog GetBlog(int id)
		{
			BaseService _baseService = new BaseService();
			return _baseService.Find<M_Blog>(id);
		}

		public List<M_Blog> GetAllBlog()
		{
			BaseService _baseService = new BaseService();
			return _baseService.Query((M_Blog P) => true).ToList();
		}
	}


}
