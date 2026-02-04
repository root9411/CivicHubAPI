using Microsoft.EntityFrameworkCore;
using SharedLibrary.Domain.Entities;
using System.Collections.Generic;

public class KioskDbContext : DbContext
{
    public KioskDbContext(DbContextOptions<KioskDbContext> options)
        : base(options) { }

    public DbSet<InvKioskDetail> Kiosks => Set<InvKioskDetail>();
    public DbSet<KioskLanguage> KioskLanguages => Set<KioskLanguage>();
    public DbSet<KioskDepartment> Departments => Set<KioskDepartment>();
    public DbSet<KioskService> KioskServices => Set<KioskService>();
}
