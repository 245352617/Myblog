using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class UniqueAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			return true;
		}
	}

}
