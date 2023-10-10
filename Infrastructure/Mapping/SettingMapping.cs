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
    public class SettingMapping:IEntityTypeConfiguration<SettingEntity>
    {
        public void Configure(EntityTypeBuilder<SettingEntity> builder)
        {
            builder.ToTable("Setting");
            builder.HasNoKey();
        }
    }
}
