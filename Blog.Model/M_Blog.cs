using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
	[Table("Blog")]
	public class M_Blog : EntityBase<int>
	{
		[MaxLength(20)]
		[Required]
		[Column("BlogName")]
		public string BlogName { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("BlogDescription")]
		public string BlogDescription { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("BlogLevel")]
		public int BlogLevel { get; set; }

		[Required]
		[Column("BlogIntegrate")]
		public DateTime BlogIntegrate { get; set; }

		[Column("BirthPlace")]
		public string BirthPlace { get; set; }

		[Column("ImageId")]
		public string ImageId { get; set; }

		[Column("BlogVisit")]
		public int BlogVisit { get; set; }
	}


}
