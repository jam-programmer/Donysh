using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interface
{
    public interface ISqlServer
    {
        DbSet<AboutEntity>? About { get; }
        DbSet<CategoryEntity>? Category { get; }
        DbSet<CompanyEntity>? Company { get; }
        DbSet<ProjectEntity>? Project { get; }
        DbSet<RequestEntity>? Request { get; }
        DbSet<StatusEntity>? Status { get; }
        DbSet<ServiceEntity>? Service { get; }
        DbSet<SettingEntity>? Setting { get; }
        DbSet<TeamEntity>? Team { get; }
      
    }
}
