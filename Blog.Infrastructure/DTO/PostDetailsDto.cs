using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.DTO
{
    public class PostDetailsDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; private set; }

        public ApplicationUser Author { get; set; }
        public PostImage Image { get; set; }
        public ICollection<Comment> Comments { get; private set; }
        public ICollection<Category> Categories { get; private set; }
    }
}
