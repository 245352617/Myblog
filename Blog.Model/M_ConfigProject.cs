using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{

	public class M_ConfigProject : EntityBase<int>
	{
		[MaxLength(20)]
		[Required]
		[Column("Code")]
		public string Code { get; set; }
	}


}
