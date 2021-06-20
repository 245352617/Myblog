using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
	public abstract class BaseModel
	{
		[Key]
		public int ID { get; set; }
	}
}
