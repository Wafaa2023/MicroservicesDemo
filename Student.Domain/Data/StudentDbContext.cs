using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Student.Domain.Data
{
	public class StudentDbContext : DbContext
	{
		private readonly IConfiguration Configuration;
		public StudentDbContext(DbContextOptions<StudentDbContext> options, IConfiguration configuration) : base(options)
		{
			Configuration = configuration;
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DBConnections"));
			}
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
		public DbSet<Student.Domain.Models.Student> Students
		{
			get;
			set;
		}
	}
}
