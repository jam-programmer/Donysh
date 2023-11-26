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
    public class PageMapping:IEntityTypeConfiguration<PageEntity>
    {
        public void Configure(EntityTypeBuilder<PageEntity> builder)
        {
            builder.ToTable("About");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Title).IsRequired();
            builder.Property(p => p.Location).IsRequired();
        }
    }
}
