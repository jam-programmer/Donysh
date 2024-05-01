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
    public class ResumeMapping:IEntityTypeConfiguration<ResumeEntity>
    {
        public void Configure(EntityTypeBuilder<ResumeEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasOne(o => o.Employment)
                .WithMany(m => m.Resumes)
                .HasForeignKey(f => f.EmploymentId);
        }
    }
}
