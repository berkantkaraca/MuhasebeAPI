using MuhasebeAPI.Domain.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhasebeAPI.Domain.Entities.App;

public sealed class MainRole : BaseEntity
{
    public string? Title { get; set; }
    public bool IsRoleCreatedByAdmin { get; set; }

    [ForeignKey("Company")]
    public string? CompanyId { get; set; }
    public Company? Company { get; set; }
}
