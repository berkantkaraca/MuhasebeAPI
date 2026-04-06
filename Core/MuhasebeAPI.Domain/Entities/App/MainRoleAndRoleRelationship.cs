using MuhasebeAPI.Domain.Abstractions;
using MuhasebeAPI.Domain.Entities.App.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhasebeAPI.Domain.Entities.App;

public sealed class MainRoleAndRoleRelationship : BaseEntity
{
    [ForeignKey("AppRole")]
    public string? RoleId { get; set; }
    public AppRole? AppRole { get; set; }

    [ForeignKey("MainRole")]
    public string? MainRoleId { get; set; }
    public MainRole? MainRole { get; set;}
}
