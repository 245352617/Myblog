using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{

	public class M_User : EntityBase<int>
	{
		[MaxLength(20)]
		[Required]
		[Column("Name")]
		public string UserName { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("Password")]
		public string UserPassword { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("Sex")]
		public int Sex { get; set; }

		[Required]
		[Column("Birthday")]
		public DateTime Birthday { get; set; }

		[Column("BirthPlace")]
		public string BirthPlace { get; set; }

		[Column("Mail")]
		public string Mail { get; set; }

		[Column("QQ")]
		public int QQ { get; set; }

		[Column("State")]
		public UserState State { get; set; }

		[Column("Question")]
		public string Question { get; set; }

		[Column("Answer")]
		public string Answer { get; set; }

		[Column("BlogId")]
		public int BlogId { get; set; }

		[Column("ImageId")]
		public int ImageId { get; set; }

		[Column("UserTypeId")]
		public int UserTypeId { get; set; }
	}

	public enum UserState
	{
		NotReviewed,
		Approved,
		reject,
		Disable
	}


}
