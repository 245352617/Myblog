using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{

	public class M_UserType : EntityBase<int>
	{
		[MaxLength(20)]
		[Required]
		[Column("BlogName")]
		public string TypeName { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("TypeDescription")]
		public string TypeDescription { get; set; }

		[MaxLength(40)]
		[Required]
		[Column("BlogFriendId")]
		public Guid BlogFriendId { get; set; }

		[Required]
		[Column("FriendId")]
		public Guid FriendId { get; set; }

		[Required]
		[Column("HostId")]
		public Guid HostId { get; set; }
	}

}
