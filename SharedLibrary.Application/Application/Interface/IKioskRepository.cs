using SharedLibrary.Application.Dtos;
using SharedLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Interface
{
    public interface IKioskRepository
    {
        Task AddAsync(InvKioskDetail kiosk);
    }

    public interface IKioskReadRepository
    {
        Task<List<KioskDto>> GetActiveAsync();
        Task<List<LanguageDto>> GetLanguagesAsync(int kioskId);
        Task<List<DepartmentDto>> GetDepartmentsAsync();
        Task<List<ServiceDto>> GetServicesAsync(int kioskId, int? departmentId);
    }


}
