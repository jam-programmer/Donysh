using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ScopeWorkMapping : IEntityTypeConfiguration<ScopeWorkEntity>
    {
        public void Configure(EntityTypeBuilder<ScopeWorkEntity> builder)
        {
            builder.ToTable("ScopeWork");
            builder.Property(p => p.Title).IsRequired();
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.HasMany(m => m.Projects)
                .WithOne(o => o.ScopeWork)
                .HasForeignKey(f => f.ScopeForeignKey);
        }
    }
}
