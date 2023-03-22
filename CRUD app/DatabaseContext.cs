using CRUD_app.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CRUD_app
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Provider> Providers { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{ 
			 
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Provider>().HasData(new List<Provider>
			{
				new Provider{ Id = 2, Name = "Leroy Merlin"},
				new Provider{ Id = 3, Name = "Норникель"},
				new Provider{ Id = 4, Name = "Роснефть"}
			});
		}
	}
}
