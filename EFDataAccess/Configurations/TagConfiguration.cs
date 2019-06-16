using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(t=> t.PostTags).WithOne(pt => pt.Tag).HasForeignKey(pt => pt.TagId).OnDelete(DeleteBehavior.Cascade);
            builder.Property(t => t.Content).HasMaxLength(15).IsRequired();
            builder.HasIndex(t => t.Content).IsUnique();
            builder.Property(t => t.IsDeleted).IsRequired().HasDefaultValue(true);
        }
    }
}
