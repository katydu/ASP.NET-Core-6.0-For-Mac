using System;
using Microsoft.EntityFrameworkCore;
using TestForMac.Models;

namespace TestForMac.Data;

public class ApplicationDbContext : DbContext
{
	// basic config for connect the entity framework
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}

	public DbSet<Category> Categories { get; set; }
}

