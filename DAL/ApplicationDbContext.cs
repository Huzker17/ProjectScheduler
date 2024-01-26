using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL;
public class ApplicationDbContext : DbContext
{
	public DbSet<User> Users { get; set; }
	public DbSet<Project> Projects { get; set; }

	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Project>()
		.HasOne(p => p.HeadWorker)
		.WithMany()
		.HasForeignKey(p => p.UserId); 
		base.OnModelCreating(modelBuilder);
	}



}
