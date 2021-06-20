using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.Model
{
	public abstract class EntityBase<T> : IEntity
	{
		public virtual T ID { get; set; }
	}

}
