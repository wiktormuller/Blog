using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class PostCategory
    {
        public int PostId { get; private set; }
        public Post Post { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
    }
}
