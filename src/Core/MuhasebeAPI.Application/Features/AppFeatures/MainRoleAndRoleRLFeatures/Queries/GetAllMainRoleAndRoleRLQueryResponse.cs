using MuhasebeAPI.Domain.Entities.App;

namespace MuhasebeAPI.Application.Features.AppFeatures.MainRoleAndRoleRLFeatures.Queries;

public sealed record GetAllMainRoleAndRoleRLQueryResponse(List<MainRoleAndRoleRelationship> mainRoleAndRoleRelationships);
