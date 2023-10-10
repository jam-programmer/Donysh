using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CompanyMapping : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("Company");
            builder.HasKey(k => k.Id);
            builder.HasQueryFilter(f => f.IsDeleted == false);
            builder.Property(p=>p.Type)
                .HasConversion(
                    c => c.ToString(),
                    e => (CompanyType)Enum.Parse(typeof(CompanyType), e))
                .IsUnicode(false);
           
        }
    }
}
