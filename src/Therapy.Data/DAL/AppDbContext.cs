using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Therapy.Core.Models;

namespace Therapy.Data.DAL;

public class AppDbContext : IdentityDbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
	{

	}
	public DbSet<Therapist> Therapists { get; set; }
	public DbSet<Settings> Settings { get; set; }
	public DbSet<AppUser> users { get; set; }
}
