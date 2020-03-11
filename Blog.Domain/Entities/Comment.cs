using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; private set; }
        public string Content { get; private set; }
        public DateTime Created { get; private set; }
        public bool IsDeleted { get; private set; }

        public ApplicationUser Author { get; private set; }
        public Post Post { get; private set; }
    }
}
