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
    public class StatusMapping : IEntityTypeConfiguration<StatusEntity>
    {
        public void Configure(EntityTypeBuilder<StatusEntity> builder)
        {
            builder.ToTable("Status");
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.Property(p => p.Status).IsRequired().HasMaxLength(100);
        }
    }
}
