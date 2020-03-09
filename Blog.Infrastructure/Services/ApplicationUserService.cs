using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Services
{
    class ApplicationUserService : IApplicationUser
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser Get(int id)
        {
            return _context.ApplicationUsers.FirstOrDefault(user => user.Id == id);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return _context.ApplicationUsers;
        }

        public Task SetProfileImage(int id, Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
