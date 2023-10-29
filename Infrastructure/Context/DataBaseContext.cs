using Application.Common.Interface;
using Domain.Entities;
using Infrastructure.Mapping.Register;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.Context
{
    public class DataBaseContext : IdentityDbContext, ISqlServer
    {


        public DataBaseContext(DbContextOptions<DataBaseContext> option) : base(option)
        {

        }
        public virtual DbSet<AboutEntity>? About { set; get; }
        public virtual DbSet<ScopeWorkEntity>? Scope { set; get; }
        public virtual DbSet<CompanyEntity>? Company { set; get; }
        public virtual DbSet<ProjectEntity>? Project { set; get; }
        public virtual DbSet<RequestEntity>? Request { set; get; }
        public virtual DbSet<StatusEntity>? Status { set; get; }
        public virtual DbSet<ServiceEntity>? Service { set; get; }
        public virtual DbSet<SettingEntity>? Setting { set; get; }
        public virtual DbSet<TeamEntity>? Team { set; get; }
     
        protected override void OnModelCreating(ModelBuilder builder)
        {

            RegisterMapping.AddMapping(builder);
            builder.HasDefaultSchema("Dy");
            base.OnModelCreating(builder);
        }
    }
}
