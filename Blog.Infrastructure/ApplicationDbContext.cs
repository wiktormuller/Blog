using System;
using System.Collections.Generic;
using System.Text;
using Blog.Domain.Entities;
using Blog.Infrastructure.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            builder.Entity<PostCategory>().HasKey(pc => new { pc.PostId, pc.CategoryId });

            //builder.Seed();
        }

        //ENTITIES
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
    }
}
