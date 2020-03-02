using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.Entities
{
    public class PostImage
    {
        public int PostId { get; set; }
        public byte[] Image { get; set; }
    }
}
