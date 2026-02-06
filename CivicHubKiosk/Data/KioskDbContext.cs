using Microsoft.EntityFrameworkCore;
using SharedLibrary.Domain.Entities;
using System.Collections.Generic;

public class KioskDbContext : DbContext
{
    public KioskDbContext(DbContextOptions<KioskDbContext> options)
        : base(options) { }

    public DbSet<InvKioskDetail> Kiosks => Set<InvKioskDetail>();
    public DbSet<InvKioskLanguage> KioskLanguages => Set<InvKioskLanguage>();
    public DbSet<InvKioskDepartment> Departments => Set<InvKioskDepartment>();
    public DbSet<InvKioskService> KioskServices => Set<InvKioskService>();
    public DbSet<InvKioskTrackingDetail> KioskTrackingDetail => Set<InvKioskTrackingDetail>();
    public DbSet<InvKioskSessionUser> KioskSessionUser => Set<InvKioskSessionUser>();

}
