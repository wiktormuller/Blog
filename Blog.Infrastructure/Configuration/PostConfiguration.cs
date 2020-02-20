using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> entity)
        {
            entity.Property(p => p.PostId).IsRequired();
            entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
            entity.Property(p => p.Content).IsRequired();
            entity.Property(p => p.Created).IsRequired().HasColumnType("date");
            entity.Property(p => p.IsActive).IsRequired();
            entity.Property(p => p.Author).IsRequired();
            entity.Property(p => p.Categories).IsRequired();
        }
    }
}
