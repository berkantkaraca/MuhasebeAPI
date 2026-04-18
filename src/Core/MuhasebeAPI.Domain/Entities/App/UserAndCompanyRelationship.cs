using MuhasebeAPI.Domain.Abstractions;
using MuhasebeAPI.Domain.Entities.App.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuhasebeAPI.Domain.Entities.App;

public class UserAndCompanyRelationship : BaseEntity
{
    public UserAndCompanyRelationship()
    {
    }

    public UserAndCompanyRelationship(string id, string appUserId, string companyId) : base(id)
    {
        AppUserId = appUserId;
        CompanyId = companyId;
    }

    [ForeignKey("AppUser")]
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }


    [ForeignKey("Company")]
    public string? CompanyId { get; set; }
    public Company? Company { get; set; }
}
