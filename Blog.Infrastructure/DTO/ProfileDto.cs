using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Infrastructure.DTO
{
    public class ProfileDto
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; } 
        public string Email { get; set; }
        public byte[] ProfileImage { get; private set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; private set; }
    }
}
