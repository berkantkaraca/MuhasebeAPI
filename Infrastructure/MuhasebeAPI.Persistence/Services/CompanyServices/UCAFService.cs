using AutoMapper;
using MuhasebeAPI.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using MuhasebeAPI.Application.Repositories.CompanyDbContextRepositories.UCAFRepositories;
using MuhasebeAPI.Application.Services;
using MuhasebeAPI.Application.Services.CompanyServices;
using MuhasebeAPI.Application.UnitOfWorks;
using MuhasebeAPI.Domain.Entities.Company;
using MuhasebeAPI.Persistence.Contexts;

namespace MuhasebeAPI.Persistence.Services.CompanyServices;

public sealed class UCAFService : IUCAFService
{
    private readonly IUCAFCommandRepository _commandRepository;
    private readonly IUCAFQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IUCAFQueryRepository queryRepository)
    {
        _commandRepository = commandRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _queryRepository = queryRepository;
    }

    public async Task CreateUcafAsync(CreateUCAFCommandRequest request, CancellationToken cancellationToken)
    {
        CompanyDbContext _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId ?? string.Empty);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
        uniformChartOfAccount.Id = Guid.NewGuid().ToString();

        await _commandRepository.AddAsync(uniformChartOfAccount, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UniformChartOfAccount> GetByCode(string code, CancellationToken cancellationToken) 
        => (await _queryRepository.GetFirstByExpiressionAsync(p => p.Code == code, cancellationToken))!;
}
