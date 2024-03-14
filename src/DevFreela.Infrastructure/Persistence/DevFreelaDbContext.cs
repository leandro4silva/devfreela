using DevFreela.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DevFreela.Infrastructure.Persistence;

public class DevFreelaDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<UserSkill> UserSkills { get; set; }
    public DbSet<ProjectComment> Comments { get; set; }

    public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
    }
}
