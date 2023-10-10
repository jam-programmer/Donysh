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
    public class ServiceMapping : IEntityTypeConfiguration<ServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.ToTable("Service");
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.Property(p => p.Title).IsRequired()
                .HasMaxLength(200);
        }
    }
}
