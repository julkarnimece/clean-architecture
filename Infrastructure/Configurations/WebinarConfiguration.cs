using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    internal sealed class WebinarConfiguration : IEntityTypeConfiguration<Webinar>
    {
        public void Configure(EntityTypeBuilder<Webinar> builder)
        {
            builder.ToTable("Webinars");

            builder.HasKey(webinar => webinar.Id);

            builder.Property(webinar => webinar.Name).HasMaxLength(100);

            builder.Property(webinar => webinar.ScheduledOn).IsRequired();

        }
    }
}
