using MuhasebeAPI.Application.Exceptions;
using MuhasebeAPI.Application.Messaging.Command;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Domain.Entities.Company;

namespace MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

public sealed class CreateUCAFCommandHandler : ICommandHandler<CreateUCAFCommandRequest, CreateUCAFCommandResponse>
{
    private readonly IUCAFService _ucafService;

    public CreateUCAFCommandHandler(IUCAFService ucafService)
    {
        _ucafService = ucafService;
    }

    public async Task<CreateUCAFCommandResponse> Handle(CreateUCAFCommandRequest request, CancellationToken cancellationToken)
    {
        UniformChartOfAccount ucaf = await _ucafService.GetByCode(request.Code);

        if (ucaf != null)
            throw new ConflictException("Bu hesap planı kodu daha önce tanımlanmış!");

        await _ucafService.CreateUcafAsync(request, cancellationToken);
        return new();
    }
}
