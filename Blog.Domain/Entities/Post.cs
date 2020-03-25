using System;
using System.Collections.Generic;

namespace Blog.Domain.Entities
{
    public class Post
    {
        private Post() { }

        public int PostId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public bool IsActive { get; private set; }
        
        public ApplicationUser Author { get; private set; }
        public PostImage Image { get; private set; }
        public IEnumerable<Comment> Comments { get; private set; }

        public IEnumerable<PostCategory> PostCategories { get; private set; }
    }
}
