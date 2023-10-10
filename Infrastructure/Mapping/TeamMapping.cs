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
    public class TeamMapping : IEntityTypeConfiguration<TeamEntity>
    {
        public void Configure(EntityTypeBuilder<TeamEntity> builder)
        {
            builder.ToTable("Team");
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.Property(p => p.FullName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.JobTitle).IsRequired().HasMaxLength(150);

        }
    }
}
