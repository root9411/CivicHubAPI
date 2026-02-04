using MediatR;

public record CreateKioskCommand(
    string Location,
    string IPAddress
) : IRequest<int>;
