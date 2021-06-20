using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
	public class M_ConfigKeys : EntityBase<int>
	{
		[MaxLength(20)]
		[Required]
		[Column("ProjectId")]
		public Guid ProjectId { get; set; }

		[Required]
		[Column("Key")]
		public string Key { get; set; }

		[Required]
		[Column("Value")]
		public string Value { get; set; }
	}



}
