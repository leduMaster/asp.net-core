using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(25);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDeleted).HasDefaultValue(false) ;
            builder.HasMany(p => p.PostTags).WithOne(pt => pt.Post).HasForeignKey(pt=>pt.PostId).OnDelete(DeleteBehavior.Cascade);
            
            
        }
    }
}
