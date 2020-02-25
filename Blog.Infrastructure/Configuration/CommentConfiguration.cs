using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.Property(p => p.CommentId).IsRequired();
            entity.Property(p => p.Content).IsRequired().HasMaxLength(500);
            entity.Property(p => p.Created).IsRequired().HasColumnType("date");
            entity.Property(p => p.IsDeleted).IsRequired();
        }
    }
}
