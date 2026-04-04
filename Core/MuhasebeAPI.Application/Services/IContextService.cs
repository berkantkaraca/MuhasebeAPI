using Microsoft.EntityFrameworkCore;

namespace MuhasebeAPI.Application.Services;

public interface IContextService
{
    /// <summary>
    /// DB instance türetir. Şirket bazlı çalıştığımız için şirket id'sine göre db instance'ı türetiriz.
    /// </summary>
    /// <param name="companyId">Şirket id</param>
    /// <returns></returns>
    DbContext CreateDbContextInstance(string companyId);
}
