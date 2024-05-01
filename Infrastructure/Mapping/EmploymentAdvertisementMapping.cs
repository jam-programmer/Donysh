
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class EmploymentAdvertisementMapping:IEntityTypeConfiguration<EmploymentAdvertisementEntity>
    {
        public void Configure(EntityTypeBuilder<EmploymentAdvertisementEntity> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
