using MuhasebeAPI.Domain.Abstractions;

namespace MuhasebeAPI.Domain.Entities.Company;

/// <summary>
/// Hesap planlarını tutar.
/// </summary>
public sealed class UniformChartOfAccount : BaseEntity
{
    public string? Code { get; set; }
    public string? Name { get; set; }
    public char Type { get; set; } // A: Ana Frup, G: Grup, M: Muavin
}
