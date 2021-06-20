using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
	public class ModelBaseClassLib : BaseModel
	{
		[Key]
		public new int ID { get; set; }

		public bool IsDeleted { get; set; } = false;


		public int InsertBy { get; set; }

		public DateTime InsertDateTime { get; set; } = DateTime.Now;


		public int UpdateBy { get; set; }

		public DateTime UpdateDateTime { get; set; }

		public int DeleteBy { get; set; }

		public DateTime DeleteDateTime { get; set; }
	}

}
