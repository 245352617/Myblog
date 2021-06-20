using Blog.Model;
using System;
using System.Collections.Generic;

namespace Blog.Interface
{
	public interface IBlog
	{
		M_Blog GetBlog(int id);

		List<M_Blog> GetAllBlog();
	}

}
