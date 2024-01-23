using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace School.Domain.Data
{
	public class SchoolDbContext : DbContext
	{
		private readonly IConfiguration Configuration;
		public SchoolDbContext(DbContextOptions<SchoolDbContext> options, IConfiguration configuration) : base(options) 
		{
			Configuration = configuration;
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBConnections"));
			}
		}
		public DbSet<Models.School> Schools
		{
			get;
			set;
		}
		
	}
}
