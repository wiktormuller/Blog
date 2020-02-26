using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces
{
    public interface IPost
    {
        Post Get(int id);
        IEnumerable<Post> GetAll();
        Task Add(Post post);
        Task Update(Post post);
        Task Remove(int id);
    }
}
