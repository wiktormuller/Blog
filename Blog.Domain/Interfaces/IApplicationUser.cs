using Blog.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IApplicationUser
    {
        ApplicationUser Get(string id);
        IQueryable<ApplicationUser> GetAll();

        Task SetProfileImage(int id, Uri uri);
    }
}
