using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.DTO
{
    public class ProfileDto
    {
        public int ProfileId { get; set; }
        public string Title { get; set; } 
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}
