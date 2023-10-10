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
    public class RequestMapping : IEntityTypeConfiguration<RequestEntity>
    {
        public void Configure(EntityTypeBuilder<RequestEntity> builder)
        {
            builder.ToTable("Request");
            builder.HasIndex(i => i.FirstName);
            builder.HasIndex(i => i.LastName);
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == true);
            builder.Property(p => p.Email).IsRequired()
                .HasMaxLength(150);
            builder.Property(p => p.FirstName).IsRequired()
                .HasMaxLength(150);
            builder.Property(p => p.LastName).IsRequired()
                .HasMaxLength(150);
            builder.HasMany(m => m.Service)
                .WithMany(m => m.Requests);
        }
    }
}
