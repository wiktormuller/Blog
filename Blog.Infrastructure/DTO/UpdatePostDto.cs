using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.DTO
{
    public class UpdatePostDto
    {
        public int PostId { get; set; }
        public string Title { get;  set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
