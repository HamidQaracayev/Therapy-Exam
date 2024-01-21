using Microsoft.EntityFrameworkCore;
using Therapy.Core.Models;

namespace Therapy.Data.DAL;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{

	}
	public DbSet<Therapist> Therapists { get; set; }
	public DbSet<Settings> Settings { get; set; }
}
