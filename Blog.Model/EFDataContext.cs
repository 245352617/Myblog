using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.Model
{
	public class EFDataContext : DbContext
	{
		public DbSet<M_ConfigKeys> ConfigKeys { get; set; }

		public DbSet<M_ConfigProject> ConfigProject { get; set; }

		public DbSet<M_Blog> Blog { get; set; }

		public DbSet<M_User> User { get; set; }

		public DbSet<M_UserType> UserType { get; set; }

		public EFDataContext()
		{
		}

		public EFDataContext(DbContextOptions option)
			: base(option)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySql("Server=81.71.1.133;Port=3306;Database=myblog;Uid=root;Pwd=123456;sslMode=None", new MySqlServerVersion(new Version(8, 0, 21))).EnableSensitiveDataLogging().EnableDetailedErrors();
			}
		}
	}


}
