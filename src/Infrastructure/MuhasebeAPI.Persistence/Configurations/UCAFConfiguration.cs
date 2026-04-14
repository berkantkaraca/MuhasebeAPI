using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MuhasebeAPI.Domain.Entities.Company;
using MuhasebeAPI.Persistence.Constans;

namespace MuhasebeAPI.Persistence.Configurations;

public class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
{
    public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
    {
        builder.ToTable(TableNames.UniformChartOfAccounts);
        builder.HasKey(p => p.Id);
    }
}
