using Microsoft.EntityFrameworkCore;
using SharedLibrary.Domain.Domain.Entities;
using SharedLibrary.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class CivicHubDbContext : DbContext
{
    public CivicHubDbContext(DbContextOptions<CivicHubDbContext> options)
        : base(options)
    {
    }

    public DbSet<InvKioskDetail> InvKioskDetail { get; set; }
    public DbSet<InvKioskLanguage> InvKioskLanguage { get; set; }
    public DbSet<InvKioskDepartment> InvKioskDepartment { get; set; }
    public DbSet<InvKioskService> InvKioskService { get; set; }
    public DbSet<InvKioskSessionUser> InvKioskSessionUser { get; set; }
    public DbSet<InvKioskTrackingDetail> InvKioskTrackingDetail { get; set; }

    // Page related entities
    public DbSet<InvPage> InvPages { get; set; }
    public DbSet<PageSection> PageSections { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<SectionComponent> SectionComponents { get; set; }
    public DbSet<ComponentContent> ComponentContent { get; set; }

    public DbSet<InvLanguageList> InvLanguageList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CivicHubDbContext).Assembly);
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<InvPage>()
            .HasIndex(p => p.PageKey)
            .IsUnique();
    }
}
