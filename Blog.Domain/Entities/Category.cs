using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; }

        public Post Post { get; private set; }
    }
}
