using Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public class LeadContext : DbContext
{
    public DbSet<LeadModel> Leads { get; set; }
    public DbSet<LeadImageModel> LeadImages { get; set; }

    public LeadContext(DbContextOptions<LeadContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeadModel>().Property(x => x.Status).HasConversion<int>();
        modelBuilder.Entity<LeadModel>().Property(x => x.Source).HasConversion<int>();
        modelBuilder.Entity<LeadModel>().HasMany<LeadImageModel>(x=>x.LeadImages).WithOne().HasForeignKey(x=>x.LeadId);
        base.OnModelCreating(modelBuilder);
    }
}