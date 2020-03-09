using Blog.Domain.Entities;
using System;

namespace Blog.Infrastructure.DTO
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
