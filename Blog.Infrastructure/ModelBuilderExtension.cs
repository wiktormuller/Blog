using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder builder)
        {
            /*builder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "Reference type vs Value type",

                }
            );*/
        }
    }
}
