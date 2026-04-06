using AutoMapper;
using MuhasebeAPI.Application;
using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Application.Repositories.UCAFRepositories;
using MuhasebeAPI.Application.Services;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Domain.Entities.Company;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.Services.CompanyServices;

public sealed class UCAFService : IUCAFService
{
    private readonly IUCAFCommandRepository _commandRepository;
    private readonly IContextService _contextService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _commandRepository = commandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CreateUcafAsync(CreateUCAFCommandRequest request)
    {
        CompanyDbContext _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId ?? string.Empty);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
        uniformChartOfAccount.Id = Guid.NewGuid().ToString();

        await _commandRepository.AddAsync(uniformChartOfAccount);
        await _unitOfWork.SaveChangesAsync();
    }
}
