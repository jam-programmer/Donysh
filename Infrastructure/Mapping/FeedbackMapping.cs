using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class FeedbackMapping : IEntityTypeConfiguration<FeedbackEntity>
    {
        public void Configure(EntityTypeBuilder<FeedbackEntity> builder)
        {
            builder.HasKey(k => k.Id);
        }
    }
}
