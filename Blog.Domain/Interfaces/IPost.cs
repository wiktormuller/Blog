using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IPost
    {
        Post Get(int id);
        IQueryable<Post> GetAll();
        void Add(Post post); //make it as a task
        Task Update(Post post);
        Task Remove(int id);
    }
}
