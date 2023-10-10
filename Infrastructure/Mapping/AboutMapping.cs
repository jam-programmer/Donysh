using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class AboutMapping : IEntityTypeConfiguration<AboutEntity>
    {
        public void Configure(EntityTypeBuilder<AboutEntity> builder)
        {
            builder.ToTable("About");
            builder.HasNoKey();
           
        }
    }
}
