using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ProjectMapping : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Project");
            builder.HasIndex(i => i.ProjectName);
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.Property(p => p.ProjectName).IsRequired()
                .HasMaxLength(300);
            builder.Property(p => p.Description)
                .IsRequired().HasMaxLength(1000);

            builder.HasMany(m => m.Service)
                .WithMany(m => m.Projects);

            builder.HasOne(o => o.Status)
                .WithMany(m => m.Projects)
                .HasForeignKey(f => f.StatusForeignKey);
      
        }
    }
}
