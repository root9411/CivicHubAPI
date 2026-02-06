using MediatR;
using SharedLibrary.Application.Dtos;

public record GetActiveKiosksQuery : IRequest<List<KioskDto>>;
public record GetLanguagesQuery(int KioskId) : IRequest<List<LanguageDto>>;
public record GetDepartmentsQuery : IRequest<List<DepartmentDto>>;
public record GetServicesQuery(int KioskId, int? DepartmentId) : IRequest<List<ServiceDto>>;