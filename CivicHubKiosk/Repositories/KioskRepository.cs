using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Dtos;
using SharedLibrary.Application.Interface;
using SharedLibrary.Domain.Entities;

public class KioskRepository :
    IKioskRepository,
    IKioskReadRepository
{
    private readonly KioskDbContext _context;

    public KioskRepository(KioskDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(InvKioskDetail kiosk)
    {
        _context.Kiosks.Add(kiosk);
        await _context.SaveChangesAsync();
    }

    public async Task<List<KioskDto>> GetActiveAsync()
    {
        return await _context.Kiosks
            .Where(x => x.IsActive)
            .Select(x => new KioskDto
            {
                Id = x.Id,
                Location = x.Location
            })
            .ToListAsync();
    }

    public async Task<List<LanguageDto>> GetLanguagesAsync(int kioskId)
    {
        return await _context.KioskLanguages
            .Where(x => x.KioskId == kioskId)
            .Select(x => new LanguageDto
            {
                Id = x.Id,
                Language = x.Languages,
                LanguageCode = x.LanguageCode
            })
            .ToListAsync();
    }

    public async Task<List<DepartmentDto>> GetDepartmentsAsync()
    {
        return await _context.Departments
            .Select(x => new DepartmentDto
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName,
                DepartmentIcon = x.DepartmentIcon
            })
            .ToListAsync();
    }

    public async Task<List<ServiceDto>> GetServicesAsync(
        int kioskId, int? departmentId)
    {
        var query = _context.KioskServices
            .Where(x => x.KioskId == kioskId);

        if (departmentId.HasValue)
            query = query.Where(x => x.DepartmentId == departmentId);

        return await query
            .Select(x => new ServiceDto
            {
                Id = x.Id,
                ServiceName = x.ServiceName
            })
            .ToListAsync();
    }





}
