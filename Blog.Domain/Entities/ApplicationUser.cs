using Microsoft.AspNetCore.Identity;
using System;

namespace Blog.Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public byte[] ProfileImage { get; private set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; private set; }
    }
}
